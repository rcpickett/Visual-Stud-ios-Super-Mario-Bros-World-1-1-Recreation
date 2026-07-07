using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class MediumPipe : IPipe
    {
        private IAnimatedSprite mediumPipe;
        private Vector2 location;
        private Vector2 newCameraLocation = new Vector2();

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public Rectangle Rectangle { get { return new Rectangle((int)location.X+Value.Two, (int)location.Y, (int)mediumPipe.TextureDimension.X-Value.Four, (int)mediumPipe.TextureDimension.Y); } }

        public MediumPipe(Vector2 location)
        {
            this.location = location;
            mediumPipe = SpriteFactory.CreateMediumPipe();
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
            mediumPipe.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mediumPipe.Draw(spriteBatch, location, Color.White);
        }
        
    }
}
