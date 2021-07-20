using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class Tube1 : GameObject
    {
        public Tube1()
        {
            WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube1_1_filled.png";
            Path = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube1_1.png";
            gameObjectType = GameObjectType.Tube1;
            GameObjectJoint = new int[] { 1, 0, 1, 0 };
            AmountOfJoint = 2;

        }
        public override void SetNewJoint()
        {
            base.SetNewJoint();
        }
        public override void SetWinPath()
        {
            WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube1_1_filled.png";
        }
    }
}
