using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioWeb.Datos.Modulos;
using ServicioWeb.Modelos.Entidades;

namespace ServicioWeb.Negocio.Modulos
{
    public class PruebaManager
    {
        PruebasDB pruebasDB;

        public PruebaManager()
        {
            this.pruebasDB = new PruebasDB(); 
        }

        public List<EntPrueba> dameEntidad()
        {
            return this.pruebasDB.DameEntidad();

        }

        public List<EntPrueba> dameRegistros(EntPrueba filtro)
        {
            return this.pruebasDB.dameRegistro(filtro);
        }

        public string ActualizacionPrueba(FiltroPrueba filtro)
        {
            return this.pruebasDB.actualizaPrueba(filtro);
        }
        public string EliminarRegistro(FiltroPrueba filtro)
        {
            return this.pruebasDB.eliminarPrueba(filtro);
        }
    }
}
