using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public interface IRover
    {
        public void Move();
        public void Right();
        public void Left();
        public IRoverPosition Position { get; set; }
        public Queue<ActionType> Directions { get; set; }

    }
}
