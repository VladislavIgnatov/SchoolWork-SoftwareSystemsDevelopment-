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
 *  Date: 9/30/2016
 *  Cop 4365 – Software Systems Development – Fall 2016 – USF
 */

namespace VladislavIgnatovAssignment03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            // closes the application
            this.Close();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            // clears the Application by calling the methods
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
        }

        private void ClearFees()
        {
            // Clears Summary (Service_and_Labor_Output, Parts_OutPut, Tax_OutPut, Total_Fees_Output)
            Service_and_Labor_Output.Text = Parts_OutPut.Text = Tax_OutPut.Text = Total_Fees_Output.Text = "";
        }

        private void ClearOther()
        {
            //clears parts  and labor
            Parts_Input.Text = Labor_Input.Text = "0";
        }

        private void ClearMisc()
        {
            // clears Inspection_CheckBox
            if (Inspection_CheckBox.Checked == true)
            { Inspection_CheckBox.Checked = false; }

            // clears Replace_Muffler_CheckBox
            if (Replace_Muffler_CheckBox.Checked == true)
            { Replace_Muffler_CheckBox.Checked = false; }

            // clears Tire_Rotation_CheckBox
            if (Tire_Rotation_CheckBox.Checked == true)
            { Tire_Rotation_CheckBox.Checked = false; }
        }

        private void ClearFlushes()
        {
            // clears Radiator_Flush_CheckBox
            if (Radiator_Flush_CheckBox.Checked == true)
            { Radiator_Flush_CheckBox.Checked = false; }

            // clears Transmission_Flush_CheckBox
            if (Transmission_Flush_CheckBox.Checked == true)
            { Transmission_Flush_CheckBox.Checked = false; }
        }

        private void ClearOilLube()
        {
            // clears Oil_Change_CheckBox
            if (Oil_Change_CheckBox.Checked == true)
            { Oil_Change_CheckBox.Checked = false; }

            // clears Lube_Job_CheckBox
            if (Lube_Job_CheckBox.Checked == true)
            { Lube_Job_CheckBox.Checked = false; }
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the inputs are negative
                if (double.Parse(Parts_Input.Text) < 0 || double.Parse(Labor_Input.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }

                //calls the service and labor method to get the sum of valuse
                Service_and_Labor_Output.Text = ServiceandLabor();

                //displays parts amount in parts_output
                Parts_OutPut.Text = double.Parse(Parts_Input.Text).ToString("c");

                // Tax (on parts): tax of the parts
                Tax_OutPut.Text = TaxCharges().ToString("c");

                // displayes the Total Fees: sum of all service, labor, and parts (including taxes)
                Total_Fees_Output.Text = TotalCharges().ToString("c");

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }

            
        }

        private string ServiceandLabor()
        {
            string tmp = "0.00";
            double num = 0.0;

            // adds up Service and Labor: sum of Oil and Lube, Flushes, Misc, and Labor
            num = FlushCharges() + MiscCharges() + OilLubeCharges() + double.Parse(Labor_Input.Text);

            // convet to string to then return
            tmp = num.ToString("c");

            return tmp;
        }

        private double TotalCharges()
        {
            double tmp = 0.0;

            //Total Fees: sum of all service, labor, and parts (including taxes)
            tmp = OilLubeCharges() + FlushCharges() + MiscCharges() + OtherCharges() + TaxCharges();

            return tmp;
        }

        private double TaxCharges()
        {
            double tmp = 0.0;
            try
            {
                //check if the inputs are negative
                if (double.Parse(Parts_Input.Text) < 0 || double.Parse(Labor_Input.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }

                // adds the oil and lub charcges if any 
                tmp = double.Parse(Parts_Input.Text) * 0.06;

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }

            return tmp;
        }

        private double OtherCharges()
        {
            double tmp = 0.0;
            try
            {
                //check if the inputs are negative
                if (double.Parse(Parts_Input.Text) < 0 || double.Parse(Labor_Input.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }

                // adds the oil and lub charcges if any 
                tmp = double.Parse(Parts_Input.Text) + double.Parse(Labor_Input.Text);

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }

            return tmp;
        }

        private double MiscCharges()
        {
            double tmp = 0.0;

            // If check adds 15 to tmp value.
            if (Inspection_CheckBox.Checked == true)
            {
                tmp += 15.00;
            }

            // If check adds 100 to tmp value.
            if (Replace_Muffler_CheckBox.Checked == true)
            {
                tmp += 100.00;
            }

            // If check adds 20 to tmp value.
            if (Tire_Rotation_CheckBox.Checked == true)
            {
                tmp += 20.00;
            }
            return tmp;
        }

        private double FlushCharges()
        {
            double tmp = 0.0;

            // If check adds 30 to tmp value.
            if (Radiator_Flush_CheckBox.Checked == true)
            {
                tmp += 30.00;
            }

            // If check adds 80 to tmp value.
            if (Transmission_Flush_CheckBox.Checked == true)
            {
                tmp += 80.00;
            }
            return tmp;
        }

        private double OilLubeCharges()
        {
            double tmp = 0.0;

            // If check adds 26 to tmp value.
            if (Oil_Change_CheckBox.Checked == true)
            {
                tmp += 26.00;
            }

            // If check adds 18 to tmp value.
            if (Lube_Job_CheckBox.Checked == true)
            {
                tmp += 18.00;
            }
            return tmp;
        }
    }
}
