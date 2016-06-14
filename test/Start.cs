using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace test
{
    public partial class Start : Form
    {
        string testPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\tests\";
        string testFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\tests\test.csv";

        public Start()
        {
            InitializeComponent();
            Directory.CreateDirectory(testPath);
            var csv = new StringBuilder();
            var newLine = "Test, Time, Distance, Distance to Circle, Radius of Circle, Direction, Index of Difficulty";
            csv.AppendLine(newLine);
            File.AppendAllText(testFile, csv.ToString());
        }

        /// <summary>
        /// begin button on click. loads the first test (32px radius circle 512 px to left). 
        /// </summary>
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            var test1 = new test1();
            test1.Closed += (s, args) => this.Close();
            test1.Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - button1.Width/2,
                            Screen.PrimaryScreen.Bounds.Height / 2);
            label1.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - label1.Width/2,
                            (Screen.PrimaryScreen.Bounds.Height / 2) - 200);
            label2.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - label2.Width/2,
                            (Screen.PrimaryScreen.Bounds.Height / 2) - 100);
        }
    }
}