using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class SuperMushroomSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private int width = Value.Sixteen;
        private int height = Value.Sixteen;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public SuperMushroomSprite(Texture2D Texture)
        {
            texture = Texture;
            textureDimensions = new Vector2(width, height);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 Location, Color color)
        {

            Rectangle sourceRectangle = new Rectangle(Value.Zero, Value.Zero, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
