using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class TwoClouds : IBackgroundItem
    {
        private IAnimatedSprite twoClouds;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)twoClouds.TextureDimension.X, (int)twoClouds.TextureDimension.Y); }
        }

        public TwoClouds(Vector2 location)
        {
            Location = location;
            twoClouds = SpriteFactory.CreateTwoClouds();
        }

        public void Update(GameTime gameTime)
        {
            twoClouds.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            twoClouds.Draw(spriteBatch, Location, Color.White);
        }
    }
}
