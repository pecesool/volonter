using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace volonter
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "volDataSet1.help". При необходимости она может быть перемещена или удалена.
            this.helpTableAdapter.Fill(this.volDataSet1.help);
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[1].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            k++;
                            break;//поиск по базе данных
                        }
                    }
                }
            }
            label3.Text = "Найдено " + k.ToString() + " Совпадений";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            label3.Text = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dobavlenie s = new dobavlenie();
            s.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = 1;
            if (radioButton4.Checked == true) { x = 0; }
            if (radioButton3.Checked == true) { x = 1; }
            if (checkBox6.Checked == true) { if (x == 0) { helpBindingSource.Sort = "Имя ASC"; } else { helpBindingSource.Sort = "Имя DESC"; } }
            if (checkBox2.Checked == true) { if (x == 0) { helpBindingSource.Sort = "Фамилия ASC"; } else { helpBindingSource.Sort = "Фамилия DESC"; } }
            if (checkBox5.Checked == true) { if (x == 0) { helpBindingSource.Sort = "Отчество ASC"; } else { helpBindingSource.Sort = "Отчество DESC"; } }
            if (checkBox1.Checked == true) { if (x == 0) { helpBindingSource.Sort = "Возраст ASC"; } else { helpBindingSource.Sort = "Возраст DESC"; } }
            if (checkBox3.Checked == true) { if (x == 0) { helpBindingSource.Sort = "Трудоустроенность ASC"; } else { helpBindingSource.Sort = "Трудоустроенность DESC"; } }
            //сортировка по нескольким полям
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox6.Checked = false;
            checkBox5.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool res;
            if (comboBox2.Text == "есть") { res = true; } else { res = false; }
            int k = 0;
            string poisk = "";
            if (textBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Имя] LIKE'%" + textBox1.Text + "%'";
            }
            if (textBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Фамилия] LIKE'%" + textBox2.Text + "%'";
            }
            if (textBox3.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Возраст]=" + Convert.ToInt32(textBox3.Text);
            }

            if (comboBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                if (res == true)
                {
                    poisk += helpBindingSource.Filter = "[Трудоустроенность] = 1";
                }
                else { poisk += helpBindingSource.Filter = "[Трудоустроенность] = 0"; }
            }
            if (k >= 1)
            {
                helpBindingSource.Filter = poisk;//фильрация по нескольким полям

            }
            else
            {
                if (k == 0)
                {
                    helpBindingSource.Filter = "";//сброс фильтрации
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helpBindingSource.Filter = null;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";//сброс фильра
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (checkBox4.Checked == true) { res =res+ 200 * Convert.ToInt32(comboBox3.Text); }
            if (checkBox7.Checked == true) { res =res+ 500 * Convert.ToInt32(comboBox1.Text); }
            if (checkBox8.Checked == true) { res = res+5000 * Convert.ToInt32(comboBox4.Text); }
            if (checkBox9.Checked == true) { res = res + 200 * Convert.ToInt32(comboBox5.Text); }
            richTextBox1.Text = "Итоговая цена: " + res.ToString();
        }
    }
}
