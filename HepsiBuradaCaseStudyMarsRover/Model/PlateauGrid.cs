using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public class PlateauGrid : IPlateauGrid
    {
        public int X0 { get; set; }
        public int Y0 { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public PlateauGrid(int x, int y)
        {
            X1 = x;
            Y1 = y;
            X0 = 0;
            Y0 = 0;
        }
    }
}
