///////////////////////////////////////////////////////
/// Location.cs 
///
namespace Aics.App.Agent;

public class Location
{
  public int X { get; set; }
  public int Y { get; set; }

  public Location(int x, int y) { X = x; Y = y; }
  public override string ToString() => $"({X}, {Y})";

  public void MoveBy(int dx, int dy) => (X, Y) = (X + dx, Y + dy);
  public void MoveTo(int x, int y) => (X, Y) = (x, y);

  public Location Clone() => new(X, Y);
}


