using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber 
{
    class Tube2 : GameObject
    {
        public Tube2()
        {
            Path = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube2_2.png";
            gameObjectType = GameObjectType.Tube2;
            GameObjectJoint = new int[] { 1, 1, 1, 1 };
            AmountOfJoint = 4;
        }
        public override void SetNewJoint()
        {
            base.SetNewJoint();
        }
        public override void SetWinPath()
        {
            if (GameObjectJoint[0] == 2 && GameObjectJoint[2] == 2)
            {
                WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube2_2_filled2.png";
            }
            else if (GameObjectJoint[1] == 2 && GameObjectJoint[3] == 2)
            {
                WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube2_2_filled1.png";
            }
            else
            {
                WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube2_2_filled.png";
            }
        }
    }
}
