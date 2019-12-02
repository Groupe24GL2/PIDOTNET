namespace PIDOTNET.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
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
                "pi4gl.evaluation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        etat = c.Boolean(nullable: false),
                        nameEvaluation = c.String(maxLength: 255, unicode: false),
                        scoreEvaluation = c.Single(nullable: false),
                        typeEvaluation = c.String(maxLength: 255, unicode: false),
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
                        dateDeb = c.DateTime(),
                        dateFin = c.DateTime(),
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
            
            CreateTable(
                "pi4gl.task",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idM = c.Int(nullable: false),
                        state = c.Int(),
                        task = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.employee_evaluation",
                c => new
                    {
                        employee_id = c.Int(nullable: false),
                        evaluations_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.employee_id, t.evaluations_id })
                .ForeignKey("pi4gl.employee", t => t.employee_id, cascadeDelete: true)
                .ForeignKey("pi4gl.evaluation", t => t.evaluations_id, cascadeDelete: true)
                .Index(t => t.employee_id)
                .Index(t => t.evaluations_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pi4gl.ficheevaluation", "idEmployee", "pi4gl.employee");
            DropForeignKey("dbo.employee_evaluation", "evaluations_id", "pi4gl.evaluation");
            DropForeignKey("dbo.employee_evaluation", "employee_id", "pi4gl.employee");
            DropForeignKey("pi4gl.ficheevaluation", "idEvaluation", "pi4gl.evaluation");
            DropIndex("dbo.employee_evaluation", new[] { "evaluations_id" });
            DropIndex("dbo.employee_evaluation", new[] { "employee_id" });
            DropIndex("pi4gl.ficheevaluation", new[] { "idEvaluation" });
            DropIndex("pi4gl.ficheevaluation", new[] { "idEmployee" });
            DropTable("dbo.employee_evaluation");
            DropTable("pi4gl.task");
            DropTable("pi4gl.repayment");
            DropTable("pi4gl.mission");
            DropTable("pi4gl.missionexpenses");
            DropTable("pi4gl.ficheevaluation");
            DropTable("pi4gl.evaluation");
            DropTable("pi4gl.employee");
        }
    }
}
