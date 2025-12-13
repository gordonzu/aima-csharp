/////////////////////////////////////////////////////////////////////////////////
/// TrivialVacuumEnvironment.cs 
///
namespace Aics.App.Agent;

public class TrivialVacuumEnvironment : Environment
{
  public Dictionary<(int X, int Y), string> Status { get; set; }
  private readonly Random rand;

  public TrivialVacuumEnvironment() : base()
  {
    rand = new();
    Status = new()
    {
      { LocA, RandomChoice(new string[] { "Clean", "Dirty" }) },
      { LocB, RandomChoice(new string[] { "Clean", "Dirty" }) }
    };
  }

  private string RandomChoice(string[] choices)
  {
    return choices[rand.Next(choices.Length)];
  }

  private (int, int) RandomChoice((int, int)[] choices)
  {
    return choices[rand.Next(choices.Length)];
  }

  public override (int X, int Y)? DefaultLocation(BaseObject obj)
  {
    return RandomChoice(new (int, int)[] { LocA, LocB });
  }

  public override Percept GetPercept(Agent agent)
  {
    if (!Status.TryGetValue(agent.Location, out var state))
      throw new InvalidOperationException($"No status for location {agent.Location}");

    return new Percept(agent.Location, state);
  }

  public override void ExecuteAction(Agent agent, string action)
  {
    if (action == "Right")
    {
      agent.Location = LocB;
      agent.Performance -= 1;
    }
    if (action == "Left")
    {
      agent.Location = LocA;
      agent.Performance -= 1;
    }
    else if (action == "Suck")
    {
      if (Status[agent.Location] == "Dirty")
      {
        agent.Performance += 10;
      }
      Status[agent.Location] = "Clean";
    }
  }

}











