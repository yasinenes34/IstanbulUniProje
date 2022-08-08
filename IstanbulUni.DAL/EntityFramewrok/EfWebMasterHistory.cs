using IstanbulUni.DAL.Abstract;
using IstanbulUni.DAL.Model;
using IstanbulUni.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.DAL.EntityFramewrok
{
    public class EfWebMasterHistory: GenericRepository<WebMasterHistory>, IWebMasterHistories
    {
    }
}
