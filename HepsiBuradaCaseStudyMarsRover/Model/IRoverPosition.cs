using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public interface IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CardinalDirection Direction { get; set; }
        public void ChangePosition(int x, int y);
    }
}
