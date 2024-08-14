using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Tea.RMQ.MessageConsume.DBHandler;
using Tea.RMQ.MessageConsume.Entity;
using Tea.RMQ.MessageConsume.FileUpload;

namespace Tea.RMQ.MessageConsume.Repository
{
    public class MQRepository : IMQRepository
    {


        //readonly IDBHandler _dBHandler;
        readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();


        public MQRepository()
        {
            //_dBHandler=new DBHandlers();
            _config = config;
        }

        async Task<string> IMQRepository.SaveSupplier(string message)
        {
            string ChallanPath = string.Empty;
            dynamic _input = JsonConvert.DeserializeObject<dynamic>(message)!;

            // Simulate file content (normally you would have actual byte data here)
            byte[] fileContents = _input.ChallanImageByte; // Initialize with the specified length

            if (fileContents.Length > 0)
            {
             
                List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CollectionId", _input.CollectionId == null ? 0 : _input.CollectionId, false, "long"),
                new ClsParamPair("@CollectionDate", Convert.ToDateTime(_input.CollectionDate), true,"Datetime"),
                new ClsParamPair("@VehicleNo",_input.VehicleNo ??"",false,"String"),
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId, false, "long"),
                new ClsParamPair("@FineLeaf", _input.FineLeaf == null ? 0 : _input.FineLeaf, false, "long"),
                new ClsParamPair("@ChallanWeight", _input.ChallanWeight == null ? 0 : _input.ChallanWeight, false, "long"),
                new ClsParamPair("@Rate",_input.Rate == null ? 0 : _input.Rate, false, "long"),
                new ClsParamPair("@GrossAmount", _input.GrossAmount == null ? 0 : _input.GrossAmount, false, "long"),
                new ClsParamPair("@TripId", _input.TripId == null ? 0 : _input.TripId, false, "long"),
                new ClsParamPair("@Remarks",_input.Remarks ??"",false,"String"),
                new ClsParamPair("@Status",_input.Status ??"",false,"String"),
                new ClsParamPair("@ChallanReceiptCopy","",false,"String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };

                IDBHandler _dBHandler = new DBHandlers();
                string Msg = await _dBHandler.SaveChangesAsyn("[TeaCollection].[SupplierMQInsertUpdate]", oclsPairs);
                Log.Information("Data Save :" + Msg);
                string[] msgList = Msg.Split(",");
                long AutoCollectionId = Convert.ToInt32(msgList[0]);

                var challanImage = _input.ChallanImage;
                using (var stream = new MemoryStream(fileContents))
                {
                    // Create FormFile
                    IFormFile challanFile = new FormFile(
                        stream,
                        0,
                        fileContents.Length,
                        (string)challanImage.Name,
                        (string)challanImage.FileName
                    )
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = (string)challanImage.ContentType,
                        ContentDisposition = (string)challanImage.ContentDisposition
                    };
                    ChallanPath = await ClsUploadFile.UploadFile(_config.GetConnectionString("FilePath"), _input.TenantId.ToString(), challanFile, "ChallanReciept" + AutoCollectionId, _config.GetConnectionString("DirectoryName"));

                    Log.Information("Upload Image :" + ChallanPath);
                    List<ClsParamPair> oclsImage = new()
                {
                new ClsParamPair("@CollectionId", AutoCollectionId, false, "long"),
                new ClsParamPair("@ChallanReceiptCopy",ChallanPath ??"",false,"String")

                };
                    IDBHandler _dBHandler1 = new DBHandlers();
                    string ImageMsg = await _dBHandler1.SaveChangesAsyn("[TeaCollection].[SupplierChallanUpdate]", oclsImage);

                    Log.Information("Update Image Details :" + ImageMsg);
                    Log.Information("Finish Consume");
                    return ImageMsg;

                }
            }
            else
            {
                Log.Information("Challan is not uploaded");
                return "0,Challan is not uploaded.!";
            }
        }
    }
}
