using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.DbHandler
{
    public class DataHandler : IDataHandler
    {
        private readonly SqlConnection SqlServerConnection;
        public DataHandler()
        {
            DbConnect Conn = DbConnect.ConnObject;
            SqlServerConnection = Conn.SqlSvrConnection();
        }
        async Task<DataSet> IDataHandler.ExecProcDataSetAsyn(string sProcName)
        {
            DataSet ds = new();
            SqlConnection sSqlConnection = this.SqlServerConnection;
            try
            {
                await sSqlConnection.OpenAsync();
                SqlCommand sSqlCommand = new(sProcName, sSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter Da = new(sSqlCommand);
                Da.Fill(ds);

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
            return ds;
        }

        async Task<DataSet> IDataHandler.ExecProcDataSetAsyn(string sProcName, List<ClsParamPair> Param)
        {
            DataSet ds = new();
            SqlConnection sSqlConnection = this.SqlServerConnection;
            try
            {
                await sSqlConnection.OpenAsync();
                SqlCommand sSqlCommand = new(sProcName, sSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter Da = new(sSqlCommand);
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
                    else
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValue));
                    }
                }
                Da.Fill(ds);
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
            return ds;
        }

        async Task<DataTable> IDataHandler.ExecProcDataTableAsyn(string sProcName)
        {
            DataTable dt = new();
            SqlConnection sSqlConnection = this.SqlServerConnection;
            try
            {
                await sSqlConnection.OpenAsync();
                dt.TableName = "tbl1";
                SqlCommand sSqlCommand = new(sProcName, sSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter Da = new(sSqlCommand);
                Da.Fill(dt);
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
            return dt;
        }

        async Task<DataTable> IDataHandler.ExecProcDataTableAsyn(string sProcName, List<ClsParamPair> Param)
        {
            DataTable dt = new();
            SqlConnection sSqlConnection = this.SqlServerConnection;
            try
            {
                await sSqlConnection.OpenAsync();
                dt.TableName = "table1";
                SqlCommand sSqlCommand = new(sProcName, sSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter Da = new(sSqlCommand);
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
                    else
                    {
                        sSqlCommand.Parameters.Add(new SqlParameter(oclsPair.ParmName, oclsPair.ParmValue));
                    }
                }
                Da.Fill(dt);
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
            return dt;
        }

        async Task<string> IDataHandler.ExecuteUserTypeTableAsyn(string sProcName, SqlParameter[] parameters, List<ClsParamPair> Param)
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
                foreach (var parameter in parameters)
                {
                    sSqlCommand.Parameters.Add(parameter);
                }
                sSqlCommand.Parameters.Add("msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                await sSqlCommand.ExecuteNonQueryAsync();
                trans.Commit();
                string? ResultMsg = Convert.ToString(sSqlCommand.Parameters["msg"].Value.ToString());
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

        async Task<string> IDataHandler.SaveChangesAsyn(string sProcName, List<ClsParamPair> Param)
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
