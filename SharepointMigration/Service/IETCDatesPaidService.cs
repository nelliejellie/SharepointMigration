using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IETCDatesPaidService
    {
        Task<ETCDatesPaidModel> Get(string ProjectNumber);
        Task<ETCDatesPaidModel> Update(string ProjectNumber, ETCDatesPaidModel data);
        void Create(string ProjectNumber, ETCDatesPaidModel data);
    }
}