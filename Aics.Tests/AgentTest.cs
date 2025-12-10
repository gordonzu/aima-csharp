///////////////////////////////////////////////////////
// AgentTest.cs 
//
using Aics.App.Agents;

namespace Aics.Tests;

public sealed class AgentTest : IDisposable
{
  private readonly Agent agent;
  private bool _disposed;

  public AgentTest()
  {
    agent = new Agent();
    _disposed = false;
  }

  public void Dispose()
  {
    if (_disposed) return;
    _disposed = true;
    (agent as IDisposable)?.Dispose();
  }

  [Fact]
  public void TestAgentIsAlive()
  {
    bool alive = agent.IsAlive;
    Assert.True(alive);
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


























}
