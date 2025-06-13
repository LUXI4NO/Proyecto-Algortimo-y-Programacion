using System;

namespace Empresa_Constructora
{
    public class DniDuplicadoException : Exception
    {
        public DniDuplicadoException() : base("Error: DNI duplicado.") { }
    }

    public class LegajoDuplicadoException : Exception
    {
        public LegajoDuplicadoException() : base("Error: Legajo duplicado.") { }
    }
    
    public class ObreroDuplicadoEnGrupoException : Exception
	{
    public ObreroDuplicadoEnGrupoException() : base("El obrero ya está en este grupo.") { }
	}

    public class ObreroNoEncontradoException : Exception
    {
        public ObreroNoEncontradoException() : base("Error: Obrero no encontrado.") { }
    }

    public class GrupoObrerosNoEncontradoException : Exception
    {
        public GrupoObrerosNoEncontradoException() : base("Error: Grupo de Obreros no encontrado.") { }
    }
    
    public class CodigoObraDuplicadoException : Exception
	{
	    public CodigoObraDuplicadoException() : base("Error: Código de Obra duplicado.") { }
	}
	
	public class ObraNoEncontradaException : Exception
	{
	    public ObraNoEncontradaException() : base("Error: Obra no encontrada.") { }

	}
	
	public class JefeObraNoEncontradoException : Exception
	{
	    public JefeObraNoEncontradoException() : base("Error: Jefe de Obra no encontrada.") { }
	}
	
	public class NoHayGruposLibresException : Exception
	{
	    public NoHayGruposLibresException() : base("Error: Grupos Libres no encontrados.") { }
	}
	
	public class JefeYaAsignadoException : Exception
	{
    public JefeYaAsignadoException() : base("Error: Este jefe ya está asignado a otra obra en ejecución.") { }
	}

	public class ObraYaTieneJefeException : Exception
	{
	    public ObraYaTieneJefeException() : base("Error: La obra ya tiene un jefe asignado.") { }
	}
	
	public class ObraNoEstaEnEjecucionException : Exception
	{
	    public ObraNoEstaEnEjecucionException() : base("Error: La obra no está en ejecución.") { }
	}
	
	public class ObraYaFinalizadaException : Exception
	{
    public ObraYaFinalizadaException() : base("No se puede modificar una obra finalizada.") { }
	}

	public class ObreroYaAsignadoAObraException : Exception
	{
	    public ObreroYaAsignadoAObraException() : base("El obrero ya está asignado a esta obra.") { }
	}
}
