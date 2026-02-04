using System;
using System.Windows.Forms;

namespace ValToCSV
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
        }
    }
}
