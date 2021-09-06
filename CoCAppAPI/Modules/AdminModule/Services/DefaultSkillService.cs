using DbLibrary.DAL;
using DbLibrary.Models.Skill;
using DbLibrary.Models.Skill.Request;
using DbLibrary.Models.Skill.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminModule.Services
{
    public interface IDefaultSkillService
    {
        public DefaultSkillResponse Get(Guid id);
        public IEnumerable<DefaultSkillResponse> GetAll();
        public bool Add(DefaultSkillRequest model);
        public bool Edit(DefaultSkill model);
        public bool Delete(Guid id);
        public bool Update(Guid id, DefaultSkillRequest model);
        
    }
    public class DefaultSkillService : IDefaultSkillService
    {
        private readonly CoCDbContext _context;

        public DefaultSkillService(CoCDbContext context)
        {
            _context = context;
        }
        public bool Add(DefaultSkillRequest model)
        {
            _context.DefaultSkills.Add(new DefaultSkill(model));
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            _context.DefaultSkills.Remove(
                _context.DefaultSkills.FirstOrDefault(x => x.Id == id)
                );
            return _context.SaveChanges() > 0;
        }

        public bool Edit(DefaultSkill model)
        {
            _context.DefaultSkills.Update(model);
            return _context.SaveChanges() > 0;
        }

        public DefaultSkillResponse Get(Guid id)
        {
            var result = _context.DefaultSkills.FirstOrDefault(x => x.Id == id);
            return new DefaultSkillResponse(result);
        }

        public IEnumerable<DefaultSkillResponse> GetAll()
        {
            var result = _context.DefaultSkills.Select(x => new DefaultSkillResponse(x)).ToList();
            return result;
        }

        public bool Update(Guid id, DefaultSkillRequest model)
        {
            DefaultSkill update = new DefaultSkill()
            {
                Id = id,
                Name = model.Name,
                Value = model.Value
            };

            _context.DefaultSkills.Update(update);
            return _context.SaveChanges() > 0;
        }
    }
}
