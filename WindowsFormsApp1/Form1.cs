using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Dictionary<string, double> StringValuesMap = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtCM360.Text = "";
            // Add key-value pairs to the dictionary
            StringValuesMap["Source"] = 41563.64;
            StringValuesMap["Unreal"] = 365.796580;
            StringValuesMap["VALORANT"] = 13062.857;
            StringValuesMap["THE FINALS"] = 11592.210438;
            StringValuesMap["BF5/2042"] = 398.977267;
            StringValuesMap["CoD 2019-2024"] = 138545.45455;
            StringValuesMap["CoD BO2"] = 41563.64;
            StringValuesMap["CoD BO3"] = 43362.86989;

            comboBoxMethod.Items.Clear();
            foreach(string x in StringValuesMap.Keys)
            {
                comboBoxMethod.Items.Add(x);
            }
        }

        private void txtCM360_TextChanged(object sender, EventArgs e)
        {
            txtOutput.Text = CalculateSens();
        }

        public string CalculateSens()
        {
            try
            {
                if (double.TryParse(txtCM360.Text, out double realWorldCm) &&
                    int.TryParse(txtDPI.Text, out int mouseDpi))
                {
                    // Source engine games use a default FOV (Field of View) of 90 degrees.
                    double inGameSensitivity = (StringValuesMap[comboBoxMethod.Text] / mouseDpi) / realWorldCm;

                    return inGameSensitivity.ToString();
                }
                else
                {
                    return "ERR";
                }
            }
            catch(Exception ex)
            {
                return "ERR";
            }

        }
    }
}
