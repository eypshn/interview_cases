using Xunit;
using System;
using System.Drawing;
using MarsRover.Common;
using MarsRover.Core;
using MarsRover.Business;
using MarsRover.Business.States;

namespace MarsRover.Test.States
{
    public class RoverStateTests
    {
        [Theory]
        [InlineData(5, 5, "N", "56N")]
        [InlineData(5, 5, "S", "54S")]
        [InlineData(5, 5, "E", "65E")]
        [InlineData(5, 5, "W", "45W")]
        public void MoveForward_ShouldAssertTrue_WhenRoverMove(int x, int y, string direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), direction);
            IRoverState roverState = currengtDirection switch
            {
                Direction.E => new EastStates(currentPosition),
                Direction.S => new SouthStates(currentPosition),
                Direction.W => new WestStates(currentPosition),
                Direction.N or _ => new NorthStates(currentPosition),
            };

            roverState.MoveForward();

            var result = $"{roverState.GetPosition().X}{roverState.GetPosition().Y}{roverState}";
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 5, "N", "W")]
        [InlineData(5, 5, "E", "N")]
        [InlineData(5, 5, "S", "E")]
        [InlineData(5, 5, "W", "S")]
        public void TurnLeft_ShouldAssertTrue_WhenRotateRover(int x, int y, string direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), direction);
            IRoverState roverState = currengtDirection switch
            {
                Direction.E => new EastStates(currentPosition),
                Direction.S => new SouthStates(currentPosition),
                Direction.W => new WestStates(currentPosition),
                Direction.N or _ => new NorthStates(currentPosition),
            };

            roverState = roverState.TurnLeft();

            Assert.Equal(expected, roverState.ToString());
        }

        [Theory]
        [InlineData(5, 5, "N", "E")]
        [InlineData(5, 5, "E", "S")]
        [InlineData(5, 5, "S", "W")]
        [InlineData(5, 5, "W", "N")]
        public void TurnRight_ShouldAssertTrue_WhenRotateRover(int x, int y, string direction, string expected)
        {
            Point currentPosition = new Point(x, y);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), direction);
            IRoverState roverState = currengtDirection switch
            {
                Direction.E => new EastStates(currentPosition),
                Direction.S => new SouthStates(currentPosition),
                Direction.W => new WestStates(currentPosition),
                Direction.N or _ => new NorthStates(currentPosition),
            };

            roverState = roverState.TurnRight();

            Assert.Equal(expected, roverState.ToString());
        }
    }
}