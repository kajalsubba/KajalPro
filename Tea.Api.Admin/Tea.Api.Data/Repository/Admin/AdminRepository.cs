using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Admin;

namespace Tea.Api.Data.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        readonly IDataHandler _dataHandler;

        public AdminRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

      async  Task<string> IAdminRepository.DeleteCategory(DeleteCategoryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CategoryId", _input.CategoryId == null ? 0 : _input.CategoryId, false, "long"),
              
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientCategoryDelete]", oclsPairs);
            return Msg;
        }

      async  Task<string> IAdminRepository.DeleteClient(DeleteClientModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientDelete]", oclsPairs);
            return Msg;
        }

       async Task<string> IAdminRepository.DeleteFactory(DeleteFactoryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@FactoryId", _input.FactoryId == null ? 0 : _input.FactoryId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[FactoryDelete]", oclsPairs);
            return Msg;
        }

       async Task<string> IAdminRepository.DeleteFactoryAccount(DeleteAccountModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[FactoryAccountDelete]", oclsPairs);
            return Msg;
        }

        async  Task<string> IAdminRepository.DeleteGrade(DeleteGradeModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@GradeId", _input.GradeId == null ? 0 : _input.GradeId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[GradeDelete]", oclsPairs);
            return Msg;
        }

        async Task<DataSet> IAdminRepository.GetCategory(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetClientCategory]", oclsPairs);
            ds.Tables[0].TableName = "CategoryDetails";
            return ds;
        }

      async  Task<DataSet> IAdminRepository.GetClient(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetClient]", oclsPairs);
            ds.Tables[0].TableName = "ClientDetails";
            return ds;
        }

      async  Task<DataSet> IAdminRepository.GetFactory(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetFactory]", oclsPairs);
            ds.Tables[0].TableName = "FactoryDetails";
            return ds;
        }

      async  Task<DataSet> IAdminRepository.GetFactoryAccount(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetFactoryAccount]", oclsPairs);
            ds.Tables[0].TableName = "AccountDetails";
            return ds;
        }

        async  Task<DataSet> IAdminRepository.GetGrade(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetGrade]", oclsPairs);
            ds.Tables[0].TableName = "GradeDetails";
            return ds;
        }

        async Task<DataTable> IAdminRepository.Login(LoginModel _input)
        {
            DataTable dt;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@LoginUserName", _input.UserName ??""),
                new ClsParamPair("@Password", _input.Password ??"")
            };
            dt = await _dataHandler.ExecProcDataTableAsyn("[Admin].[Login]", oclsPairs);
            return dt;
        }

       async Task<string> IAdminRepository.SaveCategory(SaveCategoryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CategoryId", _input.CategoryId == null ? 0 : _input.CategoryId, false, "long"),
                new ClsParamPair("@CategoryName", _input.CategoryName ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientCategoryInsertUpdate]", oclsPairs);
            return Msg;
        }

       async Task<string> IAdminRepository.SaveClient(SaveClientModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),
                new ClsParamPair("@ClientFirstName", _input.ClientFirstName ?? "", false, "String"),
                new ClsParamPair("@ClientMiddleName", _input.ClientMiddleName ??"", false, "String"),
                new ClsParamPair("@ClientLastName", _input.ClientLastName??"", false, "String"),
                new ClsParamPair("@ClientAddress", _input.ClientAddress??"", false, "String"),
                new ClsParamPair("@ContactNo", _input.ContactNo ??"", false, "String"),
                new ClsParamPair("@EmailId", _input.EmailId ??"", false, "String"),
                new ClsParamPair("@Password", _input.Password ??"", false, "String"),
                new ClsParamPair("@CategoryID",  _input.CategoryID== null ? 0 : _input.CategoryID, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@IsActive", _input.IsActive == null ? false : _input.IsActive, false, "bool"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientInsertUpdate]", oclsPairs);
            return Msg;
        }

       async Task<string> IAdminRepository.SaveFactory(SaveFactoryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@FactoryId", _input.FactoryId == null ? 0 : _input.FactoryId, false, "long"),
                new ClsParamPair("@FactoryName", _input.FactoryName ?? "", false, "String"),
                new ClsParamPair("@FactoryAddress", _input.FactoryAddress ??"", false, "String"),
                new ClsParamPair("@ContactNo", _input.ContactNo??"", false, "String"),
                new ClsParamPair("@EmailId", _input.EmailId??"", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@IsActive", _input.IsActive == null ? false : _input.IsActive, false, "bool"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[FactoryInsertUpdate]", oclsPairs);
            return Msg;
        }

       async Task<string> IAdminRepository.SaveFactoryAccount(SaveAccountModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId, false, "long"),
                new ClsParamPair("@AccountName", _input.AccountName ?? "", false, "String"),
                new ClsParamPair("@FactoryId", _input.FactoryId == null ? 0 : _input.FactoryId, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@IsActive", _input.IsActive == null ? false : _input.IsActive, false, "bool"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[FactoryAccountInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAdminRepository.SaveGrade(SaveGradeModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@GradeId", _input.GradeId == null ? 0 : _input.GradeId, false, "long"),
                new ClsParamPair("@GradeName", _input.GradeName ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[GradeInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAdminRepository.SaveUser(SaveUserModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@UserId", _input.UserId == null ? 0 : _input.UserId, false, "long"),
                new ClsParamPair("@LoginUserName", _input.LoginUserName ?? "", false, "String"),
                new ClsParamPair("@UserFirstName", _input.LoginUserName ??"", false, "String"),
                new ClsParamPair("@UserMiddleName", _input.UserMiddleName??"", false, "String"),
                new ClsParamPair("@UserLastName", _input.UserLastName??"", false, "String"),
                new ClsParamPair("@UserEmail", _input.UserEmail ??"", false, "String"),
                new ClsParamPair("@ContactNo", _input.ContactNo ??"", false, "String"),
                new ClsParamPair("@Password", _input.Password ??"", false, "String"),
                new ClsParamPair("@UserRoleId", _input.UserRoleId == null ? 0 : _input.UserRoleId, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@IsActive", _input.IsActive == null ? false : _input.IsActive, false, "bool"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Admin].[UserInsertUpdate]", oclsPairs);
            return Msg;
        }
    }
}
