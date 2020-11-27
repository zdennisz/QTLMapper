using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
    public class Position
    {
        public Chromosome Chromosome { get; set; }
        public double PositionChrGenetic { get; set; }//coordinate in cM
        public double PositionChrPhys { get; set; }//coordinate in bp (Not important for this project)

        public bool NotBeforePosition(Position Pos)
        {
            bool b = (Chromosome.Id >= Pos.Chromosome.Id);
            if (b) { b = (PositionChrGenetic >= Pos.PositionChrGenetic); }
            return b;
        }
    }
}
