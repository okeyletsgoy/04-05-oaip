using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            nameBox.Validating += nameBox_Validating;
            ageBox.Validating += ageBox_Validating;

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }



        private void nameBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nameBox.Text))
            {
                errorProvider1.SetError(nameBox, "Не указано имя!");
            }
            else if (nameBox.Text.Length < 4)
            {
                errorProvider1.SetError(nameBox, "Слишком короткое имя!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void ageBox_Validating(object sender, CancelEventArgs e)
        {
            int age = 0;
            if (String.IsNullOrEmpty(ageBox.Text))
            {
                errorProvider1.SetError(ageBox, "Не указан возраст!");
            }
            else if (!Int32.TryParse(ageBox.Text, out age))
            {
                errorProvider1.SetError(ageBox, "Некорретный возраст!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Бла-Бла-Бла",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }
    }
}
