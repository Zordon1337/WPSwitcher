using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPSwitcher
{
    public partial class Form1 : Form
    {
        bool bWritten = false;
        string FilePath = @"C:\Windows\System32\drivers\etc\hosts";
        public Form1()
        {
            if(System.IO.File.ReadAllText(FilePath).Contains("jabber.wp.pl"))
                bWritten = true;
            InitializeComponent();
            IP.Text = ParseIP();
        }
        bool WriteToFile(string IP)
        {
            if(bWritten)
            {
                string[] FileLines = System.IO.File.ReadAllLines(FilePath);

                for (int i = 0; i < FileLines.Length; i++)
                {
                    if (FileLines[i].Contains("jabber.wp.pl"))
                    {
                        FileLines[i] = $"{IP} jabber.wp.pl";

                    }

                }
                System.IO.File.WriteAllLines(FilePath, FileLines);
                return false;
            } else
            {
                System.IO.File.AppendAllText(FilePath, $"{IP} jabber.wp.pl");
                return true;
            }
        }
        string ParseIP()
        {
            string[] FileLines = System.IO.File.ReadAllLines(FilePath);

            for (int i = 0; i < FileLines.Length; i++)
            {
                if (FileLines[i].Contains("jabber.wp.pl"))
                {
                    string[] splitted = FileLines[i].Split(' ');
                    return splitted[0];

                }

            }
            return "";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteToFile(IP.Text);
            MessageBox.Show("Nadpisano plik pomyślnie");
        }
    }
}
