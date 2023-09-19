using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp2_BaiTap1
{
    internal class Bike
    {
        private int ID;
        private string Ten;
        private string HSX;

        public Bike()
        {
            
        }

        public Bike(int iD, string ten, string hSX)
        {
            ID = iD;
            Ten = ten;
            HSX = hSX;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string HSX1 { get => HSX; set => HSX = value; }
        public void InThongTin()
        {
            Console.WriteLine($"{ID} - {Ten} - {HSX}");
        }
        public string ObjToStr()
        {
            return $"{ID} - {Ten} - {HSX}\n";
        }
    }
}
