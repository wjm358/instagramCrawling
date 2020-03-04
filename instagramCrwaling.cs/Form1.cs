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

namespace instagramCrwaling.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void checkFileName(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog dlg = (sender as OpenFileDialog);
            if (Path.GetExtension(dlg.FileName).ToLower() != ".txt")
            {
                e.Cancel = true;
                MessageBox.Show(".txt 파일이 아닙니다.");
                return;
            }
        }
        private void fileOpenButton_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "txt";
            fileDialog.FileOk += checkFileName;
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1; //파일다이얼로그가 열릴 때 파일 유형을 어떤걸 선택할것인지. 2이므로 *.txt로 설정되어 있음
            fileDialog.RestoreDirectory = true;
            //set initial screen as desktop
            string initial_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.InitialDirectory = initial_path;
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                fileNameTextbox.Text = fileName;

                System.IO.StreamReader file = new System.IO.StreamReader("yourfile.txt");
                string[] columnnames = file.ReadLine().Split(' ');
                DataTable dt = new DataTable();
                foreach (string c in columnnames)
                {
                    dt.Columns.Add(c);
                }
                string newline;
                while ((newline = file.ReadLine()) != null)
                {
                    DataRow dr = dt.NewRow();
                    string[] values = newline.Split(' ');
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }
                file.Close();
                dataGridView1.DataSource = dt;
            }
        }
    }
}
