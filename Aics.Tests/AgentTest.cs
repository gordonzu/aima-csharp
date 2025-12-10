///////////////////////////////////////////////////////
// AgentTest.cs 
//
using Aics.App.Agents;

namespace Aics.Tests;

public sealed class AgentTest : IDisposable
{
  private bool _disposed;

  public AgentTest()
  {
    _disposed = false;
  }

  public void Dispose()
  {
    if (_disposed) return;
    _disposed = true;
  }

  [Fact]
  public void TestMoveForward()
  {
    var dir = new Direction("up");
    var location = dir.MoveForward((0, 0));
    Assert.Equal(location, (0, -1));

    dir = new Direction(Direction.R);
    location = dir.MoveForward((0, 0));
    Assert.Equal(location, (1, 0));

    dir = new Direction(Direction.D);
    location = dir.MoveForward((0, 0));
    Assert.Equal(location, (0, 1));

    dir = new Direction("left");
    location = dir.MoveForward((0, 0));
    Assert.Equal(location, (-1, 0));

  }

  [Fact]
  public void TestAdd()
  {
    var dir = new Direction(Direction.U);
    var d1 = dir + "right";
    var d2 = dir + "left";

    Assert.Equal(Direction.R, d1.Value);
    Assert.Equal(Direction.L, d2.Value);

    dir = new Direction("right");
    d1 = dir + Direction.L;
    d2 = dir + Direction.R;

    Assert.Equal("up", d1.Value);
    Assert.Equal("down", d2.Value);

    dir = new Direction("down");
    d1 = dir + "right";
    d2 = dir + "left";

    Assert.Equal("left", d1.Value);
    Assert.Equal("right", d2.Value);

    dir = new Direction(Direction.L);
    d1 = dir + Direction.R;
    d2 = dir + Direction.L;

    Assert.Equal(Direction.U, d1.Value);
    Assert.Equal(Direction.D, d2.Value);
  }
























}
