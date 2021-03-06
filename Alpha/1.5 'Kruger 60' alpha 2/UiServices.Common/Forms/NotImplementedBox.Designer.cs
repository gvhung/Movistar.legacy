﻿// Copyright (C) 2014-2015, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

namespace Project.DvbIpTv.UiServices.Common.Forms
{
    partial class NotImplementedBox
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
            this.labelNotImplemented = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.pictureIconNotImplemented = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconNotImplemented)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNotImplemented
            // 
            this.labelNotImplemented.AutoSize = true;
            this.labelNotImplemented.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotImplemented.Location = new System.Drawing.Point(218, 25);
            this.labelNotImplemented.Name = "labelNotImplemented";
            this.labelNotImplemented.Size = new System.Drawing.Size(239, 147);
            this.labelNotImplemented.TabIndex = 1;
            this.labelNotImplemented.Text = "We\'re sorry! Work in progress\r\n\r\n¡Lo sentimos! Trabajo en curso\r\n\r\nDésolé! Travau" +
    "x en cours\r\n\r\nSiamo spiacenti! Lavori in corso";
            this.labelNotImplemented.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Image = global::Project.DvbIpTv.UiServices.Common.Properties.Resources.Action_Ok_16x16;
            this.buttonOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOk.Location = new System.Drawing.Point(372, 187);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 25);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "&OK";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // pictureIconNotImplemented
            // 
            this.pictureIconNotImplemented.Image = global::Project.DvbIpTv.UiServices.Common.Properties.Resources.NotImplemented_200x200;
            this.pictureIconNotImplemented.Location = new System.Drawing.Point(12, 12);
            this.pictureIconNotImplemented.Name = "pictureIconNotImplemented";
            this.pictureIconNotImplemented.Size = new System.Drawing.Size(200, 200);
            this.pictureIconNotImplemented.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureIconNotImplemented.TabIndex = 0;
            this.pictureIconNotImplemented.TabStop = false;
            // 
            // NotImplementedBox
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(472, 212);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelNotImplemented);
            this.Controls.Add(this.pictureIconNotImplemented);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotImplementedBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconNotImplemented)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureIconNotImplemented;
        private System.Windows.Forms.Label labelNotImplemented;
        private System.Windows.Forms.Button buttonOk;
    }
}