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
    public class SouthStates : IRoverState
    {
        public SouthStates(Point point)
        {
            position = point;
        }

        /// <inheritdoc />
        private Point position;

        /// <inheritdoc />
        public void MoveForward()
        {
            position.Y -= 1;
        }
        /// <inheritdoc />
        public IRoverState TurnLeft()
        {
            return new EastStates(position);
        }
        /// <inheritdoc />
        public IRoverState TurnRight()
        {
            return new WestStates(position);
        }
        /// <inheritdoc />
        public Point GetPosition()
        {
            return this.position;

        }
        public override string ToString()
        {
            return Direction.S.ToString();
        }
    }
}
