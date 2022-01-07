using System.Collections.Generic;
namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      Machines = new HashSet<Machine>();
    }
    public int EngineerId {get;set;}
    public string EngineerName {get;set;}
    public virtual ICollection<Machine> Machines {get;}
  }
}