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
 *  Author: Vladislav Ignatov
 *  Date: 9/23/2016
 *  Cop 4365 – Software Systems Development – Fall 2016 – USF
 */

namespace VladislavIgnatovAssignment02
{
    public partial class ProjectileMotion : Form
    {
        double t = 0;
        double data = 0;
        public ProjectileMotion()
        {
            InitializeComponent();
        }

        private void Quit_Button_Click(object sender, EventArgs e)
        {
            //close application
            this.Close();
        }

        // determins the height at the time and out puts it to the list
        private void Display_Table_Button_Click(object sender, EventArgs e)
        {
            try{
                Output_Data_listbox.Items.Clear(); // this clears the listbox
                //check if the inputs are negative
                if (double.Parse(Initial_Velocity_Inputbox.Text) < 0 || double.Parse(Initial_Velocity_Inputbox.Text) < 0) throw new Exception("Number must be positive and non zero");
                Output_Data_listbox.Items.Add("                    Time          Height");
                while (true)
                {
                    //determins the hight at a sertine time
                    data = double.Parse(Initial_Height_Inputbox.Text) + (double.Parse(Initial_Velocity_Inputbox.Text) * t) - (16 * (t * t));
                    if (data < 0)
                    {
                        break;// breaks out of loop when the height is negative
                    }
                    Output_Data_listbox.Items.Add("                    " + t.ToString("n") + "           " + data.ToString("n1"));
                    t = t + .25; // here we increment the time by .25 seconds
                }
            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }
            data = t = 0; // clearing globel 
        }

        // this button determins the max height
        private void Determin_max_height_button_Click(object sender, EventArgs e)
        {
            try
            {
                Output_Data_listbox.Items.Clear(); // this clears the listbox
                //check if the inputs are negative
                if (double.Parse(Initial_Velocity_Inputbox.Text) < 0 || double.Parse(Initial_Velocity_Inputbox.Text) < 0) throw new Exception("Number must be positive and non zero");
                double tmp = double.Parse(Initial_Velocity_Inputbox.Text) / 32;// calculate v/32 seconds
                data = double.Parse(Initial_Height_Inputbox.Text) + (double.Parse(Initial_Velocity_Inputbox.Text) * tmp) - (16 * (tmp * tmp));
                
                Output_Data_listbox.Items.Add("                    " + "Max Height is: " + data.ToString("n"));

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }
            data = t = 0;// clearing globel 

        }

        // this button determins the time at witch the ball hits the ground
        private void Determin_Ball_Height_from_Ground_button_Click(object sender, EventArgs e)
        {
            try
            {
                Output_Data_listbox.Items.Clear(); // this clears the listbox
                //check if the inputs are negative
                if (double.Parse(Initial_Velocity_Inputbox.Text) < 0 || double.Parse(Initial_Velocity_Inputbox.Text) < 0) throw new Exception("Number must be positive and non zero");
               
                //while loops till the time at ground is meet
                while (true)
                {
                    data = double.Parse(Initial_Height_Inputbox.Text) + (double.Parse(Initial_Velocity_Inputbox.Text) * t) - (16 * (t * t));
                    //if the height is at ground level breaks out of loop
                    if (data <= 0)
                    {
                        
                        Output_Data_listbox.Items.Add("           " + "Ball hits the ground at: " + t.ToString("n") + " seconds");
                        break;
                    }
                    t = t + .1;
                }

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }
            data = t = 0;// clearing globel 
        }
    }
}
