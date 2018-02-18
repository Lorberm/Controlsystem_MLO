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
namespace Controlsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_5a.Visible = false;
            label_3a.Visible = false;
            label_1a.Visible = false;
            label_1b.Visible = false;
            label_curr.Visible = false;

        }

        private void btn_on_5a_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_on_5a.bat");
                Boolean b5a_on = true;
                if (b5a_on) { label_5a.Visible = true; label_curr.Visible = true; }
            }
            catch { MessageBox.Show("Error: Please make sure that 'J:\\Controlsystem_MLO\\Net\\files\\Net_on_5a.bat' exists and the path is correct."); }
        }

        private void btn_off_5a_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_off_5a.bat");
                Boolean b5a_on = false;
                if (!b5a_on) { label_5a.Visible = false; }
                if (label_1a.Visible == false && label_1b.Visible == false && label_3a.Visible == false && label_5a.Visible == false) { label_curr.Visible = false; }
            }
            catch { MessageBox.Show("Error: Please make sure that 'J:\\Controlsystem_MLO\\Net\\files\\Net_off_5a.bat' exists and the path is correct."); }
        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\AD-DC\\files\\mailexport.bat");
            }
            catch { MessageBox.Show("Error: Please make sure that 'J:\\Controlsystem_MLO\\AD-DC\\files\\mailexport.bat' exists and the path is correct."); }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Project: Schule 2 - Server" + Environment.NewLine + "Dev: MLO" + Environment.NewLine + "Release: 29/10/2017" + Environment.NewLine + "Purpose: Controlsystem, windowsbased" + Environment.NewLine + Environment.NewLine + "Schule 2" + Environment.NewLine + "4010 Linz" + Environment.NewLine + "Wiener Straße 151" + Environment.NewLine + "markus.lorber@innlan.at");
        }

        private void btn_AD_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\AD-DC\\files\\User_Import.bat");
            }
            catch { MessageBox.Show("Error: Please make sure that 'J:\\Controlsystem_MLO\\AD-DC\\files\\User_Import.bat' exists and the path is correct."); }
        }

        private void btn_off_3a_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_off_3a.bat");
            Boolean b3a_on = false;
            if (!b3a_on) { label_3a.Visible = false;  }
            if (label_1a.Visible == false && label_1b.Visible == false && label_3a.Visible == false && label_5a.Visible == false) { label_curr.Visible = false; }
        }

        private void btn_on_3a_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_on_3a.bat");
            Boolean b3a_on = true;
            if (b3a_on) { label_3a.Visible = true; label_curr.Visible = true; }
        }

        private void btn_on_1a_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_on_1a.bat");
            Boolean b1a_on = true;
            if (b1a_on) { label_1a.Visible = true; label_curr.Visible = true; }
        }

        private void btn_off_1a_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_off_1a.bat");
            Boolean b1a_on = false;
            if (!b1a_on) { label_1a.Visible = false;  }
            if (label_1a.Visible == false && label_1b.Visible == false && label_3a.Visible == false && label_5a.Visible == false) { label_curr.Visible = false; }
        }

        private void btn_on_1b_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_on_1b.bat");
            Boolean b1b_on = true;
            if (b1b_on) { label_1b.Visible = true; label_curr.Visible = true; }
        }

        private void btn_off_1b_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("J:\\Controlsystem_MLO\\Net\\files\\Net_off_1b.bat");
            Boolean b1b_on = false;
            if (!b1b_on) { label_1b.Visible = false; }
            if (label_1a.Visible == false && label_1b.Visible == false && label_3a.Visible == false && label_5a.Visible == false) { label_curr.Visible = false; }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
