using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Kevin Tran
 * ITD 1253
 * Fall 2019
 */

namespace Section2LabExam
{
    public partial class frmExam2 : Form
    {
        public frmExam2()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "This message box has been cleared";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime closeTime = DateTime.Now.AddSeconds(4);

            while(currentTime < closeTime)
            {
                lblMessage.Text = "Thank you for using this program, it will now close shortly";
                lblMessage.Update();
                currentTime = DateTime.Now;
                if (currentTime > closeTime)
                {
                    this.Close();
                }
            }
        }

        private void frmExam2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void btnShowModulus_Click(object sender, EventArgs e)
        {
            btnDoFibonacci.Enabled = false;
            btnDoFactorial.Enabled = false;
            btnDoModulus.Enabled = true;
            txtOp2.Enabled = true;

            lblMessage.Text = "Enter a value in text box 1 and value in text box 2 to find the modulus of the value in text box 1";
        }

        private void btnShowFactorial_Click(object sender, EventArgs e)
        {
            btnDoFibonacci.Enabled = false;
            btnDoFactorial.Enabled = true;
            btnDoModulus.Enabled = false;
            txtOp2.Enabled = false;
            lblMessage.Text = "Enter a value in text 1 box to find its factorial value";
        }

        private void btnShowFibonacci_Click(object sender, EventArgs e)
        {
            btnDoFactorial.Enabled = false;
            btnDoFibonacci.Enabled = true;
            btnDoModulus.Enabled = false;
            txtOp2.Enabled = false;
            lblMessage.Text = "Enter a value in text box 1 to find its Fibonacci value";
        }

        public bool validateData(TextBox textBox)
        {
            return
                isBlank(textBox) &&
                isDecimal(textBox) &&
                isInt32(textBox);
        }

        public bool validateData(TextBox textBox, int max)
        {
            return
                isBlank(textBox) &&
                isDecimal(textBox) &&
                isInt32(textBox)&&
                inRange(textBox, max);
        }

        private bool isDecimal(TextBox textbox)
        {
            string userString = textbox.Text;
            char[] split = userString.ToCharArray();

            for (int i = 0; i < split.Length; i++)
            {
                if(split[i] == '.')
                {
                    lblMessage.Text = "Decimal values are not allowed";
                    return false;
                }
            }
            return true;
        }

        public bool isBlank(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                lblMessage.Text = "Number entry box is empty, please input a value";
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isInt32(TextBox textBox)
        {
            string s = textBox.Text;
            int number = 0;
            if (int.TryParse(s, out number))
            {
                return true;
            }
            else
            {
                lblMessage.Text = "Please enter a numeric value";
                return false;
            }
        }

        public bool inRange(TextBox textBox, int max)
        {
            int number = Convert.ToInt32(textBox.Text);
            if (number > max)
            {
                lblMessage.Text = "A value greater than " + Convert.ToString(max) + " is too high to calculate";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnDoModulus_Click(object sender, EventArgs e)
        {
            try
            {   if (validateData(txtOp1))
                {
                    lblMessage.Text = modulus(int.Parse(txtOp1.Text), int.Parse(txtOp2.Text));
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message + ex.GetType().ToString();
            }
        }

        private string modulus(int op1, int op2)
        {
            string modulusString = "";
            int originalOp1 = op1;
            int counter = 0;
            int remainder = 0;
            while(op1 > op2)
            {
                op1 = op1 - op2;
                remainder = op1;
                counter++;
            }
            modulusString = Convert.ToString(originalOp1) + " divided by " + Convert.ToString(op2) + " is " + Convert.ToString(counter) + " with a remainder of " + Convert.ToString(remainder);
            return modulusString;
        }

        private void btnDoFactorial_Click(object sender, EventArgs e)
        {
            try
            {
                if(validateData(txtOp1, 20))
                {
                    lblMessage.Text = factorial(int.Parse(txtOp1.Text));
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + ex.GetType().ToString();
            }
        }

        private string factorial(int op1)
        {
            string factString = "";
            int result = 1;
            for(int i = 1; i <= op1; i++)
            {
                result = result * i;
            }
            factString = "The answer of " + Convert.ToString(op1) + "!" + " is " + Convert.ToString(result);
            return factString;
        }

        private void btnDoFibonacci_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateData(txtOp1, 128))
                {
                    lblMessage.Text = fibonacci(int.Parse(txtOp1.Text));
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + ex.GetType().ToString();
            }
        }

        private string fibonacci(int op1)
        {
            string fibString = "";
            int result = 1;
            int holder1 = 0;
            int holder2 = 0;
            if(op1 == 0)
            {
                result = 0;
                fibString = "Fibonacci(" + Convert.ToString(result) + ") = 0";
            }
            if(op1 == 1)
            {
                result = 1;
                fibString = "Fibonacci(" + Convert.ToString(result) + ") = 1" ;
            }
            else
            {
                for(int i = 2; i <= op1; i++)
                {
                    holder2 = holder1 + result;
                    holder1 = result;
                    result = holder2;
                }
                fibString = "Fibonacci(" + Convert.ToString(op1) + ") = " + "Fibonacci(" + Convert.ToString(op1 - 1) + ") + " + "Fibonacci(" + Convert.ToString(op1 - 2) + ") = "  + Convert.ToString(result);
            }

            return fibString;
        }
    }
}
