using Xunit;
using System;
using System.Drawing;
using MarsRover.Common;
using MarsRover.Core;
using MarsRover.Business;
using MarsRover.Business.States;

namespace MarsRover.Test.States
{
    public class EastStateTests
    {
        [Fact()]
        public void MoveForward_ShouldAssertTrue_WhenRoverMove()
        {
            Point currentPosition = new Point(5, 5);
            IRoverState roverState = new EastStates(currentPosition);

            roverState.MoveForward();

            Assert.Equal(6, roverState.GetPosition().X);
            Assert.Equal(5, roverState.GetPosition().Y);
        }

        [Theory]
        [InlineData(1, 3, 'L', "N")]
        [InlineData(1, 3, 'R', "S")]
        public void TurnLeftOrRight_ShouldAssertTrue_WhenRotateRover(int x, int y, char direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            IRoverState state = new EastStates(currentPosition);
            if (direction is 'L')
                state = state.TurnLeft();
            if (direction is 'R')
                state = state.TurnRight();

            Assert.Equal(expected, state.ToString());
        }
    }
}