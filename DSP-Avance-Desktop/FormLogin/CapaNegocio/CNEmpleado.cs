using FormLogin.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormLogin.CapaNegocio
{
    public class CNEmpleado
    {
        private CDEmpleado Empl_D = new CDEmpleado();
        private String _Usuario;
        private String _Contraseña;
        public String Usuario
        {
            set { _Usuario = value; }
            get { return _Usuario; }
        }
        public String Contraseña
        {
            set { _Contraseña = value; }
            get { return _Contraseña; }
        }
        //CONTRUCTOR 
        public CNEmpleado() { }
        //FUNCIONES O METODOS

        
        public SqlDataReader IniciarSesion()
        {

            SqlDataReader Loguear;
            Loguear = Empl_D.iniciarSesion(Usuario, Contraseña);
            return Loguear;
        }

        public DataTable MostrarUser()
        {
            DataTable tabla = new DataTable();
            tabla = Empl_D.Mostrar();
            return tabla;
        }
        public void InsertarUser(string DUI, string nomUsuario, string password, string nombre, string email, string telefono, string tipo)
        {

            Empl_D.Insertar(Convert.ToInt32(DUI), nomUsuario, password, nombre, email, Convert.ToInt32(telefono), tipo);
        }

        public void EditarUser(string DUI, string nomUsuario, string password, string nombre, string email, string telefono, string tipo, string id)
        {
            Empl_D.Editar(Convert.ToInt32(DUI), nomUsuario, password, nombre, email, Convert.ToInt32(telefono), tipo, Convert.ToInt32(id));
        }

        public void EliminarUser(string id)
        {
            Empl_D.Eliminar(Convert.ToInt32(id));
        }
    }
}
