using System;
using System.Collections;

namespace Empresa_Constructora
{
	public class GrupoObreros
	{
	    public int GrupoId { get; set; }
	    public string NombreGrupo { get; set; }
	    public ArrayList ListaObreros { get; set; } 
	    public bool EstaAsignado { get; private set; }
	    public int CodigoObraAsignada { get; private set; } 
	
	    public GrupoObreros(int id, string nombre)
	    {
	        GrupoId = id;
	        NombreGrupo = nombre;
	        ListaObreros = new ArrayList();
	        EstaAsignado = false;
	        CodigoObraAsignada = -1;
	    }
	
	    // Agrega obrero si no existe ya en el grupo
	    public void AgregarObrero(Obrero obrero)
	    {
	        foreach (Obrero o in ListaObreros)
	            if (o.Legajo == obrero.Legajo)
	                throw new ObreroDuplicadoEnGrupoException();
	
	        ListaObreros.Add(obrero);
	    }
	
	    // Elimina obrero por legajo
	    public void EliminarObrero(int legajo)
	    {
	        Obrero obreroAEliminar = null;
	        foreach (Obrero o in ListaObreros)
	            if (o.Legajo == legajo)
	            {
	                obreroAEliminar = o;
	                break;
	            }
	
	        if (obreroAEliminar != null)
	            ListaObreros.Remove(obreroAEliminar);
	    }
	
	    // Marca grupo asignado a obra
	    public void AsignarAObra(int codigoObra)
	    {
	        CodigoObraAsignada = codigoObra;
	        EstaAsignado = true;
	    }
	}
}
