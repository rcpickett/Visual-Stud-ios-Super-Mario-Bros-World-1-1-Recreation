using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class StaticObject : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public StaticObject(Texture2D Texture)
        {
            texture = Texture;
            textureDimensions = new Vector2(texture.Width , texture.Height);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 Location, Color color)
        {
            int width = texture.Width;
            int height = texture.Height;

            Rectangle sourceRectangle = new Rectangle(Value.Zero, Value.Zero, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}