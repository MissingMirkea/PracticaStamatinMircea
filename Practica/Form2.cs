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
using static System.Windows.Forms.AxHost; 


namespace Practica
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btnMaximize.Visible = true;
            btnMinimize.Visible = false;
        }
        // citește unde se află mouse ul în timpul clickului
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        // trimite acest mesaj
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        //conectarea
        SqlConnection conn = new SqlConnection("Data Source = MIRKO\\SQLEXPRESS; Initial Catalog = Toystore; Integrated Security = True;");

        //schimbarea butoanelor dupa marimea formei ( pe full screen sau in normal state )
        bool State = false;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }




        private void btnMinimize_Click(object sender, EventArgs e)
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

        private void btnTaskBar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
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

        private void Form2_Load(object sender, EventArgs e)
        {
            tabControl.ItemSize = new Size(0, 1);
            StockToys();
            ComboBoxes();
            DataOOF();
            Modify();
            tabControl1.ItemSize = new Size(0, 1);

        }

        private void StockToys()
        {
            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0 and toy_cantity >0 ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }
        private void DataOOF()
        {
            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Cantitatea ,  toy_price as Pret from outofstock where toy_cantity <1", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void Modify()
        {
            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0 and toy_cantity >0 ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void raport_Modify()
        {

            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0 and toy_cantity >0 ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void raport_OOF()
        {
            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Cantitatea ,  toy_price as Pret from outofstock where toy_cantity <1", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView5.DataSource = dt;
            dataGridView5.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void raport_Vanzari()
        {
            SqlCommand cmd = new SqlCommand("Select transaction_number as Nr_Tranzactiei , toys_name as Denumirea , toy_type  as Tip ,  toy_size as Marimea , toy_color as Culoare,toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Cantitatea , transaction_date as Data from vanzari", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView6.DataSource = dt;
            dataGridView6.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);

        }
        private void ComboBoxes()
        {
            conn.Open();
            string Sqlname = "select Distinct toys_name from toys";
            SqlCommand cmdname = new SqlCommand(Sqlname, conn);
            using (IDataReader drname = cmdname.ExecuteReader())
            {

                while (drname.Read())
                {
                    cmbName.Items.Add(drname[0].ToString());
                }
            }

            string SqlAge = "select Distinct toy_age from toys";
            SqlCommand cmdage = new SqlCommand(SqlAge, conn);
            using (IDataReader drage = cmdage.ExecuteReader())
            {


                while (drage.Read())
                {
                    cmbAge.Items.Add(drage[0].ToString());
                }
            }
            string Sqltip = "select Distinct toy_type from toys";
            SqlCommand cmdtip = new SqlCommand(Sqltip, conn);
            using (IDataReader drtip = cmdtip.ExecuteReader())
            {


                while (drtip.Read())
                {
                    cmbTip.Items.Add(drtip[0].ToString());
                }
            }

            string Sqlsize = "select Distinct toy_size from toys";
            SqlCommand cmdsize = new SqlCommand(Sqlsize, conn);
            using (IDataReader drsize = cmdsize.ExecuteReader())
            {
                while (drsize.Read())
                {
                    cmbSize.Items.Add(drsize[0].ToString());
                }
            }

            string Sqlcolor = "select Distinct toy_color from toys";
            SqlCommand cmdcolor = new SqlCommand(Sqlcolor, conn);
            using (IDataReader drcolor = cmdcolor.ExecuteReader())
            {
                while (drcolor.Read())
                {
                    cmbColor.Items.Add(drcolor[0].ToString());
                }
            }

            string Sqlprod = "select Distinct toy_color from toys";
            SqlCommand cmdprod = new SqlCommand(Sqlprod, conn);
            using (IDataReader drprod = cmdprod.ExecuteReader())
            {
                while (drprod.Read())
                {
                    cmbProd.Items.Add(drprod[0].ToString());
                }
            }

            string Sqlcountry = "select Distinct toy_country from toys";
            SqlCommand cmdcountry = new SqlCommand(Sqlcountry, conn);
            using (IDataReader drcountry = cmdcountry.ExecuteReader())
            {
                while (drcountry.Read())
                {
                    cmbCountry.Items.Add(drcountry[0].ToString());
                }
            }
            string Sqlprice = "select Distinct toy_price from toys";
            SqlCommand cmdprice = new SqlCommand(Sqlprice, conn);
            using (IDataReader drprice = cmdprice.ExecuteReader())

            {
                while (drprice.Read())
                {
                    cmbPrice.Items.Add(drprice[0].ToString());
                }
            }
            conn.Close();
        }
        private void cmbclear()
        {
            cmbName.SelectedItem = null;
            cmbTip.SelectedItem = null;
            cmbColor.SelectedItem = null;
            cmbSize.SelectedItem = null;
            cmbProd.SelectedItem = null;
            cmbCountry.SelectedItem = null;
            cmbPrice.SelectedItem = null;
            cmbAge.SelectedItem = null;



        }
        private void hide_tabs()
        {
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Hide();
            tabPage4.Hide();
        }
        private void pnlBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void raport_tabs()
        {
            Toys.Hide();
            OutOfStock.Hide();
            Vanzari.Hide();
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnToys_Click(object sender, EventArgs e)
        {
            hide_tabs();
            tabPage1.Show();
            tabControl.ItemSize = new Size(0, 1);
            StockToys();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnOutOfStock_Click(object sender, EventArgs e)
        {
            tabControl.ItemSize = new Size(0, 1);
            hide_tabs();
            tabPage2.Show();
            DataOOF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hide_tabs();
            tabPage3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            hide_tabs();
            tabPage4.Show();
            raport_Modify();
            raport_OOF();
            raport_Vanzari();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pnlBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBar_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void outofstockBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toysBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string Sql = "select * FROM toys";

            if (cmbName.SelectedItem != null || cmbAge.SelectedText != null || cmbCountry.SelectedItem != null || cmbColor.SelectedItem != null || cmbProd.SelectedItem != null || cmbSize.SelectedItem != null || cmbTip.SelectedItem != null || cmbPrice.SelectedItem != null)
                Sql += " WHERE toy_cantity >0 and toys_id> 0 and";

            if (cmbName.SelectedItem != null)
            {
                Sql += " toys_name = '" + cmbName.SelectedItem.ToString() + "' and";
            }

            if (cmbTip.SelectedItem != null)
            {
                Sql += " toy_type = '" + cmbTip.SelectedItem.ToString() + "' and";
            }

            if (cmbColor.SelectedItem != null)
            {
                Sql += " toy_color = '" + cmbColor.SelectedItem.ToString() + "' and";
            }

            if (cmbSize.SelectedItem != null)
            {
                Sql += " toy_size = '" + cmbSize.SelectedItem.ToString() + "' and";
            }

            if (cmbProd.SelectedItem != null)
            {
                Sql += " toy_manufacturer = '" + cmbProd.SelectedItem.ToString() + "' and";
            }

            if (cmbCountry.SelectedItem != null)
            {
                Sql += " toy_country = '" + cmbCountry.SelectedItem.ToString() + "' and";
            }

            if (cmbPrice.SelectedItem != null)
            {
                Sql += " toy_price ='" + cmbPrice.SelectedItem.ToString() + "' and";
            }

            if (cmbAge.SelectedItem != null)
            {
                Sql += " toy_age = '" + cmbAge.SelectedItem.ToString() + "' and";
            }

            Sql = Sql.Substring(0, Sql.Length - 3);

            using (SqlDataAdapter adapter = new SqlDataAdapter(Sql, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0 ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbclear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            


        }

        private void btnSearchAge_Click(object sender, EventArgs e)
        {
            if (txtAge1.Text != "" && txtAge2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_age BETWEEN @Age1 AND @Age2", conn);
                cmd.Parameters.AddWithValue("@Age1", txtAge1.Text);
                cmd.Parameters.AddWithValue("@Age2", txtAge2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }
            else if (txtAge1.Text != "" && txtAge2.Text == "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_age >= @Age1", conn);
                cmd.Parameters.AddWithValue("@Age1", txtAge1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }
            else if (txtAge1.Text == "" && txtAge2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_age <= @Age2", conn);
                cmd.Parameters.AddWithValue("@Age2", txtAge2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }

        }

        private void btnSearchPrice_Click(object sender, EventArgs e)
        {
            if (txtPrice1.Text != "" && txtPrice2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, " +
                    "toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS " +
                    "Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_price BETWEEN @Price1 AND @Price2", conn);
                cmd.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                cmd.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }
            else if (txtPrice1.Text != "" && txtPrice2.Text == "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, " +
                    "toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS " +
                    "Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_price >= @Price1 ", conn);
                cmd.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                cmd.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }

            else if (txtPrice1.Text == "" && txtPrice2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, " +
                    "toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS " +
                    "Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0 AND toy_price <= @Price2 ", conn);
                cmd.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                cmd.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtPrice1.Text != "" || txtPrice2.Text != "" || txtAge1.Text != "" || txtAge2.Text != "")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT toys_id AS Id, toys_name AS Denumirea, toy_type AS Tip, toy_size AS Marimea, toy_color AS Culoare, " +
                    "toy_manufacturer AS Producator, toy_country AS Tara, toy_age AS Varsta_Recomandata, toy_cantity AS Stock, toy_price AS " +
                    "Pret FROM toys WHERE toys_id > 0 AND toy_cantity > 0", conn))
                {
                    if (txtPrice1.Text != "" && txtPrice2.Text != "")
                    {
                        cmd.CommandText += " AND toy_price BETWEEN @Price1 AND @Price2";
                        cmd.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                        cmd.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                    }
                    else if (txtPrice1.Text == "" && txtPrice2.Text != "")
                    {
                        cmd.CommandText += " AND toy_price <= @Price2";
                        cmd.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                    }
                    else if (txtPrice1.Text != "" && txtPrice2.Text == "")
                    {
                        cmd.CommandText += " AND toy_price >= @Price1";
                        cmd.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                    }
                    if (txtAge1.Text != "" && txtAge2.Text != "")
                    {
                        cmd.CommandText += " AND toy_age BETWEEN @Age1 AND @Age2";
                        cmd.Parameters.AddWithValue("@Age1", txtAge1.Text);
                        cmd.Parameters.AddWithValue("@Age2", txtAge2.Text);
                    }
                    else if (txtAge1.Text == "" && txtAge2.Text != "")
                    {
                        cmd.CommandText += " AND toy_age <= @Age2";
                        cmd.Parameters.AddWithValue("@Age2", txtAge2.Text);
                    }
                    else if (txtAge1.Text != "" && txtAge2.Text == "")
                    {
                        cmd.CommandText += " AND toy_age >= @Age1";
                        cmd.Parameters.AddWithValue("@Age1", txtAge1.Text);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                    dataGridView1.DataSource = dt;
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView2.CurrentCell.RowIndex;

            txtName.Text = dataGridView2.Rows[row].Cells["Denumirea"].Value.ToString();
            txtType.Text = dataGridView2.Rows[row].Cells["Tip"].Value.ToString();
            txtSize.Text = dataGridView2.Rows[row].Cells["Marimea"].Value.ToString();
            txtColor.Text = dataGridView2.Rows[row].Cells["Culoare"].Value.ToString();
            txtProd.Text = dataGridView2.Rows[row].Cells["Producator"].Value.ToString();
            txtCountry.Text = dataGridView2.Rows[row].Cells["Tara"].Value.ToString();
            txtAge.Text = dataGridView2.Rows[row].Cells["Varsta_Recomandata"].Value.ToString();
            txtStock.Text = dataGridView2.Rows[row].Cells["Cantitatea"].Value.ToString();
            txtPrice.Text = dataGridView2.Rows[row].Cells["Pret"].Value.ToString();
        }

        private void btnAddOOF_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeOOF_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update toys set toy_cantity = @cantitatea , toy_price=@pret , toys_name=@name , toy_type=@tip , toy_size=@marime , toy_color=@culoare , toy_manufacturer=@producator , toy_country=@tara ,toy_age=@varsta  WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta;", conn);
            cmd.Parameters.AddWithValue("name", txtName.Text);
            cmd.Parameters.AddWithValue("tip", txtType.Text);
            cmd.Parameters.AddWithValue("marime", txtSize.Text);
            cmd.Parameters.AddWithValue("culoare", txtColor.Text);
            cmd.Parameters.AddWithValue("producator", txtProd.Text);
            cmd.Parameters.AddWithValue("tara", txtCountry.Text);
            cmd.Parameters.AddWithValue("varsta", txtAge.Text);
            cmd.Parameters.AddWithValue("cantitatea", txtStock.Text);
            cmd.Parameters.AddWithValue("pret", txtPrice.Text);
            SqlCommand cmd1 = new SqlCommand("Update outofstock set toy_cantity = @cantitatea , toy_price=@pret , toys_name=@name , toy_type=@tip , toy_size=@marime , toy_color=@culoare , toy_manufacturer=@producator , toy_country=@tara ,toy_age=@varsta  WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta;", conn);
            cmd1.Parameters.AddWithValue("name", txtName.Text);
            cmd1.Parameters.AddWithValue("tip", txtType.Text);
            cmd1.Parameters.AddWithValue("marime", txtSize.Text);
            cmd1.Parameters.AddWithValue("culoare", txtColor.Text);
            cmd1.Parameters.AddWithValue("producator", txtProd.Text);
            cmd1.Parameters.AddWithValue("tara", txtCountry.Text);
            cmd1.Parameters.AddWithValue("varsta", txtAge.Text);
            cmd1.Parameters.AddWithValue("cantitatea", txtStock.Text);
            cmd1.Parameters.AddWithValue("pret", txtPrice.Text);
            conn.Open();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            conn.Close();
            DataOOF();
            Modify();
            StockToys();


        }

        private void btnDeleteOOF_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM outofstock WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta AND toy_cantity=@cantitatea AND toy_price=@pret;", conn);
            cmd.Parameters.AddWithValue("name", txtName.Text);
            cmd.Parameters.AddWithValue("tip", txtType.Text);
            cmd.Parameters.AddWithValue("marime", txtSize.Text);
            cmd.Parameters.AddWithValue("culoare", txtColor.Text);
            cmd.Parameters.AddWithValue("producator", txtProd.Text);
            cmd.Parameters.AddWithValue("tara",  txtCountry.Text);
            cmd.Parameters.AddWithValue("varsta", txtAge.Text);
            cmd.Parameters.AddWithValue("cantitatea", txtStock.Text);
            cmd.Parameters.AddWithValue("pret", txtPrice.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            DataOOF();
            if (checkBoxToys.Checked)
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM toys WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta AND toy_cantity=@cantitatea AND toy_price=@pret;", conn);
                cmd1.Parameters.AddWithValue("name", txtName.Text);
                cmd1.Parameters.AddWithValue("tip", txtType.Text);
                cmd1.Parameters.AddWithValue("marime", txtSize.Text);
                cmd1.Parameters.AddWithValue("culoare", txtColor.Text);
                cmd1.Parameters.AddWithValue("producator", txtProd.Text);
                cmd1.Parameters.AddWithValue("tara", txtCountry.Text);
                cmd1.Parameters.AddWithValue("varsta", txtAge.Text);
                cmd1.Parameters.AddWithValue("cantitatea", txtStock.Text);
                cmd1.Parameters.AddWithValue("pret", txtPrice.Text);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void checkBoxToys_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView3.CurrentCell.RowIndex;

            txtNameMod.Text = dataGridView3.Rows[row].Cells["Denumirea"].Value.ToString();
            txtTipMod.Text = dataGridView3.Rows[row].Cells["Tip"].Value.ToString();
            txtSizeMod.Text = dataGridView3.Rows[row].Cells["Marimea"].Value.ToString();
            txtColorMod.Text = dataGridView3.Rows[row].Cells["Culoare"].Value.ToString();
            txtProdMod.Text = dataGridView3.Rows[row].Cells["Producator"].Value.ToString();
            txtCountryMod.Text = dataGridView3.Rows[row].Cells["Tara"].Value.ToString();
            txtAgeMod.Text = dataGridView3.Rows[row].Cells["Varsta_Recomandata"].Value.ToString();
            txtStockMod.Text = dataGridView3.Rows[row].Cells["Stock"].Value.ToString();
            txtPriceMod.Text = dataGridView3.Rows[row].Cells["Pret"].Value.ToString();
        }

        private void btnAddModify_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into toys(toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price) values (@name,@tip,@marime,@culoare,@producator,@tara,@varsta,@cantitatea,@pret)", conn);
            cmd.Parameters.AddWithValue("name", txtName.Text);
            cmd.Parameters.AddWithValue("tip", txtType.Text);
            cmd.Parameters.AddWithValue("marime", txtSize.Text);
            cmd.Parameters.AddWithValue("culoare", txtColor.Text);
            cmd.Parameters.AddWithValue("producator", txtProd.Text);
            cmd.Parameters.AddWithValue("tara", txtCountry.Text);
            cmd.Parameters.AddWithValue("varsta", txtAge.Text);
            cmd.Parameters.AddWithValue("cantitatea", txtStock.Text);
            cmd.Parameters.AddWithValue("pret", txtPrice.Text);

            SqlCommand cmd1 = new SqlCommand("insert into outofstock(toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price) values (@name,@tip,@marime,@culoare,@producator,@tara,@varsta,@cantitatea,@pret)", conn);

            cmd1.Parameters.AddWithValue("name", txtName.Text);
            cmd1.Parameters.AddWithValue("tip", txtType.Text);
            cmd1.Parameters.AddWithValue("marime", txtSize.Text);
            cmd1.Parameters.AddWithValue("culoare", txtColor.Text);
            cmd1.Parameters.AddWithValue("producator", txtProd.Text);
            cmd1.Parameters.AddWithValue("tara", txtCountry.Text);
            cmd1.Parameters.AddWithValue("varsta", txtAge.Text);
            cmd1.Parameters.AddWithValue("cantitatea", txtStock.Text);
            cmd1.Parameters.AddWithValue("pret", txtPrice.Text);

            conn.Open();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            conn.Close();
            Modify();
        }

        private void btnChangeModify_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update toys set toy_cantity = @cantitatea , toy_price=@pret , toys_name=@name , toy_type=@tip , toy_size=@marime , toy_color=@culoare , toy_manufacturer=@producator , toy_country=@tara ,toy_age=@varsta  WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta;", conn);
            cmd.Parameters.AddWithValue("name", txtNameMod.Text);
            cmd.Parameters.AddWithValue("tip", txtTipMod.Text);
            cmd.Parameters.AddWithValue("marime", txtSizeMod.Text);
            cmd.Parameters.AddWithValue("culoare", txtColorMod.Text);
            cmd.Parameters.AddWithValue("producator", txtProdMod.Text);
            cmd.Parameters.AddWithValue("tara", txtCountryMod.Text);
            cmd.Parameters.AddWithValue("varsta", txtAgeMod.Text);
            cmd.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
            cmd.Parameters.AddWithValue("pret", txtPriceMod.Text);
            SqlCommand cmd1 = new SqlCommand("Update outofstock set toy_cantity = @cantitatea , toy_price=@pret , toys_name=@name , toy_type=@tip , toy_size=@marime , toy_color=@culoare , toy_manufacturer=@producator , toy_country=@tara ,toy_age=@varsta  WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta;", conn);
            cmd1.Parameters.AddWithValue("name", txtNameMod.Text);
            cmd1.Parameters.AddWithValue("tip", txtTipMod.Text);
            cmd1.Parameters.AddWithValue("marime", txtSizeMod.Text);
            cmd1.Parameters.AddWithValue("culoare", txtColorMod.Text);
            cmd1.Parameters.AddWithValue("producator", txtProdMod.Text);
            cmd1.Parameters.AddWithValue("tara", txtCountryMod.Text);
            cmd1.Parameters.AddWithValue("varsta", txtAgeMod.Text);
            cmd1.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
            cmd1.Parameters.AddWithValue("pret", txtPriceMod.Text);
            conn.Open();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            conn.Close();
            DataOOF();
            Modify();
        }

        private void btnDeleteModify_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("DELETE FROM toys WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta AND toy_cantity=@cantitatea AND toy_price=@pret;", conn);
            cmd1.Parameters.AddWithValue("name", txtNameMod.Text);
            cmd1.Parameters.AddWithValue("tip", txtTipMod.Text);
            cmd1.Parameters.AddWithValue("marime", txtSizeMod.Text);
            cmd1.Parameters.AddWithValue("culoare", txtColorMod.Text);
            cmd1.Parameters.AddWithValue("producator", txtProdMod.Text);
            cmd1.Parameters.AddWithValue("tara", txtCountryMod.Text);
            cmd1.Parameters.AddWithValue("varsta", txtAgeMod.Text);
            cmd1.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
            cmd1.Parameters.AddWithValue("pret", txtPriceMod.Text);
            conn.Open();
            cmd1.ExecuteNonQuery();
            if (checkBoxToys.Checked)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM outofstock WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta AND toy_cantity=@cantitatea AND toy_price=@pret;", conn);
                cmd.Parameters.AddWithValue("name", txtNameMod.Text);
                cmd.Parameters.AddWithValue("tip", txtTipMod.Text);
                cmd.Parameters.AddWithValue("marime", txtSizeMod.Text);
                cmd.Parameters.AddWithValue("culoare", txtColorMod.Text);
                cmd.Parameters.AddWithValue("producator", txtProdMod.Text);
                cmd.Parameters.AddWithValue("tara", txtCountryMod.Text);
                cmd.Parameters.AddWithValue("varsta", txtAgeMod.Text);
                cmd.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
                cmd.Parameters.AddWithValue("pret", txtPriceMod.Text);
                cmd.ExecuteNonQuery();
                DataOOF();
            }
            conn.Close();
            Modify();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into vanzari (toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price,transaction_date) values (@name,@tip,@marime,@culoare,@producator,@tara,@varsta,@cantitatea,@pret,@data)", conn);
            DateTime dateTime = DateTime.Now;
            cmd.Parameters.AddWithValue("data", dateTime);
            cmd.Parameters.AddWithValue("name", txtNameMod.Text);
            cmd.Parameters.AddWithValue("tip", txtTipMod.Text);
            cmd.Parameters.AddWithValue("marime", txtSizeMod.Text);
            cmd.Parameters.AddWithValue("culoare", txtColorMod.Text);
            cmd.Parameters.AddWithValue("producator", txtProdMod.Text);
            cmd.Parameters.AddWithValue("tara", txtCountryMod.Text);
            cmd.Parameters.AddWithValue("varsta", txtAgeMod.Text);
            cmd.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
            cmd.Parameters.AddWithValue("pret", txtPriceMod.Text);
            SqlCommand cmd1 = new SqlCommand("Update toys set toy_cantity = toy_cantity - @cantitatea , toy_price=@pret , toys_name=@name , toy_type=@tip , toy_size=@marime , toy_color=@culoare , toy_manufacturer=@producator , toy_country=@tara ,toy_age=@varsta  WHERE toys_name=@name AND toy_type=@tip AND toy_size=@marime AND toy_color=@culoare AND toy_manufacturer=@producator AND toy_country=@tara AND toy_age=@varsta;", conn);
            cmd1.Parameters.AddWithValue("name", txtNameMod.Text);
            cmd1.Parameters.AddWithValue("tip", txtTipMod.Text);
            cmd1.Parameters.AddWithValue("marime", txtSizeMod.Text);
            cmd1.Parameters.AddWithValue("culoare", txtColorMod.Text);
            cmd1.Parameters.AddWithValue("producator", txtProdMod.Text);
            cmd1.Parameters.AddWithValue("tara", txtCountryMod.Text);
            cmd1.Parameters.AddWithValue("varsta", txtAgeMod.Text);
            cmd1.Parameters.AddWithValue("cantitatea", txtStockMod.Text);
            cmd1.Parameters.AddWithValue("pret", txtPriceMod.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            conn.Close();
            Modify();


        }
        // pentru toys oof si vanzari de creat cate o pagina pentru a putea face export in excel , creat selectul 
        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void OutOfStock_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportToys_Click(object sender, EventArgs e)
        {
                try
                {
                    CopyToCB();

                    Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlwb;
                    Microsoft.Office.Interop.Excel.Worksheet xlsh;
                    Microsoft.Office.Interop.Excel.Range xlr;

                    Object mv = System.Reflection.Missing.Value;

                    xls.Visible = true;

                    xlwb = xls.Workbooks.Add(mv);
                    xlsh = xls.Worksheets.get_Item(1);
                    xlr = xlsh.Cells[1, 1];
                    xlr.Select();

                    xlsh.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    xls.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void CopyToCB()
        {
            try
            {
                dataGridView4.SelectAll();
                DataObject obj = dataGridView4.GetClipboardContent();
                if (obj != null)
                    Clipboard.SetDataObject(obj);
                else
                    MessageBox.Show("Nu sunt date!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportOOF_Click(object sender, EventArgs e)
        {
            try
            {
                CopyToCB1();

                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlwb;
                Microsoft.Office.Interop.Excel.Worksheet xlsh;
                Microsoft.Office.Interop.Excel.Range xlr;

                Object mv = System.Reflection.Missing.Value;

                xls.Visible = true;

                xlwb = xls.Workbooks.Add(mv);
                xlsh = xls.Worksheets.get_Item(1);
                xlr = xlsh.Cells[1, 1];
                xlr.Select();

                xlsh.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                xls.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyToCB1()
        {
            try
            {
                dataGridView5.SelectAll();
                DataObject obj = dataGridView5.GetClipboardContent();
                if (obj != null)
                    Clipboard.SetDataObject(obj);
                else
                    MessageBox.Show("Nu sunt date!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportVanzari_Click(object sender, EventArgs e)
        {
            try
            {
                CopyToCB2();

                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlwb;
                Microsoft.Office.Interop.Excel.Worksheet xlsh;
                Microsoft.Office.Interop.Excel.Range xlr;

                Object mv = System.Reflection.Missing.Value;

                xls.Visible = true;

                xlwb = xls.Workbooks.Add(mv);
                xlsh = xls.Worksheets.get_Item(1);
                xlr = xlsh.Cells[1, 1];
                xlr.Select();

                xlsh.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                xls.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyToCB2()
        {
            try
            {
                dataGridView6.SelectAll();
                DataObject obj = dataGridView6.GetClipboardContent();
                if (obj != null)
                    Clipboard.SetDataObject(obj);
                else
                    MessageBox.Show("Nu sunt date!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Toys.Show();
            OutOfStock.Hide();
            Vanzari.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Toys.Show();
            OutOfStock.Hide();
            Vanzari.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OutOfStock.Show();
            Toys.Hide();
            Vanzari.Hide();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OutOfStock.Hide();
            Toys.Hide();
            Vanzari.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OutOfStock.Show();
            Toys.Hide();
            Vanzari.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OutOfStock.Hide();
            Toys.Hide();
            Vanzari.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Toys.Show();
            OutOfStock.Hide();
            Vanzari.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OutOfStock.Show();
            Toys.Hide();
            Vanzari.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OutOfStock.Hide();
            Toys.Hide();
            Vanzari.Show();

        }

        private void FormState_Tick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                btnMinimize.Visible = false;
                btnMaximize.Visible = true;
                State = false;
            }
            else
            {
                btnMinimize.Visible = true;
                btnMaximize.Visible = false;
                State = true;
            }
        }
    }
    
}

