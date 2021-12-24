using MarsRover.Business;
using MarsRover.Core;
using MarsRover.Common;

ISurface surface;

Console.ResetColor();
Console.WriteLine("Hello Mars!");

SetSurface();
ArgumentNullException.ThrowIfNull(surface);

var addAnotherRover = true;
int roverId = 0; 
while (addAnotherRover)
{
    roverId++;
    Console.WriteLine();
    Console.WriteLine($"================ Rover - {roverId} ================");
    SetRoverPosition();
    RedirectRover();
    GetRoverLocation();

    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Do you want to deploy another rover ? (Y)");
    var addAnotherRoverInput = Console.ReadLine();
    if (addAnotherRoverInput.ToUpper() != "Y")
    {
        addAnotherRover = false;
    }
}

string? ReadParameter()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    var result = Console.ReadLine();
    Console.ResetColor();
    return result;
}
void SetSurface()
{
    Console.WriteLine();
    Console.WriteLine("Enter the surface limits:");
    var surfaceLimit = ReadParameter();

    ArgumentNullException.ThrowIfNull(surfaceLimit);
    surfaceLimit = surfaceLimit.RemoveWhiteSpaces();
    if (surfaceLimit.Length != 2)
        throw new ArgumentException($"string length({surfaceLimit.Length}) is invalid", nameof(surfaceLimit));

    int maxX = (int)Char.GetNumericValue(surfaceLimit[0]);
    int maxY = (int)Char.GetNumericValue(surfaceLimit[1]);
    surface = new MarsSurface(maxX, maxY);
    Console.WriteLine("surface has been adjusted.");
}
void SetRoverPosition()
{
    Console.WriteLine();
    Console.WriteLine("Set rover position:");
    var roverPosition = ReadParameter();

    ArgumentNullException.ThrowIfNull(roverPosition);
    roverPosition = roverPosition.RemoveWhiteSpaces().ToUpper();
    if (roverPosition.Length != 3)
        throw new ArgumentException($"string length({roverPosition.Length}) is invalid", nameof(roverPosition));

    int x = (int)Char.GetNumericValue(roverPosition[0]);
    int y = (int)Char.GetNumericValue(roverPosition[1]);
    surface.SetPositionRover(x, y, roverPosition[2]);
    Console.WriteLine("rover is positioned.");
}
void RedirectRover()
{
    Console.WriteLine();
    Console.WriteLine("Please, enter command for move the rover:");
    var roverCommand = ReadParameter();

    ArgumentNullException.ThrowIfNull(roverCommand);
    roverCommand = roverCommand.RemoveWhiteSpaces().ToUpper();
    if (roverCommand.Length < 1)
        throw new ArgumentException($"string length({roverCommand.Length}) is invalid", nameof(roverCommand));

    roverCommand.ToList().ForEach(x => surface.RedirectLastRover(x));
}
void GetRoverLocation() {
    Console.Write("current position of rover: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(surface.GetCurrentRoverLocations());
}

