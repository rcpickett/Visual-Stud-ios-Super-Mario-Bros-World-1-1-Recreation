using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IItemState
    {
        void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision);

        void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision);

        void Update(GameTime gameTime);
    }
}
