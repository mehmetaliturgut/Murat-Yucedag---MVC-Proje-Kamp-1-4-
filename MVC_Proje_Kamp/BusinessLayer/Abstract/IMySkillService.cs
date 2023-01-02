using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMySkillService
    {
        List<MySkill> GetList();
        void SkillAdd(MySkill skill);
        MySkill GetByID(int id);
        void SkillDelete(MySkill skill);
        void SkillUpdate(MySkill skill);

    }
}
