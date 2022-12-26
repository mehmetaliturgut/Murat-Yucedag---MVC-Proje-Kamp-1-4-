using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MySkill
    {
        [Key]
        public int SkillID { get; set; }

        [StringLength(200)]
        public string MyImage { get; set; }

        [StringLength(100)]

        public string SkillName { get; set; }

        public int SkillRate { get; set; }
    }
}
