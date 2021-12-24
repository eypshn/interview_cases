using Xunit;
using System;
using System.Drawing;
using MarsRover.Common;
using MarsRover.Core;
using MarsRover.Business;
using MarsRover.Business.States;

namespace MarsRover.Test.States
{
    public class WestStateTests
    {
        [Fact()]
        public void MoveForward_ShouldAssertTrue_WhenRoverMove()
        {
            Point currentPosition = new Point(2, 1);
            IRoverState roverState = new WestStates(currentPosition);

            roverState.MoveForward();

            Assert.Equal(1, roverState.GetPosition().X);
            Assert.Equal(1, roverState.GetPosition().Y);
        }

        [Theory]
        [InlineData(5, 3, 'L', "S")]
        [InlineData(5, 3, 'R', "N")]
        public void TurnLeftOrRight_ShouldAssertTrue_WhenRotateRover(int x, int y, char direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            IRoverState state = new WestStates(currentPosition);
            if (direction is 'L')
                state = state.TurnLeft();
            if (direction is 'R')
                state = state.TurnRight();

            Assert.Equal(expected, state.ToString());
        }
    }
}