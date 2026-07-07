using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class ThreeBush : IBackgroundItem
    {
        private IAnimatedSprite threeBush;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)threeBush.TextureDimension.X, (int)threeBush.TextureDimension.Y); }
        }

        public ThreeBush(Vector2 location)
        {
            Location = location;
            threeBush = SpriteFactory.CreateThreeBush();
        }

        public void Update(GameTime gameTime)
        {
            threeBush.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            threeBush.Draw(spriteBatch, Location, Color.White);
        }
    }
}
