namespace AutenticacaoNoAspNetMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutenticacaoNoAspNetMVC.Models.UsuariosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AutenticacaoNoAspNetMVC.Models.UsuariosContext";
        }

        protected override void Seed(AutenticacaoNoAspNetMVC.Models.UsuariosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
