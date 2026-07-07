using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class OutOfBlockStarmanState : IItemState
    {
        private IItem item;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.Eight);

        public OutOfBlockStarmanState(IItem i)
        {
            item = i;
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                item.Location = new Vector2(Value.NegativeOneThousand, Value.NegativeOneThousand);
                mario.CollectItem(item);
                mario.ScoreCard.AddPoints(item.PointValue);
            }
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    item.Location = new Vector2(item.Location.X, staticObject.Rectangle.Y - item.Rectangle.Height);
                    if (staticObject is Block)
                    {
                        Block block = (Block)staticObject;
                        if (block.isBumping)
                        {
                            item.Movement = new Vector2(item.Movement.X * Speed.NegativeOne, Speed.NegativeThreeAndOneFifth);
                        }
                        else
                        {
                            item.Movement = new Vector2(item.Movement.X, Speed.NegativeThreeAndOneFifth);
                        }
                    }
                    item.Movement = new Vector2(item.Movement.X, Speed.NegativeThreeAndOneFifth);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            float y = item.Movement.Y;
            y += accel.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (y > Speed.OnePointNine)
            {
                y = Speed.OnePointNine;
            }
            item.Movement = new Vector2(item.Movement.X, y);
            item.Location += item.Movement;
        }
    }
}
