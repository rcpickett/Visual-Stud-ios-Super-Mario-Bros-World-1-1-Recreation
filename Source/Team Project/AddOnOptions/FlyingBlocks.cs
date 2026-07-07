using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class FlyingBlocks : IBlockState
    {
        private IAnimatedSprite sprite;
        private Vector2 previousMarioLocation;

        private Vector2 Movement;
        private Block blk;

        public FlyingBlocks()
        {
            sprite = SpriteFactory.CreateBrickBlock();
            Movement = new Vector2(-Speed.One, Speed.Zero);
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            Mario.Power power = player.GetPower();

            if (player.Game.playerChar == Game1.Characters.Bowser)
                if (power == Mario.Power.Fire && collision != CollisionDetector.CollisionType.none)
                {
                    block.SetBlockState(new BrickBlockDestroyedState());
                    SoundManager.PlayBlockBreakSound();
                    player.ScoreCard.AddPoints(block.PointValue);
                }
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    player.BlockCollision(block, collision);
                    player.Location += new Vector2(-Speed.Two, Speed.Zero);
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
        }

        public void GetBlock(Block b)
        {
            blk = b;
        }

        public void Update(GameTime gameTime)
        {
            blk.Location += Movement;
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 loc)
        {
            sprite.Draw(spriteBatch, loc, Color.White);
        }
    }
}
