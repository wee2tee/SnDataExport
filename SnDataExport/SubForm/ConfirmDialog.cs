using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnDataExport.SubForm
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog()
        {
            InitializeComponent();
        }

        public ConfirmDialog(int progress_count)
            : this()
        {
            this.btnRetry.Text = this.btnRetry.Text + " " + progress_count.ToString();
        }
    }
}
