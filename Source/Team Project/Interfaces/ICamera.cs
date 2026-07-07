using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public interface ICamera
    {
        // Properties
        Rectangle limits { get; set; }
        Vector2 position { get; set; }
        float zoom { get; set; }
        Viewport viewport { get; set; }

        // Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        Matrix GetViewMatrix();
        void ChangePosition(Vector2 Position);
        void Update(Game1 game);
        void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision);
        void Reset();
    }
}
