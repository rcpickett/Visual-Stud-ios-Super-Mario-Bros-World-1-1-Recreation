using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class HiddenBlockState : IBlockState
    {
        private IAnimatedSprite hiddenBlockSprite;
        private Vector2 previousMarioLocation;

        public HiddenBlockState()
        {
            hiddenBlockSprite = SpriteFactory.CreateHiddenBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    break;
                case CollisionDetector.CollisionType.bottom:
                    if (previousMarioLocation.Y > (block.Location.Y + block.Rectangle.Height))
                    {
                        block.isBumping = true;
                        player.BlockCollision(block, collision);
                        ItemTracker.Create1UpMushroom(block.Location, block);
                        block.SetBlockState(new UsedBlockState());
                        SoundManager.StopMarioJumpSound();
                        SoundManager.PlayBlockBumpSound();
                    }
                    break;
                case CollisionDetector.CollisionType.left:
                    break;
                case CollisionDetector.CollisionType.right:
                    break;
                case CollisionDetector.CollisionType.none:
                    break;
            }
            previousMarioLocation = player.Location;   
        }

        public void GetBlock(Block block)
        {
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
        }

        public void Update(GameTime gameTime)
        {
            hiddenBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            hiddenBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
