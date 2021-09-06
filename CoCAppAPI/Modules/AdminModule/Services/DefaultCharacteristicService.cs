using DbLibrary.DAL;
using DbLibrary.Models.Characteristic;
using DbLibrary.Models.Characteristic.Request;
using DbLibrary.Models.Characteristic.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminModule.Services
{
    public interface IDefaultCharacteristicService
    {
        public DefaultCharacteristicResponse Get(Guid id);
        public IEnumerable<DefaultCharacteristicResponse> GetAll();
        public bool Add(DefaultCharacteristicRequest model);
        public bool Edit(DefaultCharacteristic model);
        public bool Delete(Guid id);
        public bool Update(Guid id, DefaultCharacteristicRequest model);
        
    }
    public class DefaultCharacteristicService : IDefaultCharacteristicService
    {
        private readonly CoCDbContext _context;

        public DefaultCharacteristicService(CoCDbContext context)
        {
            _context = context;
        }
        public bool Add(DefaultCharacteristicRequest model)
        {
            _context.DefaultCharacteristics.Add(new DefaultCharacteristic(model));
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            _context.DefaultCharacteristics.Remove(
                _context.DefaultCharacteristics.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public bool Edit(DefaultCharacteristic model)
        {
            _context.DefaultCharacteristics.Update(model);
            return _context.SaveChanges() > 0;
        }

        public DefaultCharacteristicResponse Get(Guid id)
        {
            var result = _context.DefaultCharacteristics.FirstOrDefault(x => x.Id == id);
            return new DefaultCharacteristicResponse(result);
        }

        public IEnumerable<DefaultCharacteristicResponse> GetAll()
        {
            var result = _context.DefaultCharacteristics.Select(x => new DefaultCharacteristicResponse(x)).ToList();
            return result;
        }

        public bool Update(Guid id, DefaultCharacteristicRequest model)
        {
            DefaultCharacteristic update = new DefaultCharacteristic()
            {
                Id = id,
                Name = model.Name,
                Value = model.Value
            };

            _context.DefaultCharacteristics.Update(update);
            return _context.SaveChanges() > 0;
        }
    }
}
