using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
   public class Cell
    {
        public bool State { get; set; }
        public int Neighbours { get; set; }

        public void Evolve()
        {
            if (IsLonely() || IsCrowded())
            {
                State = false;
            }
            else if (IsZen() || CanReproduce())
            {
                State = true;
            }
            else
            {
                State = false;
            }
        }

        private bool IsLonely()
        {
            return Neighbours == 0 || Neighbours == 1;
        }

        private bool IsCrowded()
        {
            return Neighbours >= 4;
        }

        private bool IsZen()
        {
            return State == true && Neighbours == 2 || Neighbours == 3;
        }

        private bool CanReproduce()
        {
            return State == false && Neighbours == 3;
        }
    }
}
