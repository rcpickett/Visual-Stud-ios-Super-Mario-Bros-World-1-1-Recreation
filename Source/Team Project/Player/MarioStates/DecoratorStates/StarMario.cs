using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class StarMario : IPlayer
    {
        private Mario mario;

        private Color color;
        private int colorCounter;

        private float timer = 0;
        private float elapsedTime = 0;

        private float delayTime = 75;
        private float slowTime = 7000;
        private float totalTime = 10000;

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

        public Game1 Game => mario.Game;

        public Scorecard ScoreCard
        {
            get => mario.ScoreCard;
            set => mario.ScoreCard = value;
        }

        // ----------------------------------------------------
        // REQUIRED BY UPDATED IPLAYER (CAMERA SUPPORT)
        // ----------------------------------------------------
        public bool FacingRight => mario.FacingRight;

        public StarMario(Mario m)
        {
            mario = m;

            color = Color.Purple;
            colorCounter = 0;
        }

        public void Update(GameTime gameTime)
        {
            float eT = gameTime.ElapsedGameTime.Milliseconds;

            elapsedTime += eT;
            timer += eT;

            if (timer >= slowTime && timer < totalTime)
            {
                if (elapsedTime >= delayTime * 2)
                {
                    elapsedTime = 0;
                    colorCounter++;
                }
            }
            else if (timer < slowTime)
            {
                if (elapsedTime >= delayTime)
                {
                    elapsedTime = 0;
                    colorCounter++;
                }
            }
            else
            {
                mario.Game.currentPlayer = mario;
            }

            UpdateColor();
            mario.Update(gameTime);
        }

        private void UpdateColor()
        {
            switch (colorCounter % 5)
            {
                case 0: color = Color.Purple; break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Green; break;
                case 3: color = Color.Yellow; break;
                case 4: color = Color.Red; break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color c)
        {
            mario.Draw(spriteBatch, color);
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

        public void GetHit()
        {
            // intentionally ignored during star state
        }

        public void CollectItem(IItem item)
        {
            mario.CollectItem(item);
        }

        public Mario.Power GetPower()
        {
            return mario.GetPower();
        }

        public void PoleSequence()
        {
            mario.PoleSequence();
        }

        public void EndAnimation()
        {
            mario.EndAnimation();
        }

        public void Die()
        {
            mario.Game.currentPlayer = mario;
            mario.Die();
        }
    }
}