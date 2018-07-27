using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using BoVoyageBlandineThomasJonathan.Utils.Validators;

namespace BoVoyageBlandineThomasJonathan.Utils.Validators
{
    public static class Extensions
    {
        public static string HashMD5(this string value)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(value);

            try
            {
                MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
                byte[] hash = crypto.ComputeHash(textBytes);

                string result = "";
                foreach (byte b in hash)
                {
                    if (b < 16)
                        result += "0" + b.ToString();
                    else
                        result += b.ToString("x");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}