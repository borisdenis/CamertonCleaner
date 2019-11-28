namespace CamertonCleaner
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.роботаЗПапкоюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скануватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архiвуватиЗакритiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архiвуватиВiдмiченiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.азхiвуватиПошкодженiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всіЗакритiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewSpisok = new System.Windows.Forms.DataGridView();
            this.ColumnMetka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeloNomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSudya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFilesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKamertonFolder = new System.Windows.Forms.TextBox();
            this.buttonFolderKamerton = new System.Windows.Forms.Button();
            this.folderBrowserDialogKamerton = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArhivFolder = new System.Windows.Forms.TextBox();
            this.buttonFolderArhiv = new System.Windows.Forms.Button();
            this.folderBrowserDialogArhiv = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSpisokDel = new System.Windows.Forms.TabPage();
            this.tabPageError = new System.Windows.Forms.TabPage();
            this.dataGridViewErrorFile = new System.Windows.Forms.DataGridView();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelNumProgress = new System.Windows.Forms.Label();
            this.textBoxSudya = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDelo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpisok)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSpisokDel.SuspendLayout();
            this.tabPageError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrorFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.роботаЗПапкоюToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // роботаЗПапкоюToolStripMenuItem
            // 
            this.роботаЗПапкоюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скануватиToolStripMenuItem,
            this.архiвуватиЗакритiToolStripMenuItem,
            this.архiвуватиВiдмiченiToolStripMenuItem,
            this.азхiвуватиПошкодженiToolStripMenuItem,
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem,
            this.всіЗакритiToolStripMenuItem});
            this.роботаЗПапкоюToolStripMenuItem.Name = "роботаЗПапкоюToolStripMenuItem";
            this.роботаЗПапкоюToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.роботаЗПапкоюToolStripMenuItem.Text = "Робота з папкою";
            // 
            // скануватиToolStripMenuItem
            // 
            this.скануватиToolStripMenuItem.Name = "скануватиToolStripMenuItem";
            this.скануватиToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.скануватиToolStripMenuItem.Text = "Сканувати";
            this.скануватиToolStripMenuItem.Click += new System.EventHandler(this.скануватиToolStripMenuItem_Click);
            // 
            // архiвуватиЗакритiToolStripMenuItem
            // 
            this.архiвуватиЗакритiToolStripMenuItem.Name = "архiвуватиЗакритiToolStripMenuItem";
            this.архiвуватиЗакритiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.архiвуватиЗакритiToolStripMenuItem.Text = "Перемiстити всі закритi";
            this.архiвуватиЗакритiToolStripMenuItem.Click += new System.EventHandler(this.архiвуватиЗакритiToolStripMenuItem_Click);
            // 
            // архiвуватиВiдмiченiToolStripMenuItem
            // 
            this.архiвуватиВiдмiченiToolStripMenuItem.Name = "архiвуватиВiдмiченiToolStripMenuItem";
            this.архiвуватиВiдмiченiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.архiвуватиВiдмiченiToolStripMenuItem.Text = "Перемiстити тiльки вiдмiченi";
            this.архiвуватиВiдмiченiToolStripMenuItem.Click += new System.EventHandler(this.архiвуватиВiдмiченiToolStripMenuItem_Click);
            // 
            // азхiвуватиПошкодженiToolStripMenuItem
            // 
            this.азхiвуватиПошкодженiToolStripMenuItem.Name = "азхiвуватиПошкодженiToolStripMenuItem";
            this.азхiвуватиПошкодженiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.азхiвуватиПошкодженiToolStripMenuItem.Text = "Перемiстити всі пошкодженi";
            this.азхiвуватиПошкодженiToolStripMenuItem.Click += new System.EventHandler(this.азхiвуватиПошкодженiToolStripMenuItem_Click);
            // 
            // скопiюватиТiлькиВiдмiченiToolStripMenuItem
            // 
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem.Name = "скопiюватиТiлькиВiдмiченiToolStripMenuItem";
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem.Text = "Скопiювати тiльки вiдмiченi";
            this.скопiюватиТiлькиВiдмiченiToolStripMenuItem.Click += new System.EventHandler(this.скопiюватиТiлькиВiдмiченiToolStripMenuItem_Click);
            // 
            // всіЗакритiToolStripMenuItem
            // 
            this.всіЗакритiToolStripMenuItem.Name = "всіЗакритiToolStripMenuItem";
            this.всіЗакритiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.всіЗакритiToolStripMenuItem.Text = "Скопiювати  всі закритi";
            this.всіЗакритiToolStripMenuItem.Click += new System.EventHandler(this.всіЗакритiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dataGridViewSpisok
            // 
            this.dataGridViewSpisok.AllowUserToAddRows = false;
            this.dataGridViewSpisok.AllowUserToDeleteRows = false;
            this.dataGridViewSpisok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpisok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMetka,
            this.ColumnDeloNomer,
            this.ColumnData,
            this.ColumnStatus,
            this.ColumnSudya,
            this.ColumnFilesName});
            this.dataGridViewSpisok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSpisok.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSpisok.MultiSelect = false;
            this.dataGridViewSpisok.Name = "dataGridViewSpisok";
            this.dataGridViewSpisok.RowHeadersVisible = false;
            this.dataGridViewSpisok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSpisok.Size = new System.Drawing.Size(508, 312);
            this.dataGridViewSpisok.TabIndex = 4;
            this.dataGridViewSpisok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewSpisok_KeyDown);
            // 
            // ColumnMetka
            // 
            this.ColumnMetka.HeaderText = "";
            this.ColumnMetka.Name = "ColumnMetka";
            this.ColumnMetka.Width = 19;
            // 
            // ColumnDeloNomer
            // 
            this.ColumnDeloNomer.HeaderText = "Справа";
            this.ColumnDeloNomer.Name = "ColumnDeloNomer";
            this.ColumnDeloNomer.ReadOnly = true;
            // 
            // ColumnData
            // 
            this.ColumnData.HeaderText = "Дата";
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.ReadOnly = true;
            this.ColumnData.Width = 130;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Статус";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnSudya
            // 
            this.ColumnSudya.HeaderText = "Суддя";
            this.ColumnSudya.Name = "ColumnSudya";
            this.ColumnSudya.ReadOnly = true;
            this.ColumnSudya.Width = 140;
            // 
            // ColumnFilesName
            // 
            this.ColumnFilesName.HeaderText = "Имя файла";
            this.ColumnFilesName.Name = "ColumnFilesName";
            this.ColumnFilesName.ReadOnly = true;
            this.ColumnFilesName.Visible = false;
            this.ColumnFilesName.Width = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Робоча папка камертону";
            // 
            // textBoxKamertonFolder
            // 
            this.textBoxKamertonFolder.Location = new System.Drawing.Point(13, 45);
            this.textBoxKamertonFolder.Name = "textBoxKamertonFolder";
            this.textBoxKamertonFolder.Size = new System.Drawing.Size(479, 20);
            this.textBoxKamertonFolder.TabIndex = 6;
            // 
            // buttonFolderKamerton
            // 
            this.buttonFolderKamerton.Location = new System.Drawing.Point(498, 42);
            this.buttonFolderKamerton.Name = "buttonFolderKamerton";
            this.buttonFolderKamerton.Size = new System.Drawing.Size(33, 23);
            this.buttonFolderKamerton.TabIndex = 7;
            this.buttonFolderKamerton.Text = "...";
            this.buttonFolderKamerton.UseVisualStyleBackColor = true;
            this.buttonFolderKamerton.Click += new System.EventHandler(this.buttonFolderKamerton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Куди перемiщати";
            // 
            // textBoxArhivFolder
            // 
            this.textBoxArhivFolder.Location = new System.Drawing.Point(13, 85);
            this.textBoxArhivFolder.Name = "textBoxArhivFolder";
            this.textBoxArhivFolder.Size = new System.Drawing.Size(479, 20);
            this.textBoxArhivFolder.TabIndex = 9;
            // 
            // buttonFolderArhiv
            // 
            this.buttonFolderArhiv.Location = new System.Drawing.Point(498, 82);
            this.buttonFolderArhiv.Name = "buttonFolderArhiv";
            this.buttonFolderArhiv.Size = new System.Drawing.Size(33, 23);
            this.buttonFolderArhiv.TabIndex = 10;
            this.buttonFolderArhiv.Text = "...";
            this.buttonFolderArhiv.UseVisualStyleBackColor = true;
            this.buttonFolderArhiv.Click += new System.EventHandler(this.buttonFolderArhiv_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSpisokDel);
            this.tabControl1.Controls.Add(this.tabPageError);
            this.tabControl1.Location = new System.Drawing.Point(12, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(522, 344);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageSpisokDel
            // 
            this.tabPageSpisokDel.Controls.Add(this.dataGridViewSpisok);
            this.tabPageSpisokDel.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpisokDel.Name = "tabPageSpisokDel";
            this.tabPageSpisokDel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpisokDel.Size = new System.Drawing.Size(514, 318);
            this.tabPageSpisokDel.TabIndex = 0;
            this.tabPageSpisokDel.Text = "Перелiк справ";
            this.tabPageSpisokDel.UseVisualStyleBackColor = true;
            // 
            // tabPageError
            // 
            this.tabPageError.Controls.Add(this.dataGridViewErrorFile);
            this.tabPageError.Location = new System.Drawing.Point(4, 22);
            this.tabPageError.Name = "tabPageError";
            this.tabPageError.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageError.Size = new System.Drawing.Size(514, 318);
            this.tabPageError.TabIndex = 1;
            this.tabPageError.Text = "Пошкодженi";
            this.tabPageError.UseVisualStyleBackColor = true;
            // 
            // dataGridViewErrorFile
            // 
            this.dataGridViewErrorFile.AllowUserToAddRows = false;
            this.dataGridViewErrorFile.AllowUserToDeleteRows = false;
            this.dataGridViewErrorFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrorFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFileName});
            this.dataGridViewErrorFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewErrorFile.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewErrorFile.Name = "dataGridViewErrorFile";
            this.dataGridViewErrorFile.Size = new System.Drawing.Size(508, 312);
            this.dataGridViewErrorFile.TabIndex = 0;
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.HeaderText = "iм\'я файлу";
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.Width = 450;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 521);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // labelNumProgress
            // 
            this.labelNumProgress.AutoSize = true;
            this.labelNumProgress.Location = new System.Drawing.Point(238, 526);
            this.labelNumProgress.Name = "labelNumProgress";
            this.labelNumProgress.Size = new System.Drawing.Size(35, 13);
            this.labelNumProgress.TabIndex = 13;
            this.labelNumProgress.Text = "label3";
            // 
            // textBoxSudya
            // 
            this.textBoxSudya.Location = new System.Drawing.Point(362, 24);
            this.textBoxSudya.Name = "textBoxSudya";
            this.textBoxSudya.Size = new System.Drawing.Size(141, 20);
            this.textBoxSudya.TabIndex = 14;
            this.textBoxSudya.TextChanged += new System.EventHandler(this.textBoxFiltrAll_TextChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(262, 24);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(94, 20);
            this.textBoxStatus.TabIndex = 15;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBoxFiltrAll_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxDelo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxData);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxSudya);
            this.groupBox1.Controls.Add(this.textBoxStatus);
            this.groupBox1.Location = new System.Drawing.Point(13, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 53);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(6, 26);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(15, 15);
            this.buttonClear.TabIndex = 22;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Справа";
            // 
            // textBoxDelo
            // 
            this.textBoxDelo.Location = new System.Drawing.Point(27, 24);
            this.textBoxDelo.Name = "textBoxDelo";
            this.textBoxDelo.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelo.TabIndex = 20;
            this.textBoxDelo.TextChanged += new System.EventHandler(this.textBoxFiltrAll_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Дата";
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(133, 24);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(123, 20);
            this.textBoxData.TabIndex = 18;
            this.textBoxData.TextChanged += new System.EventHandler(this.textBoxFiltrAll_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Статус";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "По суддях";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 556);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelNumProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonFolderArhiv);
            this.Controls.Add(this.textBoxArhivFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFolderKamerton);
            this.Controls.Add(this.textBoxKamertonFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Чистка Камертону";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpisok)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSpisokDel.ResumeLayout(false);
            this.tabPageError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrorFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem роботаЗПапкоюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скануватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem архiвуватиЗакритiToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewSpisok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKamertonFolder;
        private System.Windows.Forms.Button buttonFolderKamerton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogKamerton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxArhivFolder;
        private System.Windows.Forms.Button buttonFolderArhiv;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogArhiv;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSpisokDel;
        private System.Windows.Forms.TabPage tabPageError;
        private System.Windows.Forms.DataGridView dataGridViewErrorFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.ToolStripMenuItem архiвуватиВiдмiченiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem азхiвуватиПошкодженiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelNumProgress;
        private System.Windows.Forms.ToolStripMenuItem скопiюватиТiлькиВiдмiченiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всіЗакритiToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMetka;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeloNomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSudya;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilesName;
        private System.Windows.Forms.TextBox textBoxSudya;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClear;
    }
}

