using Hui_Demo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Helper
{
    public class AccountHelper
    {
        public static void SaveUser(User User)
        {
            HttpContext.Current.Session["User"] = User;
            CookieHelper.AddCookie("Token", Encryption.DEncrypt.Encrypt(User.ID.ToString()), DateTime.Now.AddMinutes(30));
            return;
        }


        public static User GetUser()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                return (User)HttpContext.Current.Session["User"];
            }
            else
            {
                try
                {
                    if (CookieHelper.GetCookie("Token") == null)
                    {
                        return null;
                    }
                    else
                    {
                        var ctx = ContextHelper.Create();

                        String Token = CookieHelper.GetCookie("Token").Value;
                        Token = Helper.Encryption.DEncrypt.Decrypt(Token);//Token解密

                        int ID = Convert.ToInt32(Token);
                        User User = ctx.User.First(u => u.ID == ID);
                        return User;
                    }

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return null;
                }
            }

        }
    }
}