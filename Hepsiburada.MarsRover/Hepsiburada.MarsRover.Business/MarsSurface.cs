using Hepsiburada.MarsRover.Common;
using Hepsiburada.MarsRover.Core;
using System.Drawing;
using System.Text;

namespace Hepsiburada.MarsRover.Business
{
    public class MarsSurface: ISurface
    {
        /// <summary>
        /// represents max X coordinate of the surface.
        /// </summary>
        public int MaxX { get; init; }
        /// <summary>
        /// represents max Y coordinate of the surface
        /// </summary>
        public int MaxY { get; init; }

        public MarsSurface(int pointX, int pointY)
        {
            this.MaxX = pointX;
            this.MaxY = pointY;
        }

        private List<IRover> rovers = new List<IRover>();
        private IRover currentRover;

        /// <inheritdoc />
        public void SetPositionRover(int pointX, int pointY, string direction)
        {
            if (pointX > this.MaxX)
                throw new ArgumentOutOfRangeException("the x point sent is outside the surface.");
            if (pointY > this.MaxY)
                throw new ArgumentOutOfRangeException("the y point sent is outside the surface.");

            Point currengtPosition = new Point(pointX, pointY);
            Direction currengtDirection = (Direction)Enum.Parse(typeof(Direction), direction);
            currentRover = new Rover(currengtPosition, currengtDirection);
            rovers.Add(currentRover);
        }
        /// <inheritdoc />
        public void RedirectLastRover(char command)
        {
            if (currentRover is null)
                throw new NotImplementedException("Throw Exception No Rover Defined");

            // TODO: EŞ - Do we need to check if the rover's target is occupied by another rover?
            switch (command)
            {
                case RoverConstants.Actions.MoveForward:
                    currentRover.MoveForward();
                    break;
                case RoverConstants.Actions.TurnLeft:
                    currentRover.TurnLeft();
                    break;
                case RoverConstants.Actions.TurnRight:
                    currentRover.TurnRight();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        /// <inheritdoc />
        public string GetAllRoverLocations()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in rovers)
            {
                sb.AppendLine(item.GetLocation());
            }
            return sb.ToString();
        }
        /// <inheritdoc />
        public string GetCurrentgRoverLocations()
        {
            return currentRover.GetLocation();
        }

    }
}