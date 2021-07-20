using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;

namespace Plumber
{
    abstract class GameObject
    {
        private GameObjectPlace gameObjectPlace;
        public GameObjectPlace GameObjectPlace 
        {
            get
            {
                return gameObjectPlace;
            }
            set 
            {
                gameObjectPlace = value;
            }
        }
        private int[] gameObjectJoint = new int[] { 0, 0, 0, 0 };
        public int[] GameObjectJoint
        {
            get
            {
                return gameObjectJoint;
            }
            set
            {
                gameObjectJoint = value;
            }
        }
        private int objRotatin;
        public int ObjRotation
        {
            get
            {
                return objRotatin;
            }
            set
            {
                objRotatin = value;
            }
        } 
        private List<double> gameObjectJointCoordinate = new List<double>();
        public List<double> GameObjectJointCoordinate 
        {
            get
            {
                return gameObjectJointCoordinate;
            }
            set
            {
                gameObjectJointCoordinate = value;
            }
        }
        private int amountOfJoint;
        public int AmountOfJoint
        {
            get
            {
                return amountOfJoint;
            }
            set
            {
                amountOfJoint = value;
            }
        }
        private string path;
        public string Path 
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        private string winPath;
        public string WinPath
        {
            get
            {
                return winPath;
            }
            set
            {
                winPath = value;
            }
        }
        private GameObjectType GameObjectType;
        public GameObjectType gameObjectType
        {
            get
            {
                return GameObjectType;
            }
            set
            {
                GameObjectType = value;
            }
        }

        public virtual void SetNewJoint()
        {
            int[] temp = new int[4];
            for (int i = 1; i < GameObjectJoint.Length; i++)
            {
                temp[i] = GameObjectJoint[i - 1];
                if (i == 1)
                {
                    temp[0] = GameObjectJoint[GameObjectJoint.Length - 1];
                }
            }
            GameObjectJoint = temp;
        }
        public abstract void SetWinPath();
    }
}
