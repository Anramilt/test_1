using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Postrgresql_Datagridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5433;Database=test_bd;User Id=postgres;Password =1401");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection= conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from company";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if(dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource= dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
