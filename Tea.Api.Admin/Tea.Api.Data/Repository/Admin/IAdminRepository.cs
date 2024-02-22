﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Admin
{
    public interface IAdminRepository
    {
        Task<string> SaveUser(SaveUserModel _input);

        Task<DataTable> Login(LoginModel _input);

        Task<string> SaveCategory(SaveCategoryModel _input);

        Task<string> DeleteCategory(DeleteCategoryModel _input);

        Task<string> SaveClient(SaveClientModel _input);
        Task<string> DeleteClient(DeleteClientModel _input);

        Task<string> SaveGrade(SaveGradeModel _input);

        Task<string> SaveFactory(SaveFactoryModel _input);
        Task<string> DeleteFactory(DeleteFactoryModel _input);
        Task<string> DeleteGrade(DeleteGradeModel _input);
        Task<string> SaveFactoryAccount(SaveAccountModel _input);
        Task<string> DeleteFactoryAccount(DeleteAccountModel _input);
        Task<DataSet> GetCategory(CommonSelectModel _input);

        Task<DataSet> GetClient(CommonSelectModel _input);

        Task<DataSet> GetGrade(CommonSelectModel _input);

        Task<DataSet> GetFactory(CommonSelectModel _input);

        Task<DataSet> GetFactoryAccount(CommonSelectModel _input);

        Task<DataSet> GetVehicle(CommonSelectModel _input);


        Task<DataSet> GetClientList(SelectCategoryClientModel _input);

        Task<string> SaveCompany(SaveCompanyModel _input);

        Task<DataSet> GetCompany(GetCompanyModel _input);
        Task<string> SaveTenant(SaveTenantModel _input);

        Task<DataSet> GetTenant();

        Task<DataSet> GetTrip();

        Task<DataSet> GetSaleType();
    }
}
