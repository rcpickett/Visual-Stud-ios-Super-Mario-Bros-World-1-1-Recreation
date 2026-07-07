using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class BrickBlockStarmanState : IBlockState
    {
        private IAnimatedSprite brickBlockSprite;
        private Vector2 previousMarioLocation;
        private Vector2 bounceVector;
        private int bounceOffset;

        public BrickBlockStarmanState()
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
                        block.SetBlockState(new UsedBlockState());
                        player.BlockCollision(block, collision);
                        BounceBlock();
                        ItemTracker.CreateStarman(block.Location, block);
                        SoundManager.StopMarioJumpSound();
                        SoundManager.PlayBlockBumpSound();
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

        public void BounceBlock()
        {
            bounceOffset = Value.One;
            bounceVector = new Vector2(Value.Zero, Value.NegativeSix);
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
            if (bounceOffset != Value.Zero)
                bounceOffset++;
            if (bounceOffset == Value.Twelve)
            {
                bounceVector = new Vector2(Value.Zero, Value.Zero);
                bounceOffset = Value.Zero;
            }
            brickBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            brickBlockSprite.Draw(spriteBatch, new Vector2(location.X + bounceVector.X, location.Y + bounceVector.Y), Color.White);
        }
    }
}
