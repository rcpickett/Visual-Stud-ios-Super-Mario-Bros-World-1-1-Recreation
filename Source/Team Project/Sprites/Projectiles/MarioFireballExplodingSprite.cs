using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class MarioFireballExplodingSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Two;
        private float elapsedTime = Value.Zero;
        private Vector2 textureDimensions;

        public float DelayTime { get; set; }

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public MarioFireballExplodingSprite(Texture2D t)
        {
            texture = t;
            textureDimensions = new Vector2(texture.Width / totalFrames, texture.Height);
            DelayTime = Value.Fifty;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= DelayTime)
            {
                elapsedTime = Value.Zero;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = Value.Zero;
                }
            }

            DelayTime = Value.Fifty;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int width = texture.Width / totalFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, Value.Zero, width, texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, texture.Height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
