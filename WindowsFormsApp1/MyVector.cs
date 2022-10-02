using System;


namespace WindowsFormsApp1
{
    class MyVector
    {
        double[] vector = new double[2];

        public MyVector(){}

        public MyVector(double[] vector)
        {
            this.vector[0] = vector[0];
            this.vector[1] = vector[1];
        }

        public void print(System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = $"{this.vector[0]}, {this.vector[1]}";
        }

        public static MyVector operator +(MyVector vector1, MyVector vector2)
        {
            MyVector result = new MyVector();
            try
            {
                result.vector[0] = vector1.vector[0] + vector2.vector[0];
                result.vector[1] = vector1.vector[1] + vector2.vector[1];
            }
            catch(OverflowException e)
            {
                throw new Exception("Переполнение");
            }

            return result;
        }

        public static MyVector operator -(MyVector vector1, MyVector vector2)
        {
            MyVector result = new MyVector();
            try
            {
                result.vector[0] = vector1.vector[0] - vector2.vector[0];
                result.vector[1] = vector1.vector[1] - vector2.vector[1];
            }
            catch(OverflowException e)
            {
                throw new Exception("Переполнение");
            }
            
            return result;
        }

        public static MyVector operator *(MyVector vector1, double scalar)
        {
            MyVector result = new MyVector();
            try
            {
                result.vector[0] = vector1.vector[0] * scalar;
                result.vector[1] = vector1.vector[1] * scalar;
            }
            catch(OverflowException e)
            {
                throw new Exception("Переполнение");
            }
            return result;
        }

        public static bool operator ==(MyVector vector1, MyVector vector2)
        {
            return vector1.vector[0] == vector2.vector[0] && vector1.vector[1] == vector2.vector[1];
        }

        public static bool operator !=(MyVector vector1, MyVector vector2)
        {
            return vector1.vector[0] != vector2.vector[0] && vector1.vector[1] != vector2.vector[1];
        }
    }
}