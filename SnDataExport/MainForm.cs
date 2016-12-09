using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using DBFHelper;
using SnDataExport.SubForm;
using SnDataExport.Models;

namespace SnDataExport
{
    public partial class MainForm : Form
    {
        public MySqlConnection conn;
        public string mysqlTableName = string.Empty;
        public string dbfFileName = string.Empty;
        public DataTable dbf_data_table;

        private string connectionString = string.Empty;
        private BindingSource bs_mysql;
        private BindingSource bs_dbf;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BindingEventHandler();
        }

        private void BindingEventHandler()
        {
            this.mysqlTableName = this.txtMysqlTableName.Text.Trim();
            this.connectionString = this.txtConn.Text.Trim();
            this.dbfFileName = this.txtDbfFileName.Text.Trim();

            this.txtConn.TextChanged += delegate
            {
                this.connectionString = this.txtConn.Text.Trim();
            };

            this.txtMysqlTableName.TextChanged += delegate
            {
                this.mysqlTableName = this.txtMysqlTableName.Text.Trim();

                this.btnAddArea.Enabled = this.mysqlTableName.ToLower() == "serial" ? true : false;
                this.btnAddVerExt.Enabled = this.mysqlTableName.ToLower() == "serial" ? true : false;
            };

            this.txtDbfFileName.TextChanged += delegate
            {
                this.dbfFileName = this.txtDbfFileName.Text.Trim();
                this.txtMysqlTableName.Text = Path.GetFileName(this.dbfFileName).ToLower().Replace(".dbf", "");
            };

            this.btnGoMysql.Click += delegate
            {
                try
                {
                    this.conn = new MySqlConnection(this.connectionString);
                    MySqlDataAdapter adapt = new MySqlDataAdapter("Select * From " + this.mysqlTableName, this.conn);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    this.conn.Open();

                    this.bs_mysql = new BindingSource(ds, ds.Tables[0].TableName);

                    this.dgvMysql.DataSource = this.bs_mysql;

                    this.conn.Close();

                    this.lblMysqlRowCount.Text = this.bs_mysql.Count.ToString() + " Row(s)";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lblMysqlRowCount.Text = "... Row(s)";
                }
                
            };
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.Multiselect = false;
            ofd.Filter = "dbf|*.dbf";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.txtDbfFileName.Text = ofd.FileName;
                    this.dbf_data_table = DBFParse.ReadDBF(this.dbfFileName);

                    this.bs_dbf = new BindingSource();
                    this.bs_dbf.DataSource = this.dbf_data_table;

                    this.dgvDbf.DataSource = this.bs_dbf;

                    this.lblDbfRowCount.Text = this.dbf_data_table.Rows.Count.ToString() + " Row(s)";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lblDbfRowCount.Text = "... Row(s)";
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (this.conn == null)
                this.btnGoMysql.PerformClick();

            this.dbf_data_table = DBFParse.ReadDBF(this.dbfFileName);

            ConvertDialog cd = new ConvertDialog(this);
            DialogResult dlg_result = cd.ShowDialog();
            if (dlg_result == DialogResult.OK || dlg_result == DialogResult.Abort)
            {
                this.btnGoMysql.PerformClick();
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            if (this.conn == null)
                this.btnGoMysql.PerformClick();

            this.dbf_data_table = DBFParse.ReadDBF(this.dbfFileName);
            this.dbf_data_table = this.dbf_data_table.AsEnumerable().GroupBy(r => new { area = ((string)r["area"]).Trim() })
                .Select(g => g.OrderBy(r => r["area"]).First())
                .OrderBy(g => g["area"])
                .CopyToDataTable();

            ConvertDialog cd = new ConvertDialog(this, ConvertDialog.TABTYP_AREA);
            DialogResult dlg_result = cd.ShowDialog();
            if (dlg_result == DialogResult.OK || dlg_result == DialogResult.Abort)
            {
                this.btnGoMysql.PerformClick();
            }
        }

        private void btnAddVerExt_Click(object sender, EventArgs e)
        {
            if (this.conn == null)
                this.btnGoMysql.PerformClick();

            this.dbf_data_table = DBFParse.ReadDBF(this.dbfFileName);
            this.dbf_data_table = this.dbf_data_table.AsEnumerable().GroupBy(r => new { verext = r["verext"] })
                .Select(g => g.OrderBy(r => r["verext"]).First())
                .OrderBy(g => g["verext"])
                .CopyToDataTable();

            ConvertDialog cd = new ConvertDialog(this, ConvertDialog.TABTYP_VEREXT);
            DialogResult dlg_result = cd.ShowDialog();
            if (dlg_result == DialogResult.OK || dlg_result == DialogResult.Abort)
            {
                this.btnGoMysql.PerformClick();
            }
        }
    }
}
