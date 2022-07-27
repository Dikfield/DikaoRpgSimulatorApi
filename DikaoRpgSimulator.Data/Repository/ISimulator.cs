using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public interface ISimulator
    {
        public void BattleEngine(HeroEntity hero, int rounds);
    }
}
