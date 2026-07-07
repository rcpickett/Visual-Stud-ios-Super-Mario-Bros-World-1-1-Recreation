using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class LuigiSingleFrameSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimension;

        public Vector2 TextureDimension { get { return textureDimension; } }


        public LuigiSingleFrameSprite(Texture2D t)
        {
            texture = t;
            textureDimension = new Vector2(texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle = new Rectangle(Value.Zero, Value.Zero, texture.Width, texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, texture.Width, texture.Height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
