using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public interface IDynamicObject
    {
        Vector2 Location { get; set; }
        Rectangle Rectangle { get; }
        Vector2 Movement { get; set; }
    }
}
