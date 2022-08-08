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
    public class WebMasterHistoryManager : IWebMasterHistoryService
    {
        IWebMasterHistories _masterHistories;
        private static bool UpdateDatabase = false;
        public WebMasterHistoryManager(IWebMasterHistories masterHistories)
        {
            _masterHistories = masterHistories;
        }

        public void AddWebMaster(WebMasterHistory webMasterHistory,int id)
        {
           
            if (!UpdateDatabase)
            {

                webMasterHistory.webMasterHistoryID = id;
                webMasterHistory.createTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                webMasterHistory.deleteTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                GetAll().Insert(0, webMasterHistory);
            }
            else
            {
                var entity = new WebMasterHistory();

                entity.Name = webMasterHistory.Name;
                entity.Surname = webMasterHistory.Surname;
                entity.Email = webMasterHistory.Email;
                entity.Phone = webMasterHistory.Phone;
                entity.Department = webMasterHistory.Department;
                entity.DomainName = webMasterHistory.DomainName;
                entity.IsActive = true;
                entity.createTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                entity.deleteTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                _masterHistories.Insert(entity);
            }

            _masterHistories.Insert(webMasterHistory);
        }

        public WebMasterHistory GetByID(int id)
        {
            return _masterHistories.get(x => x.webMasterHistoryID == id);
        }

        public List<WebMasterHistory> GetAll()
        {
            return _masterHistories.List(x=>x.IsActive==false).ToList();
        }

        public void UpdateWebMaster(WebMasterHistory webMasterHistory,int id)
        {
            if (!UpdateDatabase)
            {
                var target = GetByID(id);
                if (target != null)
                {

                    target.deleteTime = DateTime.Now;
                    target.IsActive = false;
                    TimeSpan totalTime = target.deleteTime - target.createTime;
                    target.serviceTime = totalTime.Days.ToString();
                    _masterHistories.Update(target);
                }
            }
            else
            {
                var entity = new WebMasterHistory();
                entity.deleteTime = Convert.ToDateTime(DateTime.Now.ToString("yy/MM/dddd"));
                entity.IsActive = false;
                var totalTime = entity.deleteTime - entity.createTime;
                entity.serviceTime = totalTime.ToString();
                _masterHistories.Update(entity);
            }

        }
    }
}
