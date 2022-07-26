using IstanbulUni.BAL.Abstract;
using IstanbulUni.DAL.Abstract;
using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Concrate
{
    public class WebMasterManager : IWebMasterService
    {
        IWebMaster _webMaster;
        private static bool UpdateDatabase = false;
        public WebMasterManager(IWebMaster webMaster)
        {
            _webMaster = webMaster;
        }
        public IEnumerable<WebMaster> Read()
        {
            return GetAll();
        }

        public void AddWebMaster(WebMaster webMaster)
        {
             if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.ID).FirstOrDefault();
                var id = (first != null) ? first.ID : 0;

                webMaster.ID = id + 1;
               

                GetAll().Insert(0, webMaster);
            }
            else
            {
                var entity = new WebMaster();

                entity.Name = webMaster.Name;
                entity.Surname = webMaster.Surname;
                entity.Email = webMaster.Email;
                entity.Number = webMaster.Number;
                entity.Department = webMaster.Department;
                entity.DomainName = webMaster.DomainName;
                entity.createTime = webMaster.createTime;
                _webMaster.Insert(entity);
            }

            _webMaster.Insert(webMaster);
        }

        public List<WebMaster> GetAll()
        {
            return _webMaster.GetAll();
        }

       
        public void UpdateWebMaster(WebMaster webMaster)
        {
            if (!UpdateDatabase)
            {
                var target = GetByID(webMaster.ID);
                if (target != null)
                {
                    target.Name = webMaster.Name;
                    target.Surname = webMaster.Surname;
                    target.Email = webMaster.Email;
                    target.Department = webMaster.Department;
                    target.DomainName = webMaster.DomainName;
                    target.Number = webMaster.Number;
                    target.createTime = webMaster.createTime;
                  
                    _webMaster.Update(target);
                }
            }
            else
            {
                var entity = new WebMaster();
                entity.Name = webMaster.Name;
                entity.Surname = webMaster.Surname;
                entity.Email = webMaster.Email;
                entity.Department = webMaster.Department;
                entity.DomainName = webMaster.DomainName;
                entity.Number = webMaster.Number;
                entity.createTime = webMaster.createTime;
                _webMaster.Update(webMaster);
            }
        }

        public void RemoveWebMaster(WebMaster webMaster)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.ID == webMaster.ID);
                if (target != null)
                {
                    _webMaster.Delete(target);
                }

            }
        }

        public WebMaster GetByID(int id)
        {
            return _webMaster.get(x => x.ID == id);
        }
    }
}
