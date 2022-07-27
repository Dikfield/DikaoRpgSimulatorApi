using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public interface IHeroRepository
    {
        List<HeroEntity> GetAllHero();
        HeroEntity GetHeroId(int Id);
        HeroEntity GetStrongerHero(string _class);
        void ChangeHeroName(int heroId, string heroName);
        void UpdateHero(HeroEntity hero);
        void DeleteHero(HeroEntity hero);



    }
}
