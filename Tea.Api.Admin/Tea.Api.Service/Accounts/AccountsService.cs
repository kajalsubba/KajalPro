using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Entity.Accounts;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Accounts
{
    public class AccountsService: IAccountsService
    {

        readonly IUnitOfWork _unitOfWork;

        public AccountsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

       async Task<DataSet> IAccountsService.GetPaymentData(GetPaymentModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetPaymentData(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSeasonAdvance(GetSeasonAdvanceModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSeasonAdvance(_input);
            return ds;
        }

       async Task<DataSet> IAccountsService.GetStgBillData(StgBillModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetStgBillData(_input);
            return ds;
        }

        async  Task<SaveReturnModel> IAccountsService.SavePayment(SavePaymentModel _input)
        {
            string msg = await _unitOfWork.AccountsRepository.SavePayment(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAccountsService.SaveSeasonAdvance(SaveSeasonAdvanceModel _input)
        {
            string msg = await _unitOfWork.AccountsRepository.SaveSeasonAdvance(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

       async Task<SaveReturnModel> IAccountsService.SaveStgBill(SaveStgBill _input)
        {
            string msg = await _unitOfWork.AccountsRepository.SaveStgBill(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }
    }
}
