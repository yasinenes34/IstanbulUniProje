using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Abstract
{
    public interface IWebMasterHistoryService
    {
        void AddWebMaster(WebMasterHistory webMasterHistory, int id);
        void UpdateWebMaster(WebMasterHistory webMasterHistory,int id);
        WebMasterHistory GetByID(int id);

        List<WebMasterHistory> GetAll();
    }
}
