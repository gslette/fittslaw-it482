﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class test3 : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        List<Point> testPoints = new List<Point>();
        double trial = 3;
        double circleDistance = 128;
        double circleRadius = 64;
        double circleDirection = 1;
        string testFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\tests\test.csv";

        public test3()
        {
            InitializeComponent();
        }

        private double testDistance(List<Point> a)
        {
            double actualDistance = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (i == a.Count)
                {

                }
                else if (i < a.Count - 1)
                {
                    Point p1 = a[i];
                    Point p2 = a[i + 1];

                    var d = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

                    actualDistance = d + actualDistance;
                }
            }
            return actualDistance;
        }

        /// <summary>
        /// Calculates index of difficulty for give distance and radius (r*2 for diameter).
        /// </summary>
        /// <param name="testDistance"></param>
        /// <param name="circleRadius"></param>
        /// <returns></returns>
        private double iod(double testDistance, double circleRadius)
        {
            double indexOD = Math.Log((2 * testDistance / 2 * circleRadius), 2);
            return indexOD;
        }

        private void test3_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = MousePosition;
            testPoints.Add(mousePosition);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            var testTime = stopwatch.Elapsed;

            var actualDistance = testDistance(testPoints);
            var indexOD = iod(actualDistance, circleRadius);

            var csv = new StringBuilder();
            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", trial, testTime, actualDistance, circleDistance, circleRadius, circleDirection, indexOD);
            csv.AppendLine(newLine);
            File.AppendAllText(testFile, csv.ToString());

            this.Hide();
            var test = new test4();
            test.Closed += (s, args) => this.Close();
            test.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2,
                            Screen.PrimaryScreen.Bounds.Height / 2);
            button2.Visible = true;
            button2.Location = new Point((((Screen.PrimaryScreen.Bounds.Width / 2) - button2.Width / 2) + 128), (Screen.PrimaryScreen.Bounds.Height / 2) - button2.Height / 2);
            stopwatch.Start();
        }

        private void test3_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - button1.Width / 2,
                        Screen.PrimaryScreen.Bounds.Height / 2);
        }
    }
}