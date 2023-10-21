using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;

namespace MetalCalcLibrary
{
    // Подключаем библиотеки using System.Configuration;   using System.Security.Cryptography;
    public class AppSettings // Создаем класс для безопасного хранения паролей.
    {
        private static string GetEncryptedAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            var bytes = Convert.FromBase64String(value);
            var unprotectBytes = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
            var unprotectValue = System.Text.Encoding.Unicode.GetString(unprotectBytes);
            return unprotectValue;
        }

        public static string GetSmtpPassword()
        {
            return GetEncryptedAppSetting("SmtpPassword");
        }
    }
}
