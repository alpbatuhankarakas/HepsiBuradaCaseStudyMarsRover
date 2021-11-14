using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public class RoverPlatform : IRoverPlatform
    {
        public IPlateauGrid PlateauGrid { get; set; }
        public List<IRover> Rovers { get; set; }

        public RoverPlatform(IPlateauGrid plateauGrid)
        {
            PlateauGrid = plateauGrid;
            Rovers = new List<IRover>();
        }
        public void AddRover(IRover rover)
        {
            Rovers.Add(rover);
        }
    }
}
