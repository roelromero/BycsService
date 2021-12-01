using BycsService.DBdatosTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BycsService
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {
        UsuarioTableAdapter Usuario = new UsuarioTableAdapter();
        DBdatos DBdatos = new DBdatos();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public DataSet SelectUsuario()
        {
            this.Usuario.Fill(this.DBdatos.Usuario);
            return DBdatos;
        }
        [WebMethod]
        public string InsertUsuario(string Nombres, string Apellidos, string Correo, string Direccion, string Tipousuario, string dni, string numeroceltel, string tiposervicio)
        {
            string resultado;
            try
            {
                this.Usuario.Insert(Nombres, Apellidos, Correo, Direccion, Tipousuario, dni, numeroceltel, tiposervicio);
                resultado = "Usuario Registrado";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado = "Error al insertar" + ex.Message.ToString();
                return resultado;
            }
        }
        [WebMethod]
        public string ActuaUsuario(string Nombres, string Apellidos, string Correo, string Direccion, string Tipousuario, string dni, string numeroceltel, string tiposervicio, int Id)
        {
            try
            {
                this.Usuario.Update(Nombres, Apellidos, Correo, Direccion, Tipousuario, dni, numeroceltel, tiposervicio, Id);
                return "actulizado correctamente";
            }
            catch (Exception ex)
            {
                return "error al actualizar" + ex.Message.ToString();
            }
        }
        [WebMethod]
        public string ElimUsuario(int Id)
        {
            try
            {
                this.Usuario.Delete(Id);
                return "eliminado";
            }
            catch (Exception ex)
            {
                return "error al eliminar" + ex.Message.ToString();
            }
        }

    }
}
