using MarsRover.Common;
using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.States
{
    internal class EastStates : IRoverState
    {
        public EastStates(Point point)
        {
            position = point;
        }

        /// <inheritdoc />
        private Point position;

        /// <inheritdoc />
        public void MoveForward()
        {
            position.X += 1;
        }
        /// <inheritdoc />
        public IRoverState TurnLeft()
        {
            return new NorthStates(position);
        }
        /// <inheritdoc />
        public IRoverState TurnRight()
        {
            return new SouthStates(position);
        }
        /// <inheritdoc />
        public Point GetPosition()
        {
            return this.position;

        }

        public override string ToString()
        {
            return Direction.E.ToString();
        }
    }
}
