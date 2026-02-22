using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_exe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("msedge.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("msedge");
            foreach (Process edge in processes)
            {
                edge.Kill(); // Kill the process
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("notepad");
            foreach (Process notepad in processes)
            {
                notepad.Kill();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("mspaint");
            foreach (Process mspaint in processes)
            {
                mspaint.Kill();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form creditsForm = new Form();
            string iconPath = Path.Combine(Application.StartupPath, "icon.ico");
            creditsForm.MaximizeBox = false;
            creditsForm.Icon = new Icon(iconPath);
            creditsForm.BackColor = System.Drawing.SystemColors.AppWorkspace;
            creditsForm.Text = "Credits";
            creditsForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            Label label = new Label();
            label.Font = new Font(label.Font.FontFamily, 28);
            label.Text = "Creator: Darboy";
            label.AutoSize = true;
            creditsForm.Controls.Add(label);
            creditsForm.ShowDialog();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("explorer");
            foreach (Process explorer in processes)
            {
                explorer.Kill();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a program name or .exe file.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string processName = input.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)
                ? input.Substring(0, input.Length - 4)
                : input;

            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                {
                    MessageBox.Show("No running instances found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (Process proc in processes)
                {
                    proc.Kill();
                }

                MessageBox.Show($"Killed {processes.Length} instance(s) of {processName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to kill process:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text.Trim();

            if (input.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    Process.Start(input);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to start process:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid .exe file name or path.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
        }
