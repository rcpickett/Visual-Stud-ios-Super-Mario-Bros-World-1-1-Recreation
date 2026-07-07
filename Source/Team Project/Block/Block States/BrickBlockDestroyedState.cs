using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class BrickBlockDestroyedState : IBlockState
    {
        private IAnimatedSprite destroyedBlockSprite;

        public BrickBlockDestroyedState(){
            destroyedBlockSprite = SpriteFactory.CreateExplodingBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            block.isBumping = false;
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
        }

        public void GetBlock(Block block)
        {
        }

        public void Update(GameTime gameTime)
        {
            destroyedBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destroyedBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
    
    
}
