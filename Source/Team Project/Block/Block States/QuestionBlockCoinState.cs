using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class QuestionBlockCoinState : IBlockState
    {
        private IAnimatedSprite questionBlockSprite;
        private Vector2 previousMarioLocation;

        public QuestionBlockCoinState()
        {
            questionBlockSprite = SpriteFactory.CreateQuestionBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    if (previousMarioLocation.Y > (block.Location.Y + block.Rectangle.Height))
                    {
                        block.isBumping = true;
                        ItemTracker.CreateBlockCoin(block.Location);
                        block.SetBlockState(new UsedBlockState());
                        player.BlockCollision(block, collision);
                        SoundManager.StopMarioJumpSound();
                        SoundManager.PlayBlockBumpSound();
                        ArrayList lastItem = ItemTracker.GetItemList();
                        BlockCoin blockCoin = (BlockCoin)lastItem[lastItem.Count - Value.One];
                        player.ScoreCard.AddCoin();
                        player.ScoreCard.AddPoints(blockCoin.PointValue);
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

        public void GetBlock(Block block)
        {
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(block, collision);
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
