using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface ISubdivisionRequirementsListService
    {
        Task<SubdivisionRequirementsListModel> Get(string ProjectNumber);
        Task<SubdivisionRequirementsListModel> Update(string ProjectNumber, SubdivisionRequirementsListModel data);
        void Create(string ProjectNumber, SubdivisionRequirementsListModel data);
    }
}