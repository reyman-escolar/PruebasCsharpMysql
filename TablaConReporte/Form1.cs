using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TablaConReporte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mostrarTabla(dgvListaProducto);
        }

        DataTable dt;
        MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=db_inventario; uid = root; pwd=Aa123");

        public void mostrarTabla(DataGridView dgv)
        {
            MySqlDataAdapter mda = new MySqlDataAdapter();
            try
            {
                mda = new MySqlDataAdapter("SELECT * FROM tb_productos", conectar);
                dt = new DataTable();
                mda.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Form reporte = new Reporte(textMayorA.Text);
            reporte.Show();
        }
    }
}
