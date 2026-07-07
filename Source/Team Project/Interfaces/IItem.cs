using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IItem : IDynamicObject
    {
        IItemState State { get; set; }
        int PointValue { get; }

        void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision);

        void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
