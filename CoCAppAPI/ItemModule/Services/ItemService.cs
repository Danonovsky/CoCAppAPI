using DbLibrary.DAL;
using DbLibrary.Models.Item;
using DbLibrary.Models.Item.Request;
using DbLibrary.Models.Item.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemModule.Services
{
    public interface IItemService
    {
        public ItemTypeResponse GetItemType(Guid id);
        public List<ItemTypeResponse> GetItemTypes();
        public bool AddItemType(ItemTypeRequest model);
        public bool UpdateItemType(ItemTypeRequest model);
        public bool DeleteItemType(Guid id);

        public ItemTypeAttribute GetItemTypeAttribute(Guid id);
        public List<ItemTypeAttribute> GetItemTypeAttributes();
        public bool AddItemTypeAttribute(ItemTypeAttribute model);
        public bool UpdateItemTypeAttribute(ItemTypeAttribute model);
        public bool DeleteItemTypeAttribute(Guid id);

        public ItemAttributeValue GetItemAttributeValue(Guid id);
        public List<ItemAttributeValue> GetItemAttributeValues();
        public bool AddItemAttribureValue(ItemAttributeValue model);
        public bool UpdateItemAttribureValue(ItemAttributeValue model);
        public bool DeleteItemAttribureValue(Guid id);

        public Item GetItem(Guid id);
        public List<Item> GetItems();
        public bool AddItem(Item model);
        public bool UpdateItem(Item model);
        public bool DeleteItem(Guid id);
    }

    public class ItemService : IItemService
    {
        private readonly CoCDbContext _context;

        public ItemService(CoCDbContext context)
        {
            _context = context;
        }

        public bool AddItem(Item model)
        {
            _context.Items.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool AddItemAttribureValue(ItemAttributeValue model)
        {
            _context.ItemAttributeValues.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool AddItemType(ItemTypeRequest model)
        {
            _context.ItemTypes.Add(new ItemType(model));
            return _context.SaveChanges() > 0;
        }

        public bool AddItemTypeAttribute(ItemTypeAttribute model)
        {
            _context.ItemTypeAttributes.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItem(Guid id)
        {
            _context.Items.Remove(
                _context.Items.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemAttribureValue(Guid id)
        {
            _context.ItemAttributeValues.Remove(
                _context.ItemAttributeValues.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemType(Guid id)
        {
            _context.ItemTypes.Remove(
                _context.ItemTypes.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItemTypeAttribute(Guid id)
        {
            _context.ItemTypeAttributes.Remove(
                _context.ItemTypeAttributes.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public Item GetItem(Guid id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public ItemAttributeValue GetItemAttributeValue(Guid id)
        {
            return _context.ItemAttributeValues.FirstOrDefault(x => x.Id == id);
        }

        public List<ItemAttributeValue> GetItemAttributeValues()
        {
            return _context.ItemAttributeValues.ToList();
        }

        public List<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public ItemTypeResponse GetItemType(Guid id)
        {
            return new ItemTypeResponse(_context.ItemTypes.FirstOrDefault(x => x.Id == id));
        }

        public ItemTypeAttribute GetItemTypeAttribute(Guid id)
        {
            return _context.ItemTypeAttributes.FirstOrDefault(x => x.Id == id);
        }

        public List<ItemTypeAttribute> GetItemTypeAttributes()
        {
            return _context.ItemTypeAttributes.ToList();
        }

        public List<ItemTypeResponse> GetItemTypes()
        {
            return _context.ItemTypes.Select(x => new ItemTypeResponse(x)).ToList();
        }

        public bool UpdateItem(Item model)
        {
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemAttribureValue(ItemAttributeValue model)
        {
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemType(ItemTypeRequest model)
        {
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateItemTypeAttribute(ItemTypeAttribute model)
        {
            _context.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
