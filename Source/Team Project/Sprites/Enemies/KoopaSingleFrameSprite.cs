using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class KoopaSingleFrameSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public KoopaSingleFrameSprite(Texture2D texture)
        {
            this.texture = texture;
            textureDimensions = new Vector2(texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle = new Rectangle(Value.Zero, Value.Zero, (int)textureDimensions.X, (int)textureDimensions.Y);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)textureDimensions.X, (int)textureDimensions.Y);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
