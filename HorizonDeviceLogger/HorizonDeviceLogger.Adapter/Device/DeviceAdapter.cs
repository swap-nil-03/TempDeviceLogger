using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.RepositoryInterfaces;
using HorizonDeviceLogger.DB.DB;
using AutoMapper;

namespace HorizonDeviceLogger.Adapter
{
    public class DeviceAdapter : MasterAdapter, IDeviceAdapter, IDisposable
    {
        private readonly IDeviceRepository _deviceRepository = null;
        public DeviceAdapter(IDeviceRepository deviceRepository):base(new IOTLoggerEntities1())
        {
            this._deviceRepository = deviceRepository;
        }

        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        public int CreateDevice(DeviceDto model)
        {
            Device tblDevice = Mapper.Map<DeviceDto, Device>(model);
            _deviceRepository.CreateDevice(tblDevice, _dbContext);
            return _dbContext.SaveChanges();
        }

        public int DeleteDevice(DeviceDto model)
        {
            Device tblDevice = Mapper.Map<DeviceDto, Device>(model);
            _deviceRepository.DeleteDevice(tblDevice, _dbContext);
            return _dbContext.SaveChanges();
        }        

        public List<DeviceDto> GetAllDevices()
        {
            List<DeviceDto> result = new List<DeviceDto>();
            //Mapper.AssertConfigurationIsValid();            
            var received2 = _deviceRepository.GetAllDevice(_dbContext).ToList();
            Mapper.CreateMap<Device, DeviceDto>();
            result = Mapper.Map<List<Device>, List<DeviceDto>>(received2);            
            return result;
        }

        public DeviceDto GetDeviceById(int Id)
        {
            DeviceDto result = new DeviceDto();
            var received = _deviceRepository.GetAllDevice(_dbContext)
                .Where(x=>x.DeviceId==Id)
                .FirstOrDefault();

            Mapper.CreateMap<Device, DeviceDto>();
            result = Mapper.Map<Device, DeviceDto>(received);
            
            return result;
        }

        public int UpdateDevice(DeviceDto model)
        {
            Device tblDevice = Mapper.Map<DeviceDto, Device>(model);
            var existingDeviceData = _deviceRepository.GetAllDevice(_dbContext)
                .Where(x => x.DeviceId == model.DeviceId)
                .FirstOrDefault();

            _deviceRepository.UpdateDevice(existingDeviceData, tblDevice, _dbContext);

            return _dbContext.SaveChanges();
        }
    }
}
