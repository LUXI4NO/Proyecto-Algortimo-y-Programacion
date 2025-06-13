using System;
using System.Collections;

namespace Empresa_Constructora
{
    class Program
    {
        // Instancia principal de la empresa, con su nombre.
        static Empresa miEmpresa = new Empresa("EMPRESA CONSTRUCTORA");

        static void Main(string[] args)
        {
            // Inicialización de los 8 grupos de obreros con nombres del tipo "Grupo A", "Grupo B", ..., "Grupo H".
            for (int i = 1; i <= 8; i++)
            {
                miEmpresa.TodosLosGrupos.Add(new GrupoObreros(i, "Grupo " + (char)('A' + i - 1)));
            }

            // Carga de datos iniciales predefinidos para facilitar pruebas del sistema.
            CargarDatosIniciales();


            // Variable de control del bucle del menú principal.
            bool continuar = true;

            while (continuar)
            {
            	Console.Clear();
                // Menú principal con opciones del sistema.
                Console.WriteLine("╔═══════════════════════════════════════════════╗");
				Console.WriteLine("║               Menu Principal                  ║");
				Console.WriteLine("╚═══════════════════════════════════════════════╝");
                Console.WriteLine("  1  - Registrar nuevo obrero");
                Console.WriteLine("  2  - Asignar obrero a un grupo de trabajo");
                Console.WriteLine("  3  - Eliminar obrero registrado");
                Console.WriteLine("  4  - Incorporar nuevo jefe de obra");
                Console.WriteLine("  5  - Registrar una nueva obra");
                Console.WriteLine("  6  - Asignar jefe de obra y grupo a una obra");
                Console.WriteLine("  7  - Actualizar el avance de una obra");
                Console.WriteLine("  8  - Asignar obrero a una obra");
                Console.WriteLine("  9  - Dar de baja a un jefe de obra");
                Console.WriteLine(" 10  - Acceder al submenú de reportes e informes");
                Console.WriteLine("  0  - Salir del sistema");
                Console.WriteLine("═══════════════════════════════════════════════");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                // Estructura de control para manejar la opción ingresada por el usuario.
                switch (opcion)
                {
                    case "1":
                        RegistrarObreroNuevo();
                        break;
                    case "2":
                        AsignarObreroAGrupo();
                        break;
                    case "3":
                        EliminarObrero();
                        break;
                    case "4":
                        RegistrarJefeDeObra();
                        break;
                    case "5":
                        RegistrarObraNueva();
                        break;
                    case "6":
                        AsignarJefeYGrupoAObra();
                        break;
                    case "7":
                        ActualizarAvanceObra();
                        break;
                    case "8":
                        AsignarObreroAObra();
                        break;
                    case "9":
                        DarDeBajaJefeDeObra();
                        break;
                    case "10":
                        SubmenuDeReportes();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, ingrese un número entre 0 y 10.");
                        break;
                }

                // Pausa opcional antes de volver a mostrar el menú.
                if (continuar)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nGracias por utilizar el sistema. ¡Hasta pronto!");
            Console.ReadKey(true);
        }

        // Método auxiliar que carga datos predefinidos para pruebas.
        static void CargarDatosIniciales()
        {
            // Se crea un obrero de ejemplo.
            Obrero obrero1 = new Obrero("Luciano", "Alvarez", "44585917", 73181, 1000000, "Ingeniero");

            // Se crea un jefe de obra de ejemplo.
            JefeObra jefe1 = new JefeObra("Ezequiel", "Alvarez", "44000000", 7300, 1000000, "Jefe de Obra", 5000);

            // Se crean dos obras con distinto estado.
            Obra obra = new Obra("Edificio Central", "remodelacion", 100, "Ejecucion", 2000000);
            Obra obra1 = new Obra("Edificio Central", "remodelacion", 101, "Finalizada", 2000000);

            // Se crean dos grupos de obreros.
            GrupoObreros grupo1 = new GrupoObreros(1, "Grupo A");
            GrupoObreros grupo2 = new GrupoObreros(2, "Grupo B");

            // Se asigna un obrero al grupo 1.
            grupo1.ListaObreros.Add(obrero1);

            // Se asigna el jefe y grupo a la obra finalizada.
            obra1.JefeAsignado = jefe1;
            obra1.GruposAsignados.Add(grupo1);

            // Se agregan los trabajadores y obras a la empresa.
            miEmpresa.TodosLosObreros.Add(obrero1);
            miEmpresa.TodosLosObreros.Add(jefe1);
            miEmpresa.TodasLasObrasEjecucion.Add(obra);
            miEmpresa.TodasLasObrasFinalizadas.Add(obra1);
            miEmpresa.TodosLosGrupos.Add(grupo1);
            miEmpresa.TodosLosGrupos.Add(grupo2);
        }

        // Método que permite registrar un nuevo obrero mediante consola.
        static void RegistrarObreroNuevo()
        {
            try
            {
                Console.Clear();
               	Console.WriteLine("╔══════════════════════════════════════════════════════╗");
				Console.WriteLine("║          SISTEMA DE REGISTRO DE PERSONAL OBRERO      ║");
				Console.WriteLine("╚══════════════════════════════════════════════════════╝");

				// Solicitud de datos al usuario
				Console.Write("Por favor, ingrese el nombre del obrero: ");
				string nombre = Console.ReadLine();
				
				Console.Write("Ingrese el apellido del obrero: ");
				string apellido = Console.ReadLine();
				
				Console.Write("Ingrese el número de DNI: ");
				string dni = Console.ReadLine();
				
				Console.Write("Ingrese el número de legajo: ");
				int legajo = int.Parse(Console.ReadLine());
				
				Console.Write("Ingrese el sueldo mensual en pesos: ");
				double sueldo = double.Parse(Console.ReadLine());
				
				Console.Write("Indique el cargo que desempeñará: ");
				string cargo = Console.ReadLine();

                // Se crea y contrata al nuevo obrero.
                Obrero nuevoObrero = new Obrero(nombre, apellido, dni, legajo, sueldo, cargo);
                miEmpresa.ContratarObrero(nuevoObrero);
            }
            catch (DniDuplicadoException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (LegajoDuplicadoException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
            }
        }
		
		static void AsignarObreroAGrupo()
		{
		    try
		    {
				Console.Clear();				
				// Encabezado profesional para la sección de asignación de obreros a grupos
				
				Console.WriteLine("╔══════════════════════════════════════════════════════╗");
				Console.WriteLine("║         SISTEMA DE ASIGNACIÓN DE OBREROS A GRUPOS    ║");
				Console.WriteLine("╚══════════════════════════════════════════════════════╝");
				
				// Solicitud de datos necesarios para la asignación
				Console.Write("Por favor, ingrese el número de legajo del obrero: ");
				int legajo = int.Parse(Console.ReadLine());
				
				Console.Write("Ingrese el ID del grupo (valores válidos: 1 a 8): ");
				int grupoId = int.Parse(Console.ReadLine());
		
		        miEmpresa.AsignarObreroAGrupo(legajo, grupoId);
		    }
		    catch (ObreroNoEncontradoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (GrupoObrerosNoEncontradoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}
	
	    static void EliminarObrero()
	    {
	        try
	        {
	        	Console.Clear();
		    					
				// Encabezado profesional para el sistema de eliminación de obreros
				Console.WriteLine("╔══════════════════════════════════════════════════════╗");
				Console.WriteLine("║           SISTEMA DE ELIMINACIÓN DE OBREROS          ║");
				Console.WriteLine("╚══════════════════════════════════════════════════════╝");
				
				// Solicitud del número de legajo del obrero a eliminar
				Console.Write("Por favor, ingrese el número de legajo del obrero que desea eliminar: ");
				int legajo = int.Parse(Console.ReadLine());

	            miEmpresa.EliminarObrero(legajo);
	        }
	        catch (ObreroNoEncontradoException ex)
	        {
	            Console.WriteLine("ERROR: " + ex.Message);
	        }
	        catch (Exception ex)
	        {
	            Console.WriteLine("ERROR INESPERADO: " + ex.Message);
	        }
	    }
	    
	    static void AsignarObreroAObra()
		{
		    try
		    {
				Console.Clear();
				
				// Encabezado profesional para el sistema de asignación de obreros a obra
				Console.WriteLine("╔════════════════════════════════════════════════════╗");
				Console.WriteLine("║          SISTEMA DE ASIGNACIÓN DE OBREROS A OBRA   ║");
				Console.WriteLine("╚════════════════════════════════════════════════════╝");
				
				// Solicitud del código de la obra para asignación
				Console.Write("Por favor, ingrese el código de la obra: ");
				int codigoObra = int.Parse(Console.ReadLine());
				
				// Solicitud del legajo del obrero a asignar
				Console.Write("Por favor, ingrese el legajo del obrero: ");
				int legajo = int.Parse(Console.ReadLine());

		
		        miEmpresa.AsignarObreroAObra(codigoObra, legajo);
		    }
		    catch (ObraYaFinalizadaException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (ObraNoEncontradaException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (ObreroNoEncontradoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (ObreroYaAsignadoAObraException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}
		
		static void RegistrarJefeDeObra()
		{
		    try
		    {
				Console.Clear();
				
				// Encabezado profesional para el sistema de registro de jefe de obra
				Console.WriteLine("╔════════════════════════════════════════════════╗");
				Console.WriteLine("║           SISTEMA DE REGISTRO DE JEFE          ║");
				Console.WriteLine("╚════════════════════════════════════════════════╝");
					
				Console.Write("Ingrese el nombre: ");
				string nombre = Console.ReadLine();
				
				// Solicitar el apellido del jefe de obra
				Console.Write("Ingrese el apellido: ");
				string apellido = Console.ReadLine();
				
				// Solicitar el número de DNI
				Console.Write("Ingrese el DNI: ");
				string dni = Console.ReadLine();
				
				// Solicitar el número de legajo
				Console.Write("Ingrese el legajo: ");
				int legajo = int.Parse(Console.ReadLine());
				
				// Solicitar el sueldo mensual
				Console.Write("Ingrese el sueldo mensual ($): ");
				double sueldo = double.Parse(Console.ReadLine());
				
				// Solicitar la bonificación adicional
				Console.Write("Ingrese la bonificación ($): ");
				double bonificacion = double.Parse(Console.ReadLine());
				
				// Validación para evitar duplicados en legajo y DNI
				foreach (Obrero obr in miEmpresa.TodosLosObreros)
				{
				    if (obr.Legajo == legajo)
				        throw new LegajoDuplicadoException();
				    if (obr.DNI == dni)
				        throw new DniDuplicadoException();
				}
				
				// Creación y agregado del nuevo jefe de obra
				JefeObra nuevoJefe = new JefeObra(nombre, apellido, dni, legajo, sueldo, "Jefe de Obra", bonificacion);
				miEmpresa.TodosLosObreros.Add(nuevoJefe);
				
				Console.WriteLine("\nJefe de Obra " + nombre + " " + apellido + " agregado correctamente.");

		    }
		    catch (LegajoDuplicadoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (DniDuplicadoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}
		
		static void RegistrarObraNueva()
		{		
		    try
		    {
		    	
				Console.Clear();
				
				Console.WriteLine("╔═══════════════════════════════════════════════╗");
				Console.WriteLine("║          SISTEMA DE REGISTRO DE OBRAS         ║");
				Console.WriteLine("╚═══════════════════════════════════════════════╝");
				
				// Solicitar el nombre de la obra
				Console.Write("Ingrese el nombre de la obra: ");
				string nombre = Console.ReadLine();
				
				// Solicitar el tipo de obra
				Console.Write("Ingrese el tipo de obra: ");
				string tipoObra = Console.ReadLine();
				
				// Solicitar el código numérico de la obra
				Console.Write("Ingrese el código de obra (número): ");
				int codigoObra = int.Parse(Console.ReadLine());
				
				// Solicitar el estado de la obra (Ejecución / Finalizada)
				Console.Write("Ingrese el estado de la obra (Ejecución/Finalizada): ");
				string estado = Console.ReadLine();
				
				// Solicitar el costo estimado de la obra
				Console.Write("Ingrese el costo estimado ($): ");
				double costo = double.Parse(Console.ReadLine());
				
				Obra obraNueva = new Obra(nombre, tipoObra, codigoObra, estado, costo);
		
		        miEmpresa.AgregarNuevaObra(obraNueva);
		
		    }
		    catch (CodigoObraDuplicadoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (ObraNoEncontradaException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}

		static void AsignarJefeYGrupoAObra()
		{
		    try
		    {
		    	
				Console.Clear();
				
				Console.WriteLine("╔═══════════════════════════════════════════════╗");
				Console.WriteLine("║      SISTEMA DE ASIGNACIÓN DE JEFE A OBRAS    ║");
				Console.WriteLine("╚═══════════════════════════════════════════════╝");
				
				// Solicitar el código identificador de la obra
				Console.Write("Ingrese el código de la obra: ");
				int codigoObra = int.Parse(Console.ReadLine());
				
				// Solicitar el legajo del jefe de obra a asignar
				Console.Write("Ingrese el legajo del jefe de obra: ");
				int legajoJefe = int.Parse(Console.ReadLine());

		        miEmpresa.AsignarJefeDeObra(codigoObra, legajoJefe);
		
		        Console.WriteLine("\nAsignación realizada correctamente.");
		    }
		    catch (ObraNoEncontradaException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (JefeObraNoEncontradoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}
		
		static void ActualizarAvanceObra()
		{
		    try
		    {
		        Console.Clear();
		
		        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
		        Console.WriteLine("║       SISTEMA DE ACTUALIZACIÓN DE AVANCE DE OBRA       ║");
		        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
		
		        // Solicita al usuario el código identificador de la obra a actualizar
		        Console.Write("Ingrese el código de la obra: ");
		        int codigo = int.Parse(Console.ReadLine());
		
		        // Solicita el nuevo porcentaje de avance de la obra, válido entre 0 y 100
		        Console.Write("Ingrese el nuevo porcentaje de avance (0 a 100): ");
		        double avance = double.Parse(Console.ReadLine());
		
		        // Actualiza el avance de la obra en la empresa
		        miEmpresa.ModificarAvanceObra(codigo, avance);
		    }
		    catch (ObraNoEncontradaException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}

		static void DarDeBajaJefeDeObra()
		{
		    try
		    {
		        Console.Clear();
		
		        // Encabezado del sistema de eliminación
		        Console.WriteLine("╔════════════════════════════════════════════════════╗");
		        Console.WriteLine("║        SISTEMA DE ELIMINACIÓN DE JEFE DE OBRA      ║");
		        Console.WriteLine("╚════════════════════════════════════════════════════╝");
		        
		        // Pide el legajo del jefe que se desea eliminar
		        Console.Write("Ingrese el legajo del jefe de obra a dar de baja: ");
		        int legajo = int.Parse(Console.ReadLine());
		
		        // Llama a la función para eliminar al jefe según legajo
		        miEmpresa.DarDeBajaJefe(legajo);
		    }
		    catch (JefeObraNoEncontradoException ex)
		    {
		        Console.WriteLine("ERROR: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("ERROR INESPERADO: " + ex.Message);
		    }
		}
		
		static void SubmenuDeReportes()
		{
		    bool seguir = true;
		
		    while (seguir)
		    {
		        Console.Clear();
		        // Muestra el menú de opciones de reportes
		        Console.WriteLine("╔═══════════════════════════════════════════════╗");
		        Console.WriteLine("║             Submenu de Impresion              ║");
		        Console.WriteLine("╚═══════════════════════════════════════════════╝");
		        Console.WriteLine("1 - Listado general de obreros");
		        Console.WriteLine("2 - Listado de obras en ejecución");
		        Console.WriteLine("3 - Obreros asignados a obras en ejecución");
		        Console.WriteLine("4 - Listado de obras finalizadas");
		        Console.WriteLine("5 - Jefes de obra asignados");
		        Console.WriteLine("6 - Porcentaje de obras de remodelación sin finalizar");
		        Console.WriteLine("7 - Volver al menú principal");
		        Console.WriteLine("═══════════════════════════════════════════════");
		        Console.Write("Ingrese una opción: ");
		
		        string opcion = Console.ReadLine();
		        Console.WriteLine();
		
		        switch (opcion)
		        {
		            case "1":
		                miEmpresa.MostrarObreros(); // Llama al método para mostrar todos los obreros
		                break;
		            case "2":
		                miEmpresa.MostrarObrasEnEjecucion(); // Muestra las obras que aún están en ejecución
		                break;
		            case "3":
		                miEmpresa.MostrarObrerosEnObras(); // Muestra los obreros asignados a esas obras
		                break;
		            case "4":
		                miEmpresa.MostrarObrasFinalizadas(); // Muestra obras finalizadas
		                break;
		            case "5":
		                miEmpresa.MostrarJefes(); // Muestra jefes de obra asignados
		                break;
		            case "6":
		                miEmpresa.MostrarPorcentajeRemodelacionFinalizadas(); // Muestra el % de obras de remodelación finalizadas
		                break;
		            case "7":
		                seguir = false; 
		                break;
		            default:
		                Console.WriteLine("Opción no válida."); // Opción inválida ingresada
		                break;
		        }
		
		        if (seguir)
		        {
		            Console.WriteLine("\nPresione una tecla para continuar...");
		            Console.ReadKey();
		        }
		    }
		}
    }
}
