using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class ThreeClouds : IBackgroundItem
    {
        private IAnimatedSprite threeClouds;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)threeClouds.TextureDimension.X, (int)threeClouds.TextureDimension.Y); }
        }

        public ThreeClouds(Vector2 location)
        {
            Location = location;
            threeClouds = SpriteFactory.CreateThreeClouds();
        }

        public void Update(GameTime gameTime)
        {
            threeClouds.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            threeClouds.Draw(spriteBatch, Location, Color.White);
        }
    }
}
