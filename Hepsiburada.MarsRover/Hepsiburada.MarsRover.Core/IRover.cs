using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.MarsRover.Core
{
    public interface IRover
    {
        /// <summary>
        /// represents a forward movement for the rover
        /// </summary>
        void MoveForward();
        /// <summary>
        /// represents a left turn for the rover
        /// </summary>
        public void TurnLeft();
        /// <summary>
        /// represents a right turn for the rover
        /// </summary>
        public void TurnRight();
        /// <summary>
        /// receives the location the rover
        /// </summary>
        public string GetLocation();
    }
}
