using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public interface ISurface
    {
        /// <summary>
        /// Adds a new rover and set position it on the surface
        /// </summary>
        /// <param name="pointX">starting X coordinate</param>
        /// <param name="pointY">starting Y coordinate</param>
        /// <param name="direction">initial direction of the rover</param>
        void SetPositionRover(int pointX, int pointY, string direction);
        /// <summary>
        /// redirects to last added rover.
        /// </summary>
        /// <param name="command">Currently valid values ​​are any of the 'L', 'R', 'M' characters.</param>
        void RedirectLastRover(char command);
        /// <summary>
        /// Gets all rover locations as one line for each rover
        /// </summary>
        /// <returns></returns>
        string GetAllRoverLocations();
        /// <summary>
        /// Gets currengt rover locations as one line for each rover
        /// </summary>
        /// <returns></returns>
        string GetCurrentgRoverLocations();
    }
}
