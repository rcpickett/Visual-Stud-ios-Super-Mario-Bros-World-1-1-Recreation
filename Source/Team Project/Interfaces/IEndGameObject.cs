using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    interface IEndGameObject : IStaticObject
    {
        Boolean Wins { get; set; }

        void EndGameCollisionResponse(IPlayer mario, CollisionDetector.CollisionType collision);

        void Draw(SpriteBatch spriteBatch);
    }
}
