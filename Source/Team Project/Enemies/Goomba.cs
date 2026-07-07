using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class Goomba : IEnemy
    {
        private IEnemyState goombaState;
        private Boolean startMoving;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.Eight);
        private int[] pointValue = { Value.OneHundred, Value.TwoHundred, Value.FourHundred, Value.FiveHundred, Value.EightHundred, Value.OneThousand, Value.TwoThousand, Value.FourThousand, Value.FiveThousand, Value.EightThousand };
        private int pointValueIndex = Value.Zero;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public int PointValueIndex { get { return pointValueIndex; }
                                     set { pointValueIndex = value; } }
        public int PointValue { get { return pointValue[pointValueIndex]; } }

        public IEnemyState GetState
        {
            get { return goombaState; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)goombaState.SpriteDimensions.X, (int)goombaState.SpriteDimensions.Y); }
        }

        public Goomba(Vector2 location)
        {
            Location = location;
            goombaState = new GoombaMovingState();
            Movement = new Vector2(Speed.Zero, Speed.Zero);
            startMoving = false;
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            goombaState.CollisionResponseWithStaticObject(this, staticObject, collision);
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            goombaState.CollisionResponseWithEnemy(mario, this, enemy, collision);
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (mario.GetPower() != Mario.Power.Dead)
            {
                goombaState.CollisionResponseWithPlayer(this, mario, collision);
            }
        }

        public void CollisionResponseWithProjectile(IPlayer mario, IProjectile projectile, CollisionDetector.CollisionType collision)
        {
            goombaState.CollisionResponseWithProjectile(mario, this, projectile, collision);
        }

        public void SetEnemyState(IEnemyState newEnemyState)
        {
            goombaState = newEnemyState;
        }

        public void ReverseDirection() 
        {
            goombaState.ReverseDirection(this);
        }

        public void KillEnemy(Vector2 otherObjectLocation)
        {
            if (GetState is GoombaKilledState) { }
            else
            {
                SetEnemyState(new GoombaKilledState());
                SoundManager.PlayEnemyKickSound();

                if (otherObjectLocation.X <= Location.X)
                {
                    Movement = new Vector2(Speed.OneHalf, Speed.NegativeThree);
                }
                else
                {
                    Movement = new Vector2(Speed.NegativeOneHalf, Speed.NegativeThree);
                }
            }
        }

        public void StartMoving(IPlayer mario)
        {
            if (Location.X - mario.Location.X < Speed.OneHundredThirty && !startMoving)
            {
                Movement = new Vector2(Speed.NegativeOneHalf, Speed.Zero);
                startMoving = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            float y = Movement.Y;
            y += accel.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (y > Speed.OnePointEightFive)
            {
                y = Speed.OnePointEightFive;
            }
            Movement = new Vector2(Movement.X, y);
            Location += Movement;
            goombaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaState.Draw(spriteBatch, Location);
        }
    }
}
