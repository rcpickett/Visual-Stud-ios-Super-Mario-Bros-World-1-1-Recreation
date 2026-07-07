using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class Piranha : IEnemy
    {
        private IAnimatedSprite piranhaSprite;
        private Vector2 originalLocation;
        private float timerToKeepPosition;
        private int[] pointValue = { Value.TwoHundred, Value.FourHundred, Value.FiveHundred, Value.EightHundred, Value.OneThousand, Value.TwoThousand, Value.FourThousand, Value.FiveThousand, Value.EightThousand, Value.EightThousand };
        private int pointValueIndex = Value.Zero;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public int PointValueIndex { get; set; }
        public int PointValue { get { return pointValue[pointValueIndex]; } }

        public IEnemyState GetState
        {
            get { return null; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)piranhaSprite.TextureDimension.X, (int)piranhaSprite.TextureDimension.Y); }
        }

        public Piranha(Vector2 location)
        {
            Location = location;
            originalLocation = location;
            piranhaSprite = SpriteFactory.CreatePiranhaSprite();
            Movement = new Vector2(Speed.Zero, Speed.NegativeOne);
            timerToKeepPosition = Value.Zero;
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision){ }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            if (enemy.GetState is KoopaShellState)
            {
                if (enemy.Movement.X != Speed.Zero && collision != CollisionDetector.CollisionType.none)
                {
                    KillEnemy(enemy.Location);
                    mario.ScoreCard.AddPoints(pointValue[pointValueIndex]);
                    SoundManager.PlayEnemyKickSound();
                }
            }
        }

        public void CollisionResponseWithProjectile(IPlayer mario, IProjectile projectile, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                KillEnemy(projectile.Location);
                mario.ScoreCard.AddPoints(pointValue[pointValueIndex]);
                SoundManager.PlayEnemyKickSound();
            }
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none && mario.GetPower() != Mario.Power.Dead)
            {
                mario.GetHit();
                if (mario is StarMario || mario.Game.playerChar == Game1.Characters.Bowser)
                {
                    KillEnemy(mario.Location);
                    SoundManager.PlayEnemyKickSound();
                    mario.ScoreCard.AddPoints(pointValue[pointValueIndex]);
                }
            }
        }

        public void SetEnemyState(IEnemyState newEnemyState){ }

        public void ReverseDirection() { }

        public void KillEnemy(Vector2 otherObjectLocation)
        {
            SoundManager.PlayEnemyKickSound();
            Location = new Vector2(Value.NegativeOneThousand, Value.NegativeOneThousand);
        }

        public void StartMoving(IPlayer mario)
        {
            float nearPiranha = Location.X - mario.Location.X;
            if (Math.Abs(nearPiranha) <= mario.Rectangle.Width+8 && Location == originalLocation)
            {
                timerToKeepPosition = Value.Zero;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (timerToKeepPosition > Value.TwoThousand)
            {
                Movement = new Vector2(Movement.X, Movement.Y * Speed.NegativeOne);
                timerToKeepPosition = Value.Zero;
            }
            Location += Movement;
            if (Location.Y < originalLocation.Y - Rectangle.Height)
            {
                Location = new Vector2(Location.X, originalLocation.Y - Rectangle.Height);
                timerToKeepPosition += gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (Location.Y >= originalLocation.Y)
            {
                Location = new Vector2(Location.X, originalLocation.Y);
                timerToKeepPosition += gameTime.ElapsedGameTime.Milliseconds;
            }
            piranhaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            piranhaSprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}