using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class Camera1 : ICamera
    {
        public Rectangle limits { get; set; }
        public Vector2 position { get; set; }
        public float zoom { get; set; }
        public Viewport viewport { get; set; }

        private float viewWidth;
        private float viewHeight;

        public Camera1(Viewport viewport, float zoom, Rectangle limits)
        {
            this.viewport = viewport;
            this.zoom = zoom;
            this.limits = limits;

            viewWidth = viewport.Width / zoom;
            viewHeight = viewport.Height / zoom;

            position = Vector2.Zero;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0f)) *
                   Matrix.CreateScale(zoom, zoom, 1f);
        }

        public void Update(Game1 game)
        {
            limits = game.Level.Limits;

            if (limits.Width == 0)
                return;

            float marioX = game.currentPlayer.Location.X;

            // ----------------------------------------------------
            // CAMERA TARGET = FOLLOW MARIO DIRECTLY (NO CENTER MATH)
            // ----------------------------------------------------
            float targetX = marioX - (viewWidth * 0.5f);

            // ----------------------------------------------------
            // CLAMP TO LEVEL BOUNDS
            // ----------------------------------------------------
            float maxX = limits.Width - viewWidth;
            if (maxX < 0) maxX = 0;

            targetX = MathHelper.Clamp(targetX, 0f, maxX);

            // ----------------------------------------------------
            // APPLY POSITION (SMOOTH OPTIONAL BUT SAFE)
            // ----------------------------------------------------
            position = new Vector2(targetX, 0f);
        }

        public void ChangePosition(Vector2 Position)
        {
            position = Position;
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            // ❌ REMOVE CAMERA FORCING PLAYER POSITION (THIS CAUSED WARPS)
            // Intentionally empty
        }

        public void Reset()
        {
            position = Vector2.Zero;
        }
    }
}