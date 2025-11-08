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
            this.Aritmathic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelSidebarRight = new System.Windows.Forms.Panel();
            this.panelAritmatikContainer = new System.Windows.Forms.Panel();
            this.labelAritmatikTitle = new System.Windows.Forms.Label();
            this.btnRotate45 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.btnRotate180 = new System.Windows.Forms.Button();
            this.labelRotateTitle = new System.Windows.Forms.Label();
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
            // 
            // panelSidebarRight
            // 
            this.panelSidebarRight.AutoScroll = true;
            this.panelSidebarRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarRight.Controls.Add(this.panelAritmatikContainer);
            this.panelSidebarRight.Controls.Add(this.panelFilterContainer);
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
            this.panelAritmatikContainer.Controls.Add(this.labelAritmatikTitle);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate45);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate90);
            this.panelAritmatikContainer.Controls.Add(this.btnRotate180);
            this.panelAritmatikContainer.Controls.Add(this.labelRotateTitle);
            this.panelAritmatikContainer.Location = new System.Drawing.Point(5, 5);
            this.panelAritmatikContainer.Name = "panelAritmatikContainer";
            this.panelAritmatikContainer.Size = new System.Drawing.Size(239, 690);
            this.panelAritmatikContainer.TabIndex = 1;
            this.panelAritmatikContainer.Visible = false;
            // 
            // labelAritmatikTitle
            // 
            this.labelAritmatikTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelAritmatikTitle.ForeColor = System.Drawing.Color.White;
            this.labelAritmatikTitle.Location = new System.Drawing.Point(36, 16);
            this.labelAritmatikTitle.Name = "labelAritmatikTitle";
            this.labelAritmatikTitle.Size = new System.Drawing.Size(180, 25);
            this.labelAritmatikTitle.TabIndex = 0;
            this.labelAritmatikTitle.Text = "Aritmatika";
            this.labelAritmatikTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRotate45
            // 
            this.btnRotate45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnRotate45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate45.ForeColor = System.Drawing.Color.White;
            this.btnRotate45.Location = new System.Drawing.Point(36, 80);
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
            this.btnRotate90.Location = new System.Drawing.Point(36, 125);
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
            this.btnRotate180.Location = new System.Drawing.Point(36, 170);
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
            this.labelRotateTitle.Location = new System.Drawing.Point(36, 50);
            this.labelRotateTitle.Name = "labelRotateTitle";
            this.labelRotateTitle.Size = new System.Drawing.Size(180, 20);
            this.labelRotateTitle.TabIndex = 1;
            this.labelRotateTitle.Text = "Rotate Image";
            this.labelRotateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panelFilterContainer.Size = new System.Drawing.Size(239, 690);
            this.panelFilterContainer.TabIndex = 0;
            this.panelFilterContainer.Visible = false;
            // 
            // labelFilterTitle
            // 
            this.labelFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFilterTitle.ForeColor = System.Drawing.Color.White;
            this.labelFilterTitle.Location = new System.Drawing.Point(36, 16);
            this.labelFilterTitle.Name = "labelFilterTitle";
            this.labelFilterTitle.Size = new System.Drawing.Size(180, 25);
            this.labelFilterTitle.TabIndex = 0;
            this.labelFilterTitle.Text = "Filter Preview";
            this.labelFilterTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(50, 66);
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
            this.labelOriginal.Location = new System.Drawing.Point(50, 126);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(60, 20);
            this.labelOriginal.TabIndex = 2;
            this.labelOriginal.Text = "Original";
            this.labelOriginal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxRed
            // 
            this.pictureBoxRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRed.Location = new System.Drawing.Point(136, 66);
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
            this.labelRed.Location = new System.Drawing.Point(136, 126);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(60, 20);
            this.labelRed.TabIndex = 4;
            this.labelRed.Text = "Red";
            this.labelRed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxGreen
            // 
            this.pictureBoxGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGreen.Location = new System.Drawing.Point(50, 156);
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
            this.labelGreen.Location = new System.Drawing.Point(50, 219);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(60, 20);
            this.labelGreen.TabIndex = 6;
            this.labelGreen.Text = "Green";
            this.labelGreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxBlue
            // 
            this.pictureBoxBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlue.Location = new System.Drawing.Point(136, 156);
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
            this.labelBlue.Location = new System.Drawing.Point(136, 219);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(60, 20);
            this.labelBlue.TabIndex = 8;
            this.labelBlue.Text = "Blue";
            this.labelBlue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGray.Location = new System.Drawing.Point(50, 242);
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
            this.labelGray.Location = new System.Drawing.Point(49, 305);
            this.labelGray.Name = "labelGray";
            this.labelGray.Size = new System.Drawing.Size(60, 20);
            this.labelGray.TabIndex = 10;
            this.labelGray.Text = "Grayscale";
            this.labelGray.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxNegative
            // 
            this.pictureBoxNegative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNegative.Location = new System.Drawing.Point(49, 328);
            this.pictureBoxNegative.Name = "pictureBoxNegative";
            this.pictureBoxNegative.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxNegative.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNegative.TabIndex = 19;
            this.pictureBoxNegative.TabStop = false;
            this.pictureBoxNegative.Click += new System.EventHandler(this.pictureBoxNegative_Click);
            // 
            // labelNegative
            // 
            this.labelNegative.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelNegative.ForeColor = System.Drawing.Color.White;
            this.labelNegative.Location = new System.Drawing.Point(49, 391);
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
            this.pictureBoxThreshold.Location = new System.Drawing.Point(136, 242);
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
            this.labelThreshold.Location = new System.Drawing.Point(136, 305);
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
            this.panelBrightnessContainer.Location = new System.Drawing.Point(16, 423);
            this.panelBrightnessContainer.Name = "panelBrightnessContainer";
            this.panelBrightnessContainer.Size = new System.Drawing.Size(220, 120);
            this.panelBrightnessContainer.TabIndex = 0;
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
        protected internal System.Windows.Forms.Panel panelFilterContainer;
    }
}