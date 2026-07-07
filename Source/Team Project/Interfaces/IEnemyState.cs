using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IEnemyState
    {
        Vector2 SpriteDimensions { get; }

        void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision);

        void CollisionResponseWithEnemy(IPlayer mairo, IEnemy enemy, IEnemy secondEnemy, CollisionDetector.CollisionType collision);

        void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision);

        void CollisionResponseWithPlayer(IEnemy enemy, IPlayer mario, CollisionDetector.CollisionType collision);

        void ReverseDirection(IEnemy enemy);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
