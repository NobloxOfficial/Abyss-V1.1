using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abyss
{
    public partial class Abyss : Form
    {
        public Point mouseLocation;
        public Abyss()
        {
            InitializeComponent();
            Timer time = new Timer();
            time.Tick += timertick;
            time.Start();
            ForlornApi.Api.InitializeForlorn();
        }

        private void timertick(object sender, EventArgs e)
        {
            if (ForlornApi.Api.IsRobloxOpen())
            {
                robloxopen.Text = "Roblox Open: ✅";
                robloxopen.ForeColor = Color.LightGreen;  // Change text color to green
            }
            else
            {
                robloxopen.Text = "Roblox Open: ❌";
                robloxopen.ForeColor = Color.Red;  // Change text color to red
            }

            if (ForlornApi.Api.IsInjected())
            {
                status.Text = "Status: Injected!";
                status.ForeColor = Color.LightGreen;  // Change text color to green
            }
            else
            {
                status.Text = "Status: Not Injected!";
                status.ForeColor = Color.Red;  // Change text color to red
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.KillRoblox();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void savefile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt",
                DefaultExt = "lua",
                Title = "Save Lua or Text File"
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string textToSave = Editor.Text;
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textToSave);
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.Inject();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.ExecuteScript(Editor.Text);
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Editor.Clear();
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Editor.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        class functions
        {
            public static void PopulateListBox(System.Windows.Forms.ListBox lsb, string Folder, string FileType)
            {
                DirectoryInfo dinfo = new DirectoryInfo(Folder);
                FileInfo[] Files = dinfo.GetFiles(FileType);
                foreach (FileInfo file in Files)
                {
                    lsb.Items.Add(file.Name);
                }
            }
        }


        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
            functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
        }

        private void status_Click(object sender, EventArgs e)
        {

        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt",
                Title = "Open Lua or Text File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Editor.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void guna2CustomGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

