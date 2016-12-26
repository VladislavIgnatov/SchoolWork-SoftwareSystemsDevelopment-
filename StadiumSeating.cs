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
 * Date: 9/16/2016
 * Class: COP 4365
 */

namespace VladislavIgnatovAssignment01
{
    public partial class StadiumSeatingForm : Form
    {
        int classA, classB, classC; //decleration of the vvariables needed to calcute the total revenue

        public StadiumSeatingForm()
        {
            InitializeComponent();
        }

        private void Calculate_Revenue_Click(object sender, EventArgs e)
        {
            try
            {
                // clears the variables and the answesclasses
                classA = classB = classC = 0;
                answerClassA.Text = answerClassB.Text = answerClassC.Text = answerTotal.Text = "";

                // Calculates the revenue of classA and showes answer in label answerClassA
                if (ticketinputClassA.Text != "")
                {
                    classA = int.Parse(ticketinputClassA.Text) * 15;
                    answerClassA.Text = classA.ToString("C");
                }

                // Calculates the revenue of classB  and showes answer in label answerClassB
                if (ticketinputClassB.Text != "")
                {
                    classB = int.Parse(ticketinputClassB.Text) * 12;
                    answerClassB.Text = classB.ToString("C");

                }

                // Calculates the revenue of classC  and showes answer in label answerClassC
                if (ticketinputClassC.Text != "")
                {
                    classC = int.Parse(ticketinputClassC.Text) * 9;
                    answerClassC.Text = classC.ToString("C");
                }

                // total is all the classes a,b,c added together also checks to see that all ticket inputs have a number
                if ((ticketinputClassC.Text == "") && (ticketinputClassB.Text == "") && (ticketinputClassA.Text == ""))
                {
                    //do nothing if all ticket inputs are empty
                }
                else
                {
                    int total = classA + classB + classC;
                    answerTotal.Text = total.ToString("C");
                }
            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            //clear out the answers for all classes labels and inputtexts nad variables
            answerClassA.Text = answerClassB.Text = answerClassC.Text = answerTotal.Text = "";
            ticketinputClassA.Text = ticketinputClassB.Text = ticketinputClassC.Text  = "";
            classA = classB = classC = 0;
        }

        private void Exit_Botton_Click(object sender, EventArgs e)
        {
            // closes the application
            this.Close();
        }
    }
}
