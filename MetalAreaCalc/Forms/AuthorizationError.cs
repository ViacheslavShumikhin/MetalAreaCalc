using DocumentFormat.OpenXml.Drawing.Charts;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalAreaCalc.Forms
{
    public partial class AuthorizationError : MaterialForm
    {
        public AuthorizationError()
        {
            InitializeComponent();
        }

        private void authorizationInfoNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void authorizationInfoLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
