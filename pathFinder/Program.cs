using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder
{
    public class Program
    {
        static void Main(string[] args)
        {
  
        }

        static public bool AdventureSucceeds(TrackTree way, int matchesNumber, int ropesNumber)
        {
            Enum currentLandscape = way.GetTheTypeOfLandscape();    
            
            if (currentLandscape.Equals(Landscapes.River))
            {
                if (matchesNumber == 0)
                    return false;
                else
                    matchesNumber --;
            }

            if (currentLandscape.Equals(Landscapes.Waterfall))
            {
                if (ropesNumber == 0)
                    return false;
                else
                    ropesNumber --;
            }

 
            if (way.GetTheNumberOfFurtherWays() == 0)
                return true;

            foreach (TrackTree furtherSequence in way.GetFurtherSequencesOfLandscapes())
            {
                if (AdventureSucceeds(furtherSequence, matchesNumber, ropesNumber))
                     return true;
            }

            return false;

        }
    }
}
