using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCalcLibrary
{
    public class User
    {
        public static string Login { get; set; }

        public static void Logout()
        {
            Login = null; // Сбрасываем значение свойства Login, чтобы указать, что пользователь вышел из аккаунта
        }

    }
}
