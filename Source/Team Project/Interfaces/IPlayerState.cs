using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public interface IPlayerState
    {
        IAnimatedSprite Sprite { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);

        void Left();

        void Right();

        void Up();

        void Down();

        void B();

        void NoCommand();

        void GetHit();

        void CollectItem(IItem item);

        void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collisionType, Vector2 marioLocation, Vector2 cameraLocation);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        Mario.Power GetPower();

        void PoleSequence();

        void EndAnimation();
    }
}
