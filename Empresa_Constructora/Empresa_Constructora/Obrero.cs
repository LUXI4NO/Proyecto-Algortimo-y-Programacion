namespace Empresa_Constructora
{
    // Clase que representa un obrero con sus datos básicos
    public class Obrero
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public int Legajo { get; set; }
        public double Sueldo { get; set; }
        public string Cargo { get; set; }

        // Constructor que inicializa los atributos del obrero
        public Obrero(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo)
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
