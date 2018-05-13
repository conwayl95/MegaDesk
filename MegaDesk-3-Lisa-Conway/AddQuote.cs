using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_Lisa_Conway
{
    public partial class AddQuote : Form
    {


        public AddQuote()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtWidth, "");
            errorProvider1.SetError(txtDepth, "");
            MainMenu mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
            Close();
        }

        private void txtWidth_Validating(object sender, CancelEventArgs e)
        {
            string numberError;
            

            if (!ValidWidth(txtWidth.Text, out numberError))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtWidth.Select(0, txtWidth.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txtWidth, numberError);
            }

            //int txtWidth;
            //bool isNumberic = int.TryParse(errorMsg, out txtWidth);
            //return txtWidth;
        }

        private bool ValidWidth(string text, out string errorMsg)
        {
            string numberError = "Not a valid entry, please enter a number";
            string rangeError = "Number is out of range";
            int myInt;
            errorMsg = "";
            bool valid = false;
            // throw new NotImplementedException();
            bool validInteger = int.TryParse(text, out myInt);

            if (validInteger)
            {
                if (myInt >=24 && myInt<=96)
                {
                    valid = true;
                    
                }
                else
                {
                    errorMsg = rangeError;
                }
                
            }
            else
            {
                errorMsg = numberError;
            }

            
            return valid;
        }

       
       

        private void txtWidth_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtWidth, "");
        }



        private void txtDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar)))
            {
                errorProvider1.SetError(txtDepth, "invalid character");
            }
            else
            {

                errorProvider1.SetError(txtDepth, "");
            }
        }

        private void txtDepth_Validating(object sender, CancelEventArgs e)
        {
            int myInt = 0;
            bool validInteger = int.TryParse(txtDepth.Text, out myInt);
           
            if (  myInt >=12 &&  myInt<=48)
            {
                errorProvider1.SetError(txtDepth, "");
            }
           
            else {
                e.Cancel = true;
                txtWidth.Select(0, txtWidth.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                
                errorProvider1.SetError(txtDepth, "Input out of range");
            }


        }

        private void txtDepth_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtWidth, "");
        }
    }
}
