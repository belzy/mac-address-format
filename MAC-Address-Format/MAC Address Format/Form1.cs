// Application Name: MAC Address Format Tool
// Author: Brandon G. Elzy
// Date Created: April 11, 2017
// Date Last Modified: April 29, 2017
// Purpose: This application allows a user to enter a 48 bit MAC address string in a number of different formats.
//          When the format button is activated, the string is converted into all available MAC Address formats and
//          displayed in a text box. The user may copy any of the text from the textbox, but cannot edit the text.

// UPDATES:
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *  - Version 1.1
 *  - April 23, 2017
 *  - Added feature where user can enter any of the MAC Address formats as input.
 *  - Optimized runtime by refactoring the input validation and formatting processes.
 *    
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  - Version 1.2
 *  - April 29, 2017
 *  - Fixed a bug where if user enters a MAC address with white space, the invalid mac address error would be displayed.
 *  - Fixed a bug where if user enters the format (123456-789abc) then adds a character (123456789-abcd)
 *  - the application does not crash but displays the invalid mac address error message.
 */

// BUGS:
/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *
 * 
 *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAC_Address_Format
{
    public partial class frmMACAdressFormat : Form
    {
        // Declare variables.
        private static string emptyString = "";                             // An empty string for clearing form control text.
        private static string invalidMacAddress = "Invalid MAC Address";    // Invalid MAC address error message.

        // Declare functions.
        private static void DisplayFormattedMacAddresses(string[] macs, TextBox txt)
        {
            foreach(string m in macs)
            {
                 txt.Text += m + Environment.NewLine;
            }
        }   // Adds each element of an array to a text box with each on a new line.

        public frmMACAdressFormat()
        {
            InitializeComponent();
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            // Clear the form controls.
            txtMACFormatted.Text = emptyString;
            lblError.Text = emptyString;

            if (MAC.FormatAddress(txtMACInput.Text))
            {
                string[] macAddresses = MAC.getFormattedMacAddresses();
                DisplayFormattedMacAddresses(macAddresses, txtMACFormatted);
            }
            else
            {
                lblError.Text = invalidMacAddress;
            }
        }
    }

    // MAC Class.
    public class MAC
    {
        // ACCEPTED MAC ADDRESS FORMATS:
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         * 1) 123456789abc
         * 2) 123456-789abc
         * 3) 1234.5678.9abc
         * 4) 12.34.56.78.9a.bc
         * 5) 12-34-56-78-9a-bc
         * 6) 12:34:56:78:9a:bc
         *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         */

        // Declare variables.
        private static string[] formattedMacAddresses = new string[6];           // This array will contain the formatted MAC Addresses.
        private static char[] formatCharacters = new char[] { '.', '-', ':' };   // This array contains the acceptable format characters to be used in the validation and fomatting processes.
        private static int[] formatLengths = new int[] {12, 13, 14, 17 };        // This array contains all acceptable lengths of a mac address input string.
        private static double position = 0;                                      // Represents the position of the character in the string being tested against the format character.

        // Public class functions.
        public static bool FormatAddress(string mac)
        {   // This function takes a 48 bit MAC Address string as an argument.
            // It will check if the string matches one of the acceptable formats.
            // If the string matches one of the formats, it will convert it to the other formats and return true.
            // If the string doesn't match one of the formats, the function will return FALSE.

            // Remove white space from input string.
            string macAddress = RemoveWhiteSpace(mac);

            // If argument 'string mac' format is correct, convert it, format it, and assign it to the formattedMacAddresses array.
            if (ValidateMacAddress(macAddress))
            {
                string convertedMacAddress = ConvertMacAddress(macAddress);        // Converted MAC address to be used in Format functions.
                formattedMacAddresses[0] = FormatOne(convertedMacAddress);
                formattedMacAddresses[1] = FormatTwo(convertedMacAddress);
                formattedMacAddresses[2] = FormatThree(convertedMacAddress);
                formattedMacAddresses[3] = FormatFour(convertedMacAddress);
                formattedMacAddresses[4] = FormatFive(convertedMacAddress);
                formattedMacAddresses[5] = FormatSix(convertedMacAddress);

                return true;
            }
            // If MAC Address input format is not correct, return false.
            return false;
        }
        public static string[] getFormattedMacAddresses()
        {
            return formattedMacAddresses;
        }     // Returns the formattedMacAddresses array.

        // Private class functions.
        private static string RemoveWhiteSpace(string mac)
        {
            StringBuilder builder = new StringBuilder();
            foreach(char c in mac)
            {
                if (c == ' ')
                    continue;
                else
                    builder.Append(c);
            }
            return builder.ToString();
        }    // Removes white space from MAC address string.
        private static bool ValidateMacAddress(string mac)
        {   // This function takes a 48 bit MAC Address string as an argument.
            // It will check if the string matches one of the acceptable formats.
            // If the string matches one of the formats, the function will return TRUE.
            // If the string doesn't match one of the formats, the function will return FALSE.

            // Reset the position of the character being tested.
            position = 0;

            // Check first format.
            if (mac.Length == formatLengths[0])
            {
                foreach (char c in mac)
                {
                    foreach (char f in formatCharacters)
                    {
                        if (c == f)
                            return false;
                    }
                }
                return true;
            }

            // Check second format.
            else if (mac.Length == formatLengths[1])
            {
                foreach (char c in mac)
                {
                    if ((++position % 7) == 0)
                    {
                        if (c == formatCharacters[1])
                        {
                            if (position == 7)
                            {
                                position = 0;
                                return true;
                            }
                        }
                        else
                            break;
                    }
                }
            }

            // Check third format.
            else if (mac.Length == formatLengths[2])
            {
                foreach (char c in mac)
                {
                    if ((++position % 5) == 0)
                    {
                        if (c == formatCharacters[0])
                        {
                            if (position == 10)
                            {
                                position = 0;
                                return true;
                            }
                        }
                        else
                            break;
                    }
                }
            }
            else if (mac.Length == formatLengths[3])
            {
                // Check fourth format.
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[0])
                        {
                            if (position == 15)
                            {
                                position = 0;
                                return true;
                            }
                        }
                        else
                            break;
                    }
                }

                // Check fifth format.
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[1])
                        {
                            if (position == 15)
                            {
                                position = 0;
                                return true;
                            }
                        }
                        else
                            break;
                    }
                }

                // Check sixth format.
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[2])
                        {
                            if (position == 15)
                            {
                                position = 0;
                                return true;
                            }
                        }
                        else
                            break;
                    }
                }
            }

            // If mac string doesn't match any of the acceptable formats, return false.
            return false;
        }    // Validates a MAC address string.
        private static string ConvertMacAddress(string mac)
        {   // This function will convert the MAC Address string from its original format into
            // a format that can be used in the format functions. This function should only be called if
            // the ValidateMacAddress function is called first and returns true.

            // Declare variables.
            string convertedMacAddress = "";    // The converted MAC Address string to be returned.




            // Convert first format
            if (mac.Length == formatLengths[0])
            {
                convertedMacAddress = mac;
                return convertedMacAddress;
            }

            // check second format
            else if (mac.Length == formatLengths[1])
            {
                foreach (char c in mac)
                {
                    if ((++position % 7) == 0)
                    {
                        if (c == formatCharacters[1])
                        {
                            if (position == 7)
                            {
                                position = 0;

                                // Convert format.
                                foreach (char ch in mac)
                                {
                                    if (ch != formatCharacters[1])
                                        convertedMacAddress += ch;
                                }
                                return convertedMacAddress;
                            }
                        }
                        else
                            break;
                    }
                }
            }

            // check third format
            else if (mac.Length == formatLengths[2])
            {
                foreach (char c in mac)
                {
                    if ((++position % 5) == 0)
                    {
                        if (c == formatCharacters[0])
                        {
                            if (position == 10)
                            {
                                position = 0;

                                // Convert format.            
                                foreach (char ch in mac)
                                {
                                    if (ch != formatCharacters[0])
                                        convertedMacAddress += ch;
                                }
                                return convertedMacAddress;
                            }
                        }
                        else
                            break;
                    }
                }
            }
            else if (mac.Length == formatLengths[3])
            {
                // check fourth format
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[0])
                        {
                            if (position == 15)
                            {
                                position = 0;

                                // Convert format.            
                                foreach (char ch in mac)
                                {
                                    if (ch != formatCharacters[0])
                                        convertedMacAddress += ch;
                                }
                                return convertedMacAddress;
                            }
                        }
                        else
                            break;
                    }
                }

                // Check fifth format
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[1])
                        {
                            if (position == 15)
                            {
                                position = 0;

                                // Convert format.            
                                foreach (char ch in mac)
                                {
                                    if (ch != formatCharacters[1])
                                        convertedMacAddress += ch;
                                }
                                return convertedMacAddress;
                            }
                        }
                        else
                            break;
                    }
                }

                // Check sixth format
                foreach (char c in mac)
                {
                    if ((++position % 3) == 0)
                    {
                        if (c == formatCharacters[2])
                        {
                            if (position == 15)
                            {
                                position = 0;

                                // Convert format.            
                                foreach (char ch in mac)
                                {
                                    if (ch != formatCharacters[2])
                                        convertedMacAddress += ch;
                                }
                                return convertedMacAddress;
                            }
                        }
                        else
                            break;
                    }
                }
            }
            return convertedMacAddress;
        }   // Returns convertedMacAddress.
        private static string FormatOne(string mac)
        {
            return mac;
        }           // Formats the convertedMacAddress to format #1.
        private static string FormatTwo(string mac)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var c in mac)
            {
                builder.Append(c);
                if ((++position / 6) == 1)
                {
                    if (position != 12)
                        builder.Append('-');
                }
            }
            position = 0;
            return builder.ToString();
        }           // Formats the convertedMacAddress to format #2.
        private static string FormatThree(string mac)
        {   // This function takes a 48 bit MAC Address string as an argument.
            // It will add a '.' after every fourth character in the string then
            // return the formatted string.

            StringBuilder builder = new StringBuilder();
            foreach (var c in mac)
            {
                builder.Append(c);
                if ((++position % 4) == 0)
                {
                    if (position != 12)
                        builder.Append('.');
                }
            }
            position = 0;
            return builder.ToString();
        }         // Formats the convertedMacAddress to format #3.
        private static string FormatFour(string mac)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in mac)
            {
                builder.Append(c);
                if ((++position % 2) == 0)
                {
                    if (position != 12)
                        builder.Append(formatCharacters[0]);
                }
            }
            position = 0;
            return builder.ToString();
        }          // Formats the convertedMacAddress to format #4.
        private static string FormatFive(string mac)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in mac)
            {
                builder.Append(c);
                if ((++position % 2) == 0)
                {
                    if (position != 12)
                        builder.Append(formatCharacters[1]);
                }
            }
            position = 0;
            return builder.ToString();
        }          // Formats the convertedMacAddress to format #5.
        private static string FormatSix(string mac)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in mac)
            {
                builder.Append(c);
                if ((++position % 2) == 0)
                {
                    if (position != 12)
                        builder.Append(formatCharacters[2]);
                }
            }
            position = 0;
            return builder.ToString();
        }           // Formats the convertedMacAddress to format #6.
    }
}