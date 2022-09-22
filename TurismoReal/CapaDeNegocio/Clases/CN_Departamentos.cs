using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System.Data;

namespace CapaDeNegocio.Clases
{
    public class CN_Departamentos
    {
        private readonly CD_Departamentos objDatos = new CD_Departamentos();

        #region Consultar
        public CE_Departamentos Consulta(int idDepartamento)
        {
            return objDatos.CD_Consulta(idDepartamento);
        }
        #endregion

        #region Insertar   

        public void Insertar(CE_Departamentos Departamentos)
        {
            objDatos.CD_Insertar(Departamentos);
        }

        #endregion

        #region Eliminar   

        public void Eliminar(CE_Departamentos Departamentos)
        {
            objDatos.CD_Eliminar(Departamentos);
        }

        #endregion

        #region Actualizar Datos   

        public void ActualizarDatos(CE_Departamentos Departamentos)
        {
            objDatos.CD_ActualizarDatos(Departamentos);
        }

        #endregion

        #region ***********  

        public void ActualizarPass(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarPass(Usuarios);
        }

        #endregion

        #region CARGAR DEPTOS A LA VISTA

        public DataTable CargarDeptos()
        {
            return objDatos.CargarDepartamentos();
        }

        #endregion

        #region BUSCAR USUARIOS

        public DataTable Buscar(string buscar)
        {
            return objDatos.Buscar(buscar);
        }

        #endregion

        #region FILTRAR TIPO DE  USUARIOS

        public DataTable Filtro(string filtro)
        {
            return objDatos.Filtro(filtro);
        }

        #endregion

    }
}