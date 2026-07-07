using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class OneCloud : IBackgroundItem
    {
        private IAnimatedSprite oneCloud;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)oneCloud.TextureDimension.X, (int)oneCloud.TextureDimension.Y); }
        }

        public OneCloud(Vector2 location)
        {
            Location = location;
            oneCloud = SpriteFactory.CreateOneCloud();
        }

        public void Update(GameTime gameTime)
        {
            oneCloud.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneCloud.Draw(spriteBatch, Location, Color.White);
        }
    }
}
