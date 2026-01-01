using System;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    partial class ColorSlicingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelColorPreview = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelColorInfo = new System.Windows.Forms.Label();
            this.labelRGBValue = new System.Windows.Forms.Label();
            this.btnColorSlicing = new System.Windows.Forms.Button();
            this.btnPseudoColor = new System.Windows.Forms.Button();
            this.labelTolerance = new System.Windows.Forms.Label();
            this.trackBarTolerance = new System.Windows.Forms.TrackBar();
            this.labelToleranceValue = new System.Windows.Forms.Label();
            this.trackBarPseudoPercent = new System.Windows.Forms.TrackBar();
            this.labelPseudoPercentValue = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.checkBoxGrayBackground = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPseudoPercent)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelColorPreview
            // 
            this.panelColorPreview.BackColor = System.Drawing.Color.Red;
            this.panelColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColorPreview.Location = new System.Drawing.Point(20, 75);
            this.panelColorPreview.Name = "panelColorPreview";
            this.panelColorPreview.Size = new System.Drawing.Size(70, 70);
            this.panelColorPreview.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(260, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "🎨 Pilih Operasi Warna";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelColorInfo
            // 
            this.labelColorInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelColorInfo.ForeColor = System.Drawing.Color.LightGray;
            this.labelColorInfo.Location = new System.Drawing.Point(20, 50);
            this.labelColorInfo.Name = "labelColorInfo";
            this.labelColorInfo.Size = new System.Drawing.Size(260, 20);
            this.labelColorInfo.TabIndex = 1;
            this.labelColorInfo.Text = "Warna yang dipilih:";
            // 
            // labelRGBValue
            // 
            this.labelRGBValue.Font = new System.Drawing.Font("Consolas", 10F);
            this.labelRGBValue.ForeColor = System.Drawing.Color.White;
            this.labelRGBValue.Location = new System.Drawing.Point(100, 75);
            this.labelRGBValue.Name = "labelRGBValue";
            this.labelRGBValue.Size = new System.Drawing.Size(180, 70);
            this.labelRGBValue.TabIndex = 3;
            this.labelRGBValue.Text = "R: 255  G: 0  B: 0";
            this.labelRGBValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnColorSlicing
            // 
            this.btnColorSlicing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.btnColorSlicing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColorSlicing.FlatAppearance.BorderSize = 0;
            this.btnColorSlicing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorSlicing.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorSlicing.ForeColor = System.Drawing.Color.White;
            this.btnColorSlicing.Location = new System.Drawing.Point(20, 160);
            this.btnColorSlicing.Name = "btnColorSlicing";
            this.btnColorSlicing.Size = new System.Drawing.Size(260, 40);
            this.btnColorSlicing.TabIndex = 4;
            this.btnColorSlicing.Text = "🎯 Color Slicing";
            this.btnColorSlicing.UseVisualStyleBackColor = false;
            this.btnColorSlicing.Click += new System.EventHandler(this.btnColorSlicing_Click);
            // 
            // btnPseudoColor
            // 
            this.btnPseudoColor.BackColor = System.Drawing.Color.BlueViolet;
            this.btnPseudoColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPseudoColor.FlatAppearance.BorderSize = 0;
            this.btnPseudoColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPseudoColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPseudoColor.ForeColor = System.Drawing.Color.White;
            this.btnPseudoColor.Location = new System.Drawing.Point(20, 205);
            this.btnPseudoColor.Name = "btnPseudoColor";
            this.btnPseudoColor.Size = new System.Drawing.Size(260, 35);
            this.btnPseudoColor.TabIndex = 5;
            this.btnPseudoColor.Text = "🌈 Pewarnaan Semu";
            this.btnPseudoColor.UseVisualStyleBackColor = false;
            this.btnPseudoColor.Click += new System.EventHandler(this.btnPseudoColor_Click);
            // 
            // labelTolerance
            // 
            this.labelTolerance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTolerance.ForeColor = System.Drawing.Color.White;
            this.labelTolerance.Location = new System.Drawing.Point(20, 250);
            this.labelTolerance.Name = "labelTolerance";
            this.labelTolerance.Size = new System.Drawing.Size(80, 20);
            this.labelTolerance.TabIndex = 6;
            this.labelTolerance.Text = "Toleransi:";
            // 
            // trackBarTolerance
            // 
            this.trackBarTolerance.Location = new System.Drawing.Point(20, 270);
            this.trackBarTolerance.Maximum = 200;
            this.trackBarTolerance.Minimum = 1;
            this.trackBarTolerance.Name = "trackBarTolerance";
            this.trackBarTolerance.Size = new System.Drawing.Size(260, 45);
            this.trackBarTolerance.TabIndex = 8;
            this.trackBarTolerance.TickFrequency = 20;
            this.trackBarTolerance.Value = 50;
            this.trackBarTolerance.Scroll += new System.EventHandler(this.trackBarTolerance_Scroll);
            // 
            // labelToleranceValue
            // 
            this.labelToleranceValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelToleranceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.labelToleranceValue.Location = new System.Drawing.Point(230, 250);
            this.labelToleranceValue.Name = "labelToleranceValue";
            this.labelToleranceValue.Size = new System.Drawing.Size(50, 20);
            this.labelToleranceValue.TabIndex = 7;
            this.labelToleranceValue.Text = "50";
            this.labelToleranceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxGrayBackground
            // 
            this.checkBoxGrayBackground.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxGrayBackground.ForeColor = System.Drawing.Color.White;
            this.checkBoxGrayBackground.Location = new System.Drawing.Point(20, 315);
            this.checkBoxGrayBackground.Name = "checkBoxGrayBackground";
            this.checkBoxGrayBackground.Size = new System.Drawing.Size(220, 22);
            this.checkBoxGrayBackground.TabIndex = 11;
            this.checkBoxGrayBackground.Text = "Gunakan Background Grayscale";
            this.checkBoxGrayBackground.UseVisualStyleBackColor = true;
            this.checkBoxGrayBackground.Checked = false;
            this.checkBoxGrayBackground.CheckedChanged += new System.EventHandler(this.checkBoxGrayBackground_CheckedChanged);
            // 
            // trackBarPseudoPercent
            // 
            this.trackBarPseudoPercent.Location = new System.Drawing.Point(19, 334);
            this.trackBarPseudoPercent.Maximum = 100;
            this.trackBarPseudoPercent.Name = "trackBarPseudoPercent";
            this.trackBarPseudoPercent.Size = new System.Drawing.Size(200, 45);
            this.trackBarPseudoPercent.TabIndex = 9;
            this.trackBarPseudoPercent.TickFrequency = 5;
            this.trackBarPseudoPercent.Value = 50;
            this.trackBarPseudoPercent.Scroll += new System.EventHandler(this.trackBarPseudoPercent_Scroll);
            // 
            // labelPseudoPercentValue
            // 
            this.labelPseudoPercentValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPseudoPercentValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.labelPseudoPercentValue.Location = new System.Drawing.Point(225, 334);
            this.labelPseudoPercentValue.Name = "labelPseudoPercentValue";
            this.labelPseudoPercentValue.Size = new System.Drawing.Size(55, 20);
            this.labelPseudoPercentValue.TabIndex = 10;
            this.labelPseudoPercentValue.Text = "50%";
            this.labelPseudoPercentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(260, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "✕ Batal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.panelColorPreview);
            this.panelMain.Controls.Add(this.labelColorInfo);
            this.panelMain.Controls.Add(this.labelRGBValue);
            this.panelMain.Controls.Add(this.btnColorSlicing);
            this.panelMain.Controls.Add(this.btnPseudoColor);
            this.panelMain.Controls.Add(this.labelTolerance);
            this.panelMain.Controls.Add(this.trackBarTolerance);
            this.panelMain.Controls.Add(this.labelToleranceValue);
            this.panelMain.Controls.Add(this.checkBoxGrayBackground);
            this.panelMain.Controls.Add(this.trackBarPseudoPercent);
            this.panelMain.Controls.Add(this.labelPseudoPercentValue);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(300, 440);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kekuatan:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ColorSlicingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(300, 440);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorSlicingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pilih Operasi Warna";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPseudoPercent)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelColorInfo;
        private System.Windows.Forms.Panel panelColorPreview;
        private System.Windows.Forms.Label labelRGBValue;
        private System.Windows.Forms.Button btnColorSlicing;
        private System.Windows.Forms.Button btnPseudoColor;
        private System.Windows.Forms.Label labelTolerance;
        private System.Windows.Forms.TrackBar trackBarTolerance;
        private System.Windows.Forms.Label labelToleranceValue;
        private System.Windows.Forms.TrackBar trackBarPseudoPercent;
        private System.Windows.Forms.Label labelPseudoPercentValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxGrayBackground;
        private Label label1;
    }
}