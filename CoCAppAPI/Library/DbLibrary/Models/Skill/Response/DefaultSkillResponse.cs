using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Skill.Response
{
    public class DefaultSkillResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public DefaultSkillResponse(DefaultSkill defaultSkill)
        {
            Id = defaultSkill.Id;
            Name = defaultSkill.Name;
            Value = defaultSkill.Value;
        }
    }
}
