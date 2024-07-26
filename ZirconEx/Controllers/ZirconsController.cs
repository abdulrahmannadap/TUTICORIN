using DataAccess.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using OfficeOpenXml;
using System.Diagnostics;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ZirconEx.Controllers
{
    public class ZirconsController : Controller
    {
        #region Dependancy_And_Constructor
        private readonly IUnitOfWork _unitOfWork;
        Stopwatch stopwatch = new();
        public ZirconsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region ExcelDataFile_View
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region ExcelDataFile_Reserver
        [HttpPost]
        public async Task<IActionResult> ExcelDataFile(IFormFile excelFile)
        {
            if (excelFile == null)
            {
                ModelState.AddModelError("", "Please select an Excel file to upload.");
                return View();
            }

            // Setting the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var filePath = Path.GetTempFileName(); // creates a temporary file path on the server where the uploaded Excel file will be saved temporarily.

            using (var stream = new FileStream(filePath, FileMode.Create)) // A FileStream is created to write the uploaded file to the temporary file path.
            {
                await excelFile.CopyToAsync(stream); // excelFile.CopyToAsync(stream) copies the content of the uploaded file to the stream
            }

            var zirconMaster = new List<ZirconMaster>();

            using (var package = new ExcelPackage(new FileInfo(filePath))) // ExcelPackage is a class from the EPPlus library used to represent an Excel file.
            {
                var worksheet = package.Workbook.Worksheets[0]; // Accesses the first worksheet in the Excel workbook. It assumes that the data is located in this first worksheet.

                string previousEquipmentNumber = null; // This will store the temporary value after the first iteration then it will compare the current iteration with the Equipment Number
                int primaryKeyNumber = 0; // It will store ZirconMaster data after saving changes and initialize to EquipmentDetails table then it will work like a foreign key 

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // "worksheet.Dimension.End.Row" gives the last row number with data.
                {
                    var currentEquipmentNumber = worksheet.Cells[row, 6].Value?.ToString();

                    if (previousEquipmentNumber != currentEquipmentNumber) // This condition compares the current and previous iteration Equipment number, if they are not equal then it will add in master table and details table together
                    {
                        // Check if the cell is blank or EquipmentNumber is missing
                        if (string.IsNullOrWhiteSpace(currentEquipmentNumber))
                        {
                            // Skip the current iteration if EquipmentNumber is blank
                            continue;
                        }

                        var currentZirconMaster = new ZirconMaster
                        {
                            // Adding data in zirconmaster table and also in details table 
                            SrNo = worksheet.Cells[row, 1].Text,
                            CountryName = worksheet.Cells[row, 2].Text,
                            DepotCode = worksheet.Cells[row, 3].Text,
                            DepotName = worksheet.Cells[row, 4].Text,
                            VenderName = worksheet.Cells[row, 5].Text,
                            EquipmentNumber = worksheet.Cells[row, 6].Text,
                            EquipmentBuildDate = worksheet.Cells[row, 7].Text,
                            PONumber = worksheet.Cells[row, 8].Text,
                            EquipmentSizeType = worksheet.Cells[row, 9].Text,
                            ReceivedDate = worksheet.Cells[row, 10].Text,
                            EstimationDate = worksheet.Cells[row, 11].Text,
                            ApprovedDate = worksheet.Cells[row, 12].Text,
                            ApprovalDwellTime = worksheet.Cells[row, 13].Text,
                            RepairCompletionDate = worksheet.Cells[row, 14].Text,
                            RepairDwellTime = worksheet.Cells[row, 15].Text,
                            EstimateReferece = worksheet.Cells[row, 16].Text,
                            EstimateId = worksheet.Cells[row, 17].Text,
                            // EquipmentDetails = new List<EquipmentDetail>()
                        };

                        _unitOfWork.ZirconMasterRepo.Add(currentZirconMaster);
                        _unitOfWork.Save();
                        primaryKeyNumber = currentZirconMaster.Id; // After saving changes, the table Id is initialized and stored in this variable temporarily

                        var equipmentDetails = new EquipmentDetail
                        {
                            RepairActivity = worksheet.Cells[row, 18].Text,
                            RepairLineItemActivity = worksheet.Cells[row, 19].Text,
                            ResponsiblePartyTypeName = worksheet.Cells[row, 20].Text,
                            LLECode = worksheet.Cells[row, 21].Text,
                            LLEDescription = worksheet.Cells[row, 22].Text,
                            PartNo = worksheet.Cells[row, 23].Text,
                            DamageLocation = worksheet.Cells[row, 24].Text,
                            Component = worksheet.Cells[row, 25].Text,
                            DamageType = worksheet.Cells[row, 26].Text,
                            RepairType = worksheet.Cells[row, 27].Text,
                            Description = worksheet.Cells[row, 28].Text,
                            SumofMeasurementLength = worksheet.Cells[row, 29].Text,
                            SumofMeasurementWidth = worksheet.Cells[row, 30].Text,
                            MeasurementUnit = worksheet.Cells[row, 31].Text,
                            EstimatedQuantity = worksheet.Cells[row, 32].Text,
                            ApprovedQuantity = worksheet.Cells[row, 33].Text,
                            ApprovedBy = worksheet.Cells[row, 34].Text,
                            EstimatedLabourHours = worksheet.Cells[row, 35].Text,
                            ApprovedLabourHours = worksheet.Cells[row, 36].Text,
                            CurrencyCode = worksheet.Cells[row, 37].Text,
                            EstimatedLabourCost = worksheet.Cells[row, 38].Text,
                            ApprovedLabourCost = worksheet.Cells[row, 39].Text,
                            EstimatedMaterialCost = worksheet.Cells[row, 40].Text,
                            ApprovedMaterialCost = worksheet.Cells[row, 41].Text,
                            EstimatedCleaningCost = worksheet.Cells[row, 42].Text,
                            ApprovedCleaningCost = worksheet.Cells[row, 43].Text,
                            EstimatedTaxAmount = worksheet.Cells[row, 44].Text,
                            ApprovedTaxAmount = worksheet.Cells[row, 45].Text,
                            TotalEstimatedCost = worksheet.Cells[row, 46].Text,
                            TotalApprovedCost = worksheet.Cells[row, 47].Text,
                            ApprovedCostwithoutGST = worksheet.Cells[row, 48].Text,
                            IsThroughput = worksheet.Cells[row, 49].Text,
                            EstimateStatus = worksheet.Cells[row, 50].Text,
                            InMoveCode = worksheet.Cells[row, 51].Text,
                            InMoveDate = worksheet.Cells[row, 52].Text,
                            OutMoveCode = worksheet.Cells[row, 53].Text,
                            OutMoveDate = worksheet.Cells[row, 54].Text,
                            Size = worksheet.Cells[row, 55].Text,
                            Teus = worksheet.Cells[row, 56].Text,
                            LLIE_CODE = worksheet.Cells[row, 57].Text,
                            LLIE_Description = worksheet.Cells[row, 58].Text,
                            Location = worksheet.Cells[row, 59].Text,
                            DepoCode = worksheet.Cells[row, 60].Text,
                            FinalCleaning = worksheet.Cells[row, 61].Text,
                            FinalMaterial = worksheet.Cells[row, 62].Text,
                            FinalLabour = worksheet.Cells[row, 63].Text,
                            TotalCost = worksheet.Cells[row, 64].Text,
                            NotKnown = worksheet.Cells[row, 65].Text,
                            FinalCost = worksheet.Cells[row, 66].Text,
                        };

                        equipmentDetails.ZirconMasterId = primaryKeyNumber; // Assigning the FK value after saving changes
                        _unitOfWork.EquipmentDeatilRepo.Add(equipmentDetails);
                        _unitOfWork.Save();

                        previousEquipmentNumber = currentEquipmentNumber; // After saving in database, it will compare the current EquipmentNumber and give permission 
                    }
                    else
                    {
                        // Skip the current iteration if the EquipmentNumber is repeating
                        continue;
                    }
                }
            }

            return RedirectToAction("ExcelDataFile");
        }




        #endregion
    }



}


