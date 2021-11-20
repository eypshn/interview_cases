// See https://aka.ms/new-console-template for more information
using Hepsiburada.MarsRover.Business;
using Hepsiburada.MarsRover.Core;

Console.WriteLine("Hello Mars!");
Console.WriteLine("Enter the surface limits");
var surfaceLimit = Console.ReadLine();
var limits = surfaceLimit.Split(" ");
if (limits.Length == 2)
{
    var maxX = Convert.ToInt32(limits[0]);
    var maxY = Convert.ToInt32(limits[1]);

    ISurface surface = new MarsSurface(maxX, maxY);

    var addAnotherRover = true;
    while (addAnotherRover)
    {
        Console.WriteLine("Set rover position :");
        var roverPosition = Console.ReadLine();
        var parameters = roverPosition.Split(' ');

        if (parameters.Length == 3)
        {
            surface.SetPositionRover(Convert.ToInt32(parameters[0]), Convert.ToInt32(parameters[1]), parameters[2]);
            Console.WriteLine("rover is positioned.");

            Console.WriteLine("Please, enter command for move the rover");
            var roverCommand = Console.ReadLine();
            roverCommand.ToList().ForEach(x => surface.RedirectLastRover(x));

            Console.WriteLine($"Rover position:{surface.GetCurrentgRoverLocations()}");
        }

        Console.WriteLine("Do you want to deploy another rover ? (Y)");
        var addAnotherRoverInput = Console.ReadLine();
        if (addAnotherRoverInput.ToUpper() != "Y")
        {
            addAnotherRover = false;
        }
    }

}
