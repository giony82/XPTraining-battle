using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class Army
    {
        public Army()
        {
            Soldiers = new List<Soldier>();
        }

        public List<Soldier> Soldiers { get; }

        public void AddSoldiers(IList<Soldier> soldiers)
        {
            Soldiers.AddRange(soldiers);
        }

        public void RemoveSoldier(Soldier soldier)
        {
        }

        public Soldier GetFrontMan()
        {
            return Soldiers.FirstOrDefault();
        }
    }
}