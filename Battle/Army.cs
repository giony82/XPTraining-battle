using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public class Army
    {
        public Army()
        {
            Soldiers=new List<Soldier>();
        }
        public void AddSoldiers(IList<Soldier> soldiers)
        {
           Soldiers.AddRange(soldiers);
        }

        public List<Soldier> Soldiers { get; }

        public Soldier GetFrontMan()
        {
            return Soldiers.FirstOrDefault();
        }
    }
}
