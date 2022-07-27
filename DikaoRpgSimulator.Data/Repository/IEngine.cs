using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public interface IEngine
    {
        public void newBattle(HeroEntity hero);

        public List<MonsterEntity> MonsterGenerator(int heroLevel);
    }
}
