using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
//using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using IronPython.Hosting;
using Renci.SshNet;

namespace PlayerUI
{

    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
            circularProgressBar1.Value = 0;
            timer1.Enabled = false;
            //button3.Visible = false;
            //label1.Visible = false;
            //label2.Visible = false;
            textBox1.Text = "NULL";
            textBox2.Text = "NULL";
            textBox3.Text = "NULL";
            textBox4.Visible = false;
            panel4.Visible = false;
            //label9.Visible = false;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            //pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            richTextBox2.Visible = false;
            pypath();
            File.WriteAllBytes("C:\\Users\\"+Environment.UserName+"\\AppData\\Local\\Temp\\pdfid.py", Properties.Resources.pdfid);
        }

        void pypath()
        {

            var processInfo = new ProcessStartInfo("cmd.exe", "/c where python")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = @"C:\Windows\System32\"
            };

            StringBuilder sb = new StringBuilder();
            Process p = Process.Start(processInfo);
            p.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            p.BeginOutputReadLine();
            p.WaitForExit();
            richTextBox2.Text = sb.ToString();
            if (richTextBox2.Text.Contains("Python") && richTextBox2.Text.Contains("python.exe"))
            {

            }
            else
            {
                MessageBox.Show("Python not found or Not in the environment variable","Info", MessageBoxButtons.OK);
            }
            
        }




        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            //panelPlaylistSubMenu.Visible = false;
            panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;


            showSubMenu(panelMediaSubMenu);

        }

        #region MediaSubMenu
        public void button2_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "pdf files(*.pdf)| *.pdf";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //openChildForm(new Form2());




                float filesize = new FileInfo(openFileDialog1.FileName).Length;

                textBox2.Text = (filesize / 1000000).ToString() + " MB";
                //string filepath = Path.GetFileName(openFileDialog1.FileName);
                //MessageBox.Show(openFileDialog1.FileName);
                textBox1.Text = Path.GetFileName(openFileDialog1.FileName);
                const string quote = "\"";
                textBox4.Text = quote + (openFileDialog1.FileName)+ quote;
                string file = openFileDialog1.FileName;//It's 2.5 Gb file
                string output;
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(file))
                    {
                        byte[] checksum = md5.ComputeHash(stream);
                        output = BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
                        textBox3.Text = output.ToUpper();

                    }
                }/*
                #region SCP - upload

                Chilkat.Ssh ssh = new Chilkat.Ssh();

                // Connect to an SSH server:
                string hostname;
                int port;

                // Hostname may be an IP address or hostname:
                hostname = "www.some-ssh-server.com";
                port = 22;

                bool success = ssh.Connect(hostname, port);
                if (success != true)
                {
                    //MessageBox.Show(ssh.LastErrorText);
                    Debug.WriteLine(ssh.LastErrorText);
                    return;
                }

                // Wait a max of 5 seconds when reading responses..
                ssh.IdleTimeoutMs = 5000;

                // Authenticate using login/password:
                success = ssh.AuthenticatePw("myLogin", "myPassword");
                if (success != true)
                {
                    //MessageBox.Show(ssh.LastErrorText);
                    Debug.WriteLine(ssh.LastErrorText);
                    return;
                }

                // Once the SSH object is connected and authenticated, we use it
                // as the underlying transport in our SCP object.
                Chilkat.Scp scp = new Chilkat.Scp();

                success = scp.UseSsh(ssh);
                if (success != true)
                {
                    //MessageBox.Show(ssh.LastErrorText);
                    Debug.WriteLine(scp.LastErrorText);
                    return;
                }

                //specify upload file path
                string remotePath = "test.txt";
                string localPath = file;
                success = scp.UploadFile(localPath, remotePath);
                if (success != true)
                {
                    //MessageBox.Show(ssh.LastErrorText);
                    Debug.WriteLine(scp.LastErrorText);
                    return;
                }

                Debug.WriteLine("SCP upload file success.");

                // Disconnect
                ssh.Disconnect();
                #endregion*/






            }

            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        //private void btnPlaylist_Click(object sender, EventArgs e)
        //{
        //    showSubMenu(panelPlaylistSubMenu);
        //}

        #region PlayListManagemetSubMenu
        //private void button8_Click(object sender, EventArgs e)
        //{
        //    //..
        //    //your codes
        //    //..
        //    hideSubMenu();
        //}

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click_1(object sender, EventArgs e)
        {

            showSubMenu(panelToolsSubMenu);

        }
        #region ToolsSubMenu
        private void button13_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            openChildForm(new Form2());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            openChildForm(new Form3());
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
       
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //this.Location = new Point(0, 0);

            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            t = new System.Timers.Timer();
            t.Interval = 10000000;
            t.Elapsed += OntimeEvent;
        }

        private void OntimeEvent(object sender, ElapsedEventArgs e)
        {
            //Invoke(new Action(() =>
            //{
            //    s += 1;
            //    if (s == 60)
            //    {
            //        s = 0;
            //        m += 1;

            //    }
            //    if (m == 60)
            //    {
            //        m = 0;
            //        h += 1;
            //    }
            //    textBox2.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            //}));

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            circularProgressBar1.Value += 1;

            circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";

            if (circularProgressBar1.Value == 10)
            {
                label1.Visible = true;
                label1.Text = "Getting Document headers";
            }

            if (circularProgressBar1.Value == 30)
            {
                label1.Text = "Checking Necessary Parameters";
            }

            if (circularProgressBar1.Value == 50)
            {
                label1.Text = "Analysing Document for threat";
            }

            if (circularProgressBar1.Value == 80)
            {
                label1.Text = "Closing Background Analysing...";

            }

            if (circularProgressBar1.Value == 95)
            {
                label1.Text = "Showing Results...";
            }
            if (circularProgressBar1.Value == 100)
            {
                
                timer1.Enabled = false;
                label8.Visible = true;
                label9.Visible = true;
                circularProgressBar1.Value = 0;
                button1.Enabled = true;
                pictureBox3.Visible = true;

            }



        }
        

    private void button1_Click_2(object sender, EventArgs e)
        {

        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            richTextBox1.Clear();
            label9.Visible = false;
            label8.Visible = false;
            label8.ForeColor = Color.White;
            label8.Text = "Please Wait...";
            label9.Text = "NULL";
            //pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = null;
            //label8.ResetText();

            
            if (textBox1.Text.Contains(".pdf") == true)
            {
                backgroundWorker1.RunWorkerAsync();
                t.Start();
                timer1.Enabled = true;
                //Thread th = new Thread(() => {
                //    this.BeginInvoke((Action)delegate ()
                //    {
                //        Option1_ExecProcess(); t.Start();
                //        timer1.Enabled = true;
                //    });
                //});
                //th.Start();


                //if(!backgroundWorker1.IsBusy)
                //{
                //    backgroundWorker1.RunWorkerAsync();
                //}

                ////button1.Visible = false;
                //button3.Visible = true;
                ////label1.Visible = true;
                ////pictureBox2.Visible = false;
                ////label2.Visible = true;

               
            }
            else
            {
                MessageBox.Show("First select a pdf file","Info | Analyze PDF" ,MessageBoxButtons.OK);
            }


        }
        static string m;
        void Option1_ExecProcess()
        {
            var script = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\pdfid.py";

            var processInfo = new ProcessStartInfo("cmd.exe", "/c python.exe" + " " + script + " " + textBox4.Text)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = @"C:\Windows\System32\"
            };

            StringBuilder sb = new StringBuilder();
            Process p = Process.Start(processInfo);
            p.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            p.BeginOutputReadLine();
            p.WaitForExit();
            m = sb.ToString();
            // 1) Create Process Info
            //var psi = new ProcessStartInfo();
            //psi.FileName = @"C:\Python27\python.exe";


            //// 2) Provide script and arguments
            //var script = "C:\\Users\\"+Environment.UserName+"\\AppData\\Local\\Temp\\pdfid.py";
            ////var start = "2019-1-1";
            ////var end = "2019-1-22";
           
            //psi.Arguments = script + " " + textBox4.Text;

            //// 3) Process configuration
            //psi.UseShellExecute = false;
            //psi.CreateNoWindow = true;
            //psi.RedirectStandardOutput = true;
            //psi.RedirectStandardError = true;

            //// 4) Execute process and get output
            //var errors = "";
            //var results = "";

            //using (var process = Process.Start(psi))
            //{
            //    errors = process.StandardError.ReadToEnd();
            //    results = process.StandardOutput.ReadToEnd();
            //}

            // 5) Display output
            //MessageBox.Show("ERRORS:" + errors);

            //MessageBox.Show(errors);
            //MessageBox.Show();
            //MessageBox.Show("Results:");
            // MessageBox.Show(results);
            //richTextBox1.SelectAll();
            //richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            //richTextBox1.Text = Regex.Replace(richTextBox1.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);
           // m = results;



        }
        
       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Option1_ExecProcess();
            

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            
            
        }
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
           
             richTextBox1.Text = m;
            
                while (richTextBox1.Text.Length > 0)
                {


                    string line = richTextBox1.Lines.FirstOrDefault(l => l.Contains("AA"));

                    if (line != null)
                    {

                        if (Convert.ToInt32(line.Substring(line.Length - 1)) == 0)
                        {

                            string line2 = richTextBox1.Lines.FirstOrDefault(l => l.Contains("OpenAction"));
                            if (line2 != null)
                            {
                                if (Convert.ToInt32(line2.Substring(line2.Length - 1)) == 0)
                                {
                                    string line3 = richTextBox1.Lines.FirstOrDefault(l => l.Contains("JS"));
                                    if (line3 != null)
                                    {
                                        if (Convert.ToInt32(line3.Substring(line3.Length - 1)) == 0)
                                        {
                                            string line4 = richTextBox1.Lines.FirstOrDefault(l => l.Contains("JavaScript"));
                                            if (line4 != null)
                                            {
                                                if (Convert.ToInt32(line4.Substring(line4.Length - 1)) == 0)
                                                {
                                                    label8.ForeColor = Color.LawnGreen;
                                                    //label8.Visible = true;
                                                    label8.Text = "No Threat Found!";
                                                    //label9.Visible = true;
                                                    label9.Text = "PDF document is safe to open";
                                                    pictureBox3.Image = PlayerUI.Properties.Resources.icons8_check_document_64__2_;
                                                }

                                            }
                                            else
                                            {
                                                label8.ForeColor = Color.Red;
                                                //label8.Visible = false;
                                                label8.Text = "Warning";
                                                //label9.Visible = false;
                                                label9.Text = "PDF document not safe to open, contains JavaScript";
                                                pictureBox3.Image = PlayerUI.Properties.Resources.icons8_warning_48;
                                                //pictureBox2.Visible = true;
                                        }
                                    }

                                    }
                                    else
                                    {
                                        label8.ForeColor = Color.Red;
                                        //label8.Visible = false;
                                        label8.Text = "Warning";
                                        //label9.Visible = false;
                                        label9.Text = "PDF document not safe to open, contains JavaScript";
                                        pictureBox3.Image = PlayerUI.Properties.Resources.icons8_warning_48;
                                        //pictureBox2.Visible = true;
                                    }

                                }
                                else
                                {

                                    label8.ForeColor = Color.Orange;
                                    //label8.Visible = false;
                                    label8.Text = "Warning";
                                    //label9.Visible = false;
                                    label9.Text = "PDF document not safe to open";
                                    pictureBox3.Image = PlayerUI.Properties.Resources.icons8_warning_48;
                                    //pictureBox2.Visible = true;
                                    //label10.Text = "Tip: Scan using virus total";
                                }
                            }


                        }
                        else
                        {
                            label8.ForeColor = Color.Orange;
                            //label8.Visible = false;
                            label8.Text = "Warning";
                           // label9.Visible = false;
                            label9.Text = "PDF document not safe to open, performs automatic\nactions when document is viewed";
                            pictureBox3.Image = PlayerUI.Properties.Resources.icons8_warning_48;
                           // pictureBox2.Visible = true;
                        }



                    }
                    else
                    {

                        label8.ForeColor = Color.Orange;
                        //label8.Visible = false;
                        label8.Text = "Warning";
                        //label9.Visible = false;
                        label9.Text = "PDF document not safe to open, performs automatic\nactions when document is viewed";
                        pictureBox3.Image = PlayerUI.Properties.Resources.icons8_warning_48;
                       // pictureBox2.Visible = true;
                    }

                break;

                }
                //if (richTextBox1.Text.Contains("JS"))
                //{
                //    MessageBox.Show("File may not secure");
                //}

            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button13_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void button2_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnMedia_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnExit_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnTools_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnHelp_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}


