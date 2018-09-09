using ACM.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class PedometerWin : Form
    {
        public PedometerWin()
        {
            InitializeComponent();
        }


        private void Calculate_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            try
            {
            var result = customer.CalculatePercentOfGoalSteps(this.GoalTextBox.Text, 
                                                              this.StepsTextBox.Text);
                ResultLabel.Text = $"You reached {result} % of your goal";

            }
            catch (ArgumentException ex)
            {

                MessageBox.Show($"Problema: {ex.Message}");
                ResultLabel.Text = string.Empty; //is suvedama teisinga sukalkuliuojama o tada neteisingai
                //kad istrintu sena rez
                
            }
                                                              
        }


    }
}

