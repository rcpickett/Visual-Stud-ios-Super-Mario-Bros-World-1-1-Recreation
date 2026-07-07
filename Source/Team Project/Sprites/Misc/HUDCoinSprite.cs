using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class HUDCoinSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimension;
        private int width = Value.Five;
        private int height = Value.Seven;
        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Three;
        private float elapsedTime = Value.Zero;
        private float delayTime = Value.OneHundredFifty;

        public Vector2 TextureDimension { get { return textureDimension; } }

        public HUDCoinSprite(Texture2D Texture)
        {
            texture = Texture;
            textureDimension = new Vector2((float)texture.Width / totalFrames, (float)texture.Height / totalFrames);
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
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, Value.Zero, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
