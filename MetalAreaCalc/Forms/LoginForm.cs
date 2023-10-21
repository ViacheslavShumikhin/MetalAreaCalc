using MaterialSkin.Controls;
using MetalCalcLibrary;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace MetalAreaCalc
{
    public partial class LoginForm : MaterialForm
    {
        private MaterialSkin.Controls.MaterialTextBox2 txtLogin;  // Добавляем переменную для хранения логина
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;  // Добавляем переменную для хранения пароля
        private MaterialSkin.Controls.MaterialCheckbox checkSavePassword;  // Добавляем переменную для хранения "подверждения" сохранения пароля.

        public LoginForm()
        {
            InitializeComponent();
            // Обработчик события загрузки формы
            this.Load += new EventHandler(LoginForm_Load);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //
            // Используем класс - System.Configuration для сохранения пароля
            string savePasswird = ConfigurationManager.AppSettings["SavedPassword"];  // Получаем значение параметра конфигурации, который содежит сохраняемый пароль
            //Проверка, если сохраненный пароль не пустой, то заполняем поля логина и пароля
            if (!string.IsNullOrEmpty(savePasswird))
            {
                txtLogin.Text = ConfigurationManager.AppSettings["UserName"];
                txtPassword.Text = savePasswird;
                checkSavePassword.Checked = true;
            }
        }

        private void labelMainLoginForm_Click(object sender, EventArgs e)
        {
            // Проверяем, если стоит "Чек" то записываем в переменные логин и пароль. Далее нужно сделать проверку, если логин удачен, то пароль сохраняется
            if (checkBoxLogForm.Checked)
            {
                txtLogin = textBoxLogin;
                txtPassword = textBoxPass;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mbtnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                // Получаем логин и пароль из текстовых полей
                string login = textBoxLogin.Text.Trim();
                string password = textBoxPass.Text.Trim();

                // Формируем SQL-запрос для поиска пользователя по логину и паролю
                string query = $"SELECT * FROM Users WHERE Login='{login}' AND Password='{password}'";

                // Создаем экземпляр класса Database и вызываем метод OpenConnection для открытия соединения с базой данных

                Database db = new Database();

                // Открываем соединение с базой данных
                db.OpenConnection();

                // Выполняем запрос и получаем результаты
                DataTable dt = db.ExecuteQuery(query);

                // Если запрос вернул хотя бы одну запись, то авторизация прошла успешно
                if (dt.Rows.Count > 0)
                {
                    // Сохраняем логин в классе User
                    User.Login = login;


                    // Открываем главное окно приложения
                    if (!IsMainFormOpen())
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.CloseConnection();
                db.CloseTunnel();
            }
        }

        // Проверяем, если запущенна главная форма, нужно для авторизации из формы AuthorizationError, чтобы не открывать лишнюю форму
        private bool IsMainFormOpen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainForm)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (!FormChecker.IsMainFormOpen())
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }

            this.Hide();
        }
    }
}
