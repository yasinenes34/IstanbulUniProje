using IstanbulUni.BAL.Abstract;
using IstanbulUni.BAL.Model;
using IstanbulUni.DAL.Abstract;
using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace IstanbulUni.BAL.Concrate
{
    public class WebMasterManager : IWebMasterService
    {
        IWebMaster _webMaster;
        WebMasterViewModel WebMasterViewModel=new WebMasterViewModel();
        private static bool UpdateDatabase = false;
        public WebMasterManager(IWebMaster webMaster)
        {
            _webMaster = webMaster;
        }
        public IEnumerable<WebMaster> Read()
        {
            return GetAllAsQueryble();
        }

        public void AddWebMaster(WebMaster webMaster)
        {
             if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.webMasterID).FirstOrDefault();
                var id = (first != null) ? first.webMasterID : 0;
               
                webMaster.webMasterID = id + 1;
                webMaster.createTime =Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd"));
                webMaster.IsActive = true;
                GetAll().Insert(0, webMaster);
            }
            else
            {
                var entity = new WebMaster();

                entity.Name = webMaster.Name;
                entity.Surname = webMaster.Surname;
                entity.Email = webMaster.Email;
                entity.Phone = webMaster.Phone;
                entity.Department = webMaster.Department;
                entity.DomainName = webMaster.DomainName;
                entity.createTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                entity.userID = webMaster.userID;
                _webMaster.Insert(entity);
            }

            _webMaster.Insert(webMaster);
        }

        public List<WebMaster> GetAll()
        {
            var list = _webMaster.List(x=>x.IsActive==true);
            return list;
        }
        public IQueryable<WebMaster> GetAllAsQueryble()
        {
            var list1 = _webMaster.GetAllAsQueryble();
            return list1;
        }


        public void UpdateWebMaster(WebMaster webMaster)
        {
            if (!UpdateDatabase)
            {
                var target = GetByID(webMaster.webMasterID);
                if (target != null)
                {
                    target.Name = webMaster.Name;
                    target.Surname = webMaster.Surname;
                    target.Email = webMaster.Email;
                    target.Department = webMaster.Department;
                    target.DomainName = webMaster.DomainName;
                    target.Phone = webMaster.Phone;
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
                entity.Phone = webMaster.Phone;
                _webMaster.Update(webMaster);
            }
        }

        public void RemoveWebMaster(WebMaster webMaster)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.webMasterID == webMaster.webMasterID);
                if (target != null)
                {
                    //_webMaster.Delete(target);
                    target.IsActive = false;
                    _webMaster.Update(target);
                }

            }
        }

        public WebMaster GetByID(int id)
        {
            return _webMaster.get(x => x.webMasterID == id);
        }

        public List<WebMasterViewModel> GetViewModels()
        {
            List<WebMasterViewModel> viewModel = new List<WebMasterViewModel>();
            var list = _webMaster.List(x=>x.IsActive==true);

            for (int i = 0; i < list.Count; i++)
            {
                viewModel[i].webMasterID = list[i].webMasterID;
                viewModel[i].Name = list[i].Name;
                viewModel[i].Surname = list[i].Surname;
                viewModel[i].DomainName = list[i].DomainName;
                viewModel[i].Email = list[i].Email;
                viewModel[i].Phone = list[i].Phone;
                viewModel[i].Department = list[i].Department;
                viewModel[i].createTime = list[i].createTime;
            }
            //foreach (var item in list)
            //{
            //    viewModel.webMasterID = item.webMasterID;
            //    viewModel.Name = item.Name;
            //    viewModel.Surname= item.Surname;
            //    viewModel.DomainName= item.DomainName;
            //    viewModel.Email= item.Email;
            //    viewModel.Number= item.Number;
            //    viewModel.Department= item.Department;
            //    viewModel.createTime= item.createTime;
               
            //}
            return viewModel;
            
        }

        public List<WebMaster> ChartData()
        {
            return _webMaster.GetAll();
        }
    }
}
