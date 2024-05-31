using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //conectarea la BD
        SqlConnection conn = new SqlConnection("Data Source = MIRKO\\SQLEXPRESS; Initial Catalog = Toystore; Integrated Security = True;");


        private void Form1_Load(object sender, EventArgs e)
        {
            
            btnMaximize.Visible = false;
        }

        //o secventa de cod de pe stack overflow ce ne ajuta sa facem drag la toata forma 

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //cât timp e apăsat atât timp va primi mesaje
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool State = true;


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //pentru a minimiza forma
            WindowState = FormWindowState.Minimized;

        }

        //schimbarea butoanelor dupa marimea formei ( pe full screen sau in normal state
        private void btnMaximize_Click(object sender, EventArgs e)
        {

            if (State == true)
            {
                WindowState = FormWindowState.Maximized;
                State = false;
                btnMaximize.Visible =  true;
                btnMinimize.Visible = false;

            }
            else
            {
                WindowState = FormWindowState.Normal;
                State = true;
                btnMinimize.Visible = true;
                btnMaximize.Visible = false;
            }
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {

            if (State == true)
            {
                WindowState = FormWindowState.Maximized;
                State = false;
                btnMaximize.Visible = true;
                btnMinimize.Visible = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                State = true;
                btnMinimize.Visible = true;
                btnMaximize.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string login = txtUsername.Text;
            try
            {
                conn.Open();
                //folosim select pentru a controla daca acest accountul este registrat in BD
                String query = "SELECT *FROM boss WHERE boss_name ='" + txtUsername.Text + "' AND boss_password = '" + txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dataT = new DataTable();
                sda.Fill(dataT);
                if (dataT.Rows.Count > 0)
                {
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    //else eror
                    string message = "Login or Password wrong";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                    MessageBox.Show(message, title, buttons);
                }

            }
            finally
            {
                //In orice caz inchidem conectiunea 
                conn.Close();
            }
        }
    }

}
