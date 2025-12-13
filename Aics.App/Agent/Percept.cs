////////////////////////////////////////////////////////////
/// Percept.cs 
///
namespace Aics.App.Agent;

public record Percept((int x, int y) Location, string State)
{
  public override string ToString()
        => $"Percept(Location=({Location.x},{Location.y}), State={State})";
}

