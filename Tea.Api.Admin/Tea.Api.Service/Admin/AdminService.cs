using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Admin
{
    public class AdminService : IAdminService
    {
        readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<SaveReturnModel> IAdminService.ChangePassword(ChangePasswordModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.ChangePassword(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> IAdminService.ClientLogin(ClientLoginModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.ClientLogin(_input);
            return ds;
        }

        async Task<SaveReturnModel> IAdminService.CreateRole(SaveRoleModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.CreateRole(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteCategory(DeleteCategoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteCategory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteClient(DeleteClientModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteClient(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteFactory(DeleteFactoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteFactory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteFactoryAccount(DeleteAccountModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteFactoryAccount(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteGrade(DeleteGradeModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteGrade(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<DataTable> IAdminService.GetApkUpdateNotification()
        {
            DataTable ds;
            ds = await _unitOfWork.AdminRepository.GetApkUpdateNotification();
            return ds;
        }

        async Task<DataSet> IAdminService.GetCategory(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetCategory(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetClient(SelectCategoryClientModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetClient(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetClientList(SelectCategoryClientModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetClientList(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetCompanyWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetCompanyWiseSaleChart(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetCompany(GetCompanyModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetCompany(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetFactory(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetFactory(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetFactoryAccount(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetFactoryAccount(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetGrade(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetGrade(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetPaymentType(GetPaymentTypeModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetPaymentType(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetRole(GetRoleModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetRole(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetRolePermission(RolePermission _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetRolePermission(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetSaleType()
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetSaleType();
            return ds;
        }

        async Task<DataSet> IAdminService.GetSTGWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetSTGWiseSaleChart(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetTenant()
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetTenant();
            return ds;
        }

        async Task<DataSet> IAdminService.GetTrip()
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetTrip();
            return ds;
        }
        async Task<DataSet> IAdminService.GetSupplierWiseSaleChart(CompanyWiseSaleChartModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetSupplierWiseSaleChart(_input);
            return ds;
        }
        async Task<DataSet> IAdminService.GetUser(SelectUserModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetUser(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.GetVehicle(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetVehicle(_input);
            return ds;
        }

        async Task<DataSet> IAdminService.Login(LoginModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.Login(_input);
            return ds;

        }

        async Task<SaveReturnModel> IAdminService.SaveCategory(SaveCategoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveCategory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveClient(SaveClientModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveClient(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveCompany(SaveCompanyModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveCompany(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveFactory(SaveFactoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveFactory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };

        }

        async Task<SaveReturnModel> IAdminService.SaveFactoryAccount(SaveAccountModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveFactoryAccount(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveGrade(SaveGradeModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveGrade(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };

        }

        async Task<SaveReturnModel> IAdminService.SavePaymentType(SavePaymentTypeModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SavePaymentType(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveRolePermission(SaveRolePermissionModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveRolePermission(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveTenant(SaveTenantModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveTenant(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveUser(SaveUserModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveUser(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };

        }

        async Task<SaveReturnModel> IAdminService.UpdateClientPassword(PasswordUpdateClientModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.UpdateClientPassword(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<JwtReturnModel> IAdminService.AuthenticationLogin(LoginModel _input)
        {

            return await _unitOfWork.AdminRepository.AuthenticationLogin(_input);

        }

        async Task<SaveReturnModel> IAdminService.ChangeUserPassword(ChangeUserPasswordModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.ChangeUserPassword(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveVehicle(SaveVehicleModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveVehicle(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> IAdminService.CheckRenewDate(RenewTenantModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.CheckRenewDate(_input);
            return ds;

        }

        async Task<DataSet> IAdminService.GetClientCollActivityChart(ClientActivityChartModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetClientCollActivityChart(_input);
            return ds;
        }

        async Task<SaveReturnModel> IAdminService.SaveSupplierTarget(TargetModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveSupplierTarget(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> IAdminService.GetFinancialYear(SelectFinancialYear _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetFinancialYear(_input);
            return ds;
        }

        async Task<SaveReturnModel> IAdminService.SaveFinancialYear(FinancialYearModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveFinancialYear(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt64(msgList[0]), Message = msgList[1] };
        }
    }
}
