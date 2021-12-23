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
    public class Rover : IRover
    {
        public Rover(Point point, Direction direction)
        {
            this.RoverState = DirectionHelper.Initialize(point, direction);
        }
        private IRoverState RoverState { get; set; }

        /// <inheritdoc />
        public void TurnLeft()
        {
            this.RoverState = this.RoverState.TurnLeft();
        }
        /// <inheritdoc />
        public void TurnRight()
        {
            this.RoverState = this.RoverState.TurnRight();
        }
        /// <inheritdoc />
        public void MoveForward()
        {
            this.RoverState.MoveForward();
        }
        /// <inheritdoc />
        public string GetLocation()
        {
            return $"{this.RoverState.GetPosition().X} {this.RoverState.GetPosition().Y} {this.RoverState}"; 
        }
    }
}
