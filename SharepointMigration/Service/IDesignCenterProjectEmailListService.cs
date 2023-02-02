using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IDesignCenterProjectEmailListService
    {
        Task<DesignCenterProjectEmailListModel> Get(string ProjectNumber);
        Task<DesignCenterProjectEmailListModel> Update(string ProjectNumber, DesignCenterProjectEmailListModel data);
        void Create(string ProjectNumber, DesignCenterProjectEmailListModel data);
    }
}