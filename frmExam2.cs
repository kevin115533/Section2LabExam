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
    }
}
