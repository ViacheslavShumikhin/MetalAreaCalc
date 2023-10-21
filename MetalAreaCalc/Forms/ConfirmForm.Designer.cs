namespace MetalAreaCalc
{
    using MaterialSkin.Controls;
    using MaterialSkin.Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    partial class ConfirmForm
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
            this.labelConfirmEmail = new MaterialSkin.Controls.MaterialLabel();
            this.mtrTextBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.labelConfirmMailRepit = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // labelConfirmEmail
            // 
            this.labelConfirmEmail.AutoSize = true;
            this.labelConfirmEmail.Depth = 0;
            this.labelConfirmEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelConfirmEmail.Location = new System.Drawing.Point(113, 104);
            this.labelConfirmEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelConfirmEmail.Name = "labelConfirmEmail";
            this.labelConfirmEmail.Size = new System.Drawing.Size(256, 19);
            this.labelConfirmEmail.TabIndex = 1;
            this.labelConfirmEmail.Text = "Введите полученный на Email код";
            // 
            // mtrTextBoxEmail
            // 
            this.mtrTextBoxEmail.AnimateReadOnly = false;
            this.mtrTextBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtrTextBoxEmail.Depth = 0;
            this.mtrTextBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtrTextBoxEmail.LeadingIcon = null;
            this.mtrTextBoxEmail.Location = new System.Drawing.Point(189, 143);
            this.mtrTextBoxEmail.MaxLength = 50;
            this.mtrTextBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.mtrTextBoxEmail.Multiline = false;
            this.mtrTextBoxEmail.Name = "mtrTextBoxEmail";
            this.mtrTextBoxEmail.Size = new System.Drawing.Size(100, 50);
            this.mtrTextBoxEmail.TabIndex = 1;
            this.mtrTextBoxEmail.Text = "";
            this.mtrTextBoxEmail.TrailingIcon = null;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(175, 212);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(129, 36);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Подтвердить";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelConfirmMailRepit
            // 
            this.labelConfirmMailRepit.AutoSize = true;
            this.labelConfirmMailRepit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelConfirmMailRepit.Depth = 0;
            this.labelConfirmMailRepit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelConfirmMailRepit.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelConfirmMailRepit.Location = new System.Drawing.Point(172, 288);
            this.labelConfirmMailRepit.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelConfirmMailRepit.Name = "labelConfirmMailRepit";
            this.labelConfirmMailRepit.Size = new System.Drawing.Size(157, 19);
            this.labelConfirmMailRepit.TabIndex = 3;
            this.labelConfirmMailRepit.Text = "Отправить повторно";
            this.labelConfirmMailRepit.Click += new System.EventHandler(this.labelConfirmMailRepit_Click);
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 359);
            this.Controls.Add(this.labelConfirmMailRepit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.mtrTextBoxEmail);
            this.Controls.Add(this.labelConfirmEmail);
            this.Name = "ConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel labelConfirmEmail;
        private MaterialSkin.Controls.MaterialTextBox mtrTextBoxEmail;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialLabel labelConfirmMailRepit;
    }
}