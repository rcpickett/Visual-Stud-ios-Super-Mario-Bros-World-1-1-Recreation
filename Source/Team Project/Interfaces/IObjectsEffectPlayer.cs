using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public interface IObjectsEffectPlayer : IDynamicObject
    {
        void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
