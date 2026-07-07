using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public interface IBlockState
    {
        void CollisionResponseWithPlayer(Block block, IPlayer mario, CollisionDetector.CollisionType collision);

        void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision);

        void GetBlock(Block block);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
