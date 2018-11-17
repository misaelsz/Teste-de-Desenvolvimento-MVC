namespace TesteBNE.BLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniciarbanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome_Aluno = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome_Disciplina = c.String(),
                        Aluno_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alunos", t => t.Aluno_ID)
                .Index(t => t.Aluno_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplinas", "Aluno_ID", "dbo.Alunos");
            DropIndex("dbo.Disciplinas", new[] { "Aluno_ID" });
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Alunos");
        }
    }
}
