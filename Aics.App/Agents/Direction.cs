// Direction.cs 
//

namespace Aics.App.Agents;

public sealed class Direction
{
  public const string R = "right";
  public const string L = "left";
  public const string U = "up";
  public const string D = "down";

  private readonly string? _d;

  public Direction(string direction)
  {
    ArgumentNullException.ThrowIfNull(direction, "Null constructor parameter");
    _d = direction.ToLowerInvariant();

    if (_d != R && _d != L && _d != U && _d != D)
      throw new ArgumentException($"Invalid direction '{direction}'");
  }

  public (int, int) MoveForward((int, int) location)
  {
    (int x, int y) = location;

    if (_d == U)
      return (x, y - 1);
    if (_d == R)
      return (x + 1, y);
    if (_d == D)
      return (x, y + 1);
    if (_d == L)
      return (x - 1, y);

    return (0, 0);
  }

}


