using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IPaintedBrickColorsService
    {
        Task<List<PaintedBrickColorsModel>> Get();
        Task<PaintedBrickColorsModel> Get(string ProjectNumber);
        Task<PaintedBrickColorsModel> Update(string ProjectNumber, PaintedBrickColorsModel data);
        void Create(string ProjectNumber, PaintedBrickColorsModel data);
    }
}