using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Vladislav Ignatov
 * Class: Cop 4365 – Software Systems Development
 * Date: 11-26-2016
 */

namespace VladislavIgnatovAssignment06
{
    public partial class Calc_Form : Form
    {
        // In the label all the equations are stored and edited
        string label = "";

        // The memory for a single number.
        double M = 0.0;

        public Calc_Form()
        {
            InitializeComponent();
        }

        private void equal_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            // Checks to see if sting not is empty.
            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();
                output_label.Text = label;
            }
        }

        // Adds zero to label.
        private void zero_button_Click(object sender, EventArgs e)
        {
            label += "0";
            output_label.Text = label;
        }

        // Adds one to label.
        private void one_button_Click(object sender, EventArgs e)
        {
            label += "1";
            output_label.Text = label;
        }

        // Adds two to label.
        private void two_button_Click(object sender, EventArgs e)
        {
            label += "2";
            output_label.Text = label;
        }

        // Adds three to label.
        private void three_button_Click(object sender, EventArgs e)
        {
            label += "3";
            output_label.Text = label;
        }

        // Adds four to label.
        private void four_button_Click(object sender, EventArgs e)
        {
            label += "4";
            output_label.Text = label;
        }

        // Adds five to label.
        private void five_button_Click(object sender, EventArgs e)
        {
            label += "5";
            output_label.Text = label;
        }

        // Adds six to label.
        private void six_button_Click(object sender, EventArgs e)
        {
            label += "6";
            output_label.Text = label;
        }

        // Adds seven to label.
        private void seven_button_Click(object sender, EventArgs e)
        {
            label += "7";
            output_label.Text = label;
        }

        // Adds eight to label.
        private void eight_button_Click(object sender, EventArgs e)
        {
            label += "8";
            output_label.Text = label;
        }

        // Adds nine to label.
        private void nine_button_Click(object sender, EventArgs e)
        {
            label += "9";
            output_label.Text = label;
        }

        // Clears out everything label and output.
        private void clear_button_Click(object sender, EventArgs e)
        {
            label = "";
            output_label.Text = "0.";
        }

        // Plus Button. Adds Plus.
        private void pluse_button_Click(object sender, EventArgs e)
        {
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }
            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();

                //adds pluse to label
                label += "+";
                output_label.Text = label;
            }
        }

        // Minus Button. Adds minus.
        private void minus_button_Click(object sender, EventArgs e)
        {
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }
            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();

                // adds minus to label
                label += "-";
                output_label.Text = label;
            }
        }

        // multiplication Button. Adds multiplication.
        private void multiplication_button_Click(object sender, EventArgs e)
        {
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }
            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();

                //adds multiplication to label
                label += "*";
                output_label.Text = label;
            }
        }

        // divition Button. Adds divition.
        private void divide_buttion_Click(object sender, EventArgs e)
        {
            if(label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();

                // adds divition to label
                label += "/";
                output_label.Text = label;
            }
        }

        // Sqrt the element given.
        private void sqrt_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            // Checks to see if sting not is empty.
            if (label != "")
            {
                // Does the basic math functions
                DataTable dt = new DataTable();
                var v = dt.Compute(label, "");
                label = v.ToString();
                // Squar root the element in label and outputs it.
                label = Math.Sqrt(Double.Parse(label)).ToString();
                output_label.Text = label;
            }
        }

        // Backspace button which removes the last element in the string.
        private void backspace_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            // Checks to see if sting not is empty.
            if (label != "")
            {
                label = label.Remove(label.Length - 1);
                output_label.Text = label;
            }

            // Checks to see if sting is empty. Only happens when we remove all the elements.
            if (label == "")
            {
                output_label.Text = "0.";
            }
        }

        // Adds decimal point to label.
        private void dot_button_Click(object sender, EventArgs e)
        {
            if (label.Contains('.'))
            {
                // if there is a plus operator it can add '.' to the second half
                if (label.Contains("+"))
                {
                    string tmp = label.Substring(label.IndexOf('+'));
                    if (!tmp.Contains('.'))
                    {
                        label += ".";
                        output_label.Text = label;
                    }
                }

                // if there is a multiplication operator it can add '.' to the second half
                if (label.Contains("*"))
                {
                    string tmp = label.Substring(label.IndexOf('*'));
                    if (!tmp.Contains('.'))
                    {
                        label += ".";
                        output_label.Text = label;
                    }
                }

                // if there is a divition operator it can add '.' to the second half
                if (label.Contains("/"))
                {
                    string tmp = label.Substring(label.IndexOf('/'));
                    if (!tmp.Contains('.'))
                    {
                        label += ".";
                        output_label.Text = label;
                    }
                }

                // if there is a minus operator it can add '.' to the second half
                if (label.Contains("-"))
                {
                    string tmp = label.Substring(label.IndexOf('-'));
                    if (!tmp.Contains('.'))
                    {
                        label += ".";
                        output_label.Text = label;
                    }
                }
            }
            else
            {
                label += ".";
                output_label.Text = label;
            }

        }

        // Clears out the number after the operator.
        private void clearentry_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            // Checks to see if string has with a (+,-,*,/) if so returns NULL.
            if (!label.Contains("+") && !label.Contains("-") && !label.Contains("*") && !label.Contains("/"))
            {
                label = "";
                output_label.Text = "0.";
            }

            // Checks to see if label is empty if so returns null.
            if (label == "")
            {
                return;
            }

            // Checks to see if label contains (+,-,*,/) if so then removes the numbers after them.
            if (label.Contains('+'))
            {
                label = label.Remove(label.IndexOf('+')+1);
                output_label.Text = label;
            }
            if (label.Contains('-'))
            {
                label = label.Remove(label.IndexOf('-') + 1);
                output_label.Text = label;
            }
            if (label.Contains('*'))
            {
                label = label.Remove(label.IndexOf('*') + 1);
                output_label.Text = label;
            }
            if (label.Contains('/'))
            {
                label = label.Remove(label.IndexOf('/') + 1);
                output_label.Text = label;
            }

        }

        // Get the reciprocal of a number.
        private void reciprocal_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string contains a (+,-,*,/) if so returns NULL.
            if (label.Contains("+") || label.EndsWith("-") || label.Contains("*") || label.Contains("/"))
            {
                return;
            }

            // Checks to see if sting not is empty.
            if (label != "")
            {
                // Squar root the element in label and outputs it.
                label = (1/ Double.Parse(label)).ToString();
                output_label.Text = label;
            }
        }

        private void negative_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.EndsWith("+") || label.EndsWith("-") || label.EndsWith("*") || label.EndsWith("/"))
            {
                return;
            }

            // Checks to see if label is empty if so returns null.
            if (label == "")
            {
                return;
            }

            // Checks to see if it has an operator
            if (label.Contains("+") || label.Contains("*") || label.Contains("/") || label.Contains("-"))
            {
                // Checks to see if label contains (+,-,*,/) if so then removes the numbers after them.
                if (label.Contains('+'))
                {
                    label = label.Remove(label.IndexOf('+') + 1) + (-1 * Double.Parse(label.Substring(label.IndexOf('+') + 1))).ToString();
                    output_label.Text = label;
                }
                if (label.Contains('*'))
                {
                    label = label.Remove(label.IndexOf('*') + 1) + (-1 * Double.Parse(label.Substring(label.IndexOf('*') + 1))).ToString();
                    output_label.Text = label;
                }
                if (label.Contains('/'))
                {
                    label = label.Remove(label.IndexOf('/') + 1) + (-1 * Double.Parse(label.Substring(label.IndexOf('/') + 1))).ToString();
                    output_label.Text = label;
                }
                if (label.Contains('-') && !label.Contains("+") && !label.Contains("*") && !label.Contains("/") && !label.StartsWith("-"))
                {
                    label = label.Remove(label.IndexOf('-')) + "+" + label.Substring(label.IndexOf('-') + 1).ToString();
                    output_label.Text = label;
                }
                if (label.Contains('-') && !label.Contains("+") && !label.Contains("*") && !label.Contains("/") && label.StartsWith("-"))
                {
                    label = label.Remove(label.IndexOf('-', label.IndexOf('-') +1 )) + "+" + label.Substring(label.IndexOf('-', label.IndexOf('-') + 1) + 1).ToString();
                    output_label.Text = label;
                }
            }
            else{
                // Multiply by -1 to change from possitive to negative and viseversa.
                label = (-1 * Double.Parse(label)).ToString();
                output_label.Text = label;
            }
        }

        // Takes the number given and makes it a precent.
        private void precent_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.Contains("+") || label.EndsWith("-") || label.Contains("*") || label.Contains("/"))
            {
                return;
            }

            // Checks to see if label is empty if so returns null.
            if (label == "")
            {
                return;
            }
            else
            {
                // Divides by 100, to show as a precentage.
                label = (Double.Parse(label)/100).ToString();
                output_label.Text = label;
            }
        }

        // sets the memory
        private void MS_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.Contains("+") || label.EndsWith("-") || label.Contains("*") || label.Contains("/"))
            {
                return;
            }

            // Checks to see if label is empty if so returns null.
            if (label == "")
            {
                return;
            }
            else
            {
                M = Double.Parse(label);
                M_label.Text = "M";
                label = "";
            }
        }

        // Number is added to the new M
        private void MPlus_button_Click(object sender, EventArgs e)
        {
            // Checks to see if string ends with a (+,-,*,/) if so returns NULL.
            if (label.Contains("+") || label.EndsWith("-") || label.Contains("*") || label.Contains("/"))
            {
                return;
            }

            // Checks to see if label is empty if so returns null.
            if (label == "")
            {
                return;
            }
            else
            {
                //adds to the Memory
                M = M + Double.Parse(label);
                M_label.Text = "M";
                output_label.Text = M.ToString();
            }
        }

        // Clears the memory M and the label
        private void MC_button_Click(object sender, EventArgs e)
        {
            M = 0.0;
            M_label.Text = "";
        }

        // Adds to label the Number set in M
        private void MR_button_Click(object sender, EventArgs e)
        {
            label += M.ToString();
            output_label.Text = label;
        }
    }
}
