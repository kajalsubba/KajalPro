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

       async Task<SaveReturnModel> IAdminService.DeleteCategory(DeleteCategoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteCategory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

       async Task<SaveReturnModel> IAdminService.DeleteClient(DeleteClientModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteClient(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

       async Task<SaveReturnModel> IAdminService.DeleteFactory(DeleteFactoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteFactory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

      async  Task<SaveReturnModel> IAdminService.DeleteFactoryAccount(DeleteAccountModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteFactoryAccount(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.DeleteGrade(DeleteGradeModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.DeleteGrade(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> IAdminService.GetCategory(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetCategory(_input);
            return ds;
        }

       async Task<DataSet> IAdminService.GetClient(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetClient(_input);
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

       async Task<DataSet> IAdminService.GetVehicle(CommonSelectModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AdminRepository.GetVehicle(_input);
            return ds;
        }

        async Task<DataTable> IAdminService.Login(LoginModel _input)
        {
            DataTable dt;
            dt = await _unitOfWork.AdminRepository.Login(_input);
            return dt;
        }

       async Task<SaveReturnModel> IAdminService.SaveCategory(SaveCategoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveCategory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

       async Task<SaveReturnModel> IAdminService.SaveClient(SaveClientModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveClient(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

       async Task<SaveReturnModel> IAdminService.SaveFactory(SaveFactoryModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveFactory(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };

        }

      async  Task<SaveReturnModel> IAdminService.SaveFactoryAccount(SaveAccountModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveFactoryAccount(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAdminService.SaveGrade(SaveGradeModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveGrade(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };

        }

        async  Task<SaveReturnModel> IAdminService.SaveUser(SaveUserModel _input)
        {
            string msg = await _unitOfWork.AdminRepository.SaveUser(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };

        }
    }
}
