using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO;
using HorizonDeviceLogger.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity;

namespace HorizonDeviceLogger.Adapter 
{
    public class DeviceLogAdapter : MasterAdapter, IDeviceLogAdapter, IDisposable
    {
        private readonly IDeviceLogRepository _deviceLogRepository = null;
        public DeviceLogAdapter(IDeviceLogRepository deviceLogRepository) : base(new IOTLoggerEntities1())
        {
            this._deviceLogRepository = deviceLogRepository;
        }

        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        public int CreateDeviceLog(DeviceLogDto deviceLogDto)
        {
            Mapper.CreateMap<DeviceLogDto, DeviceLog>();
            DeviceLog tblDeviceLog = Mapper.Map<DeviceLogDto, DeviceLog>(deviceLogDto);
            _deviceLogRepository.CreateDeviceLog(tblDeviceLog, _dbContext);
            return _dbContext.SaveChanges();
        }

        public List<DeviceLogDto> GetAllDeviceLog()
        {
            List<DeviceLogDto> result = new List<DeviceLogDto>();            
            var received2 = _deviceLogRepository.GetAllDeviceLog(_dbContext)
                .OrderByDescending(x=>x.ID)
                .Take(200).ToList();
            Mapper.CreateMap<DeviceLog, DeviceLogDto>();
            result = Mapper.Map<List<DeviceLog>, List<DeviceLogDto>>(received2);
            return result;
        }

        public DeviceLogDto GetTopFirstDeviceLog()
        {
            DeviceLogDto result = new DeviceLogDto();
            var received2 = _deviceLogRepository.GetAllDeviceLog(_dbContext)
                .OrderByDescending(x => x.ID)
                .FirstOrDefault();
            Mapper.CreateMap<DeviceLog, DeviceLogDto>();
            result = Mapper.Map<DeviceLog, DeviceLogDto>(received2);
            return result;
        }

        public DeviceLogDto SpGetLatestDeviceLog()
        {
            DeviceLogDto result = new DeviceLogDto();
            //var received2 = _deviceLogRepository.SpGetLatestDeviceLog(_dbContext);
            var received2 = _IOTLoggerEntities.SpGetLatestDeviceLog().FirstOrDefault();
            Mapper.CreateMap<SpGetLatestDeviceLog_Result, DeviceLogDto>();
            result = Mapper.Map<SpGetLatestDeviceLog_Result, DeviceLogDto>(received2);
            return result;
        }

        public List<DeviceLogDto> SpGetAllDeviceLog()
        {
            List<DeviceLogDto> result = new List<DeviceLogDto>();
            //var received2 = _deviceLogRepository.SpGetLatestDeviceLog(_dbContext);
            var received2 = _IOTLoggerEntities.sp_GetAllDeviceLogs().ToList();
            Mapper.CreateMap<sp_GetAllDeviceLogs_Result, DeviceLogDto>();
            result = Mapper.Map<List<sp_GetAllDeviceLogs_Result>, List<DeviceLogDto>>(received2);
            return result;
        }
    }
}
