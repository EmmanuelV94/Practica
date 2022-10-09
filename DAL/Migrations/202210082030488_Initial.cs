namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssignments",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Carnet = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        SecondName = c.String(maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        SecondLastName = c.String(nullable: false, maxLength: 100),
                        DateBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Carnet);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Carnet = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        SecondName = c.String(maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        SecondLastName = c.String(nullable: false, maxLength: 100),
                        DateBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Carnet);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssignments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssignments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.CourseAssignments", new[] { "CourseId" });
            DropIndex("dbo.CourseAssignments", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseAssignments");
        }
    }
}
