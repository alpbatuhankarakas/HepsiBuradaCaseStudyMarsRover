using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public interface IPlateauGrid
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X0 { get; set; }
        public int Y0 { get; set; }
    }
}
