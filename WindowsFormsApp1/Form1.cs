using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void validationData(TextBox[] data)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                try
                {
                    if (data[i].Text.Length == 0 && data[i].Enabled)
                    {
                        throw new Exception("Введите данные");
                    }
                    else if (!double.TryParse(data[i].Text, out double number) && data[i].Enabled)
                    {
                        throw new Exception("Некорретные данные");
                    }
                } catch(OverflowException error)
                {
                    MessageBox.Show("Переполнение");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validationData(new TextBox[] { textBox1, textBox2, textBox3, textBox4 });
                string currentOperation = operationList.SelectedItem.ToString();
                MyVector result = new MyVector();
               
                if (currentOperation == "+")
                {
                    MyVector vector1 = new MyVector(new double[2] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) });
                    MyVector vector2 = new MyVector(new double[2] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) });
                    result = vector1 + vector2;
                    result.print(answerField);
                }
                else if (currentOperation == "-")
                {
                    MyVector vector1 = new MyVector(new double[2] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) });
                    MyVector vector2 = new MyVector(new double[2] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) });
                    result = vector1 - vector2;
                    result.print(answerField);
                }
                else if (currentOperation == "*")
                {
                    MyVector vector1 = new MyVector(new double[2] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) });
                    result = vector1 * double.Parse(textBox3.Text);
                    result.print(answerField);
                }
                else if (currentOperation == "==")
                {
                    MyVector vector1 = new MyVector(new double[2] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) });
                    MyVector vector2 = new MyVector(new double[2] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) });
                    bool isEqual = vector1 == vector2;
                    answerField.Text = isEqual.ToString();
                }
                else if (currentOperation == "!=")
                {
                    MyVector vector1 = new MyVector(new double[2] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) });
                    MyVector vector2 = new MyVector(new double[2] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) });
                    bool isEqual = vector1 != vector2;
                    answerField.Text = isEqual.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            operationList.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentOperation = operationList.SelectedItem.ToString();
            if (currentOperation == "*")
            {
                textBox4.Text = "";
                textBox4.Enabled = false;
            }
            else
            {
                textBox4.Enabled = true;
            }
        }
    }
}
