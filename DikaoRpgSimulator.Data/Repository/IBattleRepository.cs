using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public interface IBattleRepository
    {
        BattleData GetLastBattle();
        void SaveBattle(BattleData battle);
    }
}
