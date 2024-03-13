using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class PointOfInterest
    {
        public bool isResolved;

        public PointOfInterest(bool isResolved)
        {
            this.isResolved = isResolved;
        }

        public abstract void Resolve(List<Player> players);
    }
}
