using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace practicum2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Random rnd = new Random();
            InitializeComponent();

            num1Text.Text = rnd.Next(1, 11).ToString();
            num2Text.Text = rnd.Next(1, 11).ToString();
            num3Text.Text = rnd.Next(1, 11).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Int32.Parse(num1Text.Text);
            int num2 = Int32.Parse(num2Text.Text);
            int num3 = Int32.Parse(num3Text.Text);
            
            String output = MethodRunner.RunAllMethods(num1,num2,num3);
            methodOutput.Text = output;

            String output2 = LambdaRunner.RunAllMethods(num1,num2,num3);
            lambdaOutput.Text = output2;

            
            string[] words = output.Split('\n');
            string[] words2 = output2.Split('\n');
            List<String> outputs1 = new List<String>();
            List<String> outputs2 = new List<String>();
            foreach (var word in words) {
               
                 outputs1.Add(word.Split('=').Last());
              
            }
            foreach (var word in words2) {

                outputs2.Add(word.Split('=').Last());
            }
            Debug.WriteLine(outputs1.ToString());
            Debug.WriteLine(outputs2.ToString());

            MessageBox.Show(outputs1.SequenceEqual(outputs2).ToString());
        }
    }
}
