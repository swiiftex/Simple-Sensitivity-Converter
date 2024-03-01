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
        public static List<Game> Games = new List<Game>();

        public Form1()
        {
            InitializeComponent();
        }

        public struct Game
        {
            public string Name;
            public double SensitivityCoefficient;
            public string FileLocation;

        }

        public void AddGame(string aName, double SensCoeff, string ConfLocation)
        {
            Games.Add(new Game{ FileLocation = ConfLocation, Name = aName, SensitivityCoefficient = SensCoeff });
        }

        public double GetCoeff(string GameName)
        {
            return Games.Find(Game => Game.Name == GameName).SensitivityCoefficient;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCM360.Text = SimpleSensitivityConverter.Properties.Settings.Default.cm360.ToString();
            txtDPI.Text = SimpleSensitivityConverter.Properties.Settings.Default.DPI.ToString();
            // Add key-value pairs to the dictionary
            AddGame("Source", 41563.64, "");
            AddGame("Unreal", 365.796580, "");
            AddGame("Unity", 41563.6364, "");
            AddGame("VALORANT", 13062.857, "");
            AddGame("THE FINALS", 11592.210438, "");
            AddGame("Battlefield 5-2042", 398.977267, "");
            AddGame("CoD 2019-2024", 138545.45455, "");
            AddGame("CoD BO2", 41563.64, "");
            AddGame("CoD BO3", 43362.86989, "");
            AddGame("Dark and Darker", 5225.6654, "");
            AddGame("Deceive Inc.", 40193.4066, "");
            AddGame("Destiny 2", 46181.8182, "");
            AddGame("Dirty Bomb", 41615.36, "");
            AddGame("DOOM (2016)", 41563.6364, "");
            AddGame("Fortnite", 41152.1152, "");
            AddGame("KovaaK's", 41563.6364, "");
            AddGame("Krunker", 41563.5103, "");
            AddGame("Escape from Tarkov", 41563.6364, "");
            AddGame("Overwatch", 41605.2416, "");


            comboBoxMethod.Items.Clear();
            foreach(Game x in Games)
            {
                comboBoxMethod.Items.Add(x.Name);
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
                    double inGameSensitivity = GetCoeff(comboBoxMethod.Text) / mouseDpi / realWorldCm;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SimpleSensitivityConverter.Properties.Settings.Default.cm360 = float.Parse(txtCM360.Text);
            SimpleSensitivityConverter.Properties.Settings.Default.DPI = int.Parse(txtDPI.Text);
            SimpleSensitivityConverter.Properties.Settings.Default.Save();
        }
    }
}
