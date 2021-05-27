using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TBDkursach
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlconnection = null;
        private SqlCommand command = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void procedure(string str)
        {
            command = new SqlCommand(str, sqlconnection);

            if (command.ExecuteNonQuery().ToString() == "-1")
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                MessageBox.Show("Успешно!");
            }

            command.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RailWayDB"].ConnectionString);

            sqlconnection.Open();
        }

        private void B_sales_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_sales", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_passangers_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_passengers", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_trains_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_trains", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_train_classes_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_train_classes", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_train_vagon_classes_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_train_vagon_classes", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_train_suppliers_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_train_suppliers", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_employees_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_employees", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_positions_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_positions", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_cities_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_cities", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_counties_select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM v_countries", sqlconnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void B_Sales_insert_Click(object sender, EventArgs e)
        {
            //procedure($"EXECUTE p_trains " +
            //    "@new_f_passenger = N'{passangerTXT.Text}', @new_f_train = N'{trainTXT.Text}', @new_f_train_class = N'{trainTypeTXT.Text}', @new_f_train_vagon_class = N'{vagonTypeTXT.Text}', @new_f_city_start = N'{startTXT.Text}', @new_f_city_finish = N'{finishTXT.Text}', @new_f_ticket_volume = N'{ticketVolTXT.Text}', @new_f_price = N'{priceTXT.Text}', @new_f_employee = N'{workerID.Text}', @new_f_data = N'{dateTXT.Text}';");
            procedure($"INSERT INTO t_sales(f_passenger, f_train, f_train_class, f_train_vagon_class, f_city_start, f_city_finish, f_ticket_volume, f_price, f_employee, f_data) VALUES(N'{passangerTXT.Text}', N'{trainTXT.Text}', N'{trainTypeTXT.Text}', N'{vagonTypeTXT.Text}', N'{startTXT.Text}', N'{finishTXT.Text}', N'{ticketVolTXT.Text}', N'{priceTXT.Text}', N'{workerID.Text}', SYSDATETIME());");
            //command.Parameters.AddWithValue("f_passenger", passangerTXT.Text);
            //command.Parameters.AddWithValue("f_train", trainTXT.Text);
            //command.Parameters.AddWithValue("f_train_class", trainTypeTXT.Text);
            //command.Parameters.AddWithValue("f_train_vagon_class", vagonTypeTXT.Text);
            //command.Parameters.AddWithValue("f_city_start", startTXT.Text);
            //command.Parameters.AddWithValue("f_city_finish", finishTXT.Text);
            //command.Parameters.AddWithValue("f_ticket_volume", ticketVolTXT.Text);
            //command.Parameters.AddWithValue("f_price", priceTXT.Text);
            //command.Parameters.AddWithValue("f_employee", workerID.Text);
            //command.Parameters.AddWithValue("f_data", $"{date.Day}.{date.Month}.{date.Year}");
            passangerTXT.Clear();
            trainTXT.Clear();
            trainTypeTXT.Clear();
            vagonTypeTXT.Clear();
            startTXT.Clear();
            finishTXT.Clear();
            ticketVolTXT.Clear();
            priceTXT.Clear();
            workerID.Clear();
        }

        private void B_train_Insert_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_trains @new_f_name = N'{trainNametxt.Text}', @new_f_train_supplier = N'{trainSupliertxt.Text}';");
            trainNametxt.Clear();
            trainSupliertxt.Clear();
        }

        private void B_supplier_Insert_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_train_suppliers @new_f_name = N'{supplierNametxt.Text}', @new_f_inn = N'{suplierInntxt.Text}';");
            supplierNametxt.Clear();
            suplierInntxt.Clear();
        }

        private void B_train_type_Insert_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_train_classes @new_f_name = N'{trainTypeNametxt.Text}';");
            trainTypeNametxt.Clear();
        }

        private void B_passenger_Input_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_passengers @new_f_name_1 = N'{name1txt.Text}', @new_f_name_2 = N'{name2txt.Text}', @new_f_name_3 = N'{name3txt.Text}', @new_f_passport = N'{passtxt.Text}';");
            name1txt.Clear();
            name2txt.Clear();
            name3txt.Clear();
            passtxt.Clear();
        }
    }
}
