using Class06Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
    class Boat : IDrivable
    {
        public string BoatName { get; set; }
        public int Size { get; set; }

        public void Accelerate()
        {
            Console.WriteLine("Vroom Vroom!");
        }

        public void Brake()
        {
            Console.WriteLine("BRAKE!!");

        }

        public void Start()
        {
            Console.WriteLine("BRAKE!!");
        }

        public void Stop()
        {
            Console.WriteLine("We Shall Stop!!");
        }

        void BoardProcedure()
        {
            Console.WriteLine("we are boarding");
        }

        void UnBoardProcedure()
        {
            Console.WriteLine("We are off of the boat");
        }
    }
}
