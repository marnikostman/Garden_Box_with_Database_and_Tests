using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenBoxNamespace
{
    public class GardenBox
    {
        public int length;
        public int width;
        public int area;
        public int perimeter;
        public string vegetable;
        public decimal vegetablesPer4x4;
        public int numberVegetable;

        public GardenBox(int givenLength, int givenWidth, string givenVegetable, decimal givenVegetablesPer4x4)
        {
           length = givenLength; //GardenBox.GetDimension("length")
           width = givenWidth; //GardenBox.GetDimension("width")
           area = length * width;
           perimeter = (2 * length) + (2 * width);
           vegetable = givenVegetable;
           vegetablesPer4x4 = givenVegetablesPer4x4;
           numberVegetable = Convert.ToInt16(givenVegetablesPer4x4 * area);
        }
        
        public void giveBoxInfo()
        {
            Console.WriteLine($"The perimeter of your box is {perimeter} feet.");
            Console.WriteLine($"The area of your box is {area} sq feet.");
            Console.WriteLine($"You can hold {numberVegetable} {vegetable} in your box");
        }
    }
}
