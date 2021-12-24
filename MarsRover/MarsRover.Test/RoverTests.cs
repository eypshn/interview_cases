using MarsRover.Business;
using MarsRover.Common;
using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTests
    {
        [Theory]
        [InlineData(1, 2, 'N', "12N")]
        [InlineData(3, 3, 'E', "33E")]
        public void SetPositionRover_ShouldAssertTrue_WhenInitializeRover(int x, int y, char direction, string expected)
        {
            int maxX = 5;
            int maxY = 5;

            ISurface surface = new MarsSurface(maxX, maxY);
            surface.SetPositionRover(x, y, direction);

            Assert.Equal(expected, surface.GetCurrentRoverLocations());
        }

        [Theory, InlineData(5, 6, 'W')]
        public void SetPositionRover_ShouldThrowException_WhenNotInitializeRover(int x, int y, char direction)
        {
            int maxX = 5;
            int maxY = 5;

            ISurface surface = new MarsSurface(maxX, maxY);

             Assert.Throws<ArgumentOutOfRangeException>(() => surface.SetPositionRover(x, y, direction));
        }

        [Theory]
        [InlineData(1, 3, "N", 'L', "13W")]
        [InlineData(2, 4, "E", 'R', "24S")]
        [InlineData(3, 4, "S", 'M', "33S")]
        public void RedirectRover_ShouldChangeDirection_WhenRoverTurn(int x, int y, string direction, char command, string expected)
        {
            Point currentPosition = new Point(x, y);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), direction);
            IRover rover = new Rover(currentPosition, currengtDirection);
            if (command is 'L')
                rover.TurnLeft();
            if (command is 'R')
                rover.TurnRight();
            if (command is 'M')
                rover.MoveForward();

            Assert.Equal(expected, rover.GetLocation());
        }

        [Fact]
        public void GetLocation_ShouldAssertTrue_WhenInitializeRover()
        {
            Point currentPosition = new Point(5, 5);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), "N");
            IRover rover = new Rover(currentPosition, currengtDirection);

            string expectedResult = $"{currentPosition.X}{currentPosition.Y}{currengtDirection}";
            Assert.Equal(expectedResult, rover.GetLocation());
        }
    }
}