using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class QuestionBlockMushIceFlowerState : IBlockState
    {
        private IAnimatedSprite questionBlockSprite;
        private Vector2 previousMarioLocation;

        public QuestionBlockMushIceFlowerState()
        {
            questionBlockSprite = SpriteFactory.CreateQuestionBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            Mario.Power power = player.GetPower();
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    if (previousMarioLocation.Y > (block.Location.Y + block.Rectangle.Height))
                    {
                        block.isBumping = true;
                        if (power == Mario.Power.Small)
                        {
                            ItemTracker.CreateSuperMushroom(block.Location, block);
                        }
                        else if (power == Mario.Power.Big || power == Mario.Power.Fire || power == Mario.Power.Ice)
                        {
                            ItemTracker.CreateIceFlower(block.Location, block);
                        }
                        block.SetBlockState(new UsedBlockState());
                        player.BlockCollision(block, collision);
                        SoundManager.StopMarioJumpSound();
                        SoundManager.PlayBlockBumpSound();
                    }
                    break;
                case CollisionDetector.CollisionType.left:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.right:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.none:
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
            questionBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            questionBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
