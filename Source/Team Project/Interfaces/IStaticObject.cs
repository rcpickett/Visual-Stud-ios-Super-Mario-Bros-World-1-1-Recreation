using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IStaticObject
    {
        Vector2 Location { get; set; }
        Rectangle Rectangle { get; }
    }
}
