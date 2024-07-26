using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class EquipmentDetail
{
    public int Id { get; set; }
	public string RepairActivity { get; set; } = string.Empty;
	public string RepairLineItemActivity { get; set; } = string.Empty;
    public string ResponsiblePartyTypeName { get; set; } = string.Empty;
    public string LLECode { get; set; } = string.Empty;
    public string LLEDescription { get; set; } = string.Empty;
    public string PartNo { get; set; } = string.Empty;
    public string DamageLocation { get; set; } = string.Empty;
    public string Component { get; set; } = string.Empty;
    public string DamageType { get; set; } = string.Empty;
    public string RepairType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SumofMeasurementLength { get; set; } = string.Empty;
    public string SumofMeasurementWidth { get; set; } = string.Empty;
    public string MeasurementUnit { get; set; } = string.Empty;
    public string EstimatedQuantity { get; set; } = string.Empty;
    public string ApprovedQuantity { get; set; } = string.Empty;
    public string ApprovedBy { get; set; } = string.Empty;
    public string EstimatedLabourHours { get; set; } = string.Empty;
    public string ApprovedLabourHours { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public string EstimatedLabourCost { get; set; } = string.Empty;
    public string ApprovedLabourCost { get; set; } = string.Empty;
    public string EstimatedMaterialCost { get; set; } = string.Empty;
    public string ApprovedMaterialCost { get; set; } = string.Empty;
    public string EstimatedCleaningCost { get; set; } = string.Empty;
    public string ApprovedCleaningCost { get; set; } = string.Empty;
    public string EstimatedTaxAmount { get; set; } = string.Empty;
    public string ApprovedTaxAmount { get; set; } = string.Empty;
    public string TotalEstimatedCost { get; set; } = string.Empty;
    public string TotalApprovedCost { get; set; } = string.Empty;
    public string ApprovedCostwithoutGST { get; set; } = string.Empty;
    public string IsThroughput { get; set; } = string.Empty;
    public string EstimateStatus { get; set; } = string.Empty;
    public string InMoveCode { get; set; } = string.Empty;
    public string InMoveDate { get; set; } = string.Empty;
    public string OutMoveCode { get; set; } = string.Empty;
    public string OutMoveDate { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Teus { get; set; } = string.Empty;
    public string LLIE_CODE { get; set; } = string.Empty;
    public string LLIE_Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string DepoCode { get; set; } = string.Empty;
    public string FinalCleaning { get; set; } = string.Empty;
    public string FinalMaterial { get; set; } = string.Empty;
    public string FinalLabour { get; set; } = string.Empty;
    public string TotalCost { get; set; } = string.Empty;
    public string NotKnown { get; set; } = string.Empty; // have to ask from ali what is this table name 
    public string FinalCost { get; set; } = string.Empty;

    public ZirconMaster ZirconMaster { get; set; }
    [ForeignKey(nameof(ZirconMaster))]
    public int? ZirconMasterId { get; set; }


}
