using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class PoweringDownRightMario : IPlayer
    {
        private Mario mario;
        private IPlayerState marioState;

        private int state = 0;
        private int switchColor = 0;

        private float delayTimeS = 85;
        private float delayTimeF = 25;

        private float elapsedTimeS = 0;
        private float elapsedTimeF = 0;

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
        // REQUIRED BY IPLAYER (CAMERA + SYSTEMS)
        // ----------------------------------------------------
        public bool FacingRight => mario.FacingRight;

        public PoweringDownRightMario(Mario m)
        {
            mario = m;
            marioState = mario.State;

            mario.State = new BigMarioJumpingRightState(mario);

            SoundManager.PlayMarioPipeOrPowerDownSound();
        }

        public void Update(GameTime gameTime)
        {
            elapsedTimeS += gameTime.ElapsedGameTime.Milliseconds;
            elapsedTimeF += gameTime.ElapsedGameTime.Milliseconds;

            if (elapsedTimeS >= delayTimeS)
            {
                elapsedTimeS = 0;
                state++;

                switch (state % 3)
                {
                    case 0:
                        mario.State = new BigMarioJumpingRightState(mario);
                        mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 17);
                        break;

                    case 1:
                        mario.State = new BigMarioSwimIdleRightState(mario);
                        mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 3);
                        break;

                    case 2:
                        mario.State = new SmallMarioSwimIdleRightState(mario);
                        mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 14);
                        break;
                }
            }

            if (elapsedTimeF >= delayTimeF)
            {
                elapsedTimeF = 0;
                switchColor++;
            }

            if (state == 8)
            {
                mario.State = marioState;
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 1);
                mario.Game.currentPlayer = new InvincibilityFramesMario(mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color c)
        {
            if (switchColor % 2 == 0)
            {
                mario.Draw(spriteBatch, new Color(255, 255, 255, 128));
            }
        }

        public void Left() { }
        public void Right() { }
        public void Up() { }
        public void Down() { }
        public void B() { }
        public void NoCommand() { }

        public void BlockCollision(Block block, CollisionDetector.CollisionType collision) { }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision,
            Vector2 newMarioLocation, Vector2 camLocation)
        { }

        public void GetHit() { }

        public void PoleSequence() { }

        public void EndAnimation() { }

        public void CollectItem(IItem item) { }

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