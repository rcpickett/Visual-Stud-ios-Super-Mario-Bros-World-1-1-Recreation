using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class TwoBush : IBackgroundItem
    {
        private IAnimatedSprite twoBush;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)twoBush.TextureDimension.X, (int)twoBush.TextureDimension.Y); }
        }

        public TwoBush(Vector2 location)
        {
            Location = location;
            twoBush = SpriteFactory.CreateTwoBush();
        }

        public void Update(GameTime gameTime)
        {
            twoBush.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            twoBush.Draw(spriteBatch, Location, Color.White);
        }
    }

}
