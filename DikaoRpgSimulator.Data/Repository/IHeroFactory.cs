using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Data.Repository
{
    public interface IHeroFactory
    {
        public HeroEntity Create(string? _class, string? name);
        public void SaveHero(HeroEntity entity);
    }
}
