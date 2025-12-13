/////////////////////////////////////////////////////////////////////////
/// Environment.cs 
///
namespace Aics.App.Agent;

public class Environment
{
  public static readonly (int X, int Y) LocA = (0, 0);  // The two locations for the Vacuum world
  public static readonly (int X, int Y) LocB = (1, 0);

  public List<BaseObject> BaseObjects { get; set; } = new();
  public List<Agent> Agents { get; set; } = new();

  public Environment()
  {
    BaseObjects = new List<BaseObject>();
    Agents = new List<Agent>();
  }

  public virtual List<Type> BaseObjectClasses()
  {
    return new List<Type>();  // List of classes that can go into environment
  }

  public virtual Percept GetPercept(Agent agent)
  {
    throw new NotImplementedException();
  }

  public virtual void ExecuteAction(Agent agent, string action)
  {
    throw new NotImplementedException();
  }

  public virtual (int X, int Y)? DefaultLocation(BaseObject obj)
  {
    return null;
  }

  public virtual void ExogenousChange()
  {
    // pass - empty implementation
  }

  public virtual bool IsDone()
  {
    return !Agents.Any(agent => agent.IsAlive());
  }

  public void Step()
  {
    if (!IsDone())
    {
      List<string> actions = new List<string>();
      foreach (var agent in Agents)
      {
        if (agent.Alive)
        {
          actions.Add(agent.Program(GetPercept(agent)));
        }
        else
        {
          actions.Add("");
        }
      }

      for (int i = 0; i < Agents.Count; i++)
      {
        ExecuteAction(Agents[i], actions[i]);
      }

      ExogenousChange();
    }
  }

  public void Run(int steps = 1000)
  {
    for (int step = 0; step < steps; step++)
    {
      if (IsDone())
      {
        return;
      }
      Step();
    }
  }

  public List<BaseObject> ListBaseObjectsAt((int X, int Y) location, Type? tclass = null)
  {
    if (tclass == null)
      tclass = typeof(BaseObject);

    return BaseObjects.Where(obj =>
        obj.Location.X == location.X &&
        obj.Location.Y == location.Y &&
        tclass.IsAssignableFrom(obj.GetType())
    ).ToList();
  }

  public List<BaseObject> ListBaseObjectsAt(int location, Type? tclass = null)
  {
    if (tclass == null)
      tclass = typeof(BaseObject);

    // For single number location comparison
    return BaseObjects.Where(obj =>
        obj.Location.X == location &&
        tclass.IsAssignableFrom(obj.GetType())
    ).ToList();
  }

  public bool SomeBaseObjectsAt((int X, int Y) location, Type? tclass = null)
  {
    return ListBaseObjectsAt(location, tclass).Count != 0;
  }

  public bool SomeBaseObjectsAt(int location, Type? tclass = null)
  {
    return ListBaseObjectsAt(location, tclass).Count != 0;
  }

  public void AddBaseObject(object obj, (int X, int Y)? location = null)
  {
    BaseObject b;

    if (obj is AgentProgram ap)
    {
      b = new Agent(ap);
    }
    else if (obj is BaseObject bo)
    {
      b = bo;
    }
    else
    {
      b = new Agent();
    }

    if (BaseObjects.Contains(b))
    {
      Console.WriteLine("Can't add the same base object twice");
    }

    var loc = location ?? DefaultLocation(b) ?? (0, 0);
    b.Location = loc;
    BaseObjects.Add(b);

    if (b is Agent agent)
    {
      agent.Performance = 0;
      Agents.Add(agent);
    }
  }

  public void DeleteBaseObject(BaseObject obj)
  {
    try
    {
      BaseObjects.Remove(obj);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      Console.WriteLine("  in Environment delete_obj");
      Console.WriteLine($"  BaseObject to be removed: {obj} at {obj.Location}");
      Console.Write("  from list: ");
      Console.WriteLine(string.Join(", ", BaseObjects.Select(t => $"({t}, {t.Location})")));
    }

    if (obj is Agent agent && Agents.Contains(agent))
    {
      Agents.Remove(agent);
    }
  }
}





