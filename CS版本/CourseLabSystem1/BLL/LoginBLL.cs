using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Security.Cryptography;
using Model;

namespace BLL
{
    public class LoginBLL
    {
        LoginDAL loginDal = new LoginDAL();
        public string GetMd5Hash(string input)//讲 string型 转换为MD5加密
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "");
            }
        }
        
        public bool VerifyMd5Hash(string input, string pwd)//比较输入的字符串 与 密码是否一致
        {
            string hashOfInput = GetMd5Hash(input);
            return hashOfInput.CompareTo(pwd) == 0 ? true : false;
        }

        //根据用户名 判断是否存在此用户
        public bool EXiseUser(string usr)
        {
            return loginDal.ExiseUser(usr);
        }
        //根据用户名 找密码
        public string UserPwd(string usr)
        {
            return loginDal.UserPwd(usr);
        }
        public int Role(string user)
        {
            return loginDal.Role(user);
        }
        public bool BackPwd(UsersModel user)
        {
            return loginDal.BackPwd(user);
        }
    }
}
