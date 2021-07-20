using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class Tube5 : GameObject
    {
        public Tube5()
        {
            Path = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube5_5.png";
            gameObjectType = GameObjectType.Tube5;
            GameObjectJoint = new int[] { 1, 0, 0, 0 };
            AmountOfJoint = 1;
            
        }
        public override void SetNewJoint()
        {
            base.SetNewJoint();
        }
        public override void SetWinPath()
        {
            WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube5_5_filled.png";
        }
    }
}
