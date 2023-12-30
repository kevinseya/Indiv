using Indiv.Models;
using Indiv.Respository2;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Text;

class Program
{
    static ColoreRepo2 coloreRepo = new ColoreRepo2();
    static ClienteRepo2 clienteRepo = new ClienteRepo2();
    static CarroRepo2 carroRepo = new CarroRepo2();
    static DomicilioRepo2 domicilioRepo = new DomicilioRepo2();
    Indiv2Context context_general = new Indiv2Context();


    static void Main()
    {
        while (true)
        {
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1. CRUD Colores");
            Console.WriteLine("2. CRUD Clientes");
            Console.WriteLine("3. CRUD Carros");
            Console.WriteLine("4. CRUD Domicilios");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuCRUD("Colores", coloreRepo);
                    break;
                case "2":
                    MenuCRUD("Clientes", clienteRepo);
                    break;
                case "3":
                    MenuCRUD("Carros", carroRepo);
                    break;
                case "4":
                    MenuCRUD("Domicilios", domicilioRepo);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MenuCRUD(string entidad, object repo)
    {
        while (true)
        {
            Console.WriteLine($"\nMENU {entidad.ToUpper()}");
            Console.WriteLine($"1. Crear {entidad}");
            Console.WriteLine($"2. Buscar {entidad}");
            Console.WriteLine($"3. Actualizar {entidad}");
            Console.WriteLine($"4. Eliminar {entidad}");
            Console.WriteLine($"5. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        // Crear
                        Console.WriteLine($"CREAR {entidad}");
                        switch (entidad)
                        {
                            case "Colores":
                                Console.Write("Ingrese el color: ");
                                string nuevoColor = Console.ReadLine();
                                coloreRepo.guardar(new Colore { Color = nuevoColor });
                                break;
                            case "Clientes":
                                Console.Write("Ingrese los datos del cliente\n");
                                Console.Write("Ingrese los Apellidos: ");
                                string nuevoApellidos = Console.ReadLine();
                                Console.Write("Ingrese los Nombres: ");
                                string nuevoNombres = Console.ReadLine();
                                Console.Write("Ingrese la Identificacion: ");
                                string nuevoIdentificacion = Console.ReadLine();
                                clienteRepo.guardar(new Cliente {Apellidos = nuevoApellidos, Nombres = nuevoNombres, Identificacion = nuevoIdentificacion });

                                break;
                            case "Carros":
                                Console.Write("Ingrese los datos del carro\n");
                                Console.Write("Ingrese el modelo: ");
                                string nuevoModelo = Console.ReadLine();
                                Console.Write("Ingrese el año de fabricacion: ");
                                int.TryParse(Console.ReadLine(), out int nuevoAnioFab);
                                Console.Write("Ingrese el id del color: ");
                                int.TryParse(Console.ReadLine(),out int nuevoidColor);
                                carroRepo.guardar(new Carro { Modelo = nuevoModelo, Aniofabricacion = nuevoAnioFab, Colorid = nuevoidColor });
                                break;
                            case "Domicilios":
                                Console.Write("Ingrese los datos del domicilio\n");
                                Console.Write("Ingrese el numero de casa: ");
                                string nuevoNumCasa = Console.ReadLine();
                                Console.Write("Ingrese las calles de la casa: ");
                                string nuevoCalleCasa = Console.ReadLine();
                                Console.Write("Ingrese el id del cliente dueño de casa: ");
                                int.TryParse(Console.ReadLine(), out int nuevoidClienteC);
                                domicilioRepo.guardar(new Domicilio { Numerocasa=nuevoNumCasa, Calle=nuevoCalleCasa, Clientesid=nuevoidClienteC});
                                break;
                        }
                        Console.WriteLine($"{entidad} creado exitosamente.");
                        break;
                    case "2":
                        // Mostrar
                        Console.WriteLine($"BUSCAR {entidad}");
                        switch (entidad)
                        {
                            case "Colores":
                                Console.WriteLine("Selecciona la opcion de busqueda:");
                                Console.WriteLine("1. EQUALS");
                                Console.WriteLine("2. SQL NATIVO");
                                Console.WriteLine("3. SELECT ORM");
                                Console.WriteLine("4. LAMBDA");
                                Console.WriteLine("5. Salir");
                                string opcionCol = Console.ReadLine();
                                switch (opcionCol) {
                                    case "1":
                                        Console.Write("Ingrese el id del color a buscar: ");
                                        Indiv2Context context1_1 = new Indiv2Context();
                                        int.TryParse(Console.ReadLine(), out int idColor1);

                                        coloreRepo.consultaID(idColor1, context1_1);
                                        break;
                                    case "2":
                                        Console.Write("Ingrese el color a buscar: ");
                                        String color = Console.ReadLine();
                                        SqlParameter parametroColor = new SqlParameter("@color", color);
                                        Indiv2Context context2_1 = new Indiv2Context();
                                        coloreRepo.SQLNativo(parametroColor, context2_1);
                                        break;
                                    case "3":
                                        Console.Write("Ingrese el color a buscar: ");
                                        String Color2 = Console.ReadLine();
                                        Indiv2Context context3_1= new Indiv2Context();
                                        coloreRepo.SQLSelect(Color2, context3_1);
                                        break;
                                    case "4":
                                        Console.Write("Ingrese el color a buscar: ");
                                        String Color3 = Console.ReadLine();
                                        Indiv2Context context4_1 = new Indiv2Context();
                                        coloreRepo.SQLSelect(Color3, context4_1);
                                        break;
                                    case "5":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                                        break;
                                }

                                break;
                            case "Clientes":
                                Console.WriteLine("Selecciona la opcion de busqueda:");
                                Console.WriteLine("1. EQUALS");
                                Console.WriteLine("2. SQL NATIVO");
                                Console.WriteLine("3. SELECT ORM");
                                Console.WriteLine("4. LAMBDA");
                                Console.WriteLine("5. Salir");
                                string opcionCli = Console.ReadLine();
                                switch (opcionCli){

                                    case "1":
                                        Console.Write("Ingrese el id del cliente a buscar: ");
                                        Indiv2Context context1_2 = new Indiv2Context();
                                        int.TryParse(Console.ReadLine(), out int idCliente1);
                                        clienteRepo.consultaID(idCliente1, context1_2);
                                        break;
                                    case "2":
                                        Console.Write("Ingrese la identificacion del cliente a buscar: ");
                                        String identificacion = Console.ReadLine();
                                        SqlParameter parametroIdent = new SqlParameter("@identificacion", identificacion);
                                        Indiv2Context context2_2 = new Indiv2Context();
                                        clienteRepo.SQLNativo(parametroIdent, context2_2);
                                        break;
                                    case "3":
                                        Console.Write("Ingrese la identificacion del cliente a buscar: ");
                                        String Ident2 = Console.ReadLine();
                                        Indiv2Context context3_2 = new Indiv2Context();
                                        clienteRepo.SQLSelect(Ident2, context3_2);
                                        break;
                                    case "4":
                                        Console.Write("Ingrese el color a buscar: ");
                                        String Ident3 = Console.ReadLine();
                                        Indiv2Context context4_2 = new Indiv2Context();
                                        clienteRepo.SQLSelect(Ident3, context4_2);
                                        break;
                                    case "5":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                                        break;
                                }
                                break;
                            case "Carros":
                                Console.WriteLine("Selecciona la opcion de busqueda:");
                                Console.WriteLine("1. EQUALS");
                                Console.WriteLine("2. SQL NATIVO");
                                Console.WriteLine("3. SELECT ORM");
                                Console.WriteLine("4. LAMBDA");
                                Console.WriteLine("5. Salir");
                                string opcionCar = Console.ReadLine();
                                switch (opcionCar)
                                {

                                    case "1":
                                        Console.Write("Ingrese el id del carro a buscar: ");
                                        Indiv2Context context1_3 = new Indiv2Context();
                                        int.TryParse(Console.ReadLine(), out int idCarro1);
                                        carroRepo.consultaID(idCarro1, context1_3);
                                        break;
                                    case "2":
                                        Console.Write("Ingrese el modelo del carro a buscar: ");
                                        String modelo = Console.ReadLine();
                                        SqlParameter parametroCarr = new SqlParameter("@modelo", modelo);
                                        Indiv2Context context2_3 = new Indiv2Context();
                                        carroRepo.SQLNativo(parametroCarr, context2_3);
                                        break;
                                    case "3":
                                        Console.Write("Ingrese el modelo del carro a buscar: ");
                                        String Modl2 = Console.ReadLine();
                                        Indiv2Context context3_3 = new Indiv2Context();
                                        carroRepo.SQLSelect(Modl2, context3_3);
                                        break;
                                    case "4":
                                        Console.Write("Ingrese el modelo a buscar: ");
                                        String Modl3 = Console.ReadLine();
                                        Indiv2Context context4_3 = new Indiv2Context();
                                        carroRepo.SQLSelect(Modl3, context4_3);
                                        break;
                                    case "5":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                                        break;
                                }
                                break;
                            case "Domicilios":
                                Console.WriteLine("Selecciona la opcion de busqueda:");
                                Console.WriteLine("1. EQUALS");
                                Console.WriteLine("2. SQL NATIVO");
                                Console.WriteLine("3. SELECT ORM");
                                Console.WriteLine("4. LAMBDA");
                                Console.WriteLine("5. Salir");
                                string opcionDom = Console.ReadLine();
                                switch (opcionDom)
                                {

                                    case "1":
                                        Console.Write("Ingrese el id del domicilio a buscar: ");
                                        Indiv2Context context1_4 = new Indiv2Context();
                                        int.TryParse(Console.ReadLine(), out int idDom1);
                                        domicilioRepo.consultaID(idDom1, context1_4);
                                        break;
                                    case "2":
                                        Console.Write("Ingrese el número de casa a buscar: ");
                                        String numerocasa = Console.ReadLine();
                                        SqlParameter parametroDom = new SqlParameter("@numerocasa", numerocasa);
                                        Indiv2Context context2_4 = new Indiv2Context();
                                        domicilioRepo.SQLNativo(parametroDom, context2_4);
                                        break;
                                    case "3":
                                        Console.Write("Ingrese el número de casa a buscar: ");
                                        String Dom2 = Console.ReadLine();
                                        Indiv2Context context3_4 = new Indiv2Context();
                                        domicilioRepo.SQLSelect(Dom2, context3_4);
                                        break;
                                    case "4":
                                        Console.Write("Ingrese el numero de casa a buscar: ");
                                        String Dom3 = Console.ReadLine();
                                        Indiv2Context context4_4 = new Indiv2Context();
                                        domicilioRepo.SQLSelect(Dom3, context4_4);
                                        break;
                                    case "5":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "3":
                        // Actualizar
                        Console.WriteLine($"ACTUALIZAR {entidad}");
                        switch (entidad)
                        {
                            case "Colores":
                                Console.Write("Ingrese el id del color a actualizar: ");
                                Indiv2Context context1 = new Indiv2Context();
                                int.TryParse(Console.ReadLine(), out int idColor1);
                                coloreRepo.consultaID(idColor1, context1);
                                Console.Write("Ingrese el color a actualizar: ");
                                String actualizarColor = Console.ReadLine();
                                coloreRepo.actualizar(idColor1, actualizarColor, context1);
                                break;
                            case "Clientes":
                                Console.Write("Ingrese el id del cliente a actualizar: ");
                                Indiv2Context context2 = new Indiv2Context();
                                int.TryParse(Console.ReadLine(), out int idCliente1);
                                clienteRepo.consultaID(idCliente1, context2);
                                Console.Write("Ingrese los Nombres a actualizar: ");
                                String actualizarNombre = Console.ReadLine();
                                Console.Write("Ingrese los Apellidos a actualizar: ");
                                String actualizarApellido = Console.ReadLine();
                                Console.Write("Ingrese la Identificacion a actualizar: ");
                                String actualizarIdentificacion = Console.ReadLine();
                                clienteRepo.actualizar(idCliente1,actualizarNombre,actualizarApellido,actualizarIdentificacion, context2);
                                break;
                            case "Carros":
                                Console.Write("Ingrese el id del carro a actualizar: ");
                                Indiv2Context context3 = new Indiv2Context();
                                int.TryParse(Console.ReadLine(), out int idCarro1);
                                carroRepo.consultaID(idCarro1, context3);
                                Console.Write("Ingrese el Modelo a actualizar: ");
                                String actualizarModelo = Console.ReadLine();
                                Console.Write("Ingrese el año de fabricacion a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int actualizarAnioFab);
                                Console.Write("Ingrese el id de Color a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int actualizarIdColor);
                                carroRepo.actualizar(idCarro1, actualizarModelo, actualizarAnioFab, actualizarIdColor, context3);

                                break;
                            case "Domicilios":
                                Console.Write("Ingrese el id del domicilio a actualizar: ");
                                Indiv2Context context4 = new Indiv2Context();
                                int.TryParse(Console.ReadLine(), out int idDom1);
                                carroRepo.consultaID(idDom1, context4);
                                Console.Write("Ingrese la calle a actualizar: ");
                                String actualizarCalle = Console.ReadLine();
                                Console.Write("Ingrese el numero de casa a actualizar: ");
                                String actualizarNumCasa = Console.ReadLine();
                                Console.Write("Ingrese el id del cliente de casa a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int actualizarIdCLienteCasa);
                                domicilioRepo.actualizar(idDom1,actualizarCalle,actualizarNumCasa,actualizarIdCLienteCasa,context4);
                                break;
                        }
                        Console.WriteLine($"{entidad} actualizado exitosamente.");
                        break;
                        break;
                    case "4":
                        // Eliminar
                        Console.WriteLine($"ELIMINAR {entidad}");
                        switch (entidad)
                        {
                            case "Colores":
                                Console.Write("Ingrese el id del color a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idColor1);
                                Indiv2Context context1 = new Indiv2Context();
                                coloreRepo.eliminar(idColor1, context1);
                                break;
                            case "Clientes":
                                Console.Write("Ingrese el id del cliente a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idCliente1);
                                Indiv2Context context2 = new Indiv2Context();
                                clienteRepo.eliminar(idCliente1, context2);
                                break;
                            case "Carros":
                                Console.Write("Ingrese el id del carro a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idCarro1);
                                Indiv2Context context3 = new Indiv2Context();
                                carroRepo.eliminar(idCarro1, context3);
                                break;
                            case "Domicilios":
                                Console.Write("Ingrese el id del domicilio a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idDomicilio1);
                                Indiv2Context context4 = new Indiv2Context();
                                domicilioRepo.eliminar(idDomicilio1, context4);
                                break;
                        }
                        Console.WriteLine($"{entidad} eliminado exitosamente.");
                        break;
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
