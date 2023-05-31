namespace ExeUpdater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnUpdate = new Button();
            progressBar = new ProgressBar();
            lstStatus = new ListBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbLastUpdatedTime = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label7 = new Label();
            tbFileCount = new TextBox();
            btnPaste = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            tbFileName = new TextBox();
            label6 = new Label();
            lstFiles = new ListBox();
            tbLastSavedTime = new TextBox();
            label3 = new Label();
            tbRemotePath = new TextBox();
            btnPathBrowse = new Button();
            btnSave = new Button();
            tbLocalPath = new TextBox();
            label5 = new Label();
            lbRemotePath = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.Location = new Point(24, 18);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(119, 31);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(24, 91);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(744, 29);
            progressBar.TabIndex = 1;
            // 
            // lstStatus
            // 
            lstStatus.FormattingEnabled = true;
            lstStatus.HorizontalScrollbar = true;
            lstStatus.ItemHeight = 20;
            lstStatus.Location = new Point(24, 129);
            lstStatus.Name = "lstStatus";
            lstStatus.SelectionMode = SelectionMode.MultiExtended;
            lstStatus.Size = new Size(744, 364);
            lstStatus.TabIndex = 3;
            lstStatus.KeyDown += lstStatus_KeyDown;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 540);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbLastUpdatedTime);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lstStatus);
            tabPage1.Controls.Add(btnUpdate);
            tabPage1.Controls.Add(progressBar);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 507);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "程式更新";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbLastUpdatedTime
            // 
            tbLastUpdatedTime.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastUpdatedTime.Location = new Point(541, 22);
            tbLastUpdatedTime.Name = "tbLastUpdatedTime";
            tbLastUpdatedTime.ReadOnly = true;
            tbLastUpdatedTime.Size = new Size(227, 25);
            tbLastUpdatedTime.TabIndex = 6;
            tbLastUpdatedTime.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(430, 25);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 5;
            label2.Text = "上次更新時間";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 68);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 4;
            label1.Text = "狀態";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(tbFileCount);
            tabPage2.Controls.Add(btnPaste);
            tabPage2.Controls.Add(btnAdd);
            tabPage2.Controls.Add(btnRemove);
            tabPage2.Controls.Add(tbFileName);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(lstFiles);
            tabPage2.Controls.Add(tbLastSavedTime);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(tbRemotePath);
            tabPage2.Controls.Add(btnPathBrowse);
            tabPage2.Controls.Add(btnSave);
            tabPage2.Controls.Add(tbLocalPath);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(lbRemotePath);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 507);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "參數設定";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(649, 440);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 15;
            label7.Text = "檔案數量";
            // 
            // tbFileCount
            // 
            tbFileCount.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbFileCount.Location = new Point(649, 463);
            tbFileCount.Name = "tbFileCount";
            tbFileCount.ReadOnly = true;
            tbFileCount.RightToLeft = RightToLeft.Yes;
            tbFileCount.Size = new Size(119, 25);
            tbFileCount.TabIndex = 14;
            tbFileCount.TabStop = false;
            // 
            // btnPaste
            // 
            btnPaste.BackColor = Color.Transparent;
            btnPaste.Location = new Point(649, 281);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(119, 31);
            btnPaste.TabIndex = 7;
            btnPaste.Text = "貼上";
            btnPaste.UseVisualStyleBackColor = false;
            btnPaste.Click += btnPaste_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.Location = new Point(648, 206);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(119, 31);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "加入";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Transparent;
            btnRemove.Location = new Point(649, 244);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(119, 31);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "移除";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // tbFileName
            // 
            tbFileName.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbFileName.Location = new Point(24, 210);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(618, 27);
            tbFileName.TabIndex = 4;
            tbFileName.KeyPress += tbFileName_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 187);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 12;
            label6.Text = "檔案名稱";
            // 
            // lstFiles
            // 
            lstFiles.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 20;
            lstFiles.Location = new Point(23, 244);
            lstFiles.Name = "lstFiles";
            lstFiles.SelectionMode = SelectionMode.MultiExtended;
            lstFiles.Size = new Size(619, 244);
            lstFiles.TabIndex = 11;
            lstFiles.KeyDown += lstFiles_KeyDown;
            // 
            // tbLastSavedTime
            // 
            tbLastSavedTime.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastSavedTime.Location = new Point(541, 22);
            tbLastSavedTime.Name = "tbLastSavedTime";
            tbLastSavedTime.ReadOnly = true;
            tbLastSavedTime.Size = new Size(227, 25);
            tbLastSavedTime.TabIndex = 10;
            tbLastSavedTime.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 25);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 9;
            label3.Text = "上次儲存時間";
            // 
            // tbRemotePath
            // 
            tbRemotePath.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbRemotePath.Location = new Point(24, 91);
            tbRemotePath.Name = "tbRemotePath";
            tbRemotePath.Size = new Size(743, 27);
            tbRemotePath.TabIndex = 1;
            // 
            // btnPathBrowse
            // 
            btnPathBrowse.BackColor = Color.Transparent;
            btnPathBrowse.Location = new Point(648, 147);
            btnPathBrowse.Name = "btnPathBrowse";
            btnPathBrowse.Size = new Size(119, 31);
            btnPathBrowse.TabIndex = 3;
            btnPathBrowse.Text = "瀏覽";
            btnPathBrowse.UseVisualStyleBackColor = false;
            btnPathBrowse.Click += btnPathBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.Location = new Point(24, 18);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 31);
            btnSave.TabIndex = 0;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tbLocalPath
            // 
            tbLocalPath.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbLocalPath.Location = new Point(24, 151);
            tbLocalPath.Name = "tbLocalPath";
            tbLocalPath.Size = new Size(618, 27);
            tbLocalPath.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 128);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 4;
            label5.Text = "本機路徑";
            // 
            // lbRemotePath
            // 
            lbRemotePath.AutoSize = true;
            lbRemotePath.Location = new Point(23, 68);
            lbRemotePath.Name = "lbRemotePath";
            lbRemotePath.Size = new Size(73, 20);
            lbRemotePath.TabIndex = 0;
            lbRemotePath.Text = "遠端路徑";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 540);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmartMan 更新工具";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnUpdate;
        private ProgressBar progressBar;
        private ListBox lstStatus;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private TextBox tbLastUpdatedTime;
        private Button btnSave;
        private TextBox tbLocalPath;
        private Label label5;
        private Label lbRemotePath;
        private Button btnPathBrowse;
        private TextBox tbRemotePath;
        private TextBox tbLastSavedTime;
        private Label label3;
        private Label label6;
        private ListBox lstFiles;
        private Button btnAdd;
        private Button btnRemove;
        private TextBox tbFileName;
        private Button btnPaste;
        private Label label7;
        private TextBox tbFileCount;
    }
}