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
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelSidebarRight = new System.Windows.Forms.Panel();
            this.panelSidebarLeft.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebarLeft
            // 
            this.panelSidebarLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
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
            this.pictureBoxMain.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBoxMain.Size = new System.Drawing.Size(808, 701);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            // 
            // panelSidebarRight
            // 
            this.panelSidebarRight.AutoScroll = true;
            this.panelSidebarRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panelSidebarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebarRight.Location = new System.Drawing.Point(1058, 60);
            this.panelSidebarRight.Name = "panelSidebarRight";
            this.panelSidebarRight.Padding = new System.Windows.Forms.Padding(5);
            this.panelSidebarRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelSidebarRight.Size = new System.Drawing.Size(226, 701);
            this.panelSidebarRight.TabIndex = 2;
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
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengolahan Citra Digital - Mikro Photoshop";
            this.panelSidebarLeft.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
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
    }
}