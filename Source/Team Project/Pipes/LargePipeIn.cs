using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public class LargePipeIn : IPipe
    {
        private IAnimatedSprite largePipe;
        private Vector2 location;
        private Vector2 locationToWarpMario;
        private Vector2 cameraLocation = new Vector2(float.MaxValue);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private Level level;

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public Rectangle Rectangle { get { return new Rectangle((int)location.X + Value.Two, (int)location.Y, (int)largePipe.TextureDimension.X - Value.Four, (int)largePipe.TextureDimension.Y); } }

        public LargePipeIn(Vector2 location, string mWL, Level l)
        {
            this.location = location;
            largePipe = SpriteFactory.CreateLargePipe();
            level = l;
            locationToWarpMario = new Vector2(float.Parse(mWL.Substring(Value.Zero, mWL.IndexOf(GeneralString.BlankSpace))), float.Parse(mWL.Substring(mWL.IndexOf(GeneralString.BlankSpace), mWL.IndexOf(GeneralString.DollarSign) - mWL.IndexOf(GeneralString.BlankSpace))));
            if (int.Parse(mWL.Substring(mWL.IndexOf(GeneralString.DollarSign) + Value.One, Value.One)) == Value.One)
            {
                cameraLocation = new Vector2(float.Parse(mWL.Substring(mWL.IndexOf(GeneralString.Comma) + Value.One, mWL.IndexOf(GeneralString.PercentSign) - mWL.IndexOf(GeneralString.Comma) - Value.One)), float.Parse(mWL.Substring(mWL.IndexOf(GeneralString.PercentSign) + Value.One, mWL.Length - mWL.IndexOf(GeneralString.PercentSign) - Value.One)));
            }
        }


        public void CollisionResponse(IPlayer player, CollisionDetector.CollisionType collision)
        {
            Vector2 newMarioLocation;
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    if (ControllerHelper.IsDDown)
                    {
                        newMarioLocation = locationToWarpMario;
                    }
                    else
                    {
                        newMarioLocation = player.Location;
                    }
                    player.PipeCollision(this, collision, newMarioLocation, cameraLocation);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, cameraLocation);
                    break;
                case CollisionDetector.CollisionType.left:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, cameraLocation);
                    break;
                case CollisionDetector.CollisionType.right:
                    newMarioLocation = player.Location;
                    player.PipeCollision(this, collision, newMarioLocation, cameraLocation);
                    break;
            }
        }

        public void CollisionResponseWithEnemy(IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(this, collision);
        }

        public void Update(GameTime gameTime)
        {
            largePipe.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            largePipe.Draw(spriteBatch, location, Color.White);
        }

    }
}
