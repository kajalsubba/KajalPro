using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Admin
{
    public interface IAdminService
    {
        Task<SaveReturnModel> SaveUser(SaveUserModel _input);
        Task<DataTable> Login(LoginModel _input);
        Task<SaveReturnModel> SaveCategory(SaveCategoryModel _input);
        Task<SaveReturnModel> DeleteCategory(DeleteCategoryModel _input);
        
        Task<SaveReturnModel> SaveClient(SaveClientModel _input);

        Task<SaveReturnModel> SaveGrade(SaveGradeModel _input);

        Task<SaveReturnModel> SaveFactory(SaveFactoryModel _input);

        Task<SaveReturnModel> SaveFactoryAccount(SaveAccountModel _input);

        Task<DataSet> GetCategory(CommonSelectModel _input);

        Task<DataSet> GetClient(CommonSelectModel _input);
        Task<DataSet> GetGrade(CommonSelectModel _input);
        Task<DataSet> GetFactory(CommonSelectModel _input);

        Task<DataSet> GetFactoryAccount(CommonSelectModel _input);
    }
}
