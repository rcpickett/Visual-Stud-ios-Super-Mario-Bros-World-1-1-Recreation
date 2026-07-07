using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class BrickBlockCoinState : IBlockState
    {
        private IAnimatedSprite brickBlockSprite;
        private Vector2 previousMarioLocation;
        private float timer = Value.Zero;
        private float timeBeforeUsed = Value.Five;
        private int coinCounter = Value.Zero;
        private int coinsInBlock = Value.Ten;
        private bool hasBeenBumped = false;

        public BrickBlockCoinState()
        {
            brickBlockSprite = SpriteFactory.CreateBrickBlock();
        }


        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
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
                        hasBeenBumped = true;
                        SoundManager.StopMarioJumpSound();
                        if ((coinCounter == coinsInBlock) || (timer >= timeBeforeUsed))
                        {
                            block.SetBlockState(new UsedBlockState());
                        }
                        player.BlockCollision(block, collision);
                        ItemTracker.CreateBlockCoin(block.Location);
                        coinCounter++;
                        SoundManager.PlayBlockBumpSound();
                        ArrayList lastItem = ItemTracker.GetItemList();
                        BlockCoin blockCoin = (BlockCoin)lastItem[lastItem.Count - Value.One];
                        player.ScoreCard.AddCoin();
                        player.ScoreCard.AddPoints(blockCoin.PointValue);
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
            if (hasBeenBumped)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            brickBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            brickBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
