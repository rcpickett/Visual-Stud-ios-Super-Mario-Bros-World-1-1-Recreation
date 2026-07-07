using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class MarioRunningSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private int startFrame;
        private int endFrame;
        private int widthFrame;
        private float elapsedTime = Value.Zero;
        private Vector2 textureDimensions;

        public float DelayTime { get; set; }

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public MarioRunningSprite(Texture2D t)
        {
            texture = t;
            currentFrame = Value.One;
            startFrame = Value.One;
            endFrame = Value.Three;
            totalFrames = Value.Three;
            widthFrame = texture.Width / totalFrames;
            textureDimensions = new Vector2(widthFrame, texture.Height);
            DelayTime = Value.EightyFive;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= DelayTime)
            {
                elapsedTime = Value.Zero;
                currentFrame++;
                if (currentFrame > endFrame)
                {
                    currentFrame = startFrame;
                }
            }

            DelayTime = Value.EightyFive;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int column = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(widthFrame * column, Value.Zero, widthFrame, texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, widthFrame, texture.Height);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
