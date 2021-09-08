using DbLibrary.DAL;
using DbLibrary.Models.Item;
using DbLibrary.Models.Item.Request;
using DbLibrary.Models.Item.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ItemModule.Services
{
    public interface IItemService
    {
        public ItemTypeResponse GetItemType(Guid id);
        public List<ItemTypeResponse> GetItemTypes();
        public bool AddItemType(ItemTypeRequest model);
        public bool UpdateItemType(Guid id, ItemTypeRequest model);
        public bool DeleteItemType(Guid id);

        public ItemTypeAttribute GetItemTypeAttribute(Guid id);
        public List<ItemTypeAttribute> GetItemTypeAttributes(Guid id);
        public bool AddItemTypeAttribute(ItemTypeAttributeRequest model);
        public bool UpdateItemTypeAttribute(Guid id, ItemTypeAttributeRequest model);
        public bool DeleteItemTypeAttribute(Guid id);

        public ItemAttributeValue GetItemAttributeValue(Guid id);
        public List<ItemAttributeValue> GetItemAttributeValues();
        public bool AddItemAttribureValue(ItemAttributeValue model);
        public bool UpdateItemAttribureValue(Guid id, ItemAttributeValue model);
        public bool DeleteItemAttribureValue(Guid id);

        public ItemResponse GetItem(Guid id);
        public List<ItemResponse> GetItems();
        public bool AddItem(ItemRequest model);
        public bool UpdateItem(Guid id, Item model);
        public bool DeleteItem(Guid id);
    }

    public class ItemService : IItemService
    {
        private readonly CoCDbContext _context;

        public ItemService(CoCDbContext context)
        {
            _context = context;
        }

        #region Item

        public ItemResponse GetItem(Guid id)
        {
            return new ItemResponse(
                _context.Items
                .Include(x => x.ItemType)
                .Include(x => x.ItemAttributeValues)
                .ThenInclude(x => x.ItemTypeAttribute)
                .FirstOrDefault(x => x.Id == id)
                );
        }

        public List<ItemResponse> GetItems()
        {
            return _context
                .Items
                .Include(x => x.ItemType)
                .Include(x => x.ItemAttributeValues)
                .ThenInclude(x => x.ItemTypeAttribute)
                .Select(x => new ItemResponse(x))
                .ToList();
        }

        public bool AddItem(ItemRequest model)
        {
            Item insert = new Item(model);
            _context.Items.Add(insert);
            _context.SaveChanges();
            Guid savedId = insert.Id;
            //Debug.WriteLine("ILE ATRYBUTOW" + model.Attributes.Count);
            foreach (var item in model.Attributes)
            {
                _context.ItemAttributeValues.Add(new ItemAttributeValue()
                {
                    ItemId = savedId,
                    Value = item.Value,
                    ItemTypeAttributeId = item.ItemTypeAttributeId
                });
            }

            bool result = _context.SaveChanges() == model.Attributes.Count;
            if(!result) {
                _context.Items.Remove(insert);
                _context.SaveChanges();
            }

            return result;
        }

        public bool UpdateItem(Guid id, Item model)
        {
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItem(Guid id)
        {
            _context.ItemAttributeValues.Where(x => x.ItemId == id).ToList().ForEach(i =>
            {
                _context.ItemAttributeValues.Remove(i);
            });
            _context.Items.Remove(
                _context.Items.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region ItemType

        public ItemTypeResponse GetItemType(Guid id)
        {
            return new ItemTypeResponse(_context.ItemTypes.FirstOrDefault(x => x.Id == id));
        }

        public List<ItemTypeResponse> GetItemTypes()
        {
            return _context.ItemTypes.Select(x => new ItemTypeResponse(x)).ToList();
        }

        public bool AddItemType(ItemTypeRequest model)
        {
            _context.ItemTypes.Add(new ItemType(model));
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemType(Guid id, ItemTypeRequest model)
        {
            ItemType update = new ItemType()
            {
                Id = id,
                Name = model.Name
            };
            _context.Update(update);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemType(Guid id)
        {
            _context.ItemTypes.Remove(
                _context.ItemTypes.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region ItemTypeAttribute

        public ItemTypeAttribute GetItemTypeAttribute(Guid id)
        {
            return _context.ItemTypeAttributes.FirstOrDefault(x => x.Id == id);
        }

        public List<ItemTypeAttribute> GetItemTypeAttributes(Guid id)
        {
            return _context.ItemTypeAttributes.Where(x => x.ItemTypeId == id).ToList();
        }

        public bool AddItemTypeAttribute(ItemTypeAttributeRequest model)
        {
            _context.ItemTypeAttributes.Add(new ItemTypeAttribute(model));
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemTypeAttribute(Guid id, ItemTypeAttribute model)
        {
            model.Id = id;
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemTypeAttribute(Guid id)
        {
            _context.ItemTypeAttributes.Remove(
                _context.ItemTypeAttributes.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region ItemAttributeValue

        public ItemAttributeValue GetItemAttributeValue(Guid id)
        {
            return _context.ItemAttributeValues.FirstOrDefault(x => x.Id == id);
        }

        public List<ItemAttributeValue> GetItemAttributeValues()
        {
            return _context.ItemAttributeValues.ToList();
        }

        public bool AddItemAttribureValue(ItemAttributeValue model)
        {
            _context.ItemAttributeValues.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemAttribureValue(Guid id, ItemTypeAttributeRequest model)
        {

            _context.Update(new ItemTypeAttribute()
            {
                Id = id,
                Name = model.Name,
                ItemTypeId = model.ItemTypeId
            });
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemAttribureValue(Guid id)
        {
            _context.ItemAttributeValues.Remove(
                _context.ItemAttributeValues.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }



        #endregion

        public bool UpdateItemTypeAttribute(Guid id, ItemTypeAttributeRequest model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemAttribureValue(Guid id, ItemAttributeValue model)
        {
            throw new NotImplementedException();
        }
    }
}
