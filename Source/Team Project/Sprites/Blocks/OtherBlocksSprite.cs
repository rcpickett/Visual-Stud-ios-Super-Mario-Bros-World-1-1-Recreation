using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class OtherBlocksSprite : IAnimatedSprite
    {
        private Texture2D texture;
        private Vector2 textureDimensions;

        public Vector2 TextureDimension { get { return textureDimensions; } }

        public OtherBlocksSprite(Texture2D texture)
        {
            this.texture = texture;
            textureDimensions = new Vector2(texture.Width, texture.Height);
        }

        // No need for updating, as each block has just one frame in the texture file
        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
