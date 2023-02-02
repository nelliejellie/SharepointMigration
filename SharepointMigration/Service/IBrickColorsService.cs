using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IBrickColorsService
    {
        Task<List<BrickColorsModel>> Get();
        Task<BrickColorsModel> Get(string ProjectNumber);
        Task<BrickColorsModel> Update(string ProjectNumber, BrickColorsModel data);
        void Create(string ProjectNumber, BrickColorsModel data);
    }
}