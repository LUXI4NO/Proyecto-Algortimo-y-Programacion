using System;
using System.Collections;

namespace Empresa_Constructora
{
    public class Obra
    {
        public string Nombre { get; set; }
        public string TipoObra { get; set; }
        public int CodigoObra { get; set; }
        public string EstadoObra { get; set; }
        public double CostoObra { get; set; }
        public double PorcentajeAvance { get; private set; }
        public JefeObra JefeAsignado { get; set; }
        public ArrayList GruposAsignados { get; set; }

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
            
           	if (EstadoObra.ToUpper() == "FINALIZADA")
               	PorcentajeAvance = 100;
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
                return;

            PorcentajeAvance = nuevoAvance;
        }
	
		// Desvincula jefe y limpia grupos asignados
		public void DesvincularJefeObra()
        {
            JefeAsignado = null;
            GruposAsignados.Clear();
        }
    }
}
