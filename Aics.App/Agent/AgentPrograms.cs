//////////////////////////////////////////////////////////////////////////////////
/// AgentPrograms.cs 
///
namespace Aics.App.Agent;

public static class AgentPrograms
{
  public static AgentProgram RandomAgentProgram(List<string> actions)
  {
    Random r = new();
    return (percept) => actions[r.Next(actions.Count)];
  }

  public static Agent RandomVacuumAgent()
  {
    return new Agent(RandomAgentProgram(["Right", "Left", "Suck", "NoOp"]));
  }
}
