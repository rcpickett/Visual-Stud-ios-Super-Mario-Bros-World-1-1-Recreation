using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class SmallHill : IBackgroundItem
    {
        private IAnimatedSprite smallHill;
        public Vector2 Location { get; set; }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)smallHill.TextureDimension.X, (int)smallHill.TextureDimension.Y); }
        }

        public SmallHill(Vector2 location)
        {
            Location = location;
            smallHill = SpriteFactory.CreateSmallHill();
        }

        public void Update(GameTime gameTime)
        {
            smallHill.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smallHill.Draw(spriteBatch, Location, Color.White);
        }
    }
}
