using System.Collections.Generic;
namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      LicensedEngineers = new HashSet<Engineer>();
    }
    public int MachineId {get;set;}
    public string DeviceName {get;set;}
    public virtual ICollection<Engineer> LicensedEngineers {get;}
  }
}