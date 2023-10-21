namespace MetalAreaCalc
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnResume = new MaterialSkin.Controls.MaterialButton();
            this.textBoxLogin = new MaterialSkin.Controls.MaterialTextBox2();
            this.checkBoxLogForm = new MaterialSkin.Controls.MaterialCheckbox();
            this.textBoxPass = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtnRegistration = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(74, 261);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnLogin.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(160, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Войти";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(272, 261);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnCancel.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResume
            // 
            this.btnResume.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResume.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResume.Depth = 0;
            this.btnResume.HighEmphasis = true;
            this.btnResume.Icon = null;
            this.btnResume.Location = new System.Drawing.Point(174, 313);
            this.btnResume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResume.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnResume.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnResume.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResume.Name = "btnResume";
            this.btnResume.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResume.Size = new System.Drawing.Size(160, 40);
            this.btnResume.TabIndex = 6;
            this.btnResume.Text = "продолжить без авторизации";
            this.btnResume.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResume.UseAccentColor = false;
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.AnimateReadOnly = false;
            this.textBoxLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxLogin.Depth = 0;
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLogin.HideSelection = true;
            this.textBoxLogin.Hint = "Логин";
            this.textBoxLogin.LeadingIcon = null;
            this.textBoxLogin.Location = new System.Drawing.Point(126, 94);
            this.textBoxLogin.MaxLength = 32767;
            this.textBoxLogin.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.PasswordChar = '\0';
            this.textBoxLogin.PrefixSuffixText = null;
            this.textBoxLogin.ReadOnly = false;
            this.textBoxLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLogin.SelectedText = "";
            this.textBoxLogin.SelectionLength = 0;
            this.textBoxLogin.SelectionStart = 0;
            this.textBoxLogin.ShortcutsEnabled = true;
            this.textBoxLogin.Size = new System.Drawing.Size(243, 48);
            this.textBoxLogin.TabIndex = 1;
            this.textBoxLogin.TabStop = false;
            this.textBoxLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLogin.TrailingIcon = null;
            this.textBoxLogin.UseSystemPasswordChar = false;
            // 
            // checkBoxLogForm
            // 
            this.checkBoxLogForm.AutoSize = true;
            this.checkBoxLogForm.Depth = 0;
            this.checkBoxLogForm.Location = new System.Drawing.Point(126, 218);
            this.checkBoxLogForm.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxLogForm.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxLogForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxLogForm.Name = "checkBoxLogForm";
            this.checkBoxLogForm.ReadOnly = false;
            this.checkBoxLogForm.Ripple = true;
            this.checkBoxLogForm.Size = new System.Drawing.Size(237, 37);
            this.checkBoxLogForm.TabIndex = 3;
            this.checkBoxLogForm.Text = "Запомнить логин и пароль";
            this.checkBoxLogForm.UseVisualStyleBackColor = true;
            this.checkBoxLogForm.Visible = false;
            // 
            // textBoxPass
            // 
            this.textBoxPass.AnimateReadOnly = false;
            this.textBoxPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPass.Depth = 0;
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPass.HideSelection = true;
            this.textBoxPass.Hint = "Пароль";
            this.textBoxPass.LeadingIcon = null;
            this.textBoxPass.Location = new System.Drawing.Point(126, 167);
            this.textBoxPass.MaxLength = 50;
            this.textBoxPass.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '●';
            this.textBoxPass.PrefixSuffixText = null;
            this.textBoxPass.ReadOnly = false;
            this.textBoxPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPass.SelectedText = "";
            this.textBoxPass.SelectionLength = 0;
            this.textBoxPass.SelectionStart = 0;
            this.textBoxPass.ShortcutsEnabled = true;
            this.textBoxPass.Size = new System.Drawing.Size(243, 48);
            this.textBoxPass.TabIndex = 2;
            this.textBoxPass.TabStop = false;
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPass.TrailingIcon = null;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // mbtnRegistration
            // 
            this.mbtnRegistration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnRegistration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mbtnRegistration.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnRegistration.Depth = 0;
            this.mbtnRegistration.HighEmphasis = true;
            this.mbtnRegistration.Icon = null;
            this.mbtnRegistration.Location = new System.Drawing.Point(174, 365);
            this.mbtnRegistration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnRegistration.MaximumSize = new System.Drawing.Size(160, 40);
            this.mbtnRegistration.MinimumSize = new System.Drawing.Size(160, 40);
            this.mbtnRegistration.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnRegistration.Name = "mbtnRegistration";
            this.mbtnRegistration.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnRegistration.Size = new System.Drawing.Size(160, 40);
            this.mbtnRegistration.TabIndex = 7;
            this.mbtnRegistration.Text = "Зарегистрироватся";
            this.mbtnRegistration.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnRegistration.UseAccentColor = false;
            this.mbtnRegistration.UseVisualStyleBackColor = true;
            this.mbtnRegistration.Click += new System.EventHandler(this.mbtnRegistration_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(509, 429);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.mbtnRegistration);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkBoxLogForm);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор MetalAreaCalc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnResume;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxLogin;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxPass;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxLogForm;
        private MaterialSkin.Controls.MaterialButton mbtnRegistration;
    }
}

