using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class SmallPipe : IPipe
    {
        private IAnimatedSprite smallPipe;
        private Vector2 location;
        private Vector2 newCameraLocation = new Vector2();

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public Rectangle Rectangle { get { return new Rectangle((int)location.X+Value.Two, (int)location.Y, (int)smallPipe.TextureDimension.X-Value.Four, (int)smallPipe.TextureDimension.Y); } }

        public SmallPipe(Vector2 location)
        {
            this.location = location;
            smallPipe = SpriteFactory.CreateSmallPipe();
        }


        public void CollisionResponse(IPlayer player, CollisionDetector.CollisionType collision)
        {
            Vector2 newMarioLocation;
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, newCameraLocation);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, newCameraLocation);
                    break;
                case CollisionDetector.CollisionType.left:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, newCameraLocation);
                    break;
                case CollisionDetector.CollisionType.right:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, newCameraLocation);
                    break;
            }
        }

        public void CollisionResponseWithEnemy(IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(this, collision);
        }

        public void Update(GameTime gameTime)
        {
            smallPipe.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smallPipe.Draw(spriteBatch, location, Color.White);
        }
        
    }
}
