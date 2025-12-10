// Agent.cs 
//

namespace Aics.App.Agents;

public sealed class Agent : IDisposable
{
  private bool _disposed;
  public bool IsAlive { get; set; }

  public Agent()
  {
    IsAlive = true;
    _disposed = false;
  }

  public void Dispose()
  {
    if (_disposed) return;
    _disposed = true;
    IsAlive = false;
  }

}




































