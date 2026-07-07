using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class BrickBlockEmptyState : IBlockState
    {
        private IAnimatedSprite brickBlockSprite;
        private Vector2 previousMarioLocation;

        public BrickBlockEmptyState()
        {
            brickBlockSprite = SpriteFactory.CreateBrickBlock();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            Mario.Power power = player.GetPower();

            if (player.Game.playerChar == Game1.Characters.Bowser)
                if (power == Mario.Power.Fire&&collision!=CollisionDetector.CollisionType.none)
                {
                    block.SetBlockState(new BrickBlockDestroyedState());
                    SoundManager.PlayBlockBreakSound();
                    player.ScoreCard.AddPoints(block.PointValue);
                }
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
                            player.ScoreCard.AddPoints(block.PointValue);
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
            brickBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            brickBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
