﻿//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Queja : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Queja()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Queja ORDER BY idQueja");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Puesto ofer = new Puesto();
            ofer.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Representante pago = new Representante();
            pago.Show();
        }

        private void Paciente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string tipoqueja = textBox1.Text;
            string fecha = textBox2.Text;
            consulta = "INSERT INTO Queja (tipoqueja, fecha) values ('" + tipoqueja + "', '" + fecha + "', '"  + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string tipoqueja = textBox1.Text;
            string fecha = textBox2.Text;
            int idQueja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Queja SET tipoqueja = '" + tipoqueja + "',fecha = '" + fecha + "' WHERE idQueja = " + idQueja.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idQueja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Queja SET Estatus = False WHERE idPaciente = " + idQueja.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
