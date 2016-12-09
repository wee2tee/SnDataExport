namespace SnDataExport.SubForm
{
    partial class ConvertDialog
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFromFileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblToTableName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(149, 140);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "เริ่มแปลงข้อมูล";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(273, 140);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(118, 28);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "หยุด";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(62, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(413, 14);
            this.progressBar1.TabIndex = 2;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProgress.Location = new System.Drawing.Point(62, 88);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(413, 20);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "0 / 0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "แปลงข้อมูลจากไฟล์ : ";
            // 
            // lblFromFileName
            // 
            this.lblFromFileName.AutoSize = true;
            this.lblFromFileName.Location = new System.Drawing.Point(148, 23);
            this.lblFromFileName.Name = "lblFromFileName";
            this.lblFromFileName.Size = new System.Drawing.Size(91, 16);
            this.lblFromFileName.TabIndex = 4;
            this.lblFromFileName.Text = "from_filename";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "ไปยังเทเบิล : ";
            // 
            // lblToTableName
            // 
            this.lblToTableName.AutoSize = true;
            this.lblToTableName.Location = new System.Drawing.Point(148, 50);
            this.lblToTableName.Name = "lblToTableName";
            this.lblToTableName.Size = new System.Drawing.Size(86, 16);
            this.lblToTableName.TabIndex = 4;
            this.lblToTableName.Text = "to_tablename";
            // 
            // ConvertDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 184);
            this.Controls.Add(this.lblFromFileName);
            this.Controls.Add(this.lblToTableName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert DBF to MySql";
            this.Load += new System.EventHandler(this.ConvertDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFromFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblToTableName;
    }
}