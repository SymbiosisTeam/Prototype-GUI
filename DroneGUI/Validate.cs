using System.Windows.Forms;

namespace DroneGUI
{
    class Validate
    {
        /// <summary>
        /// Check a string input can be converted to a float value, returning a TRUE if the value is a float
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckFloat(string input)
        {
            bool isFloat = false;
            float number = 0.0f;

            isFloat = float.TryParse(input, out number);

            return isFloat;
        }

        /// <summary>
        /// Checks string input is not a negative number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckNegative(string input)
        {
            bool isNegative = false;

            if (input.StartsWith("-"))
            {
                isNegative = true;
            }

            return isNegative;
        }

        /// <summary>
        /// Check a string input meets all validation criteria
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ErrorCodes CheckValue(string input)
        {
            bool valueOK = true;
            ErrorCodes errorCode = ErrorCodes.NO_ERROR;

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                valueOK = false;
                errorCode = ErrorCodes.BLANK;
                MessageBox.Show("Missing data in field", "USER INPUT ERROR");
            }

            if (valueOK)
            {
                if (input.Contains(" "))
                {
                    valueOK = false;
                    errorCode = ErrorCodes.NON_FLOAT;
                    MessageBox.Show(string.Format("\'{0}\' contains a whitespace - please enter a valid number", input), "USER INPUT ERROR");
                }
            }
            if (valueOK)
            {
                if (!CheckFloat(input))
                {
                    valueOK = false;
                    errorCode = ErrorCodes.NON_FLOAT;
                    MessageBox.Show(string.Format("\'{0}\' is not an acceptable value - please enter a valid number", input), "USER INPUT ERROR");
                }
            }

            if (valueOK)
            {
                if (CheckNegative(input))
                {
                    valueOK = false;
                    errorCode = ErrorCodes.NEGATIVE;
                    MessageBox.Show(string.Format("\'{0}' cannot be a negative number - please enter a positive number", input), "USER INPUT ERROR");
                }
            }

            return errorCode;
        }
    }
}
