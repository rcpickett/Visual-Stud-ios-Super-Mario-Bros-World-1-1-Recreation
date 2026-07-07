using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class Mario : IPlayer
    {
        private Game1 game;

        public Scorecard ScoreCard { get; set; }
        public IPlayerState State { get; set; }

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }

        // ✅ NEW
        private bool facingRight = true;
        public bool FacingRight => facingRight;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Location.X,
                    (int)Location.Y,
                    (int)State.Sprite.TextureDimension.X,
                    (int)State.Sprite.TextureDimension.Y);
            }
        }

        public Game1 Game => game;

        public enum Power { Small, Big, Fire, Dead, Ice }

        public Mario(Vector2 pos, Game1 g)
        {
            if (g.playerChar == Game1.Characters.Bowser)
                State = new SmallBowserIdleRightState(this);
            else
                State = new SmallMarioIdleRightState(this);

            Location = pos;
            game = g;
            ScoreCard = new Scorecard();

            MarioMovement.LoadMario(this);
        }

        public void Update(GameTime gameTime)
        {
            if (MarioMovement.IsBouncing) MarioMovement.HitJump();
            if (MarioMovement.IsFalling) MarioMovement.Falling();

            MarioMovement.Update();
            State.Update(gameTime);

            Location = new Vector2(
                Location.X + (Movement.X * (float)gameTime.ElapsedGameTime.TotalSeconds),
                Location.Y + (Movement.Y * (float)gameTime.ElapsedGameTime.TotalSeconds));

            if (Location.X <= game.Camera.limits.X)
                Location = new Vector2(game.Camera.limits.X, Location.Y);

            if (Location.X >= game.Camera.limits.Width - Value.Sixteen)
                Location = new Vector2(game.Camera.limits.Width - Value.Sixteen, Location.Y);

            if (game.Camera.limits.Height <= Location.Y && GetPower() != Mario.Power.Dead)
            {
                if (game.playerChar == Game1.Characters.Bowser)
                    State = new BowserDeadLeftState(this);
                else
                    State = new MarioDeadLeftState(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            State.Draw(spriteBatch, Location, color);
        }

        public void Left()
        {
            facingRight = false; // ✅ NEW
            State.Left();
        }

        public void Right()
        {
            facingRight = true; // ✅ NEW
            State.Right();
        }

        public void Up()
        {
            State.Up();
            if (MarioMovement.IsJumping) MarioMovement.IsFalling = false;
        }

        public void Down() => State.Down();
        public void B() => State.B();
        public void NoCommand() => State.NoCommand();

        public void BlockCollision(Block block, CollisionDetector.CollisionType collision)
        {
            if (GetPower() == Power.Dead) return;

            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    IBlockState s = block.GetBlockState();

                    if (s is SnowyBlock || s is IceBlock1616State)
                        MarioMovement.OnIcyTerrain();
                    else
                        MarioMovement.OnNormalTerrain();

                    Location = new Vector2(Location.X, block.Rectangle.Y - Rectangle.Height);
                    MarioMovement.Grounded();
                    break;

                case CollisionDetector.CollisionType.bottom:
                    Location = new Vector2(Location.X, block.Rectangle.Y + block.Rectangle.Height);
                    MarioMovement.IsJumping = false;
                    MarioMovement.IsFalling = true;
                    break;

                case CollisionDetector.CollisionType.left:
                    Location = new Vector2(block.Rectangle.X - Rectangle.Width, Location.Y);
                    if (!MarioMovement.IsFalling)
                        Movement = new Vector2(Speed.Zero, Movement.Y);
                    break;

                case CollisionDetector.CollisionType.right:
                    Location = new Vector2(block.Rectangle.X + block.Rectangle.Width, Location.Y);
                    if (!MarioMovement.IsFalling)
                        Movement = new Vector2(Speed.Zero, Movement.Y);
                    break;
            }
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision,
            Vector2 marioLocation, Vector2 camLocation)
        {
            State.PipeCollision(pipe, collision, marioLocation, camLocation);
        }

        public void GetHit()
        {
            MarioMovement.IsJumping = false;
            State.GetHit();
        }

        public void CollectItem(IItem item)
        {
            State.CollectItem(item);
        }

        public Power GetPower() => State.GetPower();

        public void Die()
        {
            if (GetPower() == Power.Dead) return;

            State = new MarioDeadLeftState(this);
            game.Level.PauseGameTime = true;
        }

        public void PoleSequence()
        {
            MarioMovement.IsFalling = false;
            Movement = Vector2.Zero;
            State.PoleSequence();
        }

        public void EndAnimation()
        {
            State.EndAnimation();
        }
    }
}