using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spor_merkezi_uygulamasi
{
    public partial class ekipmanlar : Form
    {
        public ekipmanlar()
        {
            InitializeComponent();
        }

        private void ekipmanlarBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ekipmanlarBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.spormerkeziDataSon);

        }

        private void ekipmanlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'spormerkeziDataSon.ekipmanlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ekipmanlarTableAdapter.Fill(this.spormerkeziDataSon.ekipmanlar);

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.ekipmanlarTableAdapter.Fill(this.spormerkeziDataSon.ekipmanlar);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ekipmanlarBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.spormerkeziDataSon);
        }
    }
}
