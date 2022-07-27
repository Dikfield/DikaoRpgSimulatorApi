using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public class BattleRepository:IBattleRepository
    {
        private readonly DikaoRpgSimulator_DbContext _context;

        public BattleRepository()
        {
            _context = new DikaoRpgSimulator_DbContext();
        }
        public BattleRepository(DikaoRpgSimulator_DbContext context)
        {
            _context = context;
        }
        BattleData IBattleRepository.GetLastBattle()
        {
            return _context.BattleData.OrderByDescending(c => c.Id).FirstOrDefault();
        }

        void IBattleRepository.SaveBattle(BattleData battle)
        {
            _context.BattleData.AddAsync(battle);
            _context.SaveChangesAsync();
        }
    }
}
