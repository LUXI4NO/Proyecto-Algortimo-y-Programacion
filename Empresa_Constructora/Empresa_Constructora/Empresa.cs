using System;
using System.Collections;

namespace Empresa_Constructora
{
    public class Empresa
    {
    	// Propiedades principales: nombre, listas de obras en ejecución y finalizadas,
        // y listas de obreros y grupos de obreros.
        public string Nombre { get; set; }
        public ArrayList TodasLasObrasEjecucion { get; set; }
        public ArrayList TodasLasObrasFinalizadas { get; set; }
		public ArrayList TodosLosObreros { get; set; }
		public ArrayList TodosLosGrupos { get; set; }
		
		// Constructor inicializa las listas.
        public Empresa(string nombre)
        {
            Nombre = nombre;
            TodasLasObrasEjecucion = new ArrayList();
            TodasLasObrasFinalizadas = new ArrayList();
            TodosLosObreros = new ArrayList();
            TodosLosGrupos = new ArrayList();
        }
        
        // Método para contratar un obrero, validando duplicados por DNI y legajo.
		public void ContratarObrero(Obrero nuevoObrero)
		{
		    foreach (Obrero o in TodosLosObreros)
		    {
		        if (o.DNI == nuevoObrero.DNI)
		        {
		            throw new DniDuplicadoException();
		        }
		        if (o.Legajo == nuevoObrero.Legajo)
		        {
		            throw new LegajoDuplicadoException();
		        }
		    }
		
		    TodosLosObreros.Add(nuevoObrero);
		    Console.WriteLine("\nObrero contratado exitosamente: " + nuevoObrero.Nombre + " " + nuevoObrero.Apellido + " (Legajo: " + nuevoObrero.Legajo + ")");
		}
		
		// Asigna un obrero a un grupo, buscando ambos por identificador.		
		public void AsignarObreroAGrupo(int legajo, int grupoId)
		{
		    Obrero obreroEncontrado = null;
		    foreach (Obrero o in TodosLosObreros)
		    {
		        if (o.Legajo == legajo)
		        {
		            obreroEncontrado = o;
		            break;
		        }
		    }
		
		    if (obreroEncontrado == null)
		    {
		        throw new ObreroNoEncontradoException();
		    }
		
		    GrupoObreros grupoEncontrado = null;
		    foreach (GrupoObreros g in TodosLosGrupos)
		    {
		        if (g.GrupoId == grupoId)
		        {
		            grupoEncontrado = g;
		            break;
		        }
		    }
		
		    if (grupoEncontrado == null)
		    {
		        throw new GrupoObrerosNoEncontradoException();
		    }
		
		    try
		    {
		        grupoEncontrado.AgregarObrero(obreroEncontrado);
		        Console.WriteLine("\nObrero (legajo: " + legajo + ") asignado al grupo " + grupoId + " correctamente.");
		    }
		    catch (Exception ex) 
		    {
		        Console.WriteLine("\nNo se pudo asignar el obrero al grupo: " + ex.Message);
		    }
		}
		
		// Elimina un obrero y lo quita de todos los grupos donde esté asignado.
		public void EliminarObrero(int legajo)
		{
		    Obrero obreroAEliminar = null;
		    foreach (Obrero o in TodosLosObreros)
		    {
		        if (o.Legajo == legajo)
		        {
		            obreroAEliminar = o;
		            break;
		        }
		    }
		
		    if (obreroAEliminar != null)
		    {
		        TodosLosObreros.Remove(obreroAEliminar);
		
		        foreach (GrupoObreros g in TodosLosGrupos)
		        {
		            g.EliminarObrero(legajo);
		        }
		
		        Console.WriteLine("\nObrero eliminado: " + obreroAEliminar.Nombre + " " + obreroAEliminar.Apellido + " (Legajo: " + obreroAEliminar.Legajo + ")");
		    }
		    else
		    {
		        throw new ObreroNoEncontradoException();
		    }
		}		
		
		// Agrega una obra validando que no exista el código, y la clasifica según su estado.
		public void AgregarNuevaObra(Obra obra)
		{
		    foreach (Obra o in TodasLasObrasEjecucion)
		    {
		        if (o.CodigoObra == obra.CodigoObra)
		        {
		            throw new CodigoObraDuplicadoException();
		        }
		    }
		
		    foreach (Obra o in TodasLasObrasFinalizadas)
		    {
		        if (o.CodigoObra == obra.CodigoObra)
		        {
		            throw new CodigoObraDuplicadoException();
		        }
		    }
		
		    string estado = obra.EstadoObra.ToUpper();
		
		    if (estado == "EJECUCION")
		    {
		        TodasLasObrasEjecucion.Add(obra);
		    }
		    else if (estado == "FINALIZADA")
		    {
		        TodasLasObrasFinalizadas.Add(obra);
		    }
		    else
		    {
		        throw new Exception("Estado de obra no válido. Debe ser 'Ejecucion' o 'Finalizada'.");
		    }
		
		    Console.WriteLine("\nObra agregada: " + obra.Nombre + " (Estado: " + obra.EstadoObra + ")");
		}
		
		// Asigna un obrero a una obra, verificando que no esté ya asignado y que haya grupo disponible.
		public void AsignarObreroAObra(int codigoObra, int legajoObrero)
		{
		    Obra obra = null;
		    foreach (Obra o in TodasLasObrasEjecucion)
		    {
		        if (o.CodigoObra == codigoObra)
		        {
		            obra = o;
		            break;
		        }
		    }
		
		    if (obra == null)
		    {
		    	throw new ObraNoEncontradaException();
		    }
		        
		    if (obra.EstadoObra == "Finalizada")
		    {
		    	throw new ObraYaFinalizadaException();
		    }
		        
		    Obrero obrero = null;
		    foreach (Obrero o in TodosLosObreros)
		    {
		        if (o.Legajo == legajoObrero)
		        {
		            obrero = o;
		            break;
		        }
		    }
		
		    if (obrero == null)
		    {
		    	throw new ObreroNoEncontradoException();
		    }
		        
		    foreach (GrupoObreros grupo in obra.GruposAsignados)
		    {
		        foreach (Obrero o in grupo.ListaObreros)
		        {
		        	if (o.Legajo == obrero.Legajo)
		        	{
		        		throw new ObreroYaAsignadoAObraException();
		        	}	                
		        }
		    }
		
		    GrupoObreros grupoDisponible = null;
		    foreach (GrupoObreros grupo in TodosLosGrupos)
		    {
		        if (!grupo.EstaAsignado)
		        {
		            grupoDisponible = grupo;
		            break;
		        }
		    }
		
		    if (grupoDisponible == null)
		    {
		        Console.WriteLine("No hay grupos disponibles para asignar.");
		        return;
		    }
		
		    grupoDisponible.AgregarObrero(obrero);
		    grupoDisponible.AsignarAObra(codigoObra);
		    obra.AsignarGrupo(grupoDisponible);
		    Console.WriteLine("Obrero asignado correctamente.");
		}
		
		// Asigna un jefe de obra válido a una obra en ejecución que no tenga jefe asignado.
		public void AsignarJefeDeObra(int codigoObra, int legajoJefe)
		{
		    Obra obra = null;
		    foreach (Obra o in TodasLasObrasEjecucion)
		    {
		        if (o.CodigoObra == codigoObra)
		        {
		            obra = o;
		            break;
		        }
		    }
	
		    if (obra == null)
		    {
		    	throw new ObraNoEncontradaException();
		    }
		        		
		    if (obra.EstadoObra.ToUpper() != "EJECUCION")
		    {
		    	throw new ObraNoEstaEnEjecucionException();
		    }
		        	
		    if (obra.JefeAsignado != null)
		    {
		    	throw new ObraYaTieneJefeException();
		    }
		        
		    JefeObra jefeEncontrado = null;
		    foreach (Obrero obrero in TodosLosObreros)
		    {
		        if (obrero.Legajo == legajoJefe && obrero is JefeObra)
		        {
		            jefeEncontrado = (JefeObra)obrero;
		            break;
		        }
		    }
		
		    if (jefeEncontrado == null)
		    {
		    	throw new JefeObraNoEncontradoException();
		    }
		       		
		    foreach (Obra o in TodasLasObrasEjecucion)
		    {
		        if (o.JefeAsignado != null && o.JefeAsignado.Legajo == jefeEncontrado.Legajo)
		            throw new JefeYaAsignadoException();
		    }
		
		    GrupoObreros grupoDisponible = null;
		    foreach (GrupoObreros grupo in TodosLosGrupos)
		    {
		        if (!grupo.EstaAsignado)
		        {
		            grupoDisponible = grupo;
		            break;
		        }
		    }
		
		    if (grupoDisponible == null)
		    {
		    	throw new NoHayGruposLibresException();
		    }	     
		    
		    obra.AsignarJefeObra(jefeEncontrado);
		    obra.AsignarGrupo(grupoDisponible);
		    grupoDisponible.AsignarAObra(obra.CodigoObra);
		}
        
		// Modifica el avance porcentual de una obra, y mueve a finalizadas si alcanza 100%.
		public void ModificarAvanceObra(int codigoObra, double nuevoAvance)
		{
		    Obra obra = null;
		    bool estabaFinalizada = false;
		
		    // Buscar en obras en ejecución
		    foreach (Obra o in TodasLasObrasEjecucion)
		    {
		        if (o.CodigoObra == codigoObra)
		        {
		            obra = o;
		            break;
		        }
		    }
		
		    // Si no está en ejecución, buscar en finalizadas
		    if (obra == null)
		    {
		        foreach (Obra o in TodasLasObrasFinalizadas)
		        {
		            if (o.CodigoObra == codigoObra)
		            {
		                obra = o;
		                estabaFinalizada = true;
		                break;
		            }
		        }
		    }
		
		    if (obra == null)
		    {
		        throw new ObraNoEncontradaException();
		    }
		
		    double avanceAnterior = obra.PorcentajeAvance;
		    obra.ActualizarAvance(nuevoAvance);
		
		    if (obra.PorcentajeAvance == avanceAnterior)
		    {
		        Console.WriteLine("No se actualizó el avance porque el valor era inválido.");
		        return;
		    }
		
		    if (estabaFinalizada && obra.PorcentajeAvance < 100)
		    {
		        TodasLasObrasFinalizadas.Remove(obra);
		        TodasLasObrasEjecucion.Add(obra);
		        Console.WriteLine("La obra '" + obra.Nombre + "' volvió al estado de ejecución.");
		    }
		    else if (!estabaFinalizada && obra.PorcentajeAvance == 100)
		    {
		        TodasLasObrasEjecucion.Remove(obra);
		        TodasLasObrasFinalizadas.Add(obra);
		        Console.WriteLine("La obra '" + obra.Nombre + "' ha sido finalizada y movida a Obras Finalizadas.");
		    }
		    else
		    {
		        Console.WriteLine("\nEl avance de la obra '" + obra.Nombre + "' fue actualizado al " + nuevoAvance + "%.");
		    }
		}
        
        // Da de baja a un jefe de obra y lo desvincula de la obra si está asignado.
        public void DarDeBajaJefe(int legajoJefe)
        {
            JefeObra jefe = null;

            foreach (Obrero obrero in TodosLosObreros)
            {
                if (obrero.Legajo == legajoJefe && obrero is JefeObra)
                {
                    jefe = (JefeObra)obrero;
                    break;
                }
            }

            if (jefe == null)
            {
            	throw new JefeObraNoEncontradoException();
            }
                

            Obra obraAsignada = null;

            foreach (Obra obra in TodasLasObrasEjecucion)
            {
                if (obra.JefeAsignado != null && obra.JefeAsignado.Legajo == legajoJefe)
                {
                    obraAsignada = obra;
                    break;
                }
            }

            if (obraAsignada != null)
            {
                obraAsignada.DesvincularJefeObra();
            }

            TodosLosObreros.Remove(jefe);

            Console.WriteLine("\nEl jefe de obra con legajo " + legajoJefe + " fue dado de baja correctamente.");
        }
        
        // Muestra la lista completa de obreros con su tipo (jefe o no).
        public void MostrarObreros()
		{
		    Console.WriteLine("Listado general de obreros:\n");
		    
		    if (TodosLosObreros.Count == 0)
		    {
		        Console.WriteLine("No hay obreros registrados.");
		        return;
		    }
		
		    foreach (Obrero obrero in TodosLosObreros)
		    {
		        string tipo = (obrero is JefeObra) ? "Jefe de Obra" : "Obrero";
		        Console.WriteLine("- " + obrero.Nombre + " " + obrero.Apellido + " | Legajo: " + obrero.Legajo + " | Cargo: " + obrero.Cargo + " | Tipo: " + tipo);
		    }
		}
		
        // Muestra las obras que están actualmente en ejecución.
		public void MostrarObrasEnEjecucion()
		{
		    Console.WriteLine("\nObras en ejecución:");
		    if (TodasLasObrasEjecucion.Count == 0)
		    {
		        Console.WriteLine("No hay obras en ejecución.");
		        return;
		    }
		
		    foreach (Obra obra in TodasLasObrasEjecucion)
		    {
		        Console.WriteLine("- " + obra.Nombre + " (Código: " + obra.CodigoObra + ", Tipo: " + obra.TipoObra + ")");
		    }
		}
		
		// Muestra los obreros asignados a cada obra en ejecución, recorriendo grupos.
		public void MostrarObrerosEnObras()
		{
		    Console.WriteLine("\nObreros asignados a obras en ejecución:");
		    if (TodasLasObrasEjecucion.Count == 0)
		    {
		        Console.WriteLine("No hay obras en ejecución.");
		        return;
		    }
		
		    foreach (Obra obra in TodasLasObrasEjecucion)
		    {
		        if (obra.GruposAsignados != null && obra.GruposAsignados.Count > 0)
		        {
		            foreach (GrupoObreros grupo in obra.GruposAsignados)
		            {
		                if (grupo.ListaObreros != null && grupo.ListaObreros.Count > 0)
		                {
		                    foreach (Obrero obrero in grupo.ListaObreros)
		                    {
		                        Console.WriteLine("Obrero [Legajo: " + obrero.Legajo + "] " + obrero.Nombre + " " + obrero.Apellido + 
		                            " está asignado a la obra: " + obra.Nombre + " (Código: " + obra.CodigoObra + ")");
		                    }
		                }
		            }
		        }
		        else
		        {
		            Console.WriteLine("La obra " + obra.Nombre + " (Código: " + obra.CodigoObra + ") no tiene grupos asignados.");
		        }
		    }
		}
		
		// Muestra las obras que ya están finalizadas.
		public void MostrarObrasFinalizadas()
		{
		    Console.WriteLine("\nObras finalizadas:");
		    if (TodasLasObrasFinalizadas.Count == 0)
		    {
		        Console.WriteLine("No hay obras finalizadas.");
		        return;
		    }
		
		    foreach (Obra obra in TodasLasObrasFinalizadas)
		    {
		        Console.WriteLine("- " + obra.Nombre + " (Código: " + obra.CodigoObra + ", Tipo: " + obra.TipoObra + ")");
		    }
		}
		
		// Muestra los jefes asignados a las obras en ejecución.
		public void MostrarJefes()
		{
		    Console.WriteLine("\nJefes de obra asignados:");
		    bool hayJefes = false;
		
		    foreach (Obra obra in TodasLasObrasEjecucion)
		    {
		        if (obra.JefeAsignado != null)
		        {
		            hayJefes = true;
		            Console.WriteLine("- " + obra.JefeAsignado.Nombre + " " + obra.JefeAsignado.Apellido + " (Obra: " + obra.Nombre + ")");
		        }
		    }
		
		    if (!hayJefes)
		    {
		        Console.WriteLine("No hay jefes asignados actualmente.");
		    }
		}
		
		// Calcula y muestra el porcentaje de obras de remodelación que están finalizadas.
		public void MostrarPorcentajeRemodelacionFinalizadas()
		{
		    int totalRemodelacion = 0;
		    int remodelacionFinalizadas = 0;
		
		    foreach (Obra obra in TodasLasObrasEjecucion)
		    {
		        if (obra.TipoObra.ToLower().Replace("ó", "o") == "remodelacion")
		        {
		            totalRemodelacion++;
		        }
		    }
		
		    foreach (Obra obra in TodasLasObrasFinalizadas)
		    {
		        if (obra.TipoObra.ToLower().Replace("ó", "o") == "remodelacion")
		        {
		            totalRemodelacion++;
		            remodelacionFinalizadas++;
		        }
		    }
		
		    if (totalRemodelacion > 0)
		    {
		        double porcentaje = (double)remodelacionFinalizadas / totalRemodelacion * 100;
		        Console.WriteLine("Porcentaje de obras de remodelación finalizadas: " + porcentaje.ToString("0.00") + "%");
		    }
		    else
		    {
		        Console.WriteLine("No hay obras de tipo remodelación registradas.");
		    }
		}

    }
}
