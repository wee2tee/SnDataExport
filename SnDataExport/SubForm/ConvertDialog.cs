using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using MySql.Data.MySqlClient;
using SnDataExport.Models;

namespace SnDataExport.SubForm
{
    public partial class ConvertDialog : Form
    {
        private MainForm main_form;
        private string fromFileName = string.Empty;
        private string toTableName = string.Empty;
        private BackgroundWorker worker;


        private List<dealer> dealer_id_list;
        private List<serial> serial_id_list;
        private List<istab> probcod_list;
        private List<istab> area_list;
        private List<istab> busityp_list;
        private List<istab> howknown_list;
        private List<istab> verext_list;
        private const string TABTYP_HOWKNOW = "03";
        private const string TABTYP_BUSITYP = "04";
        private const string TABTYP_PROBCOD = "05";
        public const string TABTYP_AREA = "06";
        public const string TABTYP_VEREXT = "07";

        //private int record_count;
        private int last_converted_record = 0;
        private int error_record_count = 0;

        private int admin_id;

        public ConvertDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.fromFileName = main_form.dbfFileName;
            //this.toTableName = main_form.conn.Database + "." + main_form.mysqlTableName;
            this.toTableName = main_form.mysqlTableName;
            this.lblProgress.Text = "0 / " + this.main_form.dbf_data_table.Rows.Count.ToString();
            using (snEntities db = new snEntities())
            {
                admin_id = db.users.First().id;
            }
        }

        public ConvertDialog(MainForm main_form, string tabtyp)
            : this(main_form)
        {
            this.toTableName = "istab[tabtyp = '" + tabtyp + "']";
        }

        private void ConvertDialog_Load(object sender, EventArgs e)
        {
            this.lblFromFileName.Text = this.fromFileName;
            this.lblToTableName.Text = this.toTableName;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult confirm_result = DialogResult.Cancel;
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.toTableName + ".txt"))
            {
                int last_converted_record = 0;
                Int32.TryParse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.toTableName + ".txt"), out last_converted_record);
                ConfirmDialog confirm = new ConfirmDialog(last_converted_record);
                confirm_result = confirm.ShowDialog();
                if(confirm_result == DialogResult.Retry)
                {
                    this.last_converted_record = last_converted_record;
                }
            }
            else
            {
                confirm_result = MessageBox.Show("เริ่มทำการแปลงข้อมูลเข้าสู่ MySql", "", MessageBoxButtons.OKCancel);
            }

            Console.WriteLine(" .. >> " + confirm_result.ToString());

            if (confirm_result == DialogResult.OK || confirm_result == DialogResult.Retry)
            {
                this.btnStart.Enabled = false;

                this.worker = new BackgroundWorker();
                this.worker.WorkerReportsProgress = true;
                this.worker.WorkerSupportsCancellation = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = this.main_form.dbf_data_table.Rows.Count;
                progressBar1.Step = 1;

                using (snEntities db = new snEntities())
                {
                    this.serial_id_list = db.serial.ToList();
                    this.probcod_list = db.istab.Where(istab => istab.tabtyp == TABTYP_PROBCOD).ToList();
                    this.dealer_id_list = db.dealer.ToList();
                    this.area_list = db.istab.Where(istab => istab.tabtyp == TABTYP_AREA).ToList();
                    this.busityp_list = db.istab.Where(istab => istab.tabtyp == TABTYP_BUSITYP).ToList();
                    this.howknown_list = db.istab.Where(istab => istab.tabtyp == TABTYP_HOWKNOW).ToList();
                    this.verext_list = db.istab.Where(istab => istab.tabtyp == TABTYP_VEREXT).ToList();
                }

                this.KeepLog("Start convert from " + this.main_form.dbfFileName + " record # " + this.last_converted_record.ToString() + " to \"" + this.main_form.conn.Database + "." + this.toTableName + "\" at : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine);

                this.worker.DoWork += delegate(object obj, DoWorkEventArgs ev)
                {
                    this.main_form.conn.Open();

                    //record_count = 0;
                    //foreach (DataRow row in this.main_form.dbf_data_table.Rows)
                    //{
                    //    record_count++;
                    //    if (record_count <= this.last_converted_record)
                    //        continue;

                    //    if (this.toTableName.ToLower() == "serial")
                    //    {
                    //        this.RecSerial(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "problem")
                    //    {
                    //        this.RecProblem(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "dealer")
                    //    {
                    //        this.RecDealer(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "d_msg")
                    //    {
                    //        this.RecDmsg(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "istab")
                    //    {
                    //        this.RecIstab(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "istab[tabtyp = '" + TABTYP_AREA + "']")
                    //    {
                    //        this.RecIstabArea(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.toTableName.ToLower() == "istab[tabtyp = '" + TABTYP_VEREXT + "']")
                    //    {
                    //        this.RecIstabVerext(row);
                    //        this.worker.ReportProgress(record_count);
                    //    }
                    //    if (this.worker.CancellationPending)
                    //    {
                    //        ev.Cancel = true;
                    //        return;
                    //    }
                    //}

                    for (int i = this.last_converted_record; i < this.main_form.dbf_data_table.Rows.Count; i++)
                    {
                        this.last_converted_record++;
                        var row = this.main_form.dbf_data_table.Rows[i];

                        if (this.toTableName.ToLower() == "serial")
                        {
                            this.RecSerial(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "problem")
                        {
                            this.RecProblem(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "dealer")
                        {
                            this.RecDealer(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "d_msg")
                        {
                            this.RecDmsg(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "istab")
                        {
                            this.RecIstab(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "istab[tabtyp = '" + TABTYP_AREA + "']")
                        {
                            this.RecIstabArea(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.toTableName.ToLower() == "istab[tabtyp = '" + TABTYP_VEREXT + "']")
                        {
                            this.RecIstabVerext(row);
                            this.worker.ReportProgress(i + 1);
                        }
                        if (this.worker.CancellationPending)
                        {
                            ev.Cancel = true;
                            return;
                        }
                        //this.last_converted_record++;
                    }
                };

                this.worker.ProgressChanged += delegate(object obj, ProgressChangedEventArgs ev)
                {
                    this.progressBar1.Value = ev.ProgressPercentage;
                    this.lblProgress.Text = ev.ProgressPercentage.ToString() + " / " + this.main_form.dbf_data_table.Rows.Count.ToString();
                };

                this.worker.RunWorkerCompleted += delegate(object obj, RunWorkerCompletedEventArgs ev)
                {
                    if (this.progressBar1.Value == this.progressBar1.Maximum)
                    {
                        this.KeepLog("Convert successfully at : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine + Environment.NewLine);
                        MessageBox.Show("แปลงข้อมูลเสร็จเรียบร้อย");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.KeepLog("Stop convert by user at : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine + Environment.NewLine);
                        this.KeepConvertProgress(this.toTableName + ".txt", this.last_converted_record);
                        MessageBox.Show("หยุดการทำงานแล้ว");
                        this.DialogResult = DialogResult.Abort;
                    }

                    this.main_form.conn.Close();

                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                    this.Close();
                };
                this.worker.RunWorkerAsync();

                this.btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("หยุดการทำงาน?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this.worker.IsBusy)
                {
                    this.worker.CancelAsync();
                }
            }
        }

        //private void RecSerial(DataRow row)
        //{
        //    try
        //    {
        //        string purdat = (row[14] is DBNull ? null : ((DateTime)row[14]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
        //        string expdat = (row[15] is DBNull ? null : ((DateTime)row[15]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
        //        string manual = (row[20] is DBNull ? null : ((DateTime)row[20]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
        //        string chgdat = (row[25] is DBNull ? null : ((DateTime)row[25]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
        //        string verextdat = (row[27] is DBNull ? null : ((DateTime)row[27]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));

        //        string sql_insert = "Insert into serial (sernum, oldnum, version, contact, position, prenam, compnam, addr01, addr02, addr03, zipcod, telnum, faxnum, busityp, busides, purdat, expdat, howknown, area, branch, manual, upfree, refnum, remark, chgdat, verext, verextdat, users_id, users_name, dealer_id, dealer_dealer) ";
        //        sql_insert += " Values(@sernum, @oldnum, @version, @contact, @position, @prenam, @compnam, @addr01, @addr02, @addr03, @zipcod, @telnum, @faxnum, @busityp, @busides, @purdat, @expdat, @howknown, @area, @branch, @manual, @upfree, @refnum, @remark, @chgdat, @verext, @verextdat, @users_id, @users_name, @dealer_id, @dealer_dealer)";

        //        MySqlCommand cmd = new MySqlCommand(sql_insert, this.main_form.conn);

        //        cmd.Parameters.AddWithValue("@sernum", ((string)row[0]).Trim());
        //        cmd.Parameters.AddWithValue("@oldnum", ((string)row[1]).Trim());
        //        cmd.Parameters.AddWithValue("@version", ((string)row[2]).Trim());
        //        cmd.Parameters.AddWithValue("@contact", ((string)row[3]).Trim());
        //        cmd.Parameters.AddWithValue("@position", ((string)row[4]).Trim());
        //        cmd.Parameters.AddWithValue("@prenam", ((string)row[5]).Trim());
        //        cmd.Parameters.AddWithValue("@compnam", ((string)row[6]).Trim());
        //        cmd.Parameters.AddWithValue("@addr01", ((string)row[7]).Trim());
        //        cmd.Parameters.AddWithValue("@addr02", ((string)row[8]).Trim());
        //        cmd.Parameters.AddWithValue("@addr03", ((string)row[9]).Trim());
        //        cmd.Parameters.AddWithValue("@zipcod", ((string)row[10]).Trim());
        //        cmd.Parameters.AddWithValue("@telnum", ((string)row[11]).Trim());
        //        cmd.Parameters.AddWithValue("@faxnum", "");
        //        cmd.Parameters.AddWithValue("@busityp", ((string)row[12]).Trim());
        //        cmd.Parameters.AddWithValue("@busides", ((string)row[13]).Trim());
        //        cmd.Parameters.AddWithValue("@purdat", purdat);
        //        cmd.Parameters.AddWithValue("@expdat", expdat);
        //        cmd.Parameters.AddWithValue("@howknown", ((string)row[16]).Trim());
        //        cmd.Parameters.AddWithValue("@area", ((string)row[18]).Trim());
        //        cmd.Parameters.AddWithValue("@branch", ((string)row[19]).Trim());
        //        cmd.Parameters.AddWithValue("@manual", manual);
        //        cmd.Parameters.AddWithValue("@upfree", ((string)row[21]).Trim());
        //        cmd.Parameters.AddWithValue("@refnum", ((string)row[22]).Trim());
        //        cmd.Parameters.AddWithValue("@remark", ((string)row[23]).Trim());
        //        cmd.Parameters.AddWithValue("@chgdat", chgdat);
        //        cmd.Parameters.AddWithValue("@verext", ((string)row[26]).Trim());
        //        cmd.Parameters.AddWithValue("@verextdat", verextdat);
        //        cmd.Parameters.AddWithValue("@users_id", null);
        //        cmd.Parameters.AddWithValue("@users_name", ((string)row[24]).Trim());
        //        cmd.Parameters.AddWithValue("@dealer_id", null);
        //        cmd.Parameters.AddWithValue("@dealer_dealer", ((string)row[17]).Trim());

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.KeepLog("\t" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + "\t" + ((string)row[0]).Trim() + "\n\t\t" + ex.Message + Environment.NewLine);
        //        return;
        //    }
        //}

        private void RecSerial(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    //string purdat = (row[14] is DBNull ? null : ((DateTime)row[14]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
                    //string expdat = (row[15] is DBNull ? null : ((DateTime)row[15]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
                    //string manual = (row[20] is DBNull ? null : ((DateTime)row[20]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
                    //string chgdat = (row[25] is DBNull ? null : ((DateTime)row[25]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
                    //string verextdat = (row[27] is DBNull ? null : ((DateTime)row[27]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));

                    /*******************************/
                    var area_obj = this.area_list.Where(a => a.typdes_th.Trim() == ((string)row["area"]).Trim()).FirstOrDefault();
                    int? area = row["area"] is DBNull || area_obj == null ? null : (int?)area_obj.id;

                    var busityp_obj = this.busityp_list.Where(b => b.typcod.Trim() == ((string)row["busityp"]).Trim()).FirstOrDefault();
                    int? busityp = row["busityp"] is DBNull || busityp_obj == null ? null : (int?)busityp_obj.id;

                    var howknown_obj = this.howknown_list.Where(h => h.typcod.Trim() == ((string)row["howknown"]).Trim()).FirstOrDefault();
                    int? howknown = row["howknown"] is DBNull || howknown_obj == null ? null : (int?)howknown_obj.id;

                    var verext_obj = this.verext_list.Where(v => v.typdes_th.Trim() == ((string)row["verext"]).Trim()).FirstOrDefault();
                    int? verext = row["verext"] is DBNull || verext_obj == null ? null : (int?)verext_obj.id;


                    var dealer_obj = this.dealer_id_list.Where(d => d.dealercode.Trim() == ((string)row["dealer"]).Trim()).FirstOrDefault();
                    int? dealer_id = row["dealer"] is DBNull || dealer_obj == null ? null : (int?)dealer_obj.id;

                    serial serial = new serial
                    {
                        sernum = ((string)row[0]).Trim(),
                        oldnum = ((string)row[1]).Trim(),
                        version = ((string)row[2]).Trim(),
                        contact = ((string)row[3]).Trim(),
                        position = ((string)row[4]).Trim(),
                        prenam = ((string)row[5]).Trim(),
                        compnam = ((string)row[6]).Trim(),
                        addr01 = ((string)row[7]).Trim(),
                        addr02 = ((string)row[8]).Trim(),
                        addr03 = ((string)row[9]).Trim(),
                        zipcod = ((string)row[10]).Trim(),
                        telnum = ((string)row[11]).Trim(),
                        busides = ((string)row[13]).Trim(),
                        purdat = row[14] is DBNull ? null : (DateTime?)(DateTime)row[14],
                        expdat = row[15] is DBNull ? null : (DateTime?)(DateTime)row[15],
                        branch = ((string)row[19]).Trim(),
                        manual = row[20] is DBNull ? null : (DateTime?)(DateTime)row[20],
                        upfree = ((string)row[21]).Trim(),
                        refnum = ((string)row[22]).Trim(),
                        remark = ((string)row[23]).Trim(),
                        verextdat = row[27] is DBNull ? null : (DateTime?)(DateTime)row[27],
                        recby = this.admin_id,

                        area = area,
                        busityp = busityp,
                        howknown = howknown,
                        verext = verext,
                        dealer_id = dealer_id
                    };

                    db.serial.Add(serial);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecProblem(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    //string date = (row[3] is DBNull ? null : ((DateTime)row[3]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));

                    //string sql_insert = "Insert into problem (serial_sernum, probcod, probdesc, date, time, name, users_name) ";
                    //sql_insert += " Values(@serial_sernum, @probcod, @probdesc, @date, @time, @name, @users_name)";

                    //MySqlCommand cmd = new MySqlCommand(sql_insert, this.main_form.conn);

                    //cmd.Parameters.AddWithValue("@serial_sernum", ((string)row[0]).Trim());
                    //cmd.Parameters.AddWithValue("@probcod", ((string)row[1]).Trim());
                    //cmd.Parameters.AddWithValue("@probdesc", ((string)row[2]).Trim());
                    //cmd.Parameters.AddWithValue("@date", date);
                    //cmd.Parameters.AddWithValue("@time", ((string)row[4]).Trim());
                    //cmd.Parameters.AddWithValue("@name", ((string)row[5]).Trim());
                    //cmd.Parameters.AddWithValue("@users_name", ((string)row[6]).Trim());

                    //cmd.ExecuteNonQuery();
                    
                    var serial = this.serial_id_list.Where(d => d.sernum == ((string)row[0]).Trim()).FirstOrDefault();
                    if (serial == null)
                    {
                        this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\tSerial number not found.");
                        return;
                    }

                    var probcod = this.probcod_list.Where(p => p.typcod.Trim() == ((string)row[1]).Trim()).FirstOrDefault();
                    if(probcod == null)
                    {
                        //this.KeepLog("\t" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + "\t" + ((string)row[0]).Trim() + "\n\t\tProblem_Code not found." + Environment.NewLine);
                        //return;
                        probcod = this.probcod_list.Where(p => p.typcod.Trim() == "--").First();
                    }

                    problem problem = new problem
                    {
                        probcod = probcod.id,
                        probdesc = ((string)row[2]).Trim(),
                        date = row[3] is DBNull ? null : (DateTime?)(DateTime)row[3],
                        name = ((string)row[5]).Trim(),
                        serial_id = serial.id,
                        recby = this.admin_id
                    };

                    db.problem.Add(problem);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecDealer(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    //string chgdat = (row[14] is DBNull ? null : ((DateTime)row[14]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));

                    dealer dealer = new dealer
                    {
                        dealercode = ((string)row[0]).Trim(),
                        prenam = ((string)row[1]).Trim(),
                        compnam = ((string)row[2]).Trim(),
                        addr01 = ((string)row[3]).Trim(),
                        addr02 = ((string)row[4]).Trim(),
                        addr03 = ((string)row[5]).Trim(),
                        zipcod = ((string)row[6]).Trim(),
                        telnum = ((string)row[7]).Trim(),
                        contact = ((string)row[8]).Trim(),
                        position = ((string)row[9]).Trim(),
                        busides = ((string)row[10]).Trim(),
                        area = ((string)row[11]).Trim(),
                        remark = ((string)row[12]).Trim(),
                        recby = this.admin_id
                    };
                    db.dealer.Add(dealer);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecDmsg(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    string date = (row[2] is DBNull ? null : ((DateTime)row[2]).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));

                    //string sql_insert = "Insert into d_msg (dealer, description, date, time, name) ";
                    //sql_insert += " Values(@dealer, @description, @date, @time, @name)";

                    //MySqlCommand cmd = new MySqlCommand(sql_insert, this.main_form.conn);

                    //cmd.Parameters.AddWithValue("@dealer", ((string)row[0]).Trim());
                    //cmd.Parameters.AddWithValue("@description", ((string)row[1]).Trim());
                    //cmd.Parameters.AddWithValue("@date", date);
                    //cmd.Parameters.AddWithValue("@time", ((string)row[3]).Trim());
                    //cmd.Parameters.AddWithValue("@name", ((string)row[4]).Trim());

                    //cmd.ExecuteNonQuery();
                    var dealer = this.dealer_id_list.Where(d => d.dealercode == ((string)row[0]).Trim()).FirstOrDefault();
                    if(dealer == null)
                    {
                        this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\tDealer_Code not found.");
                        return;
                    }

                    d_msg d_msg = new d_msg
                    {
                        dealer_id = dealer.id,
                        description = ((string)row[1]).Trim(),
                        date = row[2] is DBNull ? null : (DateTime?)(DateTime)row[2],
                        name = ((string)row[4]).Trim(),
                        recby = this.admin_id
                    };

                    db.d_msg.Add(d_msg);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecIstab(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    //string sql_insert = "Insert into istab (tabtyp, typcod, abbreviate_en, abbreviate_th, typdes_en, typdes_th) ";
                    //sql_insert += " Values(@tabtyp, @typcod, @abbreviate_en, @abbreviate_th, @typdes_en, @typdes_th)";

                    //MySqlCommand cmd = new MySqlCommand(sql_insert, this.main_form.conn);

                    //cmd.Parameters.AddWithValue("@tabtyp", ((string)row[0]).Trim());
                    //cmd.Parameters.AddWithValue("@typcod", ((string)row[1]).Trim());
                    //cmd.Parameters.AddWithValue("@abbreviate_en", ((string)row[3]).Trim());
                    //cmd.Parameters.AddWithValue("@abbreviate_th", ((string)row[2]).Trim());
                    //cmd.Parameters.AddWithValue("@typdes_en", ((string)row[5]).Trim());
                    //cmd.Parameters.AddWithValue("@typdes_th", ((string)row[4]).Trim());

                    //cmd.ExecuteNonQuery();

                    istab istab = new istab
                    {
                        tabtyp = ((string)row[0]).Trim(),
                        typcod = ((string)row[1]).Trim(),
                        abbreviate_en = ((string)row[3]).Trim(),
                        abbreviate_th = ((string)row[2]).Trim(),
                        typdes_en = ((string)row[5]).Trim(),
                        typdes_th = ((string)row[4]).Trim(),
                        recby = this.admin_id
                    };
                    db.istab.Add(istab);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row[0]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecIstabArea(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    string typcod = (db.istab.Where(i => i.tabtyp == TABTYP_AREA).Count() + 1).FillLeadingZero(4);

                    istab istab = new istab
                    {
                        tabtyp = TABTYP_AREA,
                        typcod = typcod,
                        abbreviate_en = "",
                        abbreviate_th = "",
                        typdes_en = "",
                        typdes_th = ((string)row["area"]).Trim(),
                        recby = this.admin_id
                    };
                    db.istab.Add(istab);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row["area"]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecIstabVerext(DataRow row)
        {
            using (snEntities db = new snEntities())
            {
                try
                {
                    string typcod = (db.istab.Where(i => i.tabtyp == TABTYP_VEREXT).Count() + 1).FillLeadingZero(4);

                    istab istab = new istab
                    {
                        tabtyp = TABTYP_VEREXT,
                        typcod = typcod,
                        abbreviate_en = "",
                        abbreviate_th = "",
                        typdes_en = "",
                        typdes_th = ((string)row["verext"]).Trim(),
                        recby = this.admin_id
                    };
                    db.istab.Add(istab);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    this.KeepErrorLog(((string)row["verext"]).Trim() + "\n\t\t" + ex.Message);
                    return;
                }
            }
        }

        private void RecCustomerSN(DataRow row)
        {

        }

        private void KeepErrorLog(string err_message)
        {
            this.KeepLog((++this.error_record_count).ToString() + "\t record # " + this.last_converted_record.ToString() + "\t" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + "\t" + err_message + Environment.NewLine);
        }

        private void KeepLog(string message)
        {
            using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "ConvertLog.txt", FileMode.Append, FileAccess.Write))
            {
                byte[] data = new UTF8Encoding(true).GetBytes(message);
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
        }
        
        private void KeepConvertProgress(string file_name,int record_count)
        {
            using(FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + file_name, FileMode.Create, FileAccess.Write))
            {
                byte[] data = Encoding.UTF8.GetBytes(record_count.ToString());
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
        }
    }
}
