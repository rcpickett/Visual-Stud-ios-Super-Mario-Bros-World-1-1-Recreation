using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class ExplodingBlockSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimensions;

        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Seven;
        private float elapsedTime;
        private float delayTime = Value.ThirtyFive;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public ExplodingBlockSprite(Texture2D texture)
        {
            this.texture = texture;
            textureDimensions = new Vector2(texture.Width / totalFrames, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > delayTime)
            {
                elapsedTime = Value.Zero;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = totalFrames;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle = new Rectangle((int)textureDimensions.X * currentFrame, Value.Zero, (int)textureDimensions.X, (int)textureDimensions.Y);
            Rectangle destinationRectangle = new Rectangle((int)location.X - Value.TwentySix, (int)location.Y - Value.TwentySix, (int)textureDimensions.X, (int)textureDimensions.Y);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
