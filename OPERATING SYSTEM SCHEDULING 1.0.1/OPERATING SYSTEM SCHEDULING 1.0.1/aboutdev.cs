using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPERATING_SYSTEM_SCHEDULING_1._0._1
{
    public partial class aboutdev : Form
    {
        public aboutdev()
        {
            InitializeComponent();
        }

        private void aboutdev_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
