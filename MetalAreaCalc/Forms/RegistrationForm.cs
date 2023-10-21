using MaterialSkin.Controls;
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using MetalAreaCalc.Forms;
using MetalCalcLibrary;
using System.Text.RegularExpressions;

namespace MetalAreaCalc
{
    public partial class RegistrationForm : MaterialForm
    {


        // Добавляем конструктор для создания объекта класса ConfirmForm
        public RegistrationForm()
        {
            InitializeComponent();

        }

        private void btnRegisterRegForm_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            // Проверяем корректность адреса электронной почты
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (!Regex.IsMatch(tbEmail.Text, emailPattern))
            {
                MessageBox.Show("Введите корректный адрес электронной почты");
                return;
            }

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Введите email");
                return;
            }

            if (string.IsNullOrEmpty(tbPass.Text))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            // Проверяем совпадение паролей
            if (tbPass.Text != tbPass2.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            // Проверяем наличие галочки
            if (!checkBoxRegForm.Checked)
            {
                MessageBox.Show("Подтвердите условия регистрации");
                return;
            }

            // Проверяем занятость логина
            string login = tbLogin.Text;
            string email = tbEmail.Text;
            Database database = new Database();
            database.OpenConnection();

            string checkLoginQuery = $"SELECT COUNT(*) FROM Users WHERE Login = '{login}'";
            object loginResult = database.ExecuteScalar(checkLoginQuery);
            int loginCount = Convert.ToInt32(loginResult);

            // Проверяем занятость почты
            string checkEmailQuery = $"SELECT COUNT(*) FROM Users WHERE Email = '{email}'";
            object emailResult = database.ExecuteScalar(checkEmailQuery);
            int emailCount = Convert.ToInt32(emailResult);

            database.CloseConnection();
            database.CloseTunnel();

            if (loginCount > 0 && emailCount > 0)
            {
                MessageBox.Show($"Логин {login} и {email}  уже заняты");
                return;
            }

            if (emailCount == 0 && loginCount > 0)
            {
                MessageBox.Show($"Email {email} уже занят");
                return;
            }

            if (emailCount > 0 && loginCount == 0)
            {
                MessageBox.Show($"Логин {login} уже занят");
                return;
            }

            // Генерируем 4-х значное число для подтверждения email
            Random random = new Random();
            int confirmationCode = random.Next(1000, 9999);

            // Отправляем email с кодом подтверждения
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.yandex.ru", 25))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("MetalAreaCalc@yandex.ru", "vpyqmxkoxdminivd");
                    client.EnableSsl = true;
                    MailMessage message = new MailMessage("MetalAreaCalc@yandex.ru", tbEmail.Text);
                    message.Subject = "Подтверждение регистрации MetalAreaCalc - Калькулятор пасчеиа площади металлических конструкций";
                    message.Body = $"Код подтверждения: {confirmationCode}\n" +
                                   $"Ваш логин: {tbLogin.Text}\n" +
                                   $"Ваш пароль: {tbPass.Text}\n" +
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

            // Создаем экземпляр класса ConfirmForm и передаем в него все необходимые данные
            ConfirmForm confirmForm = new ConfirmForm(tbLogin.Text, tbEmail.Text, tbPass.Text, confirmationCode);
            confirmForm.Show();
        }

        private void labelUserAgreement_Click(object sender, EventArgs e)
        {
            UserАgreementForm agreementForm = new UserАgreementForm();
            agreementForm.Show();
        }

        private void btnResumeRegForm_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
        }

        private void btnCancelRegForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
