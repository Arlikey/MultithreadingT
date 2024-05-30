using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultithreadingT
{
    public partial class AdditionalTask1 : Form
    {
        public AdditionalTask1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
                Task.Run(() => CalculateFactorial(Convert.ToInt32(numericUpDown1.Value)));
        }

        private void CalculateFactorial(int number)
        {
            long result = Factorial(number);
            this.Invoke(new Action(() => resultLabel.Text = result.ToString()));
        }

        private long Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}
