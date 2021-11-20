using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.MarsRover.Core
{
    public interface IRoverState
    {
        /// <summary>
        /// represents a forward movement
        /// </summary>
        void MoveForward();
        /// <summary>
        /// represents a left turn
        /// </summary>
        IRoverState TurnLeft();
        /// <summary>
        /// represents a right turn
        /// </summary>
        IRoverState TurnRight();
        /// <summary>
        /// represents the current x and y coordinates.
        /// </summary>
        Point GetPosition();
    }
}
