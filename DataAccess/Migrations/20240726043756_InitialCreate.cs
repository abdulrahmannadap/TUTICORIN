using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZirconMasterDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepotCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentBuildDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentSizeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalDwellTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairCompletionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairDwellTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateReferece = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZirconMasterDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairLineItemActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsiblePartyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LLECode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LLEDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumofMeasurementLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumofMeasurementWidth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedLabourHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedLabourHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedLabourCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedLabourCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedMaterialCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedMaterialCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedCleaningCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedCleaningCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedTaxAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedTaxAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalApprovedCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedCostwithoutGST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsThroughput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InMoveCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InMoveDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutMoveCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutMoveDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LLIE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LLIE_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalCleaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalLabour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotKnown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZirconMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentDetailsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentDetailsTable_ZirconMasterDetailsTable_ZirconMasterId",
                        column: x => x.ZirconMasterId,
                        principalTable: "ZirconMasterDetailsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentDetailsTable_ZirconMasterId",
                table: "EquipmentDetailsTable",
                column: "ZirconMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentDetailsTable");

            migrationBuilder.DropTable(
                name: "ZirconMasterDetailsTable");
        }
    }
}
