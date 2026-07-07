using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class OutOfBlockStaticState : IItemState
    {
        private IItem item;

        public OutOfBlockStaticState(IItem i)
        {
            item = i;
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                mario.CollectItem(item);
                if (item is FloatingCoin)
                {
                    SoundManager.PlayCoinSound();
                    mario.ScoreCard.AddCoin();
                }
                mario.ScoreCard.AddPoints(item.PointValue);
                item.Location = new Vector2(Value.NegativeOneThousand, Value.NegativeOneThousand);
            }
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
