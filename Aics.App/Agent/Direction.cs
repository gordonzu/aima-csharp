// Direction.cs 
//

namespace Aics.App.Agent;

public sealed class Direction
{
  public const string R = "right";
  public const string L = "left";
  public const string U = "up";
  public const string D = "down";

  public string Value { get; }

  public Direction(string direction)
  {
    ArgumentNullException.ThrowIfNull(direction, "Null constructor parameter");
    var _d = direction.ToLowerInvariant();

    if (_d != R && _d != L && _d != U && _d != D)
      throw new ArgumentException($"Invalid direction '{direction}'");

    Value = _d;
  }

  public (int, int) MoveForward((int x, int y) from)
  {
    return Value switch
    {
      R => (from.x + 1, from.y),
      L => (from.x - 1, from.y),
      U => (from.x, from.y - 1),
      D => (from.x, from.y + 1),
      _ => throw new InvalidOperationException("Unexpected direction")
    };
  }

  public static Direction operator +(Direction d, string heading)
  {
    ArgumentNullException.ThrowIfNull(d, "Direction is null");
    ArgumentNullException.ThrowIfNull(heading, "heading is null");

    var h = heading.ToLowerInvariant();
    if (h != R && h != L)
      throw new ArgumentException("Heading must be 'right' or 'left'.", nameof(heading));
    return d.Turn(h);
  }

  private Direction Turn(string heading)
  {
    return Value switch
    {
      R => heading == R ? new Direction(D) : new Direction(U),
      L => heading == R ? new Direction(U) : new Direction(D),
      U => heading == R ? new Direction(R) : new Direction(L),
      D => heading == R ? new Direction(L) : new Direction(R),
      _ => throw new InvalidOperationException("Unexpected direction")
    };
  }
}


