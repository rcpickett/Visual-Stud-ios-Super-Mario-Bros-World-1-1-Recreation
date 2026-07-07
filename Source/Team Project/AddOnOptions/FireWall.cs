using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class FireWall : IObjectsEffectPlayer
    {
        private IAnimatedSprite sprite;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public FireWall(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateFlameShotRightSprite();
            Movement = new Vector2(Speed.One, Speed.Zero);
        }

        public void CollisionResponseWithPlayer(IPlayer p, CollisionDetector.CollisionType collision)
        {
            if (p is StarMario || p.Game.playerChar == Game1.Characters.Bowser)
            {
            }
            else if (collision != CollisionDetector.CollisionType.none)
            {
                p.GetHit();
            }
        }

        public void Update(GameTime gameTime)
        {
            Location += Movement;
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}
