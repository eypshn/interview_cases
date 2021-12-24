using Xunit;
using System;
using System.Drawing;
using MarsRover.Common;
using MarsRover.Core;
using MarsRover.Business;
using MarsRover.Business.States;

namespace MarsRover.Test.States
{
    public class NorthStateTests
    {
        [Fact()]
        public void MoveForward_ShouldAssertTrue_WhenRoverMove()
        {
            Point currentPosition = new Point(4, 3);
            IRoverState roverState = new NorthStates(currentPosition);

            roverState.MoveForward();

            Assert.Equal(4, roverState.GetPosition().X);
            Assert.Equal(4, roverState.GetPosition().Y);
        }

        [Theory]
        [InlineData(4, 3, 'L', "W")]
        [InlineData(4, 3, 'R', "E")]
        public void TurnLeftOrRight_ShouldAssertTrue_WhenRotateRover(int x, int y, char direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            IRoverState state = new NorthStates(currentPosition);
            if (direction is 'L')
                state = state.TurnLeft();
            if (direction is 'R')
                state = state.TurnRight();

            Assert.Equal(expected, state.ToString());
        }
    }
}