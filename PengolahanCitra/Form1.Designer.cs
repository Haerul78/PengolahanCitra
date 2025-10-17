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
            this.BtnSetColor = new System.Windows.Forms.Button();
            this.btnSaveToTxt = new System.Windows.Forms.Button();
            this.btnBukaGambar = new System.Windows.Forms.Button();
            this.labelHistogram = new System.Windows.Forms.Label();
            this.pictureBoxHistogramR = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramGray = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramB = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogramG = new System.Windows.Forms.PictureBox();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelSidebarRight = new System.Windows.Forms.Panel();
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
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.panelHistogramContainer = new System.Windows.Forms.Panel();
            this.panelSidebarLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramG)).BeginInit();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panelSidebarRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).BeginInit();
            this.panelHistogramContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebarLeft
            // 
            this.panelSidebarLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarLeft.Controls.Add(this.panelHistogramContainer);
            this.panelSidebarLeft.Controls.Add(this.BtnSetColor);
            this.panelSidebarLeft.Controls.Add(this.btnSaveToTxt);
            this.panelSidebarLeft.Controls.Add(this.btnBukaGambar);
            this.panelSidebarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebarLeft.Location = new System.Drawing.Point(0, 60);
            this.panelSidebarLeft.Name = "panelSidebarLeft";
            this.panelSidebarLeft.Size = new System.Drawing.Size(250, 701);
            this.panelSidebarLeft.TabIndex = 0;
            // 
            // BtnSetColor
            // 
            this.BtnSetColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetColor.FlatAppearance.BorderSize = 0;
            this.BtnSetColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetColor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BtnSetColor.ForeColor = System.Drawing.Color.White;
            this.BtnSetColor.Location = new System.Drawing.Point(15, 144);
            this.BtnSetColor.Name = "BtnSetColor";
            this.BtnSetColor.Size = new System.Drawing.Size(220, 45);
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
            this.btnSaveToTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnSaveToTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveToTxt.FlatAppearance.BorderSize = 0;
            this.btnSaveToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToTxt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSaveToTxt.ForeColor = System.Drawing.Color.White;
            this.btnSaveToTxt.Location = new System.Drawing.Point(15, 96);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(220, 42);
            this.btnSaveToTxt.TabIndex = 2;
            this.btnSaveToTxt.Text = "💾 Simpan ke .Txt";
            this.btnSaveToTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToTxt.UseVisualStyleBackColor = false;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveToTxt_Click);
            this.btnSaveToTxt.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSaveToTxt.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnBukaGambar
            // 
            this.btnBukaGambar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
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
            this.btnBukaGambar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBukaGambar.UseVisualStyleBackColor = false;
            this.btnBukaGambar.Click += new System.EventHandler(this.btnBukaGambar_Click);
            this.btnBukaGambar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnBukaGambar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
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
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelToolbar.Controls.Add(this.btnSave);
            this.panelToolbar.Controls.Add(this.btnEdit);
            this.panelToolbar.Controls.Add(this.btnHome);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1284, 60);
            this.panelToolbar.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(135, 10);
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
            this.btnHome.Size = new System.Drawing.Size(50, 40);
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
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            // 
            // panelSidebarRight
            // 
            this.panelSidebarRight.AutoScroll = true;
            this.panelSidebarRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarRight.Controls.Add(this.labelFilterTitle);
            this.panelSidebarRight.Controls.Add(this.pictureBoxOriginal);
            this.panelSidebarRight.Controls.Add(this.labelOriginal);
            this.panelSidebarRight.Controls.Add(this.pictureBoxRed);
            this.panelSidebarRight.Controls.Add(this.labelRed);
            this.panelSidebarRight.Controls.Add(this.pictureBoxGreen);
            this.panelSidebarRight.Controls.Add(this.labelGreen);
            this.panelSidebarRight.Controls.Add(this.pictureBoxBlue);
            this.panelSidebarRight.Controls.Add(this.labelBlue);
            this.panelSidebarRight.Controls.Add(this.pictureBoxGray);
            this.panelSidebarRight.Controls.Add(this.labelGray);
            this.panelSidebarRight.Controls.Add(this.btnApplyFilter);
            this.panelSidebarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebarRight.Location = new System.Drawing.Point(1035, 60);
            this.panelSidebarRight.Name = "panelSidebarRight";
            this.panelSidebarRight.Padding = new System.Windows.Forms.Padding(5);
            this.panelSidebarRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelSidebarRight.Size = new System.Drawing.Size(249, 701);
            this.panelSidebarRight.TabIndex = 2;
            this.panelSidebarRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebarRight_Paint);
            // 
            // labelFilterTitle
            // 
            this.labelFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFilterTitle.ForeColor = System.Drawing.Color.White;
            this.labelFilterTitle.Location = new System.Drawing.Point(15, 20);
            this.labelFilterTitle.Name = "labelFilterTitle";
            this.labelFilterTitle.Size = new System.Drawing.Size(180, 25);
            this.labelFilterTitle.TabIndex = 0;
            this.labelFilterTitle.Text = "Filter Preview";
            this.labelFilterTitle.Visible = false;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(15, 50);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.Visible = false;
            this.pictureBoxOriginal.Click += new System.EventHandler(this.pictureBoxOriginal_Click);
            // 
            // labelOriginal
            // 
            this.labelOriginal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelOriginal.ForeColor = System.Drawing.Color.White;
            this.labelOriginal.Location = new System.Drawing.Point(15, 110);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(60, 20);
            this.labelOriginal.TabIndex = 2;
            this.labelOriginal.Text = "Original";
            this.labelOriginal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelOriginal.Visible = false;
            // 
            // pictureBoxRed
            // 
            this.pictureBoxRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRed.Location = new System.Drawing.Point(15, 140);
            this.pictureBoxRed.Name = "pictureBoxRed";
            this.pictureBoxRed.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRed.TabIndex = 3;
            this.pictureBoxRed.TabStop = false;
            this.pictureBoxRed.Visible = false;
            this.pictureBoxRed.Click += new System.EventHandler(this.pictureBoxRed_Click);
            // 
            // labelRed
            // 
            this.labelRed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelRed.ForeColor = System.Drawing.Color.White;
            this.labelRed.Location = new System.Drawing.Point(15, 200);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(60, 20);
            this.labelRed.TabIndex = 4;
            this.labelRed.Text = "Red";
            this.labelRed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelRed.Visible = false;
            // 
            // pictureBoxGreen
            // 
            this.pictureBoxGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGreen.Location = new System.Drawing.Point(15, 230);
            this.pictureBoxGreen.Name = "pictureBoxGreen";
            this.pictureBoxGreen.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGreen.TabIndex = 5;
            this.pictureBoxGreen.TabStop = false;
            this.pictureBoxGreen.Visible = false;
            this.pictureBoxGreen.Click += new System.EventHandler(this.pictureBoxGreen_Click);
            // 
            // labelGreen
            // 
            this.labelGreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelGreen.ForeColor = System.Drawing.Color.White;
            this.labelGreen.Location = new System.Drawing.Point(15, 290);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(60, 20);
            this.labelGreen.TabIndex = 6;
            this.labelGreen.Text = "Green";
            this.labelGreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelGreen.Visible = false;
            // 
            // pictureBoxBlue
            // 
            this.pictureBoxBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlue.Location = new System.Drawing.Point(15, 320);
            this.pictureBoxBlue.Name = "pictureBoxBlue";
            this.pictureBoxBlue.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBlue.TabIndex = 7;
            this.pictureBoxBlue.TabStop = false;
            this.pictureBoxBlue.Visible = false;
            this.pictureBoxBlue.Click += new System.EventHandler(this.pictureBoxBlue_Click);
            // 
            // labelBlue
            // 
            this.labelBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBlue.ForeColor = System.Drawing.Color.White;
            this.labelBlue.Location = new System.Drawing.Point(15, 380);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(60, 20);
            this.labelBlue.TabIndex = 8;
            this.labelBlue.Text = "Blue";
            this.labelBlue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelBlue.Visible = false;
            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGray.Location = new System.Drawing.Point(15, 410);
            this.pictureBoxGray.Name = "pictureBoxGray";
            this.pictureBoxGray.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGray.TabIndex = 9;
            this.pictureBoxGray.TabStop = false;
            this.pictureBoxGray.Visible = false;
            this.pictureBoxGray.Click += new System.EventHandler(this.pictureBoxGray_Click);
            // 
            // labelGray
            // 
            this.labelGray.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelGray.ForeColor = System.Drawing.Color.White;
            this.labelGray.Location = new System.Drawing.Point(15, 470);
            this.labelGray.Name = "labelGray";
            this.labelGray.Size = new System.Drawing.Size(60, 20);
            this.labelGray.TabIndex = 10;
            this.labelGray.Text = "Grayscale";
            this.labelGray.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelGray.Visible = false;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(15, 500);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(180, 35);
            this.btnApplyFilter.TabIndex = 11;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Visible = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogramG)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panelSidebarRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).EndInit();
            this.panelHistogramContainer.ResumeLayout(false);
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

        // Filter preview controls (right sidebar)
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
        private System.Windows.Forms.Button btnApplyFilter;

        // Tambahkan di bagian deklarasi variabel (di bagian bawah)
        private System.Windows.Forms.PictureBox pictureBoxHistogramR;
        private System.Windows.Forms.PictureBox pictureBoxHistogramG;
        private System.Windows.Forms.PictureBox pictureBoxHistogramB;
        private System.Windows.Forms.PictureBox pictureBoxHistogramGray;
        private System.Windows.Forms.Label labelHistogram;
        private System.Windows.Forms.Panel panelHistogramContainer;
    }
}