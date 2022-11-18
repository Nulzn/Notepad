using System.Runtime.CompilerServices;

namespace Notepad2
{
    public partial class Form1 : Form
    {
        bool isSaved = true;
        string fileName = "";

        private FontDialog fd = new FontDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSaved = false;
            UpdateTitle();
        }

        public void UpdateTitle()
        {
            string file = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                file = Path.GetFileName(fileName);
            }
            else
            {
                file = "Unamed";
            }

            if (!isSaved)
            {
                Form1.ActiveForm.Text = $"*{file} - Notepad";
            }
            else
            {
                Form1.ActiveForm.Text = $"{file} - Notepad";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSaved = (!isSaved) ? true : false;
            UpdateTitle();
            
            if (fileName != null)
            {
                File.WriteAllText(fileName, this.textBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;
                UpdateTitle();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            isSaved = true;
            fileName = "";
            UpdateTitle();
        }

        private void typsnittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Font = fd.Font;
            }
        }
    }
}