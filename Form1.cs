using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysOfObjectsNet
{
    public partial class MainForm : Form
    {
        Points points;
        public MainForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Point point = new Point(nameTextBox.Text, Int32.Parse(X1TextBox.Text), Int32.Parse(Y1TextBox.Text));
            if (points.addPoint(point))
                richTextBox1.Text += point.ToString() + Environment.NewLine;

            this.Text = points.getPointsNumber().ToString();
        }

        private void InitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                points = new Points(Int32.Parse(poitsNumberTextBox.Text));
                points.init();
                Form.ActiveForm.Text = points.getPointsNumber().ToString();
                nameTextBox.Enabled = true;
                X1TextBox.Enabled = true;
                Y1TextBox.Enabled = true;
                SaveBtn.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(points.ToString());
            richTextBox1.Text = points.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = points.findNearestToZero();
            MessageBox.Show(k + "\t" + points.GetPointAt(k).ToString());
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        
    }
}
