using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public static class CollisionDetector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public enum CollisionType { top, bottom, left, right, total, none }

        public static CollisionType DetectCollision(Rectangle rectangleA, Rectangle rectangleB)
        {
            CollisionType collision;
            Rectangle intersection = Rectangle.Intersect(rectangleA, rectangleB);

            if (intersection.Width > intersection.Height && intersection.Location.Y == rectangleB.Location.Y)
            {
                // Hit top of B, bottom of A
                collision = CollisionType.top;
            }
            else if (intersection.Width > intersection.Height && intersection.Location.Y == rectangleA.Location.Y)
            {
                // Hit bottom of B, top of A
                collision = CollisionType.bottom;
            }
            else if (intersection.Width < intersection.Height && intersection.Location.X == rectangleB.Location.X)
            {
                // Hit left of B, right of A
                collision = CollisionType.left;
            }
            else if (intersection.Width < intersection.Height && intersection.Location.X == rectangleA.Location.X)
            {
                // Hit right of B, left of A
                collision = CollisionType.right;
            }
            else if (intersection.Width == rectangleB.Width && intersection.Height == rectangleB.Height)
            {
                collision = CollisionType.total;
            }
            else
            {
                collision = CollisionType.none;
            }
            return collision;
        }
    }
}
