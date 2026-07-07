using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class UseGravityControl: ICommand
    {
        //Just for simplicity of use since there is no second player
        public void Execute()
        {
            ControllerHelper.GravityControlOn = true;
        } 
    }
}
