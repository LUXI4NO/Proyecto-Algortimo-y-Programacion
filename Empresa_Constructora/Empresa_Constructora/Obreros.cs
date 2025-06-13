namespace Empresa_Constructora
{
    public class Obreros
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public int Legajo { get; set; }
        public double Sueldo { get; set; }
        public string Cargo { get; set; }

        public Obreros(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Legajo = legajo;
            Sueldo = sueldo;
            Cargo = cargo;
        }
    }
}