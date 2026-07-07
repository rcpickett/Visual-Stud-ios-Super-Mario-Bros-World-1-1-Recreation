using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class QuestionBlockSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimensions;

        private int currentFrame = Value.Zero;
        private int totalFrames = Value.Three;
        private float elapsedTime;
        private float delayTime = Value.TwoHundredFifty;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public QuestionBlockSprite(Texture2D texture)
        {
            this.texture = texture;
            textureDimensions = new Vector2(texture.Width / totalFrames, texture.Height);
        }

        // Only block to update, as the block flashes in game
        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > delayTime)
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
            Rectangle sourceRectangle = new Rectangle((int)textureDimensions.X * currentFrame, Value.Zero, (int)textureDimensions.X, (int)textureDimensions.Y);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)textureDimensions.X, (int)textureDimensions.Y);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
