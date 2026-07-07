using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public interface IPlayer : IDynamicObject
    {
        IPlayerState State { get; set; }
        Game1 Game { get; }
        Scorecard ScoreCard { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Color color);

        void Left();
        void Right();
        void Up();
        void Down();
        void B();
        void NoCommand();

        void BlockCollision(Block block, CollisionDetector.CollisionType collision);

        void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 newMarioLocation, Vector2 newCameraLocation);

        void GetHit();
        void CollectItem(IItem item);

        Mario.Power GetPower();

        void PoleSequence();
        void EndAnimation();
        void Die();

        // ✅ NEW: camera + rendering shared truth
        bool FacingRight { get; }
    }
}