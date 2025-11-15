using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    partial class Form1
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
            this.panelSidebarLeft = new System.Windows.Forms.Panel();
            this.panelHistogramContainer = new System.Windows.Forms.Panel();
            this.pictureBoxHistogramG = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramB = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramGray = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramR = new System.Windows.Forms.PictureBox();
            this.labelHistogram = new System.Windows.Forms.Label();
            this.btnBukaGambar = new System.Windows.Forms.Button();
            this.BtnSetColor = new System.Windows.Forms.Button();
            this.btnSaveToTxt = new System.Windows.Forms.Button();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.Aritmathic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelSidebarRight = new System.Windows.Forms.Panel();
            this.panelAritmatikContainer = new System.Windows.Forms.Panel();
            this.btnFlipVertical = new System.Windows.Forms.Button();
            this.btnFlipHorizontal = new System.Windows.Forms.Button();
            this.labelFlipTitle = new System.Windows.Forms.Label();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.numericUpDownTranslateY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTranslateX = new System.Windows.Forms.NumericUpDown();
            this.labelTranslateY = new System.Windows.Forms.Label();
            this.labelTranslateX = new System.Windows.Forms.Label();
            this.labelTranslateTitle = new System.Windows.Forms.Label();
            this.btnRotateCustom = new System.Windows.Forms.Button();
            this.numericUpDownDegree = new System.Windows.Forms.NumericUpDown();
            this.labelCustomRotate = new System.Windows.Forms.Label();
            this.btnRotate45 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.btnRotate180 = new System.Windows.Forms.Button();
            this.labelRotateTitle = new System.Windows.Forms.Label();
            this.labelAritmatikTitle = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnSubtractImage = new System.Windows.Forms.Button();
            this.btnMultiplyImage = new System.Windows.Forms.Button();
            this.btnDivideImage = new System.Windows.Forms.Button();
            this.labelZoomTitle = new System.Windows.Forms.Label();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.labelZoomValue = new System.Windows.Forms.Label();
            this.labelZoomMin = new System.Windows.Forms.Label();
            this.labelZoomMax = new System.Windows.Forms.Label();
            this.panelFilterContainer = new System.Windows.Forms.Panel();
            this.labelFilterTitle = new System.Windows.Forms.Label();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.pictureBoxRed = new System.Windows.Forms.PictureBox();
            this.labelRed = new System.Windows.Forms.Label();
            this.pictureBoxGreen = new System.Windows.Forms.PictureBox();
            this.labelGreen = new System.Windows.Forms.Label();
            this.pictureBoxBlue = new System.Windows.Forms.PictureBox();
            this.labelBlue = new System.Windows.Forms.Label();
            this.pictureBoxGray = new System.Windows.Forms.PictureBox();
            this.labelGray = new System.Windows.Forms.Label();
            this.pictureBoxNegative = new System.Windows.Forms.PictureBox();
            this.labelNegative = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.pictureBoxThreshold = new System.Windows.Forms.PictureBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.panelBrightnessContainer = new System.Windows.Forms.Panel();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.labelBrightnessValue = new System.Windows.Forms.Label();
            this.btnResetBrightness = new System.Windows.Forms.Button();
            this.panelSidebarLeft.SuspendLayout();
            this.panelHistogramContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramR)).BeginInit();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panelSidebarRight.SuspendLayout();
            this.panelAritmatikContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.panelFilterContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNegative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThreshold)).BeginInit();
            this.panelBrightnessContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebarLeft
            // 
            this.panelSidebarLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarLeft.Controls.Add(this.panelHistogramContainer);
            this.panelSidebarLeft.Controls.Add(this.btnBukaGambar);
            this.panelSidebarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebarLeft.Location = new System.Drawing.Point(0, 60);
            this.panelSidebarLeft.Name = "panelSidebarLeft";
            this.panelSidebarLeft.Size = new System.Drawing.Size(250, 701);
            this.panelSidebarLeft.TabIndex = 0;
            // 
            // panelHistogramContainer
            // 
            this.panelHistogramContainer.Controls.Add(this.pictureBoxHistogramG);
            this.panelHistogramContainer.Controls.Add(this.pictureBoxHistogramB);
            this.panelHistogramContainer.Controls.Add(this.pictureBoxHistogramGray);
            this.panelHistogramContainer.Controls.Add(this.pictureBoxHistogramR);
            this.panelHistogramContainer.Controls.Add(this.labelHistogram);
            this.panelHistogramContainer.Location = new System.Drawing.Point(0, 418);
            this.panelHistogramContainer.Name = "panelHistogramContainer";
            this.panelHistogramContainer.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.panelHistogramContainer.Size = new System.Drawing.Size(250, 271);
            this.panelHistogramContainer.TabIndex = 3;
            // 
            // pictureBoxHistogramG
            // 
            this.pictureBoxHistogramG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBoxHistogramG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHistogramG.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHistogramG.Location = new System.Drawing.Point(15, 210);
            this.pictureBoxHistogramG.Name = "pictureBoxHistogramG";
            this.pictureBoxHistogramG.Size = new System.Drawing.Size(220, 60);
            this.pictureBoxHistogramG.TabIndex = 14;
            this.pictureBoxHistogramG.TabStop = false;
            this.pictureBoxHistogramG.Visible = false;
            this.pictureBoxHistogramG.Click += new System.EventHandler(this.pictureBoxHistogramG_Click);
            // 
            // pictureBoxHistogramB
            // 
            this.pictureBoxHistogramB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBoxHistogramB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHistogramB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHistogramB.Location = new System.Drawing.Point(15, 150);
            this.pictureBoxHistogramB.Name = "pictureBoxHistogramB";
            this.pictureBoxHistogramB.Size = new System.Drawing.Size(220, 60);
            this.pictureBoxHistogramB.TabIndex = 15;
            this.pictureBoxHistogramB.TabStop = false;
            this.pictureBoxHistogramB.Visible = false;
            this.pictureBoxHistogramB.Click += new System.EventHandler(this.pictureBoxHistogramB_Click);
            // 
            // pictureBoxHistogramGray
            // 
            this.pictureBoxHistogramGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBoxHistogramGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHistogramGray.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHistogramGray.Location = new System.Drawing.Point(15, 90);
            this.pictureBoxHistogramGray.Name = "pictureBoxHistogramGray";
            this.pictureBoxHistogramGray.Size = new System.Drawing.Size(220, 60);
            this.pictureBoxHistogramGray.TabIndex = 16;
            this.pictureBoxHistogramGray.TabStop = false;
            this.pictureBoxHistogramGray.Visible = false;
            this.pictureBoxHistogramGray.Click += new System.EventHandler(this.pictureBoxHistogramGray_Click);
            // 
            // pictureBoxHistogramR
            // 
            this.pictureBoxHistogramR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBoxHistogramR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHistogramR.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHistogramR.Location = new System.Drawing.Point(15, 30);
            this.pictureBoxHistogramR.Name = "pictureBoxHistogramR";
            this.pictureBoxHistogramR.Size = new System.Drawing.Size(220, 60);
            this.pictureBoxHistogramR.TabIndex = 13;
            this.pictureBoxHistogramR.TabStop = false;
            this.pictureBoxHistogramR.Visible = false;
            this.pictureBoxHistogramR.Click += new System.EventHandler(this.pictureBoxHistogramR_Click);
            // 
            // labelHistogram
            // 
            this.labelHistogram.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHistogram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelHistogram.ForeColor = System.Drawing.Color.White;
            this.labelHistogram.Location = new System.Drawing.Point(15, 5);
            this.labelHistogram.Name = "labelHistogram";
            this.labelHistogram.Size = new System.Drawing.Size(220, 25);
            this.labelHistogram.TabIndex = 12;
            this.labelHistogram.Text = "Histogram";
            this.labelHistogram.Visible = false;
            this.labelHistogram.Click += new System.EventHandler(this.labelHistogram_Click);
            // 
            // btnBukaGambar
            // 
            this.btnBukaGambar.BackColor = System.Drawing.Color.BlueViolet;
            this.btnBukaGambar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBukaGambar.FlatAppearance.BorderSize = 0;
            this.btnBukaGambar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBukaGambar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBukaGambar.ForeColor = System.Drawing.Color.White;
            this.btnBukaGambar.Location = new System.Drawing.Point(15, 21);
            this.btnBukaGambar.Name = "btnBukaGambar";
            this.btnBukaGambar.Size = new System.Drawing.Size(220, 45);
            this.btnBukaGambar.TabIndex = 0;
            this.btnBukaGambar.Text = "📂 Buka Gambar";
            this.btnBukaGambar.UseVisualStyleBackColor = false;
            this.btnBukaGambar.Click += new System.EventHandler(this.btnBukaGambar_Click);
            this.btnBukaGambar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnBukaGambar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BtnSetColor
            // 
            this.BtnSetColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnSetColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetColor.FlatAppearance.BorderSize = 0;
            this.BtnSetColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnSetColor.ForeColor = System.Drawing.Color.White;
            this.BtnSetColor.Location = new System.Drawing.Point(200, 10);
            this.BtnSetColor.Name = "BtnSetColor";
            this.BtnSetColor.Size = new System.Drawing.Size(69, 40);
            this.BtnSetColor.TabIndex = 3;
            this.BtnSetColor.Text = "🎨 Filter";
            this.BtnSetColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSetColor.UseVisualStyleBackColor = false;
            this.BtnSetColor.Click += new System.EventHandler(this.BtnFilter_Click);
            this.BtnSetColor.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BtnSetColor.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSaveToTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveToTxt.FlatAppearance.BorderSize = 0;
            this.btnSaveToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToTxt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSaveToTxt.ForeColor = System.Drawing.Color.White;
            this.btnSaveToTxt.Location = new System.Drawing.Point(1131, 14);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(125, 30);
            this.btnSaveToTxt.TabIndex = 2;
            this.btnSaveToTxt.Text = "💾 Simpan ke .Txt";
            this.btnSaveToTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToTxt.UseVisualStyleBackColor = false;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveToTxt_Click);
            this.btnSaveToTxt.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSaveToTxt.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelToolbar.Controls.Add(this.btnReset);
            this.panelToolbar.Controls.Add(this.Aritmathic);
            this.panelToolbar.Controls.Add(this.btnSave);
            this.panelToolbar.Controls.Add(this.btnSaveToTxt);
            this.panelToolbar.Controls.Add(this.BtnSetColor);
            this.panelToolbar.Controls.Add(this.btnEdit);
            this.panelToolbar.Controls.Add(this.btnHome);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1284, 60);
            this.panelToolbar.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1060, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(54, 40);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Aritmathic
            // 
            this.Aritmathic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Aritmathic.FlatAppearance.BorderSize = 0;
            this.Aritmathic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aritmathic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aritmathic.ForeColor = System.Drawing.Color.White;
            this.Aritmathic.Location = new System.Drawing.Point(275, 10);
            this.Aritmathic.Name = "Aritmathic";
            this.Aritmathic.Size = new System.Drawing.Size(80, 40);
            this.Aritmathic.TabIndex = 4;
            this.Aritmathic.Text = "Artimatika";
            this.Aritmathic.UseVisualStyleBackColor = false;
            this.Aritmathic.Click += new System.EventHandler(this.BtnAritmathic_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(131, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(75, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(15, 10);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(54, 40);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(250, 60);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Padding = new System.Windows.Forms.Padding(15, 10, 15, 20);
            this.pictureBoxMain.Size = new System.Drawing.Size(785, 701);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            // 
            // panelSidebarRight
            // 
            this.panelSidebarRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarRight.Controls.Add(this.panelFilterContainer);
            this.panelSidebarRight.Controls.Add(this.panelAritmatikContainer);
            this.panelSidebarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebarRight.Location = new System.Drawing.Point(1035, 60);
            this.panelSidebarRight.Name = "panelSidebarRight";
            this.panelSidebarRight.Padding = new System.Windows.Forms.Padding(5);
            this.panelSidebarRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelSidebarRight.Size = new System.Drawing.Size(249, 701);
            this.panelSidebarRight.TabIndex = 2;
            this.panelSidebarRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebarRight_Paint);
            // 
            // panelAritmatikContainer
            // 
            this.panelAritmatikContainer.AutoScroll = true;
            this.panelAritmatikContainer.Controls.Add(this.btnFlipVertical);
            this.panelAritmatikContainer.Controls.Add(this.btnFlipHorizontal);
            this.panelAritmatikContainer.Controls.Add(this.labelFlipTitle);
            this.panelAritmatikContainer.Controls.Add(this.btnTranslate);
            this.panelAritmatikContainer.Controls.Add(this.numericUpDownTranslateY);
            this.panelAritmatikContainer.Controls.Add(this.numericUpDownTranslateX);
            this.panelAritmatikContainer.Controls.Add(this.labelTranslateY);
            this.panelAritmatikContainer.Controls.Add(this.labelTranslateX);
            this.panelAritmatikContainer.Controls.Add(this.labelTranslateTitle);
            this.panelAritmatikContainer.Controls.Add(this.btnRotateCustom);
            this.panelAritmatikContainer.Controls.Add(this.numericUpDownDegree);
            this.panelAritmatikContainer.Controls.Add(this.labelCustomRotate);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate45);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate90);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate180);
            this.panelAritmatikContainer.Controls.Add(this.labelRotateTitle);
            this.panelAritmatikContainer.Controls.Add(this.labelAritmatikTitle);
            this.panelAritmatikContainer.Controls.Add(this.btnAddImage);
            this.panelAritmatikContainer.Controls.Add(this.btnSubtractImage);
            this.panelAritmatikContainer.Controls.Add(this.btnMultiplyImage);
            this.panelAritmatikContainer.Controls.Add(this.btnDivideImage);
            this.panelAritmatikContainer.Controls.Add(this.labelZoomTitle);
            this.panelAritmatikContainer.Controls.Add(this.trackBarZoom);
            this.panelAritmatikContainer.Controls.Add(this.labelZoomValue);
            this.panelAritmatikContainer.Controls.Add(this.labelZoomMin);
            this.panelAritmatikContainer.Controls.Add(this.labelZoomMax);
            this.panelAritmatikContainer.Location = new System.Drawing.Point(5, 5);
            this.panelAritmatikContainer.Name = "panelAritmatikContainer";
            this.panelAritmatikContainer.Size = new System.Drawing.Size(244, 696);
            this.panelAritmatikContainer.TabIndex = 1;
            this.panelAritmatikContainer.Visible = false;
            this.panelAritmatikContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAritmatikContainer_Paint);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.btnFlipVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlipVertical.ForeColor = System.Drawing.Color.White;
            this.btnFlipVertical.Location = new System.Drawing.Point(114, 664);
            this.btnFlipVertical.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(90, 35);
            this.btnFlipVertical.TabIndex = 15;
            this.btnFlipVertical.Text = "🔄 Vertikal";
            this.btnFlipVertical.UseVisualStyleBackColor = false;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click);
            // 
            // btnFlipHorizontal
            // 
            this.btnFlipHorizontal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.btnFlipHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlipHorizontal.ForeColor = System.Drawing.Color.White;
            this.btnFlipHorizontal.Location = new System.Drawing.Point(24, 664);
            this.btnFlipHorizontal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.btnFlipHorizontal.Name = "btnFlipHorizontal";
            this.btnFlipHorizontal.Size = new System.Drawing.Size(84, 35);
            this.btnFlipHorizontal.TabIndex = 14;
            this.btnFlipHorizontal.Text = "🔄 Horizontal";
            this.btnFlipHorizontal.UseVisualStyleBackColor = false;
            this.btnFlipHorizontal.Click += new System.EventHandler(this.btnFlipHorizontal_Click);
            // 
            // labelFlipTitle
            // 
            this.labelFlipTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFlipTitle.ForeColor = System.Drawing.Color.White;
            this.labelFlipTitle.Location = new System.Drawing.Point(24, 638);
            this.labelFlipTitle.Name = "labelFlipTitle";
            this.labelFlipTitle.Size = new System.Drawing.Size(180, 20);
            this.labelFlipTitle.TabIndex = 13;
            this.labelFlipTitle.Text = "Flip Gambar";
            this.labelFlipTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelFlipTitle.Click += new System.EventHandler(this.labelFlipTitle_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslate.ForeColor = System.Drawing.Color.White;
            this.btnTranslate.Location = new System.Drawing.Point(24, 597);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(180, 35);
            this.btnTranslate.TabIndex = 13;
            this.btnTranslate.Text = "📍 Translasi";
            this.btnTranslate.UseVisualStyleBackColor = false;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // numericUpDownTranslateY
            // 
            this.numericUpDownTranslateY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numericUpDownTranslateY.ForeColor = System.Drawing.Color.White;
            this.numericUpDownTranslateY.Location = new System.Drawing.Point(114, 571);
            this.numericUpDownTranslateY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTranslateY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownTranslateY.Name = "numericUpDownTranslateY";
            this.numericUpDownTranslateY.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownTranslateY.TabIndex = 12;
            this.numericUpDownTranslateY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTranslateY.ValueChanged += new System.EventHandler(this.numericUpDownTranslateY_ValueChanged);
            // 
            // numericUpDownTranslateX
            // 
            this.numericUpDownTranslateX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numericUpDownTranslateX.ForeColor = System.Drawing.Color.White;
            this.numericUpDownTranslateX.Location = new System.Drawing.Point(24, 571);
            this.numericUpDownTranslateX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTranslateX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownTranslateX.Name = "numericUpDownTranslateX";
            this.numericUpDownTranslateX.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownTranslateX.TabIndex = 11;
            this.numericUpDownTranslateX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTranslateX.ValueChanged += new System.EventHandler(this.numericUpDownTranslateX_ValueChanged);
            // 
            // labelTranslateY
            // 
            this.labelTranslateY.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelTranslateY.ForeColor = System.Drawing.Color.White;
            this.labelTranslateY.Location = new System.Drawing.Point(114, 551);
            this.labelTranslateY.Name = "labelTranslateY";
            this.labelTranslateY.Size = new System.Drawing.Size(90, 17);
            this.labelTranslateY.TabIndex = 10;
            this.labelTranslateY.Text = "Y Offset";
            this.labelTranslateY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTranslateY.Click += new System.EventHandler(this.labelTranslateY_Click);
            // 
            // labelTranslateX
            // 
            this.labelTranslateX.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelTranslateX.ForeColor = System.Drawing.Color.White;
            this.labelTranslateX.Location = new System.Drawing.Point(24, 551);
            this.labelTranslateX.Name = "labelTranslateX";
            this.labelTranslateX.Size = new System.Drawing.Size(90, 17);
            this.labelTranslateX.TabIndex = 9;
            this.labelTranslateX.Text = "X Offset";
            this.labelTranslateX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTranslateX.Click += new System.EventHandler(this.labelTranslateX_Click);
            // 
            // labelTranslateTitle
            // 
            this.labelTranslateTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTranslateTitle.ForeColor = System.Drawing.Color.White;
            this.labelTranslateTitle.Location = new System.Drawing.Point(24, 526);
            this.labelTranslateTitle.Name = "labelTranslateTitle";
            this.labelTranslateTitle.Size = new System.Drawing.Size(180, 20);
            this.labelTranslateTitle.TabIndex = 8;
            this.labelTranslateTitle.Text = "Translasi / Pergeseran";
            this.labelTranslateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTranslateTitle.Click += new System.EventHandler(this.labelTranslateTitle_Click);
            // 
            // btnRotateCustom
            // 
            this.btnRotateCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.btnRotateCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotateCustom.ForeColor = System.Drawing.Color.White;
            this.btnRotateCustom.Location = new System.Drawing.Point(24, 487);
            this.btnRotateCustom.Name = "btnRotateCustom";
            this.btnRotateCustom.Size = new System.Drawing.Size(180, 35);
            this.btnRotateCustom.TabIndex = 7;
            this.btnRotateCustom.Text = "🔄 Rotate Custom";
            this.btnRotateCustom.UseVisualStyleBackColor = false;
            this.btnRotateCustom.Click += new System.EventHandler(this.btnRotateCustom_Click);
            // 
            // numericUpDownDegree
            // 
            this.numericUpDownDegree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numericUpDownDegree.ForeColor = System.Drawing.Color.White;
            this.numericUpDownDegree.Location = new System.Drawing.Point(27, 461);
            this.numericUpDownDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownDegree.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownDegree.Name = "numericUpDownDegree";
            this.numericUpDownDegree.Size = new System.Drawing.Size(180, 20);
            this.numericUpDownDegree.TabIndex = 6;
            this.numericUpDownDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDegree.ValueChanged += new System.EventHandler(this.numericUpDownDegree_ValueChanged);
            // 
            // labelCustomRotate
            // 
            this.labelCustomRotate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCustomRotate.ForeColor = System.Drawing.Color.White;
            this.labelCustomRotate.Location = new System.Drawing.Point(24, 444);
            this.labelCustomRotate.Name = "labelCustomRotate";
            this.labelCustomRotate.Size = new System.Drawing.Size(180, 20);
            this.labelCustomRotate.TabIndex = 5;
            this.labelCustomRotate.Text = "Custom Rotation";
            this.labelCustomRotate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelCustomRotate.Click += new System.EventHandler(this.labelCustomRotate_Click);
            // 
            // btnRotate45
            // 
            this.btnRotate45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnRotate45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate45.ForeColor = System.Drawing.Color.White;
            this.btnRotate45.Location = new System.Drawing.Point(24, 304);
            this.btnRotate45.Name = "btnRotate45";
            this.btnRotate45.Size = new System.Drawing.Size(180, 35);
            this.btnRotate45.TabIndex = 2;
            this.btnRotate45.Text = "Rotate 45°";
            this.btnRotate45.UseVisualStyleBackColor = false;
            this.btnRotate45.Click += new System.EventHandler(this.btnRotate45_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnRotate90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate90.ForeColor = System.Drawing.Color.White;
            this.btnRotate90.Location = new System.Drawing.Point(24, 349);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(180, 35);
            this.btnRotate90.TabIndex = 3;
            this.btnRotate90.Text = "Rotate 90°";
            this.btnRotate90.UseVisualStyleBackColor = false;
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // btnRotate180
            // 
            this.btnRotate180.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnRotate180.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate180.ForeColor = System.Drawing.Color.White;
            this.btnRotate180.Location = new System.Drawing.Point(24, 394);
            this.btnRotate180.Name = "btnRotate180";
            this.btnRotate180.Size = new System.Drawing.Size(180, 35);
            this.btnRotate180.TabIndex = 4;
            this.btnRotate180.Text = "Rotate 180°";
            this.btnRotate180.UseVisualStyleBackColor = false;
            this.btnRotate180.Click += new System.EventHandler(this.btnRotate180_Click);
            // 
            // labelRotateTitle
            // 
            this.labelRotateTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRotateTitle.ForeColor = System.Drawing.Color.White;
            this.labelRotateTitle.Location = new System.Drawing.Point(24, 281);
            this.labelRotateTitle.Name = "labelRotateTitle";
            this.labelRotateTitle.Size = new System.Drawing.Size(180, 20);
            this.labelRotateTitle.TabIndex = 1;
            this.labelRotateTitle.Text = "Rotate Image";
            this.labelRotateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelAritmatikTitle
            // 
            this.labelAritmatikTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelAritmatikTitle.ForeColor = System.Drawing.Color.White;
            this.labelAritmatikTitle.Location = new System.Drawing.Point(24, 12);
            this.labelAritmatikTitle.Name = "labelAritmatikTitle";
            this.labelAritmatikTitle.Size = new System.Drawing.Size(180, 25);
            this.labelAritmatikTitle.TabIndex = 0;
            this.labelAritmatikTitle.Text = "Aritmatika";
            this.labelAritmatikTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelAritmatikTitle.Click += new System.EventHandler(this.labelAritmatikTitle_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(24, 52);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(180, 40);
            this.btnAddImage.TabIndex = 0;
            this.btnAddImage.Text = "Tambah Citra";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnSubtractImage
            // 
            this.btnSubtractImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnSubtractImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubtractImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubtractImage.ForeColor = System.Drawing.Color.White;
            this.btnSubtractImage.Location = new System.Drawing.Point(24, 109);
            this.btnSubtractImage.Name = "btnSubtractImage";
            this.btnSubtractImage.Size = new System.Drawing.Size(180, 40);
            this.btnSubtractImage.TabIndex = 1;
            this.btnSubtractImage.Text = "Kurangi Citra";
            this.btnSubtractImage.UseVisualStyleBackColor = false;
            this.btnSubtractImage.Click += new System.EventHandler(this.btnSubtractImage_Click);
            // 
            // btnMultiplyImage
            // 
            this.btnMultiplyImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnMultiplyImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiplyImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMultiplyImage.ForeColor = System.Drawing.Color.White;
            this.btnMultiplyImage.Location = new System.Drawing.Point(24, 166);
            this.btnMultiplyImage.Name = "btnMultiplyImage";
            this.btnMultiplyImage.Size = new System.Drawing.Size(180, 40);
            this.btnMultiplyImage.TabIndex = 2;
            this.btnMultiplyImage.Text = "Kalikan Citra";
            this.btnMultiplyImage.UseVisualStyleBackColor = false;
            this.btnMultiplyImage.Click += new System.EventHandler(this.btnMultiplyImage_Click);
            // 
            // btnDivideImage
            // 
            this.btnDivideImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnDivideImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivideImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDivideImage.ForeColor = System.Drawing.Color.White;
            this.btnDivideImage.Location = new System.Drawing.Point(24, 223);
            this.btnDivideImage.Name = "btnDivideImage";
            this.btnDivideImage.Size = new System.Drawing.Size(180, 40);
            this.btnDivideImage.TabIndex = 3;
            this.btnDivideImage.Text = "Bagi Citra";
            this.btnDivideImage.UseVisualStyleBackColor = false;
            this.btnDivideImage.Click += new System.EventHandler(this.btnDivideImage_Click);
            // 
            // labelZoomTitle
            // 
            this.labelZoomTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelZoomTitle.ForeColor = System.Drawing.Color.White;
            this.labelZoomTitle.Location = new System.Drawing.Point(24, 708);
            this.labelZoomTitle.Name = "labelZoomTitle";
            this.labelZoomTitle.Size = new System.Drawing.Size(180, 20);
            this.labelZoomTitle.TabIndex = 19;
            this.labelZoomTitle.Text = "Zoom Gambar";
            this.labelZoomTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelZoomTitle.Click += new System.EventHandler(this.labelZoomTitle_Click);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Location = new System.Drawing.Point(24, 725);
            this.trackBarZoom.Maximum = 200;
            this.trackBarZoom.Minimum = 10;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(180, 45);
            this.trackBarZoom.TabIndex = 20;
            this.trackBarZoom.TickFrequency = 10;
            this.trackBarZoom.Value = 100;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // labelZoomValue
            // 
            this.labelZoomValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelZoomValue.ForeColor = System.Drawing.Color.LightGray;
            this.labelZoomValue.Location = new System.Drawing.Point(138, 708);
            this.labelZoomValue.Name = "labelZoomValue";
            this.labelZoomValue.Size = new System.Drawing.Size(66, 20);
            this.labelZoomValue.TabIndex = 21;
            this.labelZoomValue.Text = "100%";
            this.labelZoomValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelZoomValue.Click += new System.EventHandler(this.labelZoomValue_Click);
            // 
            // labelZoomMin
            // 
            this.labelZoomMin.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelZoomMin.ForeColor = System.Drawing.Color.LightGray;
            this.labelZoomMin.Location = new System.Drawing.Point(24, 769);
            this.labelZoomMin.Name = "labelZoomMin";
            this.labelZoomMin.Size = new System.Drawing.Size(40, 20);
            this.labelZoomMin.TabIndex = 22;
            this.labelZoomMin.Text = "10%";
            this.labelZoomMin.Click += new System.EventHandler(this.labelZoomMin_Click);
            // 
            // labelZoomMax
            // 
            this.labelZoomMax.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelZoomMax.ForeColor = System.Drawing.Color.LightGray;
            this.labelZoomMax.Location = new System.Drawing.Point(164, 769);
            this.labelZoomMax.Name = "labelZoomMax";
            this.labelZoomMax.Size = new System.Drawing.Size(40, 20);
            this.labelZoomMax.TabIndex = 23;
            this.labelZoomMax.Text = "200%";
            this.labelZoomMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelZoomMax.Click += new System.EventHandler(this.labelZoomMax_Click);
            // 
            // panelFilterContainer
            // 
            this.panelFilterContainer.Controls.Add(this.labelFilterTitle);
            this.panelFilterContainer.Controls.Add(this.pictureBoxOriginal);
            this.panelFilterContainer.Controls.Add(this.labelOriginal);
            this.panelFilterContainer.Controls.Add(this.pictureBoxRed);
            this.panelFilterContainer.Controls.Add(this.labelRed);
            this.panelFilterContainer.Controls.Add(this.pictureBoxGreen);
            this.panelFilterContainer.Controls.Add(this.labelGreen);
            this.panelFilterContainer.Controls.Add(this.pictureBoxBlue);
            this.panelFilterContainer.Controls.Add(this.labelBlue);
            this.panelFilterContainer.Controls.Add(this.pictureBoxGray);
            this.panelFilterContainer.Controls.Add(this.labelGray);
            this.panelFilterContainer.Controls.Add(this.pictureBoxNegative);
            this.panelFilterContainer.Controls.Add(this.labelNegative);
            this.panelFilterContainer.Controls.Add(this.btnApplyFilter);
            this.panelFilterContainer.Controls.Add(this.pictureBoxThreshold);
            this.panelFilterContainer.Controls.Add(this.labelThreshold);
            this.panelFilterContainer.Controls.Add(this.panelBrightnessContainer);
            this.panelFilterContainer.Location = new System.Drawing.Point(5, 5);
            this.panelFilterContainer.Name = "panelFilterContainer";
            this.panelFilterContainer.Size = new System.Drawing.Size(244, 690);
            this.panelFilterContainer.TabIndex = 0;
            this.panelFilterContainer.Visible = false;
            // 
            // labelFilterTitle
            // 
            this.labelFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFilterTitle.ForeColor = System.Drawing.Color.White;
            this.labelFilterTitle.Location = new System.Drawing.Point(32, 16);
            this.labelFilterTitle.Name = "labelFilterTitle";
            this.labelFilterTitle.Size = new System.Drawing.Size(180, 25);
            this.labelFilterTitle.TabIndex = 0;
            this.labelFilterTitle.Text = "Filter Preview";
            this.labelFilterTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(47, 69);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.Click += new System.EventHandler(this.pictureBoxOriginal_Click);
            // 
            // labelOriginal
            // 
            this.labelOriginal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelOriginal.ForeColor = System.Drawing.Color.White;
            this.labelOriginal.Location = new System.Drawing.Point(47, 129);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(60, 20);
            this.labelOriginal.TabIndex = 2;
            this.labelOriginal.Text = "Original";
            this.labelOriginal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxRed
            // 
            this.pictureBoxRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRed.Location = new System.Drawing.Point(133, 69);
            this.pictureBoxRed.Name = "pictureBoxRed";
            this.pictureBoxRed.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRed.TabIndex = 3;
            this.pictureBoxRed.TabStop = false;
            this.pictureBoxRed.Click += new System.EventHandler(this.pictureBoxRed_Click);
            // 
            // labelRed
            // 
            this.labelRed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelRed.ForeColor = System.Drawing.Color.White;
            this.labelRed.Location = new System.Drawing.Point(133, 129);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(60, 20);
            this.labelRed.TabIndex = 4;
            this.labelRed.Text = "Red";
            this.labelRed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxGreen
            // 
            this.pictureBoxGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGreen.Location = new System.Drawing.Point(47, 159);
            this.pictureBoxGreen.Name = "pictureBoxGreen";
            this.pictureBoxGreen.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGreen.TabIndex = 5;
            this.pictureBoxGreen.TabStop = false;
            this.pictureBoxGreen.Click += new System.EventHandler(this.pictureBoxGreen_Click);
            // 
            // labelGreen
            // 
            this.labelGreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelGreen.ForeColor = System.Drawing.Color.White;
            this.labelGreen.Location = new System.Drawing.Point(47, 222);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(60, 20);
            this.labelGreen.TabIndex = 6;
            this.labelGreen.Text = "Green";
            this.labelGreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxBlue
            // 
            this.pictureBoxBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlue.Location = new System.Drawing.Point(133, 159);
            this.pictureBoxBlue.Name = "pictureBoxBlue";
            this.pictureBoxBlue.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBlue.TabIndex = 7;
            this.pictureBoxBlue.TabStop = false;
            this.pictureBoxBlue.Click += new System.EventHandler(this.pictureBoxBlue_Click);
            // 
            // labelBlue
            // 
            this.labelBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBlue.ForeColor = System.Drawing.Color.White;
            this.labelBlue.Location = new System.Drawing.Point(133, 222);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(60, 20);
            this.labelBlue.TabIndex = 8;
            this.labelBlue.Text = "Blue";
            this.labelBlue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGray.Location = new System.Drawing.Point(47, 245);
            this.pictureBoxGray.Name = "pictureBoxGray";
            this.pictureBoxGray.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGray.TabIndex = 9;
            this.pictureBoxGray.TabStop = false;
            this.pictureBoxGray.Click += new System.EventHandler(this.pictureBoxGray_Click);
            // 
            // labelGray
            // 
            this.labelGray.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelGray.ForeColor = System.Drawing.Color.White;
            this.labelGray.Location = new System.Drawing.Point(46, 308);
            this.labelGray.Name = "labelGray";
            this.labelGray.Size = new System.Drawing.Size(60, 20);
            this.labelGray.TabIndex = 10;
            this.labelGray.Text = "Grayscale";
            this.labelGray.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxNegative
            // 
            this.pictureBoxNegative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNegative.Location = new System.Drawing.Point(47, 331);
            this.pictureBoxNegative.Name = "pictureBoxNegative";
            this.pictureBoxNegative.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxNegative.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNegative.TabIndex = 11;
            this.pictureBoxNegative.TabStop = false;
            this.pictureBoxNegative.Click += new System.EventHandler(this.pictureBoxNegative_Click);
            // 
            // labelNegative
            // 
            this.labelNegative.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelNegative.ForeColor = System.Drawing.Color.White;
            this.labelNegative.Location = new System.Drawing.Point(47, 394);
            this.labelNegative.Name = "labelNegative";
            this.labelNegative.Size = new System.Drawing.Size(60, 20);
            this.labelNegative.TabIndex = 20;
            this.labelNegative.Text = "Negative";
            this.labelNegative.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(36, 642);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(180, 35);
            this.btnApplyFilter.TabIndex = 11;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // pictureBoxThreshold
            // 
            this.pictureBoxThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxThreshold.Location = new System.Drawing.Point(133, 245);
            this.pictureBoxThreshold.Name = "pictureBoxThreshold";
            this.pictureBoxThreshold.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxThreshold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThreshold.TabIndex = 17;
            this.pictureBoxThreshold.TabStop = false;
            this.pictureBoxThreshold.Click += new System.EventHandler(this.pictureBoxThreshold_Click);
            // 
            // labelThreshold
            // 
            this.labelThreshold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelThreshold.ForeColor = System.Drawing.Color.White;
            this.labelThreshold.Location = new System.Drawing.Point(133, 308);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(60, 20);
            this.labelThreshold.TabIndex = 18;
            this.labelThreshold.Text = "Threshold";
            this.labelThreshold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelBrightnessContainer
            // 
            this.panelBrightnessContainer.Controls.Add(this.labelBrightness);
            this.panelBrightnessContainer.Controls.Add(this.trackBarBrightness);
            this.panelBrightnessContainer.Controls.Add(this.labelBrightnessValue);
            this.panelBrightnessContainer.Controls.Add(this.btnResetBrightness);
            this.panelBrightnessContainer.Location = new System.Drawing.Point(12, 423);
            this.panelBrightnessContainer.Name = "panelBrightnessContainer";
            this.panelBrightnessContainer.Size = new System.Drawing.Size(220, 120);
            this.panelBrightnessContainer.TabIndex = 0;
            this.panelBrightnessContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBrightnessContainer_Paint);
            // 
            // labelBrightness
            // 
            this.labelBrightness.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelBrightness.ForeColor = System.Drawing.Color.White;
            this.labelBrightness.Location = new System.Drawing.Point(5, 5);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(100, 20);
            this.labelBrightness.TabIndex = 0;
            this.labelBrightness.Text = "Brightness";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(5, 30);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = -100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(210, 45);
            this.trackBarBrightness.TabIndex = 1;
            this.trackBarBrightness.TickFrequency = 10;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // labelBrightnessValue
            // 
            this.labelBrightnessValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelBrightnessValue.ForeColor = System.Drawing.Color.LightGray;
            this.labelBrightnessValue.Location = new System.Drawing.Point(165, 7);
            this.labelBrightnessValue.Name = "labelBrightnessValue";
            this.labelBrightnessValue.Size = new System.Drawing.Size(50, 20);
            this.labelBrightnessValue.TabIndex = 2;
            this.labelBrightnessValue.Text = "0";
            this.labelBrightnessValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnResetBrightness
            // 
            this.btnResetBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnResetBrightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetBrightness.ForeColor = System.Drawing.Color.White;
            this.btnResetBrightness.Location = new System.Drawing.Point(5, 75);
            this.btnResetBrightness.Name = "btnResetBrightness";
            this.btnResetBrightness.Size = new System.Drawing.Size(210, 30);
            this.btnResetBrightness.TabIndex = 3;
            this.btnResetBrightness.Text = "Reset";
            this.btnResetBrightness.UseVisualStyleBackColor = false;
            this.btnResetBrightness.Click += new System.EventHandler(this.btnResetBrightness_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.panelSidebarRight);
            this.Controls.Add(this.panelSidebarLeft);
            this.Controls.Add(this.panelToolbar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengolahan Citra Digital - Mikro Photoshop";
            this.panelSidebarLeft.ResumeLayout(false);
            this.panelHistogramContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramR)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panelSidebarRight.ResumeLayout(false);
            this.panelAritmatikContainer.ResumeLayout(false);
            this.panelAritmatikContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.panelFilterContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNegative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThreshold)).EndInit();
            this.panelBrightnessContainer.ResumeLayout(false);
            this.panelBrightnessContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebarLeft;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btnBukaGambar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSaveToTxt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelSidebarRight;
        private System.Windows.Forms.Button BtnSetColor;
        private System.Windows.Forms.Label labelFilterTitle;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.PictureBox pictureBoxRed;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.PictureBox pictureBoxGreen;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.PictureBox pictureBoxBlue;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.PictureBox pictureBoxGray;
        private System.Windows.Forms.Label labelGray;
        private System.Windows.Forms.PictureBox pictureBoxNegative;
        private System.Windows.Forms.Label labelNegative;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.PictureBox pictureBoxThreshold;
        private System.Windows.Forms.Label labelThreshold;

        // Histogram controls
        private System.Windows.Forms.PictureBox pictureBoxHistogramR;
        private System.Windows.Forms.PictureBox pictureBoxHistogramG;
        private System.Windows.Forms.PictureBox pictureBoxHistogramB;
        private System.Windows.Forms.PictureBox pictureBoxHistogramGray;
        private System.Windows.Forms.Label labelHistogram;
        private System.Windows.Forms.Panel panelHistogramContainer;

        // Brightness controls
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Label labelBrightnessValue;
        private System.Windows.Forms.Button btnResetBrightness;
        private System.Windows.Forms.Panel panelBrightnessContainer;
        
        // Arithmetic controls
        private System.Windows.Forms.Button Aritmathic;
        private System.Windows.Forms.Panel panelAritmatikContainer;
        private System.Windows.Forms.Label labelAritmatikTitle;
        private System.Windows.Forms.Label labelRotateTitle;
        private System.Windows.Forms.Button btnRotate45;
        private System.Windows.Forms.Button btnRotate90;
        private System.Windows.Forms.Button btnRotate180;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnSubtractImage;
        private System.Windows.Forms.Button btnMultiplyImage;
        private System.Windows.Forms.Button btnDivideImage;
        private System.Windows.Forms.Label labelCustomRotate;
        private System.Windows.Forms.NumericUpDown numericUpDownDegree;
        private System.Windows.Forms.Button btnRotateCustom;
        
        // Translation controls
        private System.Windows.Forms.Label labelTranslateTitle;
        private System.Windows.Forms.Label labelTranslateX;
        private System.Windows.Forms.Label labelTranslateY;
        private System.Windows.Forms.NumericUpDown numericUpDownTranslateX;
        private System.Windows.Forms.NumericUpDown numericUpDownTranslateY;
        private System.Windows.Forms.Button btnTranslate;
        
        // Flip controls
        private System.Windows.Forms.Label labelFlipTitle;
        private System.Windows.Forms.Button btnFlipHorizontal;
        private System.Windows.Forms.Button btnFlipVertical;
        
        private System.Windows.Forms.Panel panelFilterContainer;
        private System.Windows.Forms.Label labelZoomTitle;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label labelZoomValue;
        private System.Windows.Forms.Label labelZoomMin;
        private System.Windows.Forms.Label labelZoomMax;
        private Button btnReset;
    }
}