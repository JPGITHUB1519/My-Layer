using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Cliente
    {
        private int idcliente;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string email;
        private bool status;

        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
 
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
      
        public string Email
        {
            get { return email; }
            set { email = value; }
        } 

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public Cliente()
        {

        }

        public Cliente(int idcliente, string nombre, string apellido, string direccion, string telefono, string email, bool status)
        {
            this.idcliente = idcliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.status = status;
        }

        public string Act_Cliente(Cliente cliente)
        {
            string rpta = "";
            try
            {
                DataSet ds = new DataSet();
                // agregando parametros al metodo execute query
                string query = "SP_ACTCLIENTE";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idcliente", cliente.Idcliente);
                parameters.Add("@nombre", cliente.Nombre);
                parameters.Add("@apellido", cliente.Apellido);
                parameters.Add("@direccion", cliente.Direccion);
                parameters.Add("@telefono", cliente.Telefono);
                parameters.Add("@email", cliente.Email);
                parameters.Add("@estatus", cliente.Status);
                ds = dbconnection.execute_query(query, parameters);

                // if the query cannot be executed notify the error
                if (ds == null)
                {
                    rpta = "Error Insertando";
                }
                else
                {
                    rpta = "REGISTRO REGISTRADO/ACTUALIZADO EXITOSAMENTE";
                }

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            return rpta;
        }

        public string Delete_Cliente(Cliente cliente)
        {
            string rpta;
            try
            {
                DataSet ds = new DataSet();
                string query = "SP_DELETE_CLIENTE";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idcliente", cliente.Idcliente);
                ds = dbconnection.execute_query(query, parameters);
                rpta = "REGISTRO ELIMINADO EXITOSAMENTE";
            }
            catch (Exception ex)
            {
                rpta = "ERROR";
            }
            return rpta;
        }

        public DataSet Select_Cliente()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SP_SELECT_CLIENTE";
                ds = dbconnection.execute_query(query);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }

        public DataSet FilterbyID(Cliente cliente)
        {
            DataSet ds = new DataSet();

            try
            {
                string query = "SP_FILTERID_CLIENTE";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idcliente", cliente.Idcliente);
                ds = dbconnection.execute_query(query, parameters);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }

        public DataSet FilterByName(Cliente cliente)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SP_FILTERBYNAME_CLIENTE";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@nombre", cliente.Nombre);
                ds = dbconnection.execute_query(query, parameters);

            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }
    }
}
