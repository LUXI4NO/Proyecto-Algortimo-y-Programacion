namespace Empresa_Constructora
{
    // Representa un jefe de obra, hereda de Obrero
    public class JefeObra : Obrero
    {
        public double Bonificacion { get; set; } 

        // Constructor que inicializa datos del jefe y su bonificación
        public JefeObra(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo, double bonificacion)
            : base(nombre, apellido, dni, legajo, sueldo, cargo)
        {
            Bonificacion = bonificacion;
        } 
    }
}
