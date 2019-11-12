using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private bool validateData(TextBox textbox)
        {
            return
                isDecimal(textbox);

        }

        private bool isDecimal(TextBox userString)
        {
            decimal number = 0;
            if (decimal.TryParse(userString.Text, out number))
            {
                lblMessage.Text = "Decimals are not allow in the entries";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnDoModulus_Click(object sender, EventArgs e)
        {
            lblMessage.Text = modulus(int.Parse(txtOp1.Text), int.Parse(txtOp2.Text));
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
    }
}
