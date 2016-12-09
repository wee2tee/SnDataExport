namespace SnDataExport
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvMysql = new System.Windows.Forms.DataGridView();
            this.btnGoMysql = new System.Windows.Forms.Button();
            this.txtMysqlTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblMysqlRowCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDbf = new System.Windows.Forms.DataGridView();
            this.lblDbfRowCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDbfFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddVerExt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMysql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDbf)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMysql
            // 
            this.dgvMysql.AllowUserToAddRows = false;
            this.dgvMysql.AllowUserToDeleteRows = false;
            this.dgvMysql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMysql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMysql.Location = new System.Drawing.Point(3, 26);
            this.dgvMysql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMysql.Name = "dgvMysql";
            this.dgvMysql.ReadOnly = true;
            this.dgvMysql.Size = new System.Drawing.Size(474, 330);
            this.dgvMysql.TabIndex = 0;
            // 
            // btnGoMysql
            // 
            this.btnGoMysql.Location = new System.Drawing.Point(267, 49);
            this.btnGoMysql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGoMysql.Name = "btnGoMysql";
            this.btnGoMysql.Size = new System.Drawing.Size(87, 24);
            this.btnGoMysql.TabIndex = 1;
            this.btnGoMysql.Text = "Show Data";
            this.btnGoMysql.UseVisualStyleBackColor = true;
            // 
            // txtMysqlTableName
            // 
            this.txtMysqlTableName.Location = new System.Drawing.Point(121, 50);
            this.txtMysqlTableName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMysqlTableName.Name = "txtMysqlTableName";
            this.txtMysqlTableName.Size = new System.Drawing.Size(140, 23);
            this.txtMysqlTableName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connection string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table name";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 167);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvMysql);
            this.splitContainer1.Panel1.Controls.Add(this.lblMysqlRowCount);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDbf);
            this.splitContainer1.Panel2.Controls.Add(this.lblDbfRowCount);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(957, 360);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 4;
            // 
            // lblMysqlRowCount
            // 
            this.lblMysqlRowCount.AutoSize = true;
            this.lblMysqlRowCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMysqlRowCount.Location = new System.Drawing.Point(56, 6);
            this.lblMysqlRowCount.Name = "lblMysqlRowCount";
            this.lblMysqlRowCount.Size = new System.Drawing.Size(65, 16);
            this.lblMysqlRowCount.TabIndex = 3;
            this.lblMysqlRowCount.Text = "... Row(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mysql";
            // 
            // dgvDbf
            // 
            this.dgvDbf.AllowUserToAddRows = false;
            this.dgvDbf.AllowUserToDeleteRows = false;
            this.dgvDbf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDbf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDbf.Location = new System.Drawing.Point(3, 26);
            this.dgvDbf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDbf.Name = "dgvDbf";
            this.dgvDbf.ReadOnly = true;
            this.dgvDbf.Size = new System.Drawing.Size(467, 330);
            this.dgvDbf.TabIndex = 0;
            // 
            // lblDbfRowCount
            // 
            this.lblDbfRowCount.AutoSize = true;
            this.lblDbfRowCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDbfRowCount.Location = new System.Drawing.Point(40, 6);
            this.lblDbfRowCount.Name = "lblDbfRowCount";
            this.lblDbfRowCount.Size = new System.Drawing.Size(65, 16);
            this.lblDbfRowCount.TabIndex = 3;
            this.lblDbfRowCount.Text = "... Row(s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "DBF";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConn);
            this.groupBox1.Controls.Add(this.txtMysqlTableName);
            this.groupBox1.Controls.Add(this.btnConvert);
            this.groupBox1.Controls.Add(this.btnGoMysql);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MySql";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtDbfFileName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(693, 61);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DBF file";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(647, 22);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 25);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDbfFileName
            // 
            this.txtDbfFileName.Location = new System.Drawing.Point(121, 23);
            this.txtDbfFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbfFileName.Name = "txtDbfFileName";
            this.txtDbfFileName.ReadOnly = true;
            this.txtDbfFileName.Size = new System.Drawing.Size(524, 23);
            this.txtDbfFileName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "DBF File Path";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(538, 21);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(141, 53);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert Dbf to MySql";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(121, 22);
            this.txtConn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(415, 23);
            this.txtConn.TabIndex = 2;
            this.txtConn.Text = "Server=localhost; Database=sn; Uid=root; Pwd=12345; Charset=utf8;";
            // 
            // btnAddArea
            // 
            this.btnAddArea.Enabled = false;
            this.btnAddArea.Location = new System.Drawing.Point(16, 22);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(214, 30);
            this.btnAddArea.TabIndex = 7;
            this.btnAddArea.Text = "Add Sales Area Data";
            this.btnAddArea.UseVisualStyleBackColor = true;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddVerExt);
            this.groupBox3.Controls.Add(this.btnAddArea);
            this.groupBox3.Location = new System.Drawing.Point(705, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 152);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Istab Data";
            // 
            // btnAddVerExt
            // 
            this.btnAddVerExt.Enabled = false;
            this.btnAddVerExt.Location = new System.Drawing.Point(16, 58);
            this.btnAddVerExt.Name = "btnAddVerExt";
            this.btnAddVerExt.Size = new System.Drawing.Size(214, 30);
            this.btnAddVerExt.TabIndex = 7;
            this.btnAddVerExt.Text = "Add VerExt. Data";
            this.btnAddVerExt.UseVisualStyleBackColor = true;
            this.btnAddVerExt.Click += new System.EventHandler(this.btnAddVerExt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 529);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBF to MySql Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMysql)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDbf)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMysql;
        private System.Windows.Forms.Button btnGoMysql;
        private System.Windows.Forms.TextBox txtMysqlTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDbf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDbfFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblMysqlRowCount;
        private System.Windows.Forms.Label lblDbfRowCount;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.Button btnAddArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddVerExt;
    }
}

