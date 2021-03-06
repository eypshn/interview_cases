using MarsRover.Business.States;
using MarsRover.Common;
using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class DirectionHelper
    {
        /// <summary>
        /// determines the  rover position
        /// </summary>
        public static IRoverState Initialize(Point position, Direction direction)
        {
            return direction switch
            {
                Direction.E => new EastStates(position),
                Direction.S => new SouthStates(position),
                Direction.W => new WestStates(position),
                Direction.N or _ => new NorthStates(position),
            };
        }
    }
}
