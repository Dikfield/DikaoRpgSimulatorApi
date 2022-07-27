using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DikaoRpgSimulator_DbContext _context;

        public HeroRepository()
        {
            _context = new DikaoRpgSimulator_DbContext();
        }
        public HeroRepository(DikaoRpgSimulator_DbContext context)
        {
            _context = context;
        }

        void IHeroRepository.DeleteHero(HeroEntity hero)
        {
            _context.Remove(hero);
            _context.SaveChangesAsync();
        }

        List<HeroEntity> IHeroRepository.GetAllHero()
        {
            return _context.HeroEntity.ToList();
        }

        HeroEntity IHeroRepository.GetHeroId(int id)
        {
            return _context.HeroEntity.Find(id);
        }

        HeroEntity IHeroRepository.GetStrongerHero(string _class)
        {
            return _context.HeroEntity.Where(c => c.Class == _class).OrderByDescending(c => c.Level).FirstOrDefault();
        }


        void IHeroRepository.ChangeHeroName(int heroId, string heroName)
        {
            var hero = _context.HeroEntity.Where(h => h.Id == heroId).FirstOrDefault();
            hero.Name = heroName;
            _context.SaveChangesAsync();
        }

        void IHeroRepository.UpdateHero(HeroEntity hero)
        {

            if (hero != null)
            {
                _context.HeroEntity.Update(hero);
                _context.SaveChanges();
            }
        }
    }
}
