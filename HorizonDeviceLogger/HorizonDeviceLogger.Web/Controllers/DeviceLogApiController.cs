using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.RepositoryInterfaces;
using HorizonDeviceLogger.Models.DTO;
using HorizonDeviceLogger.Action.DeviceLog;
using HorizonDeviceLogger.Adapter;
using HorizonDeviceLogger.Repository;

namespace HorizonDeviceLogger.Web.Controllers
{
    public class DeviceLogApiController : ApiController
    {
        private readonly IDeviceLogAction _deviceLogAction = null;
        public DeviceLogApiController(IDeviceLogAction deviceLogAction)
        {
            //this._deviceLogAction = deviceLogAction;

            this._deviceLogAction = new DeviceLogAction(new DeviceLogAdapter(new DeviceLogRepository()));
        }
        public DeviceLogApiController()
        {
            this._deviceLogAction = new DeviceLogAction(new DeviceLogAdapter(new DeviceLogRepository()));
        }
        [HttpGet]
        [Route("api/DL/P/{msg}")]
        public IHttpActionResult GetMessage(string msg)
        {
            try
            {
                string received = PustToDeviceLogger(msg);
                // AddDataLocal(msg, received);
                return Ok(received);//200 status code        
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/test/GetMessage/{msg}")]
        public IHttpActionResult getmessage(string msg)
        {
            try
            {
                string received = PustToDeviceLogger(msg);
                // AddDataLocal(msg, received);
                return Ok(received);//200 status code        
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string PustToDeviceLogger(string msg)
        {
            string[] received = msg.Split(';');
            //AddToQueue(msg, received.Length);
            try
            {
                if (received.Count() >= 22)
                {
                    DeviceLogDto model = new DeviceLogDto();
                    model.ReceivedDateTime = DateTime.Now;

                    model.deviceID = received[0].Trim().Replace(",", ".").ToString();
                    model.VRN = received[1].Trim().Replace(",", ".");
                    model.VYN = received[2].Trim().Replace(",", ".");
                    model.VBN = received[3].Trim().Replace(",", ".");
                    model.IR = received[4].Trim().Replace(",", ".");
                    model.IY = received[5].Trim().Replace(",", ".");
                    model.IB = received[6].Trim().Replace(",", ".");
                    model.F = received[7].Trim().Replace(",", ".");

                    model.KW = received[8].Trim().Replace(",", ".");
                    model.KVA = received[9].Trim().Replace(",", ".");

                    model.KVAR = received[10].Trim().Replace(",", ".");

                    model.PFR = received[10].Trim().Replace(",", ".");
                    model.KWH = received[11].Trim().Replace(",", ".");
                    model.KVAH = received[12].Trim().Replace(",", ".");

                    model.AI1 = received[13].Trim().Replace(",", ".");
                    model.AI2 = received[14].Trim().Replace(",", ".");
                    model.AI3 = received[15].Trim().Replace(",", ".");
                    model.AI4 = received[16].Trim().Replace(",", ".");
                    model.AI5 = received[17].Trim().Replace(",", ".");
                    model.AI6 = received[18].Trim().Replace(",", ".");
                    model.AI7 = received[19].Trim().Replace(",", ".");
                    model.AI8 = received[20].Trim().Replace(",", ".");

                    if (string.IsNullOrEmpty(received[21].Trim().Replace(",", ".")) == false)
                    {
                        char[] digitalArr = received[21].Trim().Replace(",", ".").ToString().Trim().ToArray();
                        if (digitalArr.Length == 8)
                        {
                            model.DI1 = digitalArr[0].ToString();
                            model.DI2 = digitalArr[1].ToString();
                            model.DI3 = digitalArr[2].ToString();
                            model.DI4 = digitalArr[3].ToString();
                            model.DI5 = digitalArr[4].ToString();
                            model.DI6 = digitalArr[5].ToString();
                            model.DI7 = digitalArr[6].ToString();
                            model.DI8 = digitalArr[7].ToString();
                        }
                    }
                    //push to db
                    return _deviceLogAction.CreateDeviceLog(model).ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "error";
        }

        private static decimal ConvertToDouble(string value)
        {
            decimal result = 0;
            decimal.TryParse(value, out result);
            return result;
        }        
    }
}
