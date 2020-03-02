using HorizonDeviceLogger.ActionInterfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.DataAnalytics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceLogAction _deviceLogAction = null;
        public HomeController(IDeviceLogAction deviceLogAction)
        {
            this._deviceLogAction = deviceLogAction;
        }
        // GET: DataAnalytics/Home
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> DownloadFile()
        {
            string webRootPath = Server.MapPath(Url.Content("~/Content/"));

            Guid guid = new Guid();
            //string filename1 = guid.ToString() + "_";
            string fileName = @"Logfile.xlsx";


            //Delete Previous excel file: .xlsx, .xls
            DirectoryInfo di = new DirectoryInfo(webRootPath);
            FileInfo[] files = di.GetFiles("*.xlsx")
                                 .Where(p => p.Extension == ".xlsx").ToArray();
            foreach (FileInfo fileItem in files)
                try
                {
                    fileItem.Attributes = FileAttributes.Normal;
                    System.IO.File.Delete(fileItem.FullName);
                }
                catch { }


            //string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(webRootPath, fileName));
            var memoryStream = new MemoryStream();

            List<string> headerList = new List<string>();

            #region Add Headers
            headerList.Add("ReceivedDateTime");
            headerList.Add("deviceID");
            headerList.Add("VRN");
            headerList.Add("VYN");
            headerList.Add("VBN");
            headerList.Add("IR");
            headerList.Add("IY");
            headerList.Add("IB");
            headerList.Add("W_R");
            headerList.Add("W_Y");
            headerList.Add("W_B");
            headerList.Add("VA_R");
            headerList.Add("VA_Y");
            headerList.Add("VA_B");
            headerList.Add("VAR_R");
            headerList.Add("VAR_Y");
            headerList.Add("VAR_B");
            headerList.Add("RY");
            headerList.Add("YB");
            headerList.Add("BR");
            headerList.Add("F");
            headerList.Add("KWH");
            headerList.Add("KVAH");
            headerList.Add("PFR");
            headerList.Add("PFY");
            headerList.Add("PFB");
            headerList.Add("PA1");
            headerList.Add("PA2");
            headerList.Add("PA3");
            headerList.Add("VAVG");
            headerList.Add("VSM");
            headerList.Add("IAVG");
            headerList.Add("ISM");
            headerList.Add("W_AV");
            headerList.Add("W_SM");
            headerList.Add("VAAVG");
            headerList.Add("VASM");
            headerList.Add("PFAV");
            headerList.Add("PFSM");
            headerList.Add("PAAV");
            headerList.Add("PASM");
            //headerList.Add("deviceID");
            headerList.Add("AI1");
            headerList.Add("AI2");
            headerList.Add("AI3");
            headerList.Add("AI4");
            headerList.Add("AI5");
            headerList.Add("AI6");
            headerList.Add("AI7");
            headerList.Add("AI8");
            headerList.Add("DI1");
            headerList.Add("DI2");
            headerList.Add("DI3");
            headerList.Add("DI4");
            headerList.Add("DI5");
            headerList.Add("DI6");
            headerList.Add("DI7");
            headerList.Add("DI8");
            headerList.Add("DO1");
            headerList.Add("DO2");
            headerList.Add("DO3");
            headerList.Add("DO4");
            headerList.Add("KW");
            headerList.Add("KVA");
            headerList.Add("KVAR");
            #endregion

            // --- Below code would create excel file with dummy data----  
            using (var fs = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("DeviceLogs");

                IRow row = excelSheet.CreateRow(0);
                for(int headerCount = 0; headerCount< headerList.Count;headerCount++)
                {
                    row.CreateCell(headerCount).SetCellValue(headerList[headerCount].ToString());
                }

                var receivedAllData = _deviceLogAction.SpGetAllDeviceLog();

                for (int i=0; i < receivedAllData.Count; i++)
                {
                    IRow rowTemp = excelSheet.CreateRow(i+1);

                    //Add data in each cell
                    rowTemp.CreateCell(0).SetCellValue(receivedAllData[i].deviceID.ToString());
                    rowTemp.CreateCell(1).SetCellValue(receivedAllData[i].ReceivedDateTime.ToString());
                    rowTemp.CreateCell(2).SetCellValue(receivedAllData[i].VRN.ToString());
                    rowTemp.CreateCell(3).SetCellValue(receivedAllData[i].VYN.ToString());
                    rowTemp.CreateCell(4).SetCellValue(receivedAllData[i].VBN.ToString());
                    rowTemp.CreateCell(5).SetCellValue(receivedAllData[i].IR.ToString());
                    rowTemp.CreateCell(6).SetCellValue(receivedAllData[i].IY.ToString());
                    rowTemp.CreateCell(7).SetCellValue(receivedAllData[i].IB.ToString());
                    rowTemp.CreateCell(8).SetCellValue(receivedAllData[i].W_R.ToString());
                    rowTemp.CreateCell(9).SetCellValue(receivedAllData[i].W_Y.ToString());
                    rowTemp.CreateCell(10).SetCellValue(receivedAllData[i].W_B.ToString());
                    rowTemp.CreateCell(11).SetCellValue(receivedAllData[i].VA_R.ToString());
                    rowTemp.CreateCell(12).SetCellValue(receivedAllData[i].VA_Y.ToString());
                    rowTemp.CreateCell(13).SetCellValue(receivedAllData[i].VA_B.ToString());
                    rowTemp.CreateCell(14).SetCellValue(receivedAllData[i].VAR_R.ToString());
                    rowTemp.CreateCell(15).SetCellValue(receivedAllData[i].VAR_Y.ToString());
                    rowTemp.CreateCell(16).SetCellValue(receivedAllData[i].VAR_B.ToString());
                    rowTemp.CreateCell(17).SetCellValue(receivedAllData[i].RY.ToString());
                    rowTemp.CreateCell(18).SetCellValue(receivedAllData[i].YB.ToString());
                    rowTemp.CreateCell(19).SetCellValue(receivedAllData[i].BR.ToString());
                    rowTemp.CreateCell(20).SetCellValue(receivedAllData[i].F.ToString());
                    rowTemp.CreateCell(21).SetCellValue(receivedAllData[i].KWH.ToString());
                    rowTemp.CreateCell(22).SetCellValue(receivedAllData[i].KVAH.ToString());
                    rowTemp.CreateCell(23).SetCellValue(receivedAllData[i].PFR.ToString());
                    rowTemp.CreateCell(24).SetCellValue(receivedAllData[i].PFY.ToString());
                    rowTemp.CreateCell(25).SetCellValue(receivedAllData[i].PFB.ToString());
                    rowTemp.CreateCell(26).SetCellValue(receivedAllData[i].PA1.ToString());
                    rowTemp.CreateCell(27).SetCellValue(receivedAllData[i].PA2.ToString());
                    rowTemp.CreateCell(28).SetCellValue(receivedAllData[i].PA3.ToString());
                    rowTemp.CreateCell(29).SetCellValue(receivedAllData[i].VAVG.ToString());
                    rowTemp.CreateCell(30).SetCellValue(receivedAllData[i].VSM.ToString());
                    rowTemp.CreateCell(31).SetCellValue(receivedAllData[i].IAVG.ToString());
                    rowTemp.CreateCell(32).SetCellValue(receivedAllData[i].ISM.ToString());
                    rowTemp.CreateCell(33).SetCellValue(receivedAllData[i].W_AV.ToString());
                    rowTemp.CreateCell(34).SetCellValue(receivedAllData[i].W_SM.ToString());
                    rowTemp.CreateCell(35).SetCellValue(receivedAllData[i].VAAVG.ToString());
                    rowTemp.CreateCell(36).SetCellValue(receivedAllData[i].VASM.ToString());
                    rowTemp.CreateCell(37).SetCellValue(receivedAllData[i].PFAV.ToString());
                    rowTemp.CreateCell(38).SetCellValue(receivedAllData[i].PFSM.ToString());
                    rowTemp.CreateCell(39).SetCellValue(receivedAllData[i].PAAV.ToString());
                    rowTemp.CreateCell(40).SetCellValue(receivedAllData[i].PASM.ToString());
                    rowTemp.CreateCell(41).SetCellValue(receivedAllData[i].AI1.ToString());
                    rowTemp.CreateCell(42).SetCellValue(receivedAllData[i].AI2.ToString());
                    rowTemp.CreateCell(43).SetCellValue(receivedAllData[i].AI3.ToString());
                    rowTemp.CreateCell(44).SetCellValue(receivedAllData[i].AI4.ToString());
                    rowTemp.CreateCell(45).SetCellValue(receivedAllData[i].AI5.ToString());
                    rowTemp.CreateCell(46).SetCellValue(receivedAllData[i].AI6.ToString());
                    rowTemp.CreateCell(47).SetCellValue(receivedAllData[i].AI7.ToString());
                    rowTemp.CreateCell(48).SetCellValue(receivedAllData[i].AI8.ToString());
                    rowTemp.CreateCell(49).SetCellValue(receivedAllData[i].DI1.ToString());
                    rowTemp.CreateCell(50).SetCellValue(receivedAllData[i].DI2.ToString());
                    rowTemp.CreateCell(51).SetCellValue(receivedAllData[i].DI3.ToString());
                    rowTemp.CreateCell(52).SetCellValue(receivedAllData[i].DI4.ToString());
                    rowTemp.CreateCell(53).SetCellValue(receivedAllData[i].DI5.ToString());
                    rowTemp.CreateCell(54).SetCellValue(receivedAllData[i].DI6.ToString());
                    rowTemp.CreateCell(55).SetCellValue(receivedAllData[i].DI7.ToString());
                    rowTemp.CreateCell(56).SetCellValue(receivedAllData[i].DI8.ToString());
                    rowTemp.CreateCell(57).SetCellValue(receivedAllData[i].DO1.ToString());
                    rowTemp.CreateCell(58).SetCellValue(receivedAllData[i].DO2.ToString());
                    rowTemp.CreateCell(59).SetCellValue(receivedAllData[i].DO3.ToString());
                    rowTemp.CreateCell(60).SetCellValue(receivedAllData[i].DO4.ToString());
                    rowTemp.CreateCell(61).SetCellValue(receivedAllData[i].KW.ToString());
                    rowTemp.CreateCell(62).SetCellValue(receivedAllData[i].KVA.ToString());
                    rowTemp.CreateCell(63).SetCellValue(receivedAllData[i].KVAR.ToString());
                }
                workbook.Write(fs);
            }
            using (var fileStream = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        private List<FileInfo> GetFiles(string path, params string[] extensions)
        {
            List<FileInfo> list = new List<FileInfo>();
            foreach (string ext in extensions)
                list.AddRange(new DirectoryInfo(path).GetFiles("*" + ext).Where(p =>
                      p.Extension.Equals(ext, StringComparison.CurrentCultureIgnoreCase))
                      .ToArray());
            return list;
        }
    }
}