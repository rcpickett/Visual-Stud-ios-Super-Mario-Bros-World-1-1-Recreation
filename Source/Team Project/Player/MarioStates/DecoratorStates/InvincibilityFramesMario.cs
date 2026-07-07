using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class InvincibilityFramesMario : IPlayer
    {
        private Mario mario;

        private int switchColor = 0;
        private float timer = 0;
        private float elapsedTime = 0;

        private float delayTime = 25;
        private float totalTime = 2000;

        public IPlayerState State
        {
            get => mario.State;
            set => mario.State = value;
        }

        public Vector2 Location
        {
            get => mario.Location;
            set => mario.Location = value;
        }

        public Vector2 Movement
        {
            get => mario.Movement;
            set => mario.Movement = value;
        }

        public Rectangle Rectangle => mario.Rectangle;

        public Scorecard ScoreCard
        {
            get => mario.ScoreCard;
            set => mario.ScoreCard = value;
        }

        public Game1 Game => mario.Game;

        // ----------------------------------------------------
        // REQUIRED BY IPLAYER (CAMERA FIX)
        // ----------------------------------------------------
        public bool FacingRight => mario.FacingRight;

        public InvincibilityFramesMario(Mario m)
        {
            mario = m;
        }

        public void Update(GameTime gameTime)
        {
            float eT = gameTime.ElapsedGameTime.Milliseconds;

            elapsedTime += eT;
            timer += eT;

            if (timer < totalTime)
            {
                if (elapsedTime >= delayTime)
                {
                    elapsedTime = 0;
                    switchColor++;
                }
            }
            else
            {
                mario.Game.currentPlayer = mario;
            }

            mario.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color c)
        {
            if (switchColor % 2 == 0)
            {
                mario.Draw(spriteBatch, new Color(255, 255, 255, 128));
            }
        }

        public void Left() => mario.Left();
        public void Right() => mario.Right();
        public void Up() => mario.Up();
        public void Down() => mario.Down();
        public void B() => mario.B();
        public void NoCommand() => mario.NoCommand();

        public void BlockCollision(Block block, CollisionDetector.CollisionType collision)
        {
            mario.BlockCollision(block, collision);
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision,
            Vector2 newMarioLocation, Vector2 camLocation)
        {
            mario.PipeCollision(pipe, collision, newMarioLocation, camLocation);
        }

        public void GetHit() { }
        public void PoleSequence() { }
        public void EndAnimation() { }

        public void CollectItem(IItem item)
        {
            mario.CollectItem(item);
        }

        public Mario.Power GetPower()
        {
            return mario.GetPower();
        }

        public void Die()
        {
            mario.Game.currentPlayer = mario;
            mario.Die();
        }
    }
}