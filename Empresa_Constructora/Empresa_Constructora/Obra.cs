using System;
using System.Collections;

namespace Empresa_Constructora
{
    public class Obra
    {
        // Propiedades básicas de la obra
        public string Nombre { get; set; }
        public string TipoObra { get; set; }
        public int CodigoObra { get; set; }
        public string EstadoObra { get; set; }
        public double CostoObra { get; set; }
        public double PorcentajeAvance { get; private set; }  
        public JefeObra JefeAsignado { get; set; }
        public ArrayList GruposAsignados { get; set; } 

        // Constructor inicializa valores por defecto
        public Obra(string nombre, string tipoObra, int codigoObra, string estadoObra, double costoObra)
        {
			Nombre = nombre;
			TipoObra = tipoObra;
			CodigoObra = codigoObra;
			EstadoObra = estadoObra;
			CostoObra = costoObra;
			PorcentajeAvance = 0; 
            JefeAsignado = null;
            GruposAsignados = new ArrayList();
        }
        
        // Asigna jefe a la obra
        public void AsignarJefeObra(JefeObra jefe)
		{
		    JefeAsignado = jefe;
		}
		
		// Agrega grupo de obreros a la obra
		public void AsignarGrupo(GrupoObreros grupo)
		{
		    GruposAsignados.Add(grupo);
		}
		
		// Actualiza el avance y cambia estado según porcentaje
		public void ActualizarAvance(double nuevoAvance)
		{
		    if (nuevoAvance < 0 || nuevoAvance > 100)
		    {
		        Console.WriteLine("El avance debe estar entre 0 y 100. No se actualizó el avance.");
		        return;
		    }
		
		    PorcentajeAvance = nuevoAvance;
		
		    if (PorcentajeAvance == 100)
		        EstadoObra = "Finalizada";
		    else
		        EstadoObra = "Ejecucion";
		
		    Console.WriteLine("\nNuevo avance registrado: " + PorcentajeAvance + "%");
		    Console.WriteLine("\nEstado actual de la obra: " + EstadoObra);
		}
	
		// Desvincula jefe y limpia grupos asignados
		public void DesvincularJefeObra()
        {
            JefeAsignado = null;
            GruposAsignados.Clear();
        }
    }
}
