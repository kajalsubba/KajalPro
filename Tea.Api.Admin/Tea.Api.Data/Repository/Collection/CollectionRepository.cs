using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Collection;

namespace Tea.Api.Data.Repository.Collection
{
    public class CollectionRepository : ICollectionRepository
    {
        readonly IDataHandler _dataHandler;


        public CollectionRepository(IDataHandler dataHandler)
        {

            _dataHandler = dataHandler;
        }

       async Task<DataSet> ICollectionRepository.GetStgPendingData(StgFilterModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[TeaCollection].[GetSTGPendingData]", oclsPairs);
            ds.Tables[0].TableName = "STGDetails";
            return ds;
        }

        async Task<string> ICollectionRepository.SaveSTG(SaveStgModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CollectionId", _input.CollectionId == null ? 0 : _input.CollectionId, false, "long"),
                new ClsParamPair("@CollectionDate",Convert.ToDateTime(_input.CollectionDate), true,"Datetime"),
                new ClsParamPair("@VehicleNo", _input.VehicleNo == null ? "" : _input.VehicleNo, false, "string"),
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),
                new ClsParamPair("@FirstWeight", _input.FirstWeight == null ? 0 : _input.FirstWeight, false, "long"),
                new ClsParamPair("@WetLeaf", _input.WetLeaf == null ? 0 : _input.WetLeaf, false, "long"),
                new ClsParamPair("@LongLeaf", _input.LongLeaf == null ? 0 : _input.LongLeaf, false, "long"),
                new ClsParamPair("@Deduction",_input.Deduction == null ? 0 : _input.Deduction, false, "long"),
                new ClsParamPair("@FinalWeight", _input.FinalWeight == null ? 0 : _input.FinalWeight, false, "long"),
                new ClsParamPair("@Rate", _input.Rate == null ? 0 : _input.Rate, false, "long"),
                new ClsParamPair("@GrossAmount", _input.GrossAmount == null ? 0 : _input.GrossAmount, false, "long"),
                new ClsParamPair("@GradeId",_input.GradeId == null ? 0 : _input.GradeId, false, "long"),
                new ClsParamPair("@Remarks", _input.Remarks ?? "", false, "String"),
                new ClsParamPair("@Status", _input.Status ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[TeaCollection].[STGInsertUpdate]", oclsPairs);
            return Msg;
        }
    }
}
