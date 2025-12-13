///////////////////////////////////////////////////////////////
// Agent.cs 
//
namespace Aics.App.Agent;

public delegate string AgentProgram(Percept percept);

public sealed class Agent : BaseObject, IDisposable
{
  private bool _disposed;
  public AgentProgram Program { get; set; }
  public bool Bump { get; set; }
  public bool Alive { get; set; }
  public List<BaseObject> Holding { get; set; } = new();
  //public Location Loc { get; set; }
  public double Performance { get; set; }

  public Agent(AgentProgram? program = null)
  {
    Alive = true;
    Bump = false;
    //Loc = new Location(0, 0);
    Performance = 0;
    _disposed = false;

    if (program is null)
    {
      Console.WriteLine($"No valid program for- {GetType().Name}, falling back to default that throws.");
      Program = p => throw new InvalidOperationException("No program assigned to agent.");
    }
    else { Program = program; }
  }

  public static bool CanGrab() => false;

  public void Dispose()
  {
    if (_disposed) return;
    _disposed = true;
    Alive = false;
  }

}

















































