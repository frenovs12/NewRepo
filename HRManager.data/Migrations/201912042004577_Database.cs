namespace HRManager.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        CriterionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Response = c.Boolean(),
                        Survey_SurveyId = c.Int(),
                    })
                .PrimaryKey(t => t.CriterionId)
                .ForeignKey("dbo.Surveys", t => t.Survey_SurveyId)
                .Index(t => t.Survey_SurveyId);
            
            CreateTable(
                "dbo.DayOffs",
                c => new
                    {
                        DayOffId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(),
                        Balance = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayOffId);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Survey_SurveyId = c.Int(),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.Surveys", t => t.Survey_SurveyId)
                .Index(t => t.Survey_SurveyId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SurveyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "Survey_SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Criteria", "Survey_SurveyId", "dbo.Surveys");
            DropIndex("dbo.Responses", new[] { "Survey_SurveyId" });
            DropIndex("dbo.Criteria", new[] { "Survey_SurveyId" });
            DropTable("dbo.Surveys");
            DropTable("dbo.Responses");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Criteria");
        }
    }
}
