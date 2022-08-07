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
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*') { textBox2.PasswordChar = '\0'; } else { textBox2.PasswordChar = '*'; }//скрытие пароля и его отображение
        }


        private void authorization_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "volDataSet.авторизация". При необходимости она может быть перемещена или удалена.
            this.авторизацияTableAdapter.Fill(this.volDataSet.авторизация);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registr form3 = new registr();
            form3.Owner = this;
            form3.Show();//регистрация
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool res = false;
            for (int b = 0; b < dataGridView1.Rows.Count - 1; b++)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Поле заполнено неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;//вывод об ошибке
                }
                else
                {
                    if (dataGridView1.Rows[b].Cells[1].Value.ToString() == textBox2.Text && dataGridView1.Rows[b].Cells[2].Value.ToString() == textBox1.Text)
                    {
                        MessageBox.Show("Добро пожаловать!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        menu s = new menu();
                        s.Show();
                        this.Hide();
                        res = false;
                        break;//проверка на наличие данных в БД и переход на другую форму
                    }
                    else { res = true; }
                }
            }
            if (res == true)
            {
                MessageBox.Show("Данного пользователя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //вывод об ошибке
            }
        }
    }
}
