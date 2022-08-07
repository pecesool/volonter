using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace volonter
{
    public partial class dobavlenie : Form
    {
        public dobavlenie()
        {
            InitializeComponent();
        }

        private void dobavlenie_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "volDataSet1.help". При необходимости она может быть перемещена или удалена.
            this.helpTableAdapter.Fill(this.volDataSet1.help);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }//загрузка изображение из файлов
        }

        private void button3_Click(object sender, EventArgs e)
        {
            helpTableAdapter.Adapter.Update(volDataSet1.help);
            volDataSet1.Tables[0].AcceptChanges();
            dataGridView1.Refresh();
            menu s = new menu();
            s.Show();
            this.Hide();//сохранение и переход на другую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res;
            

            if (comboBox2.Text == "есть") { res = true; } else { res = false; }
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                DataRow nRow = volDataSet1.Tables[0].NewRow();
                int rc = dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = textBox1.Text;
                nRow[2] = textBox2.Text;
                nRow[3] = textBox3.Text;
                nRow[4] = Convert.ToInt32(textBox4.Text);
                nRow[5] = res;
                nRow[6] = img;
                nRow[7] = textBox5.Text;
                volDataSet1.Tables[0].Rows.Add(nRow);

                helpTableAdapter.Adapter.Update(volDataSet1.help);
                volDataSet1.Tables[0].AcceptChanges();
                dataGridView1.Refresh();//сохранение записи
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
