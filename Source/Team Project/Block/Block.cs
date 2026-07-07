using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class Block : IStaticObject
    {
        private IBlockState blockState;
        private int pointValue = Value.Fifty;
        private int bounceOffset;

        public Boolean isBumping { get; set; }
        public Vector2 Location{ get; set; }
        public int PointValue { get { return pointValue; } }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, Value.Sixteen, Value.Sixteen); }
        }

        public Block(Vector2 location, IBlockState initBlockState)
        {
            Location = location;
            blockState = initBlockState;
            isBumping = false;
            bounceOffset = Value.One;
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (mario.GetPower() != Mario.Power.Dead)
            {
                blockState.CollisionResponseWithPlayer(this, mario, collision);
            }
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            if (collision == CollisionDetector.CollisionType.top && isBumping)            
            {
                enemy.KillEnemy(Location);
                mario.ScoreCard.AddPoints(enemy.PointValue);
            }
            blockState.CollisionResponseWithEnemy(this, enemy, collision);
        }

        public void SetBlockState(IBlockState newBlockState)
        {
            blockState = newBlockState;
        }

        public IBlockState GetBlockState()
        {
            return blockState;
        }

        public void GetBlock()
        {
            blockState.GetBlock(this);
        }

        public void Update(GameTime gameTime)
        {
            if (blockState is UsedBlockState || ((blockState is BrickBlockEmptyState || blockState is SnowyBlock) && isBumping == true) || ((blockState is BrickBlockCoinState || blockState is SnowyBlock) && isBumping == true))
            {
                if (bounceOffset >= Value.One && bounceOffset < Value.Seven) 
                {
                    Location = new Vector2(Location.X, Location.Y - Value.SixTenth);
                    bounceOffset++;
                }
                else if (bounceOffset >= Value.Seven && bounceOffset < Value.Thirteen)
                {
                    Location = new Vector2(Location.X, Location.Y + Value.SixTenth);
                    bounceOffset++;
                }
                else if (bounceOffset >= Value.Thirteen)
                {
                    isBumping = false;
                    if (blockState is UsedBlockState)
                        bounceOffset = Value.Zero;
                    else if (blockState is BrickBlockCoinState || blockState is BrickBlockEmptyState)
                        bounceOffset = Value.One;
                }
            }
            blockState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockState.Draw(spriteBatch, Location);
        }
    }
}
