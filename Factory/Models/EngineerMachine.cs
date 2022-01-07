namespace Factory.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId {get;set;}
    public int MachineId {get;set;}
    public virtual Machine Machine {get;}
    public int EngineerId {get;set;}
    public virtual Engineer Engineer {get;}
  }
}