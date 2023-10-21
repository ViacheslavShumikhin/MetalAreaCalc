namespace MetalAreaCalc.Forms
{
    partial class AuthorizationError
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
            this.authorizationInfo = new MaterialSkin.Controls.MaterialLabel();
            this.authorizationInfo1 = new MaterialSkin.Controls.MaterialLabel();
            this.authorizationInfo2 = new MaterialSkin.Controls.MaterialLabel();
            this.authorizationInfoLogin = new MaterialSkin.Controls.MaterialButton();
            this.authorizationInfoNext = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // authorizationInfo
            // 
            this.authorizationInfo.AutoSize = true;
            this.authorizationInfo.Depth = 0;
            this.authorizationInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.authorizationInfo.Location = new System.Drawing.Point(96, 83);
            this.authorizationInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.authorizationInfo.Name = "authorizationInfo";
            this.authorizationInfo.Size = new System.Drawing.Size(204, 19);
            this.authorizationInfo.TabIndex = 0;
            this.authorizationInfo.Text = "Уважаемый пользователь!";
            // 
            // authorizationInfo1
            // 
            this.authorizationInfo1.AutoSize = true;
            this.authorizationInfo1.Depth = 0;
            this.authorizationInfo1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.authorizationInfo1.Location = new System.Drawing.Point(71, 118);
            this.authorizationInfo1.MouseState = MaterialSkin.MouseState.HOVER;
            this.authorizationInfo1.Name = "authorizationInfo1";
            this.authorizationInfo1.Size = new System.Drawing.Size(266, 19);
            this.authorizationInfo1.TabIndex = 1;
            this.authorizationInfo1.Text = "Для совершения данного действия";
            // 
            // authorizationInfo2
            // 
            this.authorizationInfo2.AutoSize = true;
            this.authorizationInfo2.Depth = 0;
            this.authorizationInfo2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.authorizationInfo2.Location = new System.Drawing.Point(71, 137);
            this.authorizationInfo2.MouseState = MaterialSkin.MouseState.HOVER;
            this.authorizationInfo2.Name = "authorizationInfo2";
            this.authorizationInfo2.Size = new System.Drawing.Size(271, 19);
            this.authorizationInfo2.TabIndex = 2;
            this.authorizationInfo2.Text = "пройдите пожалуйста авторизацию";
            // 
            // authorizationInfoLogin
            // 
            this.authorizationInfoLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.authorizationInfoLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.authorizationInfoLogin.Depth = 0;
            this.authorizationInfoLogin.HighEmphasis = true;
            this.authorizationInfoLogin.Icon = null;
            this.authorizationInfoLogin.Location = new System.Drawing.Point(74, 192);
            this.authorizationInfoLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.authorizationInfoLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.authorizationInfoLogin.Name = "authorizationInfoLogin";
            this.authorizationInfoLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.authorizationInfoLogin.Size = new System.Drawing.Size(129, 36);
            this.authorizationInfoLogin.TabIndex = 1;
            this.authorizationInfoLogin.Text = "Авторизация";
            this.authorizationInfoLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.authorizationInfoLogin.UseAccentColor = false;
            this.authorizationInfoLogin.UseVisualStyleBackColor = true;
            this.authorizationInfoLogin.Click += new System.EventHandler(this.authorizationInfoLogin_Click);
            // 
            // authorizationInfoNext
            // 
            this.authorizationInfoNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.authorizationInfoNext.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.authorizationInfoNext.Depth = 0;
            this.authorizationInfoNext.HighEmphasis = true;
            this.authorizationInfoNext.Icon = null;
            this.authorizationInfoNext.Location = new System.Drawing.Point(217, 192);
            this.authorizationInfoNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.authorizationInfoNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.authorizationInfoNext.Name = "authorizationInfoNext";
            this.authorizationInfoNext.NoAccentTextColor = System.Drawing.Color.Empty;
            this.authorizationInfoNext.Size = new System.Drawing.Size(125, 36);
            this.authorizationInfoNext.TabIndex = 2;
            this.authorizationInfoNext.Text = "Продолжить";
            this.authorizationInfoNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.authorizationInfoNext.UseAccentColor = false;
            this.authorizationInfoNext.UseVisualStyleBackColor = true;
            this.authorizationInfoNext.Click += new System.EventHandler(this.authorizationInfoNext_Click);
            // 
            // AuthorizationError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 280);
            this.Controls.Add(this.authorizationInfoNext);
            this.Controls.Add(this.authorizationInfoLogin);
            this.Controls.Add(this.authorizationInfo2);
            this.Controls.Add(this.authorizationInfo1);
            this.Controls.Add(this.authorizationInfo);
            this.Name = "AuthorizationError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Требуется авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel authorizationInfo;
        private MaterialSkin.Controls.MaterialLabel authorizationInfo1;
        private MaterialSkin.Controls.MaterialLabel authorizationInfo2;
        private MaterialSkin.Controls.MaterialButton authorizationInfoLogin;
        private MaterialSkin.Controls.MaterialButton authorizationInfoNext;
    }
}