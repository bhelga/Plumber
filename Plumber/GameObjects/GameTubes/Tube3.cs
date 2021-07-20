using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class Tube3 : GameObject
    {

        public Tube3()
        {
            Path = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3.png";
            gameObjectType = GameObjectType.Tube3;
            GameObjectJoint = new int[] { 1, 1, 1, 0 };
            AmountOfJoint = 3;
        }
        public override void SetNewJoint()
        {
            base.SetNewJoint();
        }
        public override void SetWinPath()
        {
            WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled.png";
            if (ObjRotation == 0)
            {
                if (GameObjectJoint[1] == 2 && GameObjectJoint[2] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled1.png";
                }
                else if (GameObjectJoint[1] == 2 && GameObjectJoint[0] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled2.png";
                }
                else if (GameObjectJoint[0] == 2 && GameObjectJoint[2] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled3.png";
                }
            }
            else if (ObjRotation == 1)
            {
                if (GameObjectJoint[0] == 2 && GameObjectJoint[1] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled1.png";
                }
                else if (GameObjectJoint[1] == 2 && GameObjectJoint[2] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled2.png";
                }
                else if (GameObjectJoint[1] == 2 && GameObjectJoint[3] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled3.png";
                }
            }
            else if (ObjRotation == 2)
            {
                if (GameObjectJoint[0] == 2 && GameObjectJoint[3] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled1.png";
                }
                else if (GameObjectJoint[2] == 2 && GameObjectJoint[3] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled2.png";
                }
                else if (GameObjectJoint[0] == 2 && GameObjectJoint[2] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled3.png";
                }
            }
            else if (ObjRotation == 3)
            {
                if (GameObjectJoint[0] == 2 && GameObjectJoint[1] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled1.png";
                }
                else if (GameObjectJoint[0] == 2 && GameObjectJoint[3] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled2.png";
                }
                else if (GameObjectJoint[1] == 2 && GameObjectJoint[3] == 2)
                {
                    WinPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\Tube3_3_filled3.png";
                }
            }
        }
    }
}
