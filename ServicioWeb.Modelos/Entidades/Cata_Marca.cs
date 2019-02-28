
namespace ServicioWeb.Modelos.Entidades
{
   
    using System.Runtime.Serialization;
    [DataContract]
    public class Cata_Marca
    {
        [DataMember]
        public int Cata_Id;

        [DataMember]
        public string Cata_Nombre;
    }
}