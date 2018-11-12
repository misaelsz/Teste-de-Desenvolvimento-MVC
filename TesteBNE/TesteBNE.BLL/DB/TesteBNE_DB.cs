namespace TesteBNE.BLL.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TesteBNE.BLL.DTO;

    public class TesteBNE_DB : DbContext
    {
        // Your context has been configured to use a 'TesteBNE_DB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TesteBNE.BLL.DB.TesteBNE_DB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TesteBNE_DB' 
        // connection string in the application configuration file.
        public TesteBNE_DB()
            : base("name=TesteBNE_DB")
        {
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public  DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}