using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IProjectile : IDynamicObject
    { 
        void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision);

        void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision);

        void Update(Game1 game, GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
