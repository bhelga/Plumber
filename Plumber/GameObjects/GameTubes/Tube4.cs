using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class Tube4 : GameObject
    {
        public Tube4()
        {
            Path = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube4_4.png";
            gameObjectType = GameObjectType.Tube4;
            GameObjectJoint = new int[] { 1, 0, 0, 1 };
            AmountOfJoint = 2;
            
        }
        public override void SetNewJoint()
        {
            base.SetNewJoint();
        }
        public override void SetWinPath()
        {
            WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube4_4_filled.png";
        }
    }
}
