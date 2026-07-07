using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public interface IAnimatedSprite
    {
        // Properties
        Vector2 TextureDimension { get; } 

        // Methods
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
    }
}