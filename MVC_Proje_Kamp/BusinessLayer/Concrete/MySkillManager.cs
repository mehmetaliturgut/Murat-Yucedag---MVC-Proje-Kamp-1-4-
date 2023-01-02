using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MySkillManager:IMySkillService
    {
        IMySkillDAL _myskillDal;

        public MySkillManager(IMySkillDAL myskillDal)
        {
            _myskillDal = myskillDal;
        }

        public MySkill GetByID(int id)
        {            
            return _myskillDal.Get(x => x.SkillID == id);
        }

        public List<MySkill> GetList()
        {
            return _myskillDal.List();
        }

        public void SkillAdd(MySkill skill)
        {
            _myskillDal.Insert(skill);
        }

        public void SkillDelete(MySkill skill)
        {
            _myskillDal.Delete(skill);

        }

        public void SkillUpdate(MySkill skill)
        {
            _myskillDal.Update(skill);

        }

       
    }
}
