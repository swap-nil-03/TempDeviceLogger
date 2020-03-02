using AutoMapper;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO;
using HorizonDeviceLogger.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Adapter
{
    public class DeviceTypeAdapter : MasterAdapter, IDeviceTypeAdapter, IDisposable
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository = null;
        public DeviceTypeAdapter(IDeviceTypeRepository deviceTypeRepository) : base(new IOTLoggerEntities1())
        {
            this._deviceTypeRepository = deviceTypeRepository;
        }

        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        public int CreateDeviceType(DeviceTypeDto model)
        {
            Mapper.CreateMap<DeviceTypeDto, DeviceType>();
            DeviceType tblDevice = Mapper.Map<DeviceTypeDto, DeviceType>(model);
            _deviceTypeRepository.CreateDeviceType(tblDevice, _dbContext);
            return _dbContext.SaveChanges();
        }

        public int DeleteDeviceType(DeviceTypeDto model)
        {
            DeviceType tblDevice = Mapper.Map<DeviceTypeDto, DeviceType>(model);
            _deviceTypeRepository.DeleteDeviceType(tblDevice, _dbContext);
            return _dbContext.SaveChanges();
        }

        public List<DeviceTypeDto> GetAllDevicesType()
        {
            List<DeviceTypeDto> result = new List<DeviceTypeDto>();
            //Mapper.AssertConfigurationIsValid();            
            var received2 = _deviceTypeRepository.GetAllDeviceType(_dbContext).ToList();
            Mapper.CreateMap<DeviceType, DeviceTypeDto>();
            result = Mapper.Map<List<DeviceType>, List<DeviceTypeDto>>(received2);
            return result;
        }

        public DeviceTypeDto GetDeviceTypeById(int Id)
        {
            DeviceTypeDto result = new DeviceTypeDto();
            var received = _deviceTypeRepository.GetAllDeviceType(_dbContext)
                .Where(x => x.DeviceTypeId == Id)
                .FirstOrDefault();

            Mapper.CreateMap<DeviceType, DeviceTypeDto>();
            result = Mapper.Map<DeviceType, DeviceTypeDto>(received);

            return result;
        }

        public int UpdateDeviceType(DeviceTypeDto model)
        {
            DeviceType tblDeviceType = Mapper.Map<DeviceTypeDto, DeviceType>(model);
            var existingDeviceTypeData = _deviceTypeRepository.GetAllDeviceType(_dbContext)
                .Where(x => x.DeviceTypeId == model.DeviceTypeId)
                .FirstOrDefault();

            _deviceTypeRepository.UpdateDeviceType(existingDeviceTypeData, tblDeviceType, _dbContext);

            return _dbContext.SaveChanges();
        }

        public bool IsExistsDeviceTypeName(string DeviceTypeName)
         {
            var result = _deviceTypeRepository.GetAllDeviceType(_dbContext)
                .Where(x => x.DeviceTypeName == DeviceTypeName)
                .FirstOrDefault();

            if(result==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
