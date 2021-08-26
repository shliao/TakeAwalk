using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TakeAwalk.DBSource;

namespace TakeAwalk.Auth
{
    public class AuthManager
    {
        /// <summary> 檢查目前是否登入 </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary> 取得已登入的使用者資訊 (如果沒有登入就回傳 null) </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;


            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            if (userInfo == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }


            UserInfoModel model = new UserInfoModel();
            model.CustomerID = userInfo.CustomerID;
            model.Name = userInfo.Name;
            model.IdNumber = userInfo.IdNumber;
            model.MobilePhone = userInfo.MobilePhone;
            model.Email = userInfo.Email;
            model.Account = userInfo.Account;
            model.UserLevel = userInfo.UserLevel;

            return model;
        }

        /// <summary> 登出 </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }

        /// <summary> 嘗試登入 </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // 檢查空白
            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "請輸入帳號/密碼";
                return false;
            }


            // 讀取和檢查資料庫
            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            // 檢查 Null
            if (userInfo == null)
            {
                errorMsg = $"帳號: {account} 輸入錯誤";
                return false;
            }


            // 檢查帳號/密碼
            if (string.Compare(userInfo.Account, account, true) == 0 &&
                string.Compare(userInfo.Password, pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account;

                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "登入失敗，請重新確認帳號/密碼";
                return false;
            }
        }
    }
}
