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
    public class AccountsService : IAccountsService
    {

        readonly IUnitOfWork _unitOfWork;

        public AccountsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<DataSet> IAccountsService.GetNarration(NarrationModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetNarration(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetPaymentData(GetPaymentModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetPaymentData(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSaleSummary(SaleSummaryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSaleSummary(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSeasonAdvance(GetSeasonAdvanceModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSeasonAdvance(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSmartHistory(SmartHistoryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSmartHistory(_input);
            return ds;
        }


        async Task<DataSet> IAccountsService.GetStgBillData(StgBillModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetStgBillData(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetStgBillHistory(GetSTGBillHistoryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetStgBillHistory(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetStgSummary(StgSummaryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetStgSummary(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSupplierBillData(SupplierBillModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSupplierBillData(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSupplierBillHistory(GetSupplierBillHistoryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSupplierBillHistory(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetSupplierSummary(SupplierSummaryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetSupplierSummary(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetWalletBalanace(WalletBalanceModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetWalletBalanace(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetWalletHistory(WalletHistModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetWalletHistory(_input);
            return ds;
        }

        async Task<DataSet> IAccountsService.GetWalletStatement(WalletHistModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.AccountsRepository.GetWalletStatement(_input);
            return ds;
        }

        async Task<SaveReturnModel> IAccountsService.SavePayment(SavePaymentModel _input)
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

        async Task<SaveReturnModel> IAccountsService.SaveSupplierBill(SaveSupplierBill _input)
        {
            string msg = await _unitOfWork.AccountsRepository.SaveSupplierBill(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IAccountsService.SaveUserWallet(WalletModel _input)
        {
            string msg = await _unitOfWork.AccountsRepository.SaveUserWallet(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }
    }
}
