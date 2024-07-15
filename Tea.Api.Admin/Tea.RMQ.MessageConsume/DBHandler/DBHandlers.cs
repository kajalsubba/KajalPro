using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.DBHandler
{
    public class DBHandlers: IDBHandler
    {
        //readonly IConfiguration _config;
        //static readonly IConfiguration config = new ConfigurationBuilder()
        //           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

        private readonly SqlConnection SqlServerConnection;
        public DBHandlers()
        {
            //_config = config;
            DBConnect Conn = DBConnect.ConnObject;
            SqlServerConnection = Conn.SqlSvrConnection();
        }

       async Task<string> IDBHandler.SaveChangesAsyn(string sProcName, List<ClsParamPair> Param)
        {
            SqlTransaction trans;
            SqlConnection sSqlConnection = this.SqlServerConnection;
            try
            {
                await sSqlConnection.OpenAsync();
                trans = sSqlConnection.BeginTransaction();
                SqlCommand sSqlCommand = new(sProcName, sSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = trans
                };

                foreach (ClsParamPair oclsPair in Param)
                {
                    if (oclsPair.IsInteger == true)
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValueInt));
                    }
                    else if (oclsPair.IsdateDateUpdate == true)
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValuedate));
                    }
                    else if (oclsPair.Isbool == true)
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValueBool));
                    }
                    else if (oclsPair.IsTimespan == true)
                    {
                        if (oclsPair.ParmValueTimespan == null)
                        {
                            sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, DBNull.Value));
                        }
                        else
                        {
                            sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValueTimespan));
                        }
                    }
                    else if (oclsPair.Isvarbinary == true)
                    {
                        if (oclsPair.ParmValueByte == null)
                        {
                            sSqlCommand.Parameters.AddWithValue(oclsPair.ParmName, SqlBinary.Null);
                        }
                        else
                        {
                            sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValueByte));
                        }
                    }
                    else
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValue));
                    }
                }

                sSqlCommand.Parameters.Add("Msg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                await sSqlCommand.ExecuteNonQueryAsync();
                trans.Commit();
                string? ResultMsg = Convert.ToString(sSqlCommand.Parameters["Msg"].Value.ToString());
                return ResultMsg ?? "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await sSqlConnection.CloseAsync();
                SqlConnection.ClearPool(sSqlConnection);
                await sSqlConnection.DisposeAsync();
            }

        }
    }
}
