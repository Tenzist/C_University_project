using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 2; i <= 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
            InitTable(2, 2);
        }

        void InitTable(int n, int m)
        {
            dataGridView1.Columns.Clear();

            for (int j = 1; j <= m; j++)
            {
                dataGridView1.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { HeaderText = j + "" });
            }

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());

                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                }
            }

        }


        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "2";
            comboBox2.Text = "2";
            InitTable(2 , 2);
            
            checkBox1.Checked = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void считатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створюємо масив з чисел, увадених у таблиці:
            int n = dataGridView1.RowCount;
            int m = dataGridView1.ColumnCount;
            int[,] a = new int[n, m];
            try
            {
                // Здійснюємо копіювання з таблиці в масив:
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        a[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value + "");

                int sum = 0;
                for (int i = 0, trace; i < a.GetLength(0); i++)
                {
                    trace = 1;
                    for (int j = 0; j < a.GetLength(1); j++)
                        trace *= a[i, j];
                    sum += trace;
                }

                // Виводимо результат:
                if (checkBox1.Checked)
                    MessageBox.Show("Результат: " + sum, "Результат");
                else
                    textBox1.Text = sum + "";
            }
            catch (Exception)
            {
                MessageBox.Show("Перевірте дані!", "Помилка");
            }
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("КН-421с\n\nПахомов Олег", "Про програму");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(comboBox1.Text);
            int m = int.Parse(comboBox2.Text);
            InitTable(n, m);
        }


    }
}
