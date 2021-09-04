using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Skill
{
    public class DefaultSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
