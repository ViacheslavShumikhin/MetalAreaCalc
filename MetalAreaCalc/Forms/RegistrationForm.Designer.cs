namespace MetalAreaCalc
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMainRegisterForm = new MaterialSkin.Controls.MaterialLabel();
            this.tbName = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbLogin = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnResumeRegForm = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelRegForm = new MaterialSkin.Controls.MaterialButton();
            this.btnRegisterRegForm = new MaterialSkin.Controls.MaterialButton();
            this.checkBoxRegForm = new MaterialSkin.Controls.MaterialCheckbox();
            this.tbEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbPass2 = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbPass = new MaterialSkin.Controls.MaterialTextBox2();
            this.labelUserAgreement = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // labelMainRegisterForm
            // 
            this.labelMainRegisterForm.AutoSize = true;
            this.labelMainRegisterForm.Depth = 0;
            this.labelMainRegisterForm.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelMainRegisterForm.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.labelMainRegisterForm.Location = new System.Drawing.Point(154, 71);
            this.labelMainRegisterForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelMainRegisterForm.Name = "labelMainRegisterForm";
            this.labelMainRegisterForm.Size = new System.Drawing.Size(145, 29);
            this.labelMainRegisterForm.TabIndex = 7;
            this.labelMainRegisterForm.Text = "Регистрация";
            // 
            // tbName
            // 
            this.tbName.AnimateReadOnly = false;
            this.tbName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbName.Depth = 0;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbName.HideSelection = true;
            this.tbName.Hint = "Имя";
            this.tbName.LeadingIcon = null;
            this.tbName.Location = new System.Drawing.Point(135, 115);
            this.tbName.MaxLength = 32767;
            this.tbName.MouseState = MaterialSkin.MouseState.OUT;
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.PrefixSuffixText = null;
            this.tbName.ReadOnly = false;
            this.tbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbName.SelectedText = "";
            this.tbName.SelectionLength = 0;
            this.tbName.SelectionStart = 0;
            this.tbName.ShortcutsEnabled = true;
            this.tbName.Size = new System.Drawing.Size(265, 48);
            this.tbName.TabIndex = 1;
            this.tbName.TabStop = false;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbName.TrailingIcon = null;
            this.tbName.UseSystemPasswordChar = false;
            // 
            // tbLogin
            // 
            this.tbLogin.AnimateReadOnly = false;
            this.tbLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbLogin.Depth = 0;
            this.tbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbLogin.HideSelection = true;
            this.tbLogin.Hint = "Логин";
            this.tbLogin.LeadingIcon = null;
            this.tbLogin.Location = new System.Drawing.Point(135, 169);
            this.tbLogin.MaxLength = 32767;
            this.tbLogin.MouseState = MaterialSkin.MouseState.OUT;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.PasswordChar = '\0';
            this.tbLogin.PrefixSuffixText = null;
            this.tbLogin.ReadOnly = false;
            this.tbLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbLogin.SelectedText = "";
            this.tbLogin.SelectionLength = 0;
            this.tbLogin.SelectionStart = 0;
            this.tbLogin.ShortcutsEnabled = true;
            this.tbLogin.Size = new System.Drawing.Size(265, 48);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.TabStop = false;
            this.tbLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbLogin.TrailingIcon = null;
            this.tbLogin.UseSystemPasswordChar = false;
            // 
            // btnResumeRegForm
            // 
            this.btnResumeRegForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResumeRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResumeRegForm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResumeRegForm.Depth = 0;
            this.btnResumeRegForm.HighEmphasis = true;
            this.btnResumeRegForm.Icon = null;
            this.btnResumeRegForm.Location = new System.Drawing.Point(190, 526);
            this.btnResumeRegForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResumeRegForm.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnResumeRegForm.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnResumeRegForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResumeRegForm.Name = "btnResumeRegForm";
            this.btnResumeRegForm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResumeRegForm.Size = new System.Drawing.Size(160, 40);
            this.btnResumeRegForm.TabIndex = 9;
            this.btnResumeRegForm.Text = "продолжить без авторизации";
            this.btnResumeRegForm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResumeRegForm.UseAccentColor = false;
            this.btnResumeRegForm.UseVisualStyleBackColor = true;
            this.btnResumeRegForm.Click += new System.EventHandler(this.btnResumeRegForm_Click);
            // 
            // btnCancelRegForm
            // 
            this.btnCancelRegForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelRegForm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelRegForm.Depth = 0;
            this.btnCancelRegForm.HighEmphasis = true;
            this.btnCancelRegForm.Icon = null;
            this.btnCancelRegForm.Location = new System.Drawing.Point(190, 474);
            this.btnCancelRegForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelRegForm.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnCancelRegForm.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnCancelRegForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelRegForm.Name = "btnCancelRegForm";
            this.btnCancelRegForm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelRegForm.Size = new System.Drawing.Size(160, 40);
            this.btnCancelRegForm.TabIndex = 8;
            this.btnCancelRegForm.Text = "Отмена";
            this.btnCancelRegForm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelRegForm.UseAccentColor = false;
            this.btnCancelRegForm.UseVisualStyleBackColor = true;
            this.btnCancelRegForm.Click += new System.EventHandler(this.btnCancelRegForm_Click);
            // 
            // btnRegisterRegForm
            // 
            this.btnRegisterRegForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegisterRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterRegForm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegisterRegForm.Depth = 0;
            this.btnRegisterRegForm.HighEmphasis = true;
            this.btnRegisterRegForm.Icon = null;
            this.btnRegisterRegForm.Location = new System.Drawing.Point(190, 422);
            this.btnRegisterRegForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegisterRegForm.MaximumSize = new System.Drawing.Size(160, 40);
            this.btnRegisterRegForm.MinimumSize = new System.Drawing.Size(160, 40);
            this.btnRegisterRegForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegisterRegForm.Name = "btnRegisterRegForm";
            this.btnRegisterRegForm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegisterRegForm.Size = new System.Drawing.Size(160, 40);
            this.btnRegisterRegForm.TabIndex = 7;
            this.btnRegisterRegForm.Text = "Зарегистрироваться";
            this.btnRegisterRegForm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegisterRegForm.UseAccentColor = false;
            this.btnRegisterRegForm.UseVisualStyleBackColor = true;
            this.btnRegisterRegForm.Click += new System.EventHandler(this.btnRegisterRegForm_Click);
            // 
            // checkBoxRegForm
            // 
            this.checkBoxRegForm.AutoSize = true;
            this.checkBoxRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRegForm.Depth = 0;
            this.checkBoxRegForm.Location = new System.Drawing.Point(107, 383);
            this.checkBoxRegForm.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxRegForm.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxRegForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxRegForm.Name = "checkBoxRegForm";
            this.checkBoxRegForm.ReadOnly = false;
            this.checkBoxRegForm.Ripple = true;
            this.checkBoxRegForm.Size = new System.Drawing.Size(35, 37);
            this.checkBoxRegForm.TabIndex = 6;
            this.checkBoxRegForm.UseVisualStyleBackColor = true;
            // 
            // tbEmail
            // 
            this.tbEmail.AnimateReadOnly = false;
            this.tbEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbEmail.Depth = 0;
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbEmail.HideSelection = true;
            this.tbEmail.Hint = "Email (требует подтверждения)";
            this.tbEmail.LeadingIcon = null;
            this.tbEmail.Location = new System.Drawing.Point(135, 221);
            this.tbEmail.MaxLength = 32767;
            this.tbEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PasswordChar = '\0';
            this.tbEmail.PrefixSuffixText = null;
            this.tbEmail.ReadOnly = false;
            this.tbEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbEmail.SelectedText = "";
            this.tbEmail.SelectionLength = 0;
            this.tbEmail.SelectionStart = 0;
            this.tbEmail.ShortcutsEnabled = true;
            this.tbEmail.Size = new System.Drawing.Size(265, 48);
            this.tbEmail.TabIndex = 3;
            this.tbEmail.TabStop = false;
            this.tbEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbEmail.TrailingIcon = null;
            this.tbEmail.UseSystemPasswordChar = false;
            // 
            // tbPass2
            // 
            this.tbPass2.AnimateReadOnly = false;
            this.tbPass2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbPass2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbPass2.Depth = 0;
            this.tbPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPass2.HideSelection = true;
            this.tbPass2.Hint = "Повторите пароль";
            this.tbPass2.LeadingIcon = null;
            this.tbPass2.Location = new System.Drawing.Point(135, 329);
            this.tbPass2.MaxLength = 32767;
            this.tbPass2.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '●';
            this.tbPass2.PrefixSuffixText = null;
            this.tbPass2.ReadOnly = false;
            this.tbPass2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPass2.SelectedText = "";
            this.tbPass2.SelectionLength = 0;
            this.tbPass2.SelectionStart = 0;
            this.tbPass2.ShortcutsEnabled = true;
            this.tbPass2.Size = new System.Drawing.Size(265, 48);
            this.tbPass2.TabIndex = 5;
            this.tbPass2.TabStop = false;
            this.tbPass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPass2.TrailingIcon = null;
            this.tbPass2.UseSystemPasswordChar = true;
            // 
            // tbPass
            // 
            this.tbPass.AnimateReadOnly = false;
            this.tbPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbPass.Depth = 0;
            this.tbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPass.HideSelection = true;
            this.tbPass.Hint = "Пароль";
            this.tbPass.LeadingIcon = null;
            this.tbPass.Location = new System.Drawing.Point(135, 275);
            this.tbPass.MaxLength = 32767;
            this.tbPass.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '●';
            this.tbPass.PrefixSuffixText = null;
            this.tbPass.ReadOnly = false;
            this.tbPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPass.SelectedText = "";
            this.tbPass.SelectionLength = 0;
            this.tbPass.SelectionStart = 0;
            this.tbPass.ShortcutsEnabled = true;
            this.tbPass.Size = new System.Drawing.Size(265, 48);
            this.tbPass.TabIndex = 4;
            this.tbPass.TabStop = false;
            this.tbPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPass.TrailingIcon = null;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // labelUserAgreement
            // 
            this.labelUserAgreement.AutoSize = true;
            this.labelUserAgreement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUserAgreement.Depth = 0;
            this.labelUserAgreement.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelUserAgreement.Location = new System.Drawing.Point(145, 392);
            this.labelUserAgreement.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelUserAgreement.Name = "labelUserAgreement";
            this.labelUserAgreement.Size = new System.Drawing.Size(270, 19);
            this.labelUserAgreement.TabIndex = 10;
            this.labelUserAgreement.Text = "Согласие с условиями пользования";
            this.labelUserAgreement.Click += new System.EventHandler(this.labelUserAgreement_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 616);
            this.Controls.Add(this.labelUserAgreement);
            this.Controls.Add(this.checkBoxRegForm);
            this.Controls.Add(this.btnRegisterRegForm);
            this.Controls.Add(this.btnCancelRegForm);
            this.Controls.Add(this.btnResumeRegForm);
            this.Controls.Add(this.tbPass2);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelMainRegisterForm);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelMainRegisterForm;
        private MaterialSkin.Controls.MaterialTextBox2 tbName;
        private MaterialSkin.Controls.MaterialTextBox2 tbLogin;
        private MaterialSkin.Controls.MaterialTextBox2 tbPass;
        private MaterialSkin.Controls.MaterialTextBox2 tbPass2;
        private MaterialSkin.Controls.MaterialButton btnResumeRegForm;
        private MaterialSkin.Controls.MaterialButton btnCancelRegForm;
        private MaterialSkin.Controls.MaterialButton btnRegisterRegForm;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxRegForm;
        private MaterialSkin.Controls.MaterialTextBox2 tbEmail;
        private MaterialSkin.Controls.MaterialLabel labelUserAgreement;
    }
}