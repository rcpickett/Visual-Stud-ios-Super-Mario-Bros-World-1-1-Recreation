using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class UndergroundBrickBlockState : IBlockState
    {
        private IAnimatedSprite undergroundBrickBlockSprite;
        private Vector2 previousMarioLocation;

        public UndergroundBrickBlockState(){
            undergroundBrickBlockSprite = SpriteFactory.CreateUndergroundBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            Mario.Power power = player.GetPower();
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    block.isBumping = false;
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    if (previousMarioLocation.Y > (block.Location.Y + block.Rectangle.Height))
                    {
                        block.isBumping = true;
                        SoundManager.StopMarioJumpSound();
                        if (power != Mario.Power.Small)
                        {
                            block.SetBlockState(new BrickBlockDestroyedState());
                            SoundManager.PlayBlockBreakSound();
                        }
                        else
                        {
                            SoundManager.PlayBlockBumpSound();
                        }
                        player.BlockCollision(block, collision);
                    }
                    break;
                case CollisionDetector.CollisionType.left:
                    block.isBumping = false;
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.right:
                    block.isBumping = false;
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.none:
                    block.isBumping = false;
                    break;
            }
            previousMarioLocation = player.Location;
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
            undergroundBrickBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            undergroundBrickBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
