using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class Koopa : IEnemy
    {
        private IEnemyState koopaState;
        private Boolean startMoving;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.Eight);
        private int[] pointValue = { Value.OneHundred, Value.TwoHundred, Value.FourHundred, Value.FiveHundred, Value.EightHundred, Value.OneThousand, Value.TwoThousand, Value.FourThousand, Value.FiveThousand, Value.EightThousand };
        private int pointValueIndex = Value.Zero;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public int PointValueIndex { get; set; }
        public int PointValue { get { return pointValue[pointValueIndex]; } }

        public IEnemyState GetState
        {
            get { return koopaState; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)koopaState.SpriteDimensions.X, (int)koopaState.SpriteDimensions.Y); }
        }

        public Koopa(Vector2 location)
        {
            Location = location;
            koopaState = new KoopaMovingLeftState();
            Movement = new Vector2(Speed.Zero, Speed.Zero);
            startMoving = false;
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            koopaState.CollisionResponseWithStaticObject(this, staticObject, collision);
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            koopaState.CollisionResponseWithEnemy(mario, this, enemy, collision);
        }

        public void CollisionResponseWithProjectile(IPlayer mario, IProjectile projectile, CollisionDetector.CollisionType collision)
        {
            koopaState.CollisionResponseWithProjectile(mario, this, projectile, collision);
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (mario.GetPower() != Mario.Power.Dead)
            {
                koopaState.CollisionResponseWithPlayer(this, mario, collision);
            }
        }

        public void SetEnemyState(IEnemyState newEnemyState)
        {
            koopaState = newEnemyState;
        }

        public void ReverseDirection()
        {
            koopaState.ReverseDirection(this);
        }

        public void KillEnemy(Vector2 otherObjectLocation)
        {
            if (GetState is KoopaKilledState) { }
            else
            {
                SoundManager.PlayEnemyKickSound();
                SetEnemyState(new KoopaKilledState());
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
            koopaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaState.Draw(spriteBatch, Location);
        }


    }
}
