using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IProjectsService
    {
        Task<List<ProjectsModel>> Get();
        Task<ProjectsModel> Get(string ProjectNumber);
        Task<ProjectsModel> Update(string ProjectNumber, ProjectsModel data);
        void Delete(string ProjectNumber);
        void Create(string ProjectNumber, ProjectsModel data);
    }
}