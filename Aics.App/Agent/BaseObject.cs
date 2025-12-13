///////////////////////////////////////////////////
/// BaseObject.cs : represents any physical object that can appear in an environment.
///
namespace Aics.App.Agent;

public class BaseObject
{
  public (int X, int Y) Location { get; set; }

  public override string ToString()
  {
    var name = this.GetType().GetProperty("__name__")?.GetValue(this) as string ?? this.GetType().Name;
    return $"<{name}>";
  }

  public virtual bool IsAlive()
  {
    var aliveProperty = this.GetType().GetProperty("Alive");
    if (aliveProperty != null)
    {
      var aliveValue = aliveProperty.GetValue(this);
      return aliveValue is bool b && b;
    }
    return false;
  }

  public void ShowState()
  {
    Console.WriteLine("I don't know how to show state.");
  }

  public void Display(object canvas, int x, int y, int width, int height)
  {
  }


}
