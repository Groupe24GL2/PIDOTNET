namespace PIDOTNET.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t60 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pi4gl.employee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi4gl.ficheevaluation",
                c => new
                    {
                        idEmployee = c.Int(nullable: false),
                        idEvaluation = c.Int(nullable: false),
                        averageRate = c.Single(nullable: false),
                        comment = c.String(maxLength: 255, unicode: false),
                        desription = c.String(maxLength: 255, unicode: false),
                        noteCommunication = c.Int(),
                        noteDeadlineRespect = c.Int(),
                        noteInteraction = c.Int(),
                        noteLeadership = c.Int(),
                        noteOrganisation = c.Int(),
                        noteRegularity = c.Int(),
                        noteTeamWork = c.Int(),
                        noteWorkQuality = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEmployee, t.idEvaluation })
                .ForeignKey("pi4gl.evaluation", t => t.idEvaluation)
                .ForeignKey("pi4gl.employee", t => t.idEmployee)
                .Index(t => t.idEmployee)
                .Index(t => t.idEvaluation);
            
            CreateTable(
                "pi4gl.evaluation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        etat = c.Boolean(nullable: false, storeType: "bit"),
                        nameEvaluation = c.String(maxLength: 255, unicode: false),
                        scoreEvaluation = c.Single(nullable: false),
                        typeEvaluation = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi4gl.evaluation360",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        etat = c.Boolean(nullable: false, storeType: "bit"),
                        nameEvaluation = c.String(maxLength: 255, unicode: false),
                        noteEvaluation = c.Single(nullable: false),
                        avisEvaluation = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi4gl.missionexpenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accommodationFees = c.Int(nullable: false),
                        ceiling = c.Int(nullable: false),
                        idMission = c.Int(nullable: false),
                        mealFees = c.Int(nullable: false),
                        transportationCosts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi4gl.mission",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateDeb = c.DateTime(precision: 0),
                        dateFin = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        place = c.String(maxLength: 255, unicode: false),
                        repaymentMethod = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi4gl.repayment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idEmp = c.Int(nullable: false),
                        idMess = c.Int(nullable: false),
                        money = c.Int(nullable: false),
                        ribEmp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pi4gl.ficheevaluation", "idEmployee", "pi4gl.employee");
            DropForeignKey("pi4gl.ficheevaluation", "idEvaluation", "pi4gl.evaluation");
            DropIndex("pi4gl.ficheevaluation", new[] { "idEvaluation" });
            DropIndex("pi4gl.ficheevaluation", new[] { "idEmployee" });
            DropTable("pi4gl.repayment");
            DropTable("pi4gl.mission");
            DropTable("pi4gl.missionexpenses");
            DropTable("pi4gl.evaluation360");
            DropTable("pi4gl.evaluation");
            DropTable("pi4gl.ficheevaluation");
            DropTable("pi4gl.employee");
        }
    }
}
