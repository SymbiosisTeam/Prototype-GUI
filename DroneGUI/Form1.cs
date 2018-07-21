using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a Python Proecss object to run the Python flight code
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        private void RunFlightApplication(string x, string y, string z)
        {
            PythonProcess runFlight = new PythonProcess(x, y, z);
        }

        /// <summary>
        /// Validates co-ordinate values and runs application if ok, else generates an error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRunFlight_Click(object sender, EventArgs e)
        {
            // Variables
            string X = textBoxX.Text;
            string Y = textBoxY.Text;
            string Z = textBoxZ.Text;
            bool valuePassed_X = true;
            bool valuePassed_Y = true;
            bool valuePassed_Z = true;

            // Check values and run application
            valuePassed_X = CheckTextBox(textBoxX, X);
            valuePassed_Y = CheckTextBox(textBoxY, Y);
            valuePassed_Z = CheckTextBox(textBoxZ, Z);

            if (valuePassed_X && valuePassed_Y && valuePassed_Z)
            {
                RunFlightApplication(X, Y, Z);
            }
        }
        
        // Text Box Control
        #region
        /// <summary>
        /// Check value in text box and change text / box colour according to error, returning a boolean
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckTextBox(TextBox textbox, string value)
        {
            bool valuesPassed = true;

            // Validate Co-ordinates
            Validate validate = new Validate();

            // Check Value
            ErrorCodes errorCode = validate.CheckValue(value);
            if (errorCode == ErrorCodes.BLANK)
            {
                textbox.BackColor = Color.Red;
                valuesPassed = false;
            }
            if (errorCode == ErrorCodes.NEGATIVE || errorCode == ErrorCodes.NON_FLOAT)
            {
                textbox.ForeColor = Color.Red;
                valuesPassed = false;
            }
            
            return valuesPassed;
        }

        // Reset Text Box value colour to black
        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            textBoxX.ForeColor = Color.Black;
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            textBoxY.ForeColor = Color.Black;
        }

        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            textBoxZ.ForeColor = Color.Black;
        }

        // Clear Text Box if clicked with value in field
        private void textBoxX_Click(object sender, EventArgs e)
        {
            if (textBoxX.BackColor == Color.Red)
            {
                textBoxX.BackColor = Color.White;
            }

            if (textBoxX.Text != "")
            {
                textBoxX.Clear();
            }
        }

        private void textBoxY_Click(object sender, EventArgs e)
        {
            if (textBoxY.BackColor == Color.Red)
            {
                textBoxY.BackColor = Color.White;
            }

            if (textBoxY.Text != "")
            {
                textBoxY.Clear();
            }
        }

        private void textBoxZ_Click(object sender, EventArgs e)
        {
            if (textBoxZ.BackColor == Color.Red)
            {
                textBoxZ.BackColor = Color.White;
            }

            if (textBoxZ.Text != "")
            {
                textBoxZ.Clear();
            }
        }

        // Event: Clear Values
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxX.Clear();
            textBoxY.Clear();
            textBoxZ.Clear();
        }

        // Event: Exit Application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
