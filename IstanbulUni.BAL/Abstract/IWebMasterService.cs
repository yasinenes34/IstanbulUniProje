﻿using IstanbulUni.BAL.Model;
using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Abstract
{
    public interface IWebMasterService
    {
        List<WebMaster> GetAll();
        List<WebMaster> ChartData();
        List<WebMasterViewModel> GetViewModels();
        void AddWebMaster(WebMaster webMaster);
        void RemoveWebMaster(WebMaster webMaster);
        void UpdateWebMaster(WebMaster webMaster);
        WebMaster GetByID(int id);

    }
}
