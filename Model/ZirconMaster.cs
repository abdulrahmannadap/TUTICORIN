using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ZirconMaster
{
    public int Id { get; set; }
    public string SrNo { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string DepotCode { get; set; } = string.Empty;
    public string DepotName { get; set; } = string.Empty;
    public string VenderName { get; set; } = string.Empty;
    public string EquipmentNumber { get; set; } = string.Empty;
    public string EquipmentBuildDate { get; set; } = string.Empty;
    public string PONumber { get; set; } = string.Empty;
    public string EquipmentSizeType { get; set; } = string.Empty;
    public string ReceivedDate { get; set; } = string.Empty;
    public string EstimationDate { get; set; } = string.Empty;
    public string ApprovedDate { get; set; } = string.Empty;
    public string ApprovalDwellTime { get; set; } = string.Empty;
    public string RepairCompletionDate { get; set; } = string.Empty;
    public string RepairDwellTime { get; set; } = string.Empty;
    public string EstimateReferece { get; set; } = string.Empty;
    public string EstimateId { get; set; } = string.Empty;

    
}
