using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part6
{
    public class Classroom
    {
        public string code;
        private int _capacity;
        private int _floor;
        public int Capacity
        {
            get { return _capacity; }
            set => _capacity = (value >= 5)&&(value<=25) 
                                ? value : (value>25) 
                                ? 25 : 5;
        }
        public int Floor
        {
            get { return _floor; }
            set => _floor = (value >= 1) && (value <= 5)
                                ? value : (value > 5)
                                ? 5 : 1;
        }

        public Classroom(string code)
        {
            this.code = code;
            this.Capacity = 5;
            this.Floor = 1;
        }
        public Classroom(string code, int capacity)
        {
            this.code = code;
            this.Capacity = capacity;
            this.Floor = 1;
        }
        public Classroom(string code, int capacity, int floor)
        {
            this.code = code;
            this.Capacity = capacity;
            this.Floor = floor;

        }
    }
}
