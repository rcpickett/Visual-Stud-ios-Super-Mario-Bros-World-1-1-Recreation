using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class ComingOutOfBlockState : IItemState
    {
        private IItem item;
        private Block blockThatWasHoldingItem;

        public ComingOutOfBlockState(IItem i, Block b)
        {
            item = i;
            blockThatWasHoldingItem = b;
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision){ }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            if (staticObject == blockThatWasHoldingItem && collision == CollisionDetector.CollisionType.none)
            {
                if (item is Starman)
                {
                    item.State = new OutOfBlockStarmanState(item);
                }
                else if (item is SuperMushroom || item is OneUpMushroom)
                {
                    item.State = new OutOfBlockMushroomState(item);
                }
                else
                {
                    item.State = new OutOfBlockStaticState(item);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            item.Location = new Vector2(item.Location.X, item.Location.Y - Value.One);
        }
    }
}
