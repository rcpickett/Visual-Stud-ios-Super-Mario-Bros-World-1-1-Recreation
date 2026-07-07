using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class OneBush : IBackgroundItem
    {
        private IAnimatedSprite oneBush;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)oneBush.TextureDimension.X, (int)oneBush.TextureDimension.Y); }
        }

        public OneBush(Vector2 location)
        {
            Location = location;
            oneBush = SpriteFactory.CreateOneBush();
        }

        public void Update(GameTime gameTime)
        {
            oneBush.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneBush.Draw(spriteBatch, Location, Color.White);
        }
    }
}
