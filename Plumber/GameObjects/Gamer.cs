using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Plumber
{
    public struct Gamer : IComparable, IGamer
    {
        private string name;
        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private int amountOfSeconds;
        public int AmountOfSeconds
        {
            get
            {
                return amountOfSeconds;
            }
            set
            {
                amountOfSeconds = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Gamer otherGamer = (Gamer)obj;
            if (otherGamer.Equals(null) != true)
                return this.AmountOfSeconds.CompareTo(otherGamer.AmountOfSeconds);
            else
                throw new ArgumentException("Object is not a Temperature");
        }

        public List<Gamer> ReadFile()
        {
            List<Gamer> gamers = new List<Gamer>();
            Gamer temp = new Gamer();
            FileStream fs = new FileStream(@"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\scoreTable.txt", FileMode.OpenOrCreate);
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                int i = 3;
                while ((line = sr.ReadLine()) != null)
                {
                    if (i % 2 == 0)
                    {
                        temp.Name = line;
                        gamers.Add(temp);
                    }
                    else
                    {
                        temp.AmountOfSeconds = Convert.ToInt32(line);
                    }
                    i++;
                }
            }
            gamers.Sort();
            return gamers;
        }

        public override string ToString()
        {
            return $"Гравець {Name} – {AmountOfSeconds} секунд";
        }
    }
}
