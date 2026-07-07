using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class StaticCamera : ICamera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private float centerX, centerY;

        public Rectangle limits { get; set; }
        public Vector2 position { get; set; }
        public float zoom { get; set; }
        public Viewport viewport { get; set; }

        public StaticCamera(Vector2 p, ICamera camera)
        {
            viewport = camera.viewport;
            zoom = camera.zoom;
            limits = new Rectangle((int)p.X, (int)p.Y, viewport.Width, viewport.Height);
            position = p;
            centerX = viewport.Width / Speed.Two;
            centerY = viewport.Height / Speed.Two;
        }
        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-position, Speed.Zero)) *
                Matrix.CreateScale(zoom, zoom, Speed.One);
        }
        public void ChangePosition(Vector2 Position) { }
        public void Update(Game1 game) { }
        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision) { }
        public void Reset() { }
    }
}
