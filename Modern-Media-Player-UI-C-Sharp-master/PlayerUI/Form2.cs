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
using SautinSoft.Document;


namespace PlayerUI
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

          
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Docx File (*.docx)|*.docx";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                
            }
             
        }

        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.InitialDirectory = @"C:\";
        //    saveFileDialog1.Title = "Save PDf File";
        //    saveFileDialog1.Filter = "Pdf File (*.pdf)|*.pdf";
        //    //saveFileDialog1.FilterIndex = 2;
        //    saveFileDialog1.RestoreDirectory = true;
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        textBox2.Text = saveFileDialog1.FileName;
        //    }
        //}
        static string globfilename;
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Where to save PDf file";
            saveFileDialog1.Filter = "Pdf File (*.pdf)|*.pdf";
            //saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                globfilename = saveFileDialog1.FileName;
                DocumentCore dc = DocumentCore.Load(textBox1.Text);
                dc.Save(globfilename);
                while (button3.Enabled == true)
                {
                    MessageBox.Show("Conversion has completed", "Extras | Media Converter", MessageBoxButtons.OK);
                    break;
                }


            }
            



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            while (globfilename.Length > 0)
            {

            }
        }
    }                                            
}

