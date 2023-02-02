using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IDesignCenterAppoitnmentsService
    {
        Task<List<DesignCenterAppointmentsModel>> Get();
        Task<DesignCenterAppointmentsModel> Get(string ProjectNumber);
        Task<DesignCenterAppointmentsModel> Update(string ProjectNumber, DesignCenterAppointmentsModel data);
        void Create(string ProjectNumber, DesignCenterAppointmentsModel data);
    }
}