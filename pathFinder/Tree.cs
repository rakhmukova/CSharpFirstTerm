using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder
{
    public enum Landscapes
    {
        Forest,
        River,
        Waterfall
    }

    public class TrackTree
    {       
        private TrackTree[] children;
        private Enum sceneryType;

        public TrackTree(Enum sceneryType, params TrackTree[] children) 
        {
            this.sceneryType = sceneryType;            
            this.children = children;           
        }

        public int GetTheNumberOfFurtherWays()
        {
            return children.Length;
        }

        public Enum GetTheTypeOfLandscape()
        {
            return sceneryType;
        }

        public TrackTree[] GetFurtherSequencesOfLandscapes()
        {
            return children;
        }

    }
}
