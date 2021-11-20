using Hepsiburada.MarsRover.Business;
using Hepsiburada.MarsRover.Common;
using Hepsiburada.MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace Hepsiburada.MarsRover.Test
{
    public class RoverTests
    {
        [Theory]
        [InlineData(1, 2, "N", "1 2 N")]
        [InlineData(3, 3, "E", "3 3 E")]
        public void SetPositionRover_ShouldAssertTrue_WhenInitializeRover(int x, int y, string direction, string expected)
        {
            int maxX = 5;
            int maxY = 5;

            ISurface surface = new MarsSurface(maxX, maxY);
            surface.SetPositionRover(x, y, direction);

            Assert.Equal(expected, surface.GetCurrentgRoverLocations());
        }

        [Theory, InlineData(5, 6, "W")]
        public void SetPositionRover_ShouldThrowException_WhenNotInitializeRover(int x, int y, string direction)
        {
            int maxX = 5;
            int maxY = 5;

            ISurface surface = new MarsSurface(maxX, maxY);

             Assert.Throws<ArgumentOutOfRangeException>(() => surface.SetPositionRover(x, y, direction));
        }

        [Theory]
        [InlineData(1, 3, "N", 'L', "1 3 W")]
        [InlineData(2, 4, "E", 'R', "2 4 S")]
        [InlineData(3, 4, "S", 'M', "3 3 S")]
        public void SetPositionRover_ShouldChangeDirection_WhenRoverTurn(int x, int y, string direction, char command, string expected)
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
    }
}