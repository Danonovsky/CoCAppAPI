using System;
using System.Collections.Generic;
using System.Text;

using DbLibrary.Models.Character;

namespace DbLibrary.Models.Skill
{
    public class Skill
    {
        public Guid Id { get; set; }

        public Guid? CharacterId { get; set; }
        public virtual Character.Character Character { get; set; }

        public Guid DefaultSkillId { get; set; }
        public virtual DefaultSkill DefaultSkill { get; set; }

        public int Value { get; set; }
        public int Advancement { get; set; }
    }
}
