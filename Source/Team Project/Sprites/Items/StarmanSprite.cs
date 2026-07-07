using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class StarmanSprite : IAnimatedSprite
    {
        private int width = Value.Sixteen;
        private int height = Value.Sixteen;
        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Four;
        private float elapsedTime = Value.Zero;
        private float delayTime = Value.OneHundredFifty;
        private Texture2D texture;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public StarmanSprite(Texture2D Texture)
        {
            texture = Texture;
            textureDimensions = new Vector2(width, height);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 Location, Color color)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, Value.Zero, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
