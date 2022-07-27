namespace DikaoRpgSimulator.Data
{
    public class DikaoRpgSimulator_DbContext : DbContext
    {
        public DbSet<HeroEntity>? HeroEntity { get; set; }
        public DbSet<MonsterEntity>? MonsterEntity { get; set; }
        public DbSet<BattleData>? BattleData { get; set; }

        public DikaoRpgSimulator_DbContext(DbContextOptions<DikaoRpgSimulator_DbContext> options) : base(options) { }
        public DikaoRpgSimulator_DbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Dikao_RpgSimulator");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {

        }


    }
}
