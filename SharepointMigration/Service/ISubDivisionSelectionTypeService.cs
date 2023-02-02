using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface ISubDivisionSelectionTypeService
    {
        Task<SubdivisionSelectionTypeModel> Get(string ProjectNumber);
        Task<SubdivisionSelectionTypeModel> Update(string ProjectNumber, SubdivisionSelectionTypeModel data);
        void Create(string ProjectNumber, SubdivisionSelectionTypeModel data);
    }
}
