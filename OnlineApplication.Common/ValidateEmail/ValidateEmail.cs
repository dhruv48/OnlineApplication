using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineApplication.Common.ValidateEmail
{
    public class ValidateEmail
    {
        public const string MatchEmailPattern = @"^([\w-.]+@(?!gmail\.com)(?!yahoo\.com)(?!hotmail\.com)(?!mail\.ru)(?!yandex\.ru)(?!mail\.com)([\w-]+.)+[\w-]{2,4})?$";
        public  bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }

    }
}
