using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class BigHill : IBackgroundItem
    {
        private IAnimatedSprite bigHill;

        public Vector2 Location { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, (int)bigHill.TextureDimension.X, (int)bigHill.TextureDimension.Y); }
        }

        public BigHill(Vector2 location)
        {
            Location = location;
            bigHill = SpriteFactory.CreateBigHill();
        }

        public void Update(GameTime gameTime)
        {
            bigHill.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bigHill.Draw(spriteBatch, Location, Color.White);
        }
    }
}
