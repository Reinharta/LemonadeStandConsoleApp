namespace LemonadeStandConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HighScoresLStand : DbContext
    {
        public HighScoresLStand()
            : base("name=HighScoresLStand")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
