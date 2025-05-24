using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Common;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.JWT;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;
using Twilio.Jwt.AccessToken;
using Twilio.TwiML.Voice;

namespace Tea.Api.Data.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        readonly IDataHandler _dataHandler;

        readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

        public AdminRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
            _config = config;
        }

        async Task<string> IAdminRepository.DeleteCategory(DeleteCategoryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CategoryId", _input.CategoryId == null ? 0 : _input.CategoryId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientCategoryDelete]", oclsPairs);
            return Msg;
        }

        async Task<string> IAdminRepository.DeleteClient(DeleteClientModel _input)
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

        async Task<string> IAdminRepository.DeleteGrade(DeleteGradeModel _input)
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

        async Task<DataSet> IAdminRepository.GetClient(SelectCategoryClientModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@Category", _input.Category ?? "")
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetClient]", oclsPairs);
            ds.Tables[0].TableName = "ClientDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetClientList(SelectCategoryClientModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@Category", _input.Category == null ? 0 : _input.Category)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetClientAutocomplete]", oclsPairs);
            ds.Tables[0].TableName = "ClientDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetCompany(GetCompanyModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetCompany]", oclsPairs);
            ds.Tables[0].TableName = "CompanyDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetFactory(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@IsClientView",  _input.IsClientView == null ? false : _input.IsClientView),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetFactory]", oclsPairs);
            ds.Tables[0].TableName = "FactoryDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetFactoryAccount(CommonSelectModel _input)
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

        async Task<DataSet> IAdminRepository.GetGrade(CommonSelectModel _input)
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

        async Task<DataSet> IAdminRepository.GetSaleType()
        {
            DataSet ds;
            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetSaleType]");
            ds.Tables[0].TableName = "SaleTypes";
            return ds;
        }


        async Task<DataSet> IAdminRepository.GetTenant()
        {
            DataSet ds;
            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetTenant]");
            ds.Tables[0].TableName = "TenantDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetTrip()
        {
            DataSet ds;
            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetTrip]");
            ds.Tables[0].TableName = "TripDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetVehicle(CommonSelectModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetVehicle]", oclsPairs);
            ds.Tables[0].TableName = "VehicleDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.Login(LoginModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                  new ClsParamPair("@LoginUserName", _input.UserName ??""),
                new ClsParamPair("@Password", _input.Password ??"")
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[Login]", oclsPairs);
            ds.Tables[0].TableName = "LoginDetails";
            ds.Tables[1].TableName = "PermissionDetails";
            return ds;

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
                new ClsParamPair("@WhatsAppNo", _input.WhatsAppNo ??"", false, "String"),
                new ClsParamPair("@BioMatrixNo", _input.BioMatrixNo ??"", false, "String"),
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

        async Task<string> IAdminRepository.SaveCompany(SaveCompanyModel _input)
        {
            string logoName = await ClsUploadFile.UploadFile(_config.GetConnectionString("FilePath"), _input.TenantId.ToString(), _input.Image, "Logo", _config.GetConnectionString("DirectoryName"));


            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CompanyId", _input.CompanyId == null ? 0 : _input.CompanyId, false, "long"),
                new ClsParamPair("@CompanyName", _input.CompanyName ?? "", false, "String"),
                new ClsParamPair("@CompanyLogo", logoName ??"", false, "String"),
                new ClsParamPair("@UserEmail", _input.UserEmail??"", false, "String"),
                new ClsParamPair("@ContactNo", _input.ContactNo??"", false, "String"),
                new ClsParamPair("@CompanyDetails", _input.CompanyDetails??"", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[CompanyInsertUpdate]", oclsPairs);
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
                new ClsParamPair("@IsClientView", _input.IsClientView == null ? false : _input.IsClientView, false, "bool"),
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
                new ClsParamPair("@BioMatrixNo", _input.BioMatrixNo??"", false, "long"),
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

        async Task<string> IAdminRepository.SaveTenant(SaveTenantModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@TenantName", _input.TenantName ?? "", false, "String"),
                new ClsParamPair("@TenantOwner", _input.TenantOwner ??"", false, "String"),
                new ClsParamPair("@TenantEmail", _input.TenantEmail??"", false, "String"),
                new ClsParamPair("@TenantContactNo", _input.TenantContactNo??"", false, "String"),
                new ClsParamPair("@UserName", _input.UserName??"", false, "String"),
                new ClsParamPair("@Password", _input.Password??"", false, "String"),
                new ClsParamPair("@IsActive", _input.IsActive == null ? false : _input.IsActive, false, "bool")

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Admin].[TenantInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAdminRepository.SaveUser(SaveUserModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@UserId", _input.UserId == null ? 0 : _input.UserId, false, "long"),
                new ClsParamPair("@LoginUserName", _input.LoginUserName ?? "", false, "String"),
                new ClsParamPair("@UserFirstName", _input.UserFirstName ??"", false, "String"),
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

        async Task<DataSet> IAdminRepository.GetRole(GetRoleModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetUserRole]", oclsPairs);
            ds.Tables[0].TableName = "RoleDetails";
            return ds;

        }

        async Task<string> IAdminRepository.CreateRole(SaveRoleModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@UserRoleId", _input.UserRoleId == null ? 0 : _input.UserRoleId, false, "long"),
                new ClsParamPair("@RoleName", _input.RoleName ?? "", false, "String"),
                new ClsParamPair("@RoleDescription",  _input.RoleDescription ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Admin].[RoleInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<DataSet> IAdminRepository.ClientLogin(ClientLoginModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@UserId",  _input.UserId ?? "", false, "String"),
                new ClsParamPair("@Password",  _input.Password ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[ClientLogin]", oclsPairs);
            ds.Tables[0].TableName = "ClientLoginDetails";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetRolePermission(RolePermission _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
               new ClsParamPair("@TenantId", _input.TenantId ?? 0 ),
               new ClsParamPair("@RoleId", _input.RoleId ?? 0 )
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetRolePermission]", oclsPairs);
            ds.Tables[0].TableName = "RolePermission";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetUser(SelectUserModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                  new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetUser]", oclsPairs);
            ds.Tables[0].TableName = "UserDetails";
            return ds;
        }


        async Task<string> IAdminRepository.SaveRolePermission(SaveRolePermissionModel _input)
        {
            List<PermissionList> _items = _input.PermissionLists.ToList();
            DataTable dt = ConvertToDatatable.ToDataTable(_items);
            SqlParameter[] parameters = new SqlParameter[] {
        ParameterCreation.CreateParameter("@PermissionList", dt, SqlDbType.Structured),


    };
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long"),

            };
            string Msg = await _dataHandler.ExecuteUserTypeTableAsyn("[Admin].[RolePermissionInsertUpdate]", parameters, oclsPairs);
            return Msg;
        }

        async Task<DataSet> IAdminRepository.GetPaymentType(GetPaymentTypeModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Master].[GetPaymentType]", oclsPairs);
            ds.Tables[0].TableName = "PaymentTypeDetails";
            return ds;
        }

        async Task<string> IAdminRepository.SavePaymentType(SavePaymentTypeModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@PaymentTypeId", _input.PaymentTypeId??0 , false, "long"),
                new ClsParamPair("@PaymentType", _input.PaymentType ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[PaymentTypeInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<DataTable> IAdminRepository.GetApkUpdateNotification()
        {
            DataTable ds;
            ds = await _dataHandler.ExecProcDataTableAsyn("[Notify].[GetUpdateVesion]");
            return ds;
        }

        async Task<string> IAdminRepository.ChangePassword(ChangePasswordModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@Username", _input.UserName??"" , false, "String"),
                new ClsParamPair("@LoginType", _input.LoginType ?? "", false, "String"),
                new ClsParamPair("@Password", _input.Password ?? "" ,false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
               new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Admin].[ChangePassword]", oclsPairs);
            return Msg;
        }

        async Task<DataSet> IAdminRepository.GetCompanyWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId ??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetCompanyWiseChart]", oclsPairs);
            ds.Tables[0].TableName = "CompanyWiseChart";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetSTGWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId ??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetSTGWiseChart]", oclsPairs);
            ds.Tables[0].TableName = "StgWiseChart";
            return ds;
        }

        async Task<DataSet> IAdminRepository.GetSupplierWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId ??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetSupplierWiseChart]", oclsPairs);
            ds.Tables[0].TableName = "SupplierWiseChart";
            return ds;
        }

        async Task<string> IAdminRepository.UpdateClientPassword(PasswordUpdateClientModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@ClientId", _input.ClientId??0, false, "long"),
                new ClsParamPair("@Password", _input.Password ??"", false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0, false, "long"),
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[ClientChangePassword]", oclsPairs);
            return Msg;
        }

        async Task<JwtReturnModel> IAdminRepository.AuthenticationLogin(LoginModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                  new ClsParamPair("@LoginUserName", _input.UserName ??""),
                new ClsParamPair("@Password", _input.Password ??"")
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[Login]", oclsPairs);
            ds.Tables[0].TableName = "LoginDetails";
            ds.Tables[1].TableName = "PermissionDetails";


            if (ds.Tables[0].Rows.Count < 0)
            {
                return null;
            }
            else
            {
                //var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _input.UserName??""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var tokenOptions = JwtExtensions.GetToken(authClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return (new JwtReturnModel
                {
                    token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                    expiration = tokenOptions.ValidTo
                });
            }

        }

        async Task<string> IAdminRepository.ChangeUserPassword(ChangeUserPasswordModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@UserId", _input.UserId??0, false, "long"),
                new ClsParamPair("@Password", _input.Password ??"", false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0, false, "long"),
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Admin].[UserChangePassword]", oclsPairs);
            return Msg;
        }

        async Task<string> IAdminRepository.SaveVehicle(SaveVehicleModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@VehicleNo", _input.VehicleNo??"", false, "string"),
                new ClsParamPair("@VehicleDetails", _input.VehicleDetails??"", false, "string"),
                new ClsParamPair("@TenantId", _input.TenantId??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0, false, "long"),

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Master].[VehicleInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<DataSet> IAdminRepository.CheckRenewDate(RenewTenantModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@TenantId", _input.TenantId ??0),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetCheckRenewDate]", oclsPairs);
            ds.Tables[0].TableName = "RenewInfo";
            return ds;
        }
    }
}



