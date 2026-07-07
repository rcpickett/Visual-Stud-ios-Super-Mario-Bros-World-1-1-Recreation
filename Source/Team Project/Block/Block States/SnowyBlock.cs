using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class SnowyBlock : IBlockState
    {
        private IBlockState blockState;
        private IAnimatedSprite snow;

        public SnowyBlock(IBlockState state)
        {
            blockState = state;
            snow = SpriteFactory.CreateSnowOnBlockSprite();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer mario, CollisionDetector.CollisionType collision)
        {
            blockState.CollisionResponseWithPlayer(block, mario, collision);
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            blockState.CollisionResponseWithEnemy(block, enemy, collision);
        }

        public void GetBlock(Block block)
        {
        }

        public void Update(GameTime gameTime)
        {
            blockState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            blockState.Draw(spriteBatch, location);
            snow.Draw(spriteBatch, location, Color.White);
        }
    }
}
