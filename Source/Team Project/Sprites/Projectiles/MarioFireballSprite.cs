using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class MarioFireballSprite : IAnimatedSprite 
    {
        private Texture2D texture;
        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Four;
        private float elapsedTime = Value.Zero;
        private float delayTime = Value.Fifty;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public MarioFireballSprite(Texture2D t)
        {
            texture = t;
            textureDimensions = new Vector2(texture.Width / totalFrames, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= delayTime)
            {
                elapsedTime = Value.Zero;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = Value.Zero;
                }
            }
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

