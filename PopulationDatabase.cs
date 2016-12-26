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
 * Date: 11/6/2016 
 */

namespace VladislavIngatovAssignment05
{
    public partial class DBFrame : Form
    {
        public DBFrame()
        {
            InitializeComponent();
        }

        private void cBTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
            this.Validate();
            this.cBTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.populationDBDataSet);

            // updates if the save button is hit
            TotalPoP_label.Text = this.cBTableTableAdapter.TotalPOP().ToString();
            AveragePoP_label.Text = this.cBTableTableAdapter.AvgPOP().ToString();
            MaxPoP_label.Text = this.cBTableTableAdapter.MaxPOP().ToString();
            MinPoP_label.Text = this.cBTableTableAdapter.MinPOP().ToString();
        }

        private void DBFrame_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'populationDBDataSet.CBTable' table. You can move, or remove it, as needed.
            this.cBTableTableAdapter.Fill(this.populationDBDataSet.CBTable);

        }

        private void CitySortButton_Click(object sender, EventArgs e)
        {
            // sorts city in a-z order
            this.cBTableTableAdapter.FillByCity(this.populationDBDataSet.CBTable);
        }

        private void PriceSortButton_Click(object sender, EventArgs e)
        {
            // sorts population in ascending order
            this.cBTableTableAdapter.FillByPopulation(this.populationDBDataSet.CBTable);
        }

        private void pop_ascending_SortButton_Click(object sender, EventArgs e)
        {
            // sorting population in desending
            this.cBTableTableAdapter.FillByPopulationASC(this.populationDBDataSet.CBTable);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            // close application
            this.Close();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            // Calculate the average, total, min and max
            TotalPoP_label.Text = this.cBTableTableAdapter.TotalPOP().ToString();
            AveragePoP_label.Text = this.cBTableTableAdapter.AvgPOP().ToString();
            MaxPoP_label.Text = this.cBTableTableAdapter.MaxPOP().ToString();
            MinPoP_label.Text = this.cBTableTableAdapter.MinPOP().ToString();
        }

        private void Sort_za_button_Click(object sender, EventArgs e)
        {
            // sorts city in z-a order
            this.cBTableTableAdapter.FillByCityDESC(this.populationDBDataSet.CBTable);
        }
    }
}
