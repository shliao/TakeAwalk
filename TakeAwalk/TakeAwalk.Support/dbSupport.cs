using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using TakeAwalk.DBSource;
using TakeAwalk.ORM.DBModels;

namespace TakeAwalk.Support
{
    public class dbSupport
    {
        public static string Getconnectionstring()
        {
            string val = ConfigurationManager.ConnectionStrings["DefauitConnectionString"].ConnectionString;
            return val;
        }
        public static DataRow ReadDataRow(string connectionstring, string dbCommandstring, List<SqlParameter> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddRange(list.ToArray());

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();

                    if (dt.Rows.Count == 0)
                        return null;
                    DataRow dr = dt.Rows[0];
                    return dr;
                }
            }
        }
        public class Logger
        {
            public static void Writelog(Exception ex)
            {
                throw ex;
            }
        }
        public static bool trySearch(string account, string email, out string errorMsg)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(email))
            {
                errorMsg = "請輸入帳號和信箱。";
                return false;
            }

            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            if (userInfo == null)
            {
                errorMsg = "帳號輸入錯誤。";
                return false;
            }
            if (string.Compare(userInfo.Account, account) == 0 &&
                string.Compare(userInfo.Email, email) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account;
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "請重新確認帳號與信箱。";
                return false;
            }

        }
        public static void CreateCustomer(UserInfo userInfo)
        {

            try
            {
                using (ContextModel context = new ContextModel())
                {

                    context.UserInfoes.Add(userInfo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);

            }
        }
        public static bool UpdatePWD(Guid CustomerID, string PWD)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.UserInfoes
                                 where item.CustomerID == CustomerID
                                 select item).FirstOrDefault();
                    query.Password = PWD;
                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
                return false;
            }
        }
    }
}

