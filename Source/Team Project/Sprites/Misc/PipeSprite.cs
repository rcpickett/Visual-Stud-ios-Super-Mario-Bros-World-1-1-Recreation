using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class PipeSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimension;

        public Vector2 TextureDimension { get { return textureDimension; } }

        public PipeSprite(Texture2D Texture)
        {
            texture = Texture;
            textureDimension = new Vector2(texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
    
    
}
