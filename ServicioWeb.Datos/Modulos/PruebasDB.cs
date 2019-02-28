using ServicioWeb.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWeb.Datos.Modulos
{
    public class PruebasDB
    {
        public List<EntPrueba> DameEntidad()
        {


            try
            {
                List<EntPrueba> lst = new List<EntPrueba>();

                using (JuguetesEntities contexto = new JuguetesEntities())
                {
                    lst = (from ent in contexto.Juguete
                           select new EntPrueba
                           {
                               Id = ent.Jugue_Id,
                               Nombre = ent.Jugue_Nombre,

                           }).ToList();
                }


                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);

            }

        }

        public List<EntPrueba> dameRegistro(EntPrueba filtro)
        {


            try
            {
                List<EntPrueba> rest = new List<EntPrueba>();
                using (JuguetesEntities contexto = new JuguetesEntities())
                {
                    rest = (from ent in contexto.Juguete

                            select new EntPrueba
                            {
                                Id = ent.Jugue_Id,
                                Nombre = ent.Jugue_Nombre,

                            }).Where(x => x.Id == filtro.Id || x.Nombre == filtro.Nombre).ToList();
                }
                return rest;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);

            }



        }



        public string actualizaPrueba(FiltroPrueba filtro)
        {
            string res = "";
            using (JuguetesEntities contexto = new JuguetesEntities())
            {
                Juguete newentPrueba = new Juguete();              
                DateTime DiaHora = contexto.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                Juguete oldentPrueba = contexto.Juguete.Where(x => x.Jugue_Id == filtro.Jugue_Id).FirstOrDefault(); 
                if (oldentPrueba != null)
                {
                    oldentPrueba.Jugue_Nombre = filtro.Jugue_Nombre;
                    oldentPrueba.Jugue_Existencia = oldentPrueba.Jugue_Existencia;
                    oldentPrueba.Jugue_Fecha_Alta = DiaHora;
                    oldentPrueba.Jugue_Precio = oldentPrueba.Jugue_Precio;
                    oldentPrueba.Jugue_Estatus = oldentPrueba.Jugue_Estatus;
                    oldentPrueba.Jugue_Foto = oldentPrueba.Jugue_Foto;
                    oldentPrueba.Jugue_Costo = oldentPrueba.Jugue_Costo;
                    res = "Actualizacion Exitosa";
                }
                else
                {
                    newentPrueba.Jugue_Id = filtro.Jugue_Id;
                    newentPrueba.Jugue_Nombre = "Otro";
                    newentPrueba.Jugue_Existencia = 1;
                    newentPrueba.Jugue_Marca_Id = 1;
                    newentPrueba.Jugue_Categoria_Id = 1;
                    newentPrueba.Jugue_Fecha_Alta = DiaHora;
                    newentPrueba.Jugue_Precio = 1000;
                    newentPrueba.Jugue_Estatus = true;
                    newentPrueba.Jugue_Foto = "sin foto";
                    newentPrueba.Jugue_Costo = 2;
                    res = "Se Inserto correctamente registro";                    
                    contexto.Juguete.Add(newentPrueba);
                }
              contexto.SaveChanges();
            }
            return res;
        }

        public string eliminarPrueba(FiltroPrueba filtro)
        {
            string res = "";
            using (JuguetesEntities contexto = new JuguetesEntities())
            {
                Juguete oldPrueba = contexto.Juguete.Where(x => x.Jugue_Id == filtro.Jugue_Id).FirstOrDefault();

                if (oldPrueba != null)
                {
                    contexto.Juguete.Remove(oldPrueba);
                    res = "Se elimino registro";
                }
                contexto.SaveChanges();
            }
                return res;
        }


    }
}