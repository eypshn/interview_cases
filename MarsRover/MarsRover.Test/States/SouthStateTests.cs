using Xunit;
using System;
using System.Drawing;
using MarsRover.Common;
using MarsRover.Core;
using MarsRover.Business;
using MarsRover.Business.States;

namespace MarsRover.Test.States
{
    public class SouthStateTests
    {
        [Fact()]
        public void MoveForward_ShouldAssertTrue_WhenRoverMove()
        {
            Point currentPosition = new Point(3, 3);
            IRoverState roverState = new SouthStates(currentPosition);

            roverState.MoveForward();

            Assert.Equal(3, roverState.GetPosition().X);
            Assert.Equal(2, roverState.GetPosition().Y);
        }

        [Theory]
        [InlineData(2, 3, 'L', "E")]
        [InlineData(2, 3, 'R', "W")]
        public void TurnLeftOrRight_ShouldAssertTrue_WhenRotateRover(int x, int y, char direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            IRoverState state = new SouthStates(currentPosition);
            if (direction is 'L')
                state = state.TurnLeft();
            if (direction is 'R')
                state = state.TurnRight();

            Assert.Equal(expected, state.ToString());
        }
    }
}