using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public interface IEnemy : IDynamicObject
    {
        IEnemyState GetState { get; }
        int PointValue { get; }
        int PointValueIndex { get; set; }
        void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision);
        void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision);
        void CollisionResponseWithProjectile(IPlayer mario, IProjectile projectile, CollisionDetector.CollisionType collision);
        void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision);
        void SetEnemyState(IEnemyState newEnemyState);
        void ReverseDirection();
        void KillEnemy(Vector2 otherObjectLocation);
        void StartMoving(IPlayer mario);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
