using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class UsedBlockState : IBlockState
    {
        private IAnimatedSprite usedBlockSprite;
        private Vector2 previousMarioLocation;

        public UsedBlockState()
        {
            usedBlockSprite = SpriteFactory.CreateUsedBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer mario, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    mario.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    if (previousMarioLocation.Y > (block.Location.Y + block.Rectangle.Height))
                    {
                        SoundManager.StopMarioJumpSound();
                        SoundManager.PlayBlockBumpSound();
                        mario.BlockCollision(block, collision);
                    }
                    break;
                case CollisionDetector.CollisionType.left:
                    mario.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.right:
                    mario.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.none:
                    break;
            }
            previousMarioLocation = mario.Location;
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(block, collision);
        }

        public void GetBlock(Block block)
        {
        }

        public void Update(GameTime gameTime)
        {

            usedBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            usedBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
