using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.DBHandler
{
    public class ClsParamPair
    {
        public string? ParmName { get; set; }
        public string? ParmValue { get; set; }
        public bool? ParmValueBool { get; set; }
        public Int64? ParmValueInt { get; set; }
        public bool? IsInteger { get; set; }
        public bool? IsdateDate { get; set; }
        public bool? IsdateDateUpdate { get; set; }
        public bool? IsTimespan { get; set; }
        public bool? Isbool { get; set; }
        public bool? Isvarbinary { get; set; }
        public DateTime? ParmValuedate { get; set; }
        public Byte[]? ParmValueByte { get; set; }
        public TimeSpan? ParmValueTimespan { get; set; }


        public ClsParamPair(string sParamName, string sParmValue)
        {
            ParmName = sParamName;
            ParmValue = sParmValue;
        }


        public ClsParamPair(string sParamName, string sParmValue, bool IsdateDate = false)
        {
            ParmName = sParamName;
            if (IsdateDate == false)
            {
                ParmValue = sParmValue;
            }
            else
            {
                IsdateDateUpdate = true;
                ParmValuedate = Convert.ToDateTime(sParmValue);

            }

        }

        public ClsParamPair(string sParamName, object sParmValue, bool IsdateDate = false, string sParamType = "")
        {
            ParmName = sParamName;

            if (IsdateDate == false)
            {
                if (sParamType.ToLower() == "timespan")
                {

                    IsTimespan = true;

                    if (sParmValue == null)
                    {
                        ParmValueTimespan = null;
                    }
                    else
                    {
                        if (sParmValue.ToString() == "00:00")
                        {
                            ParmValueTimespan = null;
                        }
                        else
                        {
                            DateTime date1 = Convert.ToDateTime(sParmValue);
                            TimeSpan ts = new(date1.Hour, date1.Minute, date1.Second);

                            ParmValueTimespan = TimeSpan.Parse(ts.ToString());
                        }
                    }

                }
                else if (sParamType.ToLower() == "bool")
                {
                    Isbool = true;
                    ParmValueBool = Convert.ToBoolean(sParmValue);
                }
                else if (sParamType.ToLower() == "varbinary")
                {
                    Isvarbinary = true;
                    ParmValueByte = (byte[])sParmValue;
                }
                else if (sParamType.ToLower() == "nullable")
                {

                    ParmValue = null;
                }

                else
                {

                    ParmValue = sParmValue == null ? null : Convert.ToString(sParmValue);

                }
            }
            else
            {
                IsdateDateUpdate = true;
                if (sParmValue == null)
                {
                    ParmValuedate = null;

                }
                else
                {
                    ParmValuedate = Convert.ToDateTime(sParmValue);

                }

            }


        }
    }
}
