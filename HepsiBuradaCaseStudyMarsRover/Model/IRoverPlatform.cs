using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public interface IRoverPlatform
    {
        public IPlateauGrid PlateauGrid { get; set; }
        public List<IRover> Rovers { get; set; }
        void AddRover(IRover rover);
    }
}
