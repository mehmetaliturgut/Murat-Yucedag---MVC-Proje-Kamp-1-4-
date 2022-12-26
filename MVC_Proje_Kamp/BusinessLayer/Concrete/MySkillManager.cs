using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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

        public List<MySkill> GetList()
        {
            return _myskillDal.List();
        }
    }
}
