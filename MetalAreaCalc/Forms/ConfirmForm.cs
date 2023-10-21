using MaterialSkin.Controls;
using MetalCalcLibrary;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace MetalAreaCalc
{
    public partial class ConfirmForm : MaterialForm
    {
        // Добавляем определения свойств
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ConfirmationCode { get; set; }

        // Добавляем конструктор для создания объекта класса ConfirmForm
        public ConfirmForm(string login, string email, string password, int confirmationCode)
        {
            InitializeComponent();
            Login = login;
            Email = email;
            Password = password;
            ConfirmationCode = confirmationCode;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ConfirmationCode == int.Parse(mtrTextBoxEmail.Text))
            {
                DateTime Date = DateTime.Now;
                // Создаем экземпляр класса Database и вызываем метод OpenConnection для открытия соединения с базой данных

                Database db = new Database();

                // Открываем соединение с базой данных
                db.OpenConnection();

                // Сохраняем данные пользователя в базе данных
                string query = "INSERT INTO Users (Login, Email, Password, RegistrationDate) " +
                               $"VALUES ('{Login}', '{Email}', '{Password}', CURRENT_TIMESTAMP)";


                db.ExecuteQuery(query);

                // Закрываем соединение с базой данных
                db.CloseConnection();
                db.CloseTunnel();

                // Закрываем текущее окно регистрации
                this.Close();

                // Закрываем окно регистрации, если оно существует
                RegistrationForm registerForm = Application.OpenForms.OfType<RegistrationForm>().FirstOrDefault();
                registerForm?.Close();
            }
            else MessageBox.Show("Ой! Неверный код подтверждения", "Попробуйте снова!", MessageBoxButtons.OK);

        }

        private void labelConfirmMailRepit_Click(object sender, EventArgs e)
        {
            // Генерируем новый код подтверждения
            Random random = new Random();
            int newConfirmationCode = random.Next(1000, 9999);

            // Отправляем новый email с новым кодом подтверждения
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.yandex.ru", 25))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("MetalAreaCalc@yandex.ru", "vpyqmxkoxdminivd");
                    client.EnableSsl = true;
                    MailMessage message = new MailMessage("MetalAreaCalc@yandex.ru", Email);
                    message.Subject = "Повторное подтверждение регистрации MetalAreaCalc - Калькулятор пасчеиа площади металлических конструкций";
                    message.Body = $"Новый код подтверждения: {newConfirmationCode}\n" +
                                   $"Ваш логин: {Login}\n" +
                                   $"Ваш пароль: {Password}\n" +
                                   $"\n" +
                                   $"Аккаунт будет создан только после подтверждения данной электронной почты";

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки email: {ex.Message}");
                return;
            }

            // Обновляем значение ConfirmationCode
            ConfirmationCode = newConfirmationCode;

            MessageBox.Show("Новый код подтверждения отправлен на ваш email");
        }

    }
}
