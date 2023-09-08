using System.ComponentModel.Design;
using System.Diagnostics;
using NotasMatematicas.Entities;

internal class Program
{

    /**el profesor del area de matematicas necesita un programa que le permita registrar los estudiantes que se encuentran matriculados, la informacion que el docente posee de cada estaudiante es la siguiente:
-codigo del estudiante: con una logitud maxina de 15 caracteres
-nombre del estudiante: con una logitud macima de 40 caracteres
-correo electronico del estudiante: con una cantidad maxima de 40 caracteres
-edad del estudiante: debe ser un entero y no puede ser negativo
-direccion: con una longitud de 35 caracteres

No se conoce la cantidad de estudiantes que se registraron en la asignatura.

la universidad tiene como norma que cada estudiante debe presentar 4 quices 2 trabajos y 3 parciales

la notas de los equivalen a:
quices: 25%
trabajos: 15%
parciales: 60%

el programa debe permitirle al profesor generar los siguiente reportes:
1. listado general de notas del grupo paginado por 10 estudiantes
2. listado con las definitivas de cada nota y la nota final
el programa debe permitirle al docente hacer el ingreso de Quices, Trabajos y Parciales*/
    private static void Main(string[] args)
    {
        bool run = true;
        List<Estudiantes> ListEst = new List<Estudiantes>();
        while (run)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("+{0}+", new string('-', 30));
            Console.WriteLine("|         Menú Principal       |");
            Console.WriteLine("+{0}+", new string('-', 30));
            Console.WriteLine("| 1. Agregar Estudiante        |");
            Console.WriteLine("| 2. Ver Lista de Estudiantes  |");
            Console.WriteLine("| 3. Agregar Notas             |");
            Console.WriteLine("| 4. Ver Lista de Notas        |");
            Console.WriteLine("| 5. Salir                     |");
            Console.WriteLine("+{0}+", new string('-', 30));
            Console.Write("Seleccione una opción: ");
            try
            {
                string opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        AgregarEstudiante(ListEst);
                        break;
                    case "2":
                        VerListaEstudiantes(ListEst);
                        break;
                    case "3":
                        AgregarNotas(ListEst);
                        break;
                    case "4":
                        VerListaNotas(ListEst);
                        break;
                    case "5":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            catch (Exception e)
            {
                int lineaDeError = (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetFileLineNumber();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.WriteLine($"| error | {e.Message} |");
                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.WriteLine($"| Tipo  | {e.GetType()} |");
                Console.WriteLine("+{0}+", new string('-', Convert.ToString(e.GetType()).Length + 10));
                Console.WriteLine($"| Linea | {lineaDeError} |");
                Console.WriteLine("+{0}+", new string('-', Convert.ToString(lineaDeError).Length + 10));
                Console.ReadKey();
            }
        }
    }

    public static void AgregarEstudiante(List<Estudiantes> ListEst)
    {
        try
        {
            var read = "";
            Estudiantes estudiante = new Estudiantes();
            Console.WriteLine("Ingrese Codigo: ");
            read = Console.ReadLine();
            estudiante.Id = read.Length <= 15 ? read : throw new ArgumentException("El Codigo que Ingreso debe ser menor a 15 caracteres");
            Console.WriteLine("Ingrese Nombre: ");
            read = Console.ReadLine();
            estudiante.Nombre = read.Length <= 40 ? read : throw new ArgumentException("El Nombre que Ingreso debe ser menor a 40 caracteres");
            Console.WriteLine("Ingrese Email: ");
            read = Console.ReadLine();
            estudiante.Email = read.Length <= 40 ? read : throw new ArgumentException("El correo electronico del estudiante que Ingreso debe ser menor a 40 caracteres");
            Console.WriteLine("Ingrese Edad: ");
            read = Console.ReadLine();
            estudiante.Edad = int.Parse(read) >= 0 ? int.Parse(read) : throw new ArgumentException("La Edad que Ingreso debe ser positiva");
            Console.WriteLine("Ingrese Direccion: ");
            read = Console.ReadLine();
            estudiante.Direccion = read.Length <= 35 ? read : throw new ArgumentException("La Direccion que Ingreso debe ser menor a 35 caracteres");
            estudiante.Notas = new Notas();
            estudiante.Notas.NotasQuices = new List<double>();
            estudiante.Notas.NotasTrabajos = new List<double>();
            estudiante.Notas.NotasParciales = new List<double>();
            ListEst.Add(estudiante);
            estudiante.ImprimirDatos();
        }
        catch (Exception e)
        {
            int lineaDeError = (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetFileLineNumber();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
            Console.WriteLine($"| error | {e.Message} |");
            Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
            Console.WriteLine($"| Tipo  | {e.GetType()} |");
            Console.WriteLine("+{0}+", new string('-', Convert.ToString(e.GetType()).Length + 10));
            Console.WriteLine($"| Linea | {lineaDeError} |");
            Console.WriteLine("+{0}+", new string('-', Convert.ToString(lineaDeError).Length + 10));
            Console.ReadKey();
        }
    }
    private static void VerListaEstudiantes(List<Estudiantes> ListEst)
    {
        if (ListEst.Count() != 0)
        {

            string[] titulos = { "id", "nombre", "email", "Quices", "Trabajos", "Parciales", "edad", "direccion" };
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("+{0}+", new string('-', 114));
            Console.WriteLine("| {0, -15} | {1, -40} | {2, -21} | {3, -9} | {4, -15} |", titulos[0], titulos[1], titulos[3], titulos[4], titulos[5]);
            Console.WriteLine("+{0}+", new string('-', 114));
            Console.WriteLine("| {0, -15} | {1, -40} | {2, -3} | {3, -3} | {4, -3} | {5, -3} | {6, -3} | {7, -3} | {8, -3} | {9, -3} | {10, -3} |", "", "", "Q1", "Q2", "Q3", "Q4", "T1", "T2", "P1", "P2", "P3");
            Console.WriteLine("+{0}+", new string('-', 114));
            foreach (Estudiantes list in ListEst)
            {
                // list.ImprimirDatos()
                Console.WriteLine($"{list.ToString()}");
                Console.WriteLine("+{0}+", new string('-', 114));
            }
            Console.ReadKey();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+{0}+", new string('-', 39));
            Console.WriteLine("| No se ha registrado ningun estudiante |");
            Console.WriteLine("+{0}+", new string('-', 39));
            Console.ReadKey();

        }

    }
    private static void AgregarNotas(List<Estudiantes> ListEst)
    {
        bool continuar = true;
        Console.WriteLine("Ingrese el código del estudiante");
        string cod = Console.ReadLine();
        Estudiantes estu = ListEst.Find(estudiante => estudiante.Id == cod);
        if (estu == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+{0}+", new string('-', 35));
            Console.WriteLine("| No se ha encontrado al estudiante |");
            Console.WriteLine("+{0}+", new string('-', 35));
            Console.ReadKey();
        }
        while (estu != null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("+{0}+", new string('-', 26));
            Console.WriteLine("|         Menú Notas       |");
            Console.WriteLine("+{0}+", new string('-', 26));
            Console.WriteLine("| 1. Agregar Quices        |");
            Console.WriteLine("| 2. Agregar Trabajos      |");
            Console.WriteLine("| 3. Agregar Parciales     |");
            Console.WriteLine("| 4. Salir                 |");
            Console.WriteLine("+{0}+", new string('-', 26));
            Console.WriteLine("Seleccione una opción: ");
            try
            {
                string opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        if (estu.Notas.NotasQuices.Count() < 4)
                            while (continuar && estu.Notas.NotasQuices.Count() < 4)
                            {
                                Console.Clear();
                                Console.WriteLine("+{0}+", new string('-', 26));
                                Console.WriteLine("|        Nota Quices       |");
                                Console.WriteLine("+{0}+", new string('-', 26));
                                Console.WriteLine($"Quiz {estu.Notas.NotasQuices.Count() + 1}: ");
                                estu.Notas.NotasQuices.Add(double.Parse(Console.ReadLine()));
                                if (estu.Notas.NotasQuices.Count() < 4)
                                {
                                    Console.WriteLine($"Desea agregar otra nota de quiz \n1. Si \n2. No");
                                    continuar = int.Parse(Console.ReadLine()) == 1 ? true : false;
                                }
                            }
                        else
                        {
                            Console.WriteLine("solo se pueden agregar 4 notas de quices");
                        }
                        break;
                    case "2":
                        if (estu.Notas.NotasTrabajos.Count() < 2)
                            while (continuar && estu.Notas.NotasTrabajos.Count() < 2)
                            {
                                Console.Clear();
                                Console.WriteLine("+{0}+", new string('-', 28));
                                Console.WriteLine("|        Nota Trabajos       |");
                                Console.WriteLine("+{0}+", new string('-', 28));
                                Console.WriteLine($"Trabajo {estu.Notas.NotasTrabajos.Count() + 1}: ");
                                estu.Notas.NotasTrabajos.Add(double.Parse(Console.ReadLine()));
                                if (estu.Notas.NotasTrabajos.Count() < 2)
                                {
                                    Console.WriteLine("Desea agregar otro trabajo \n1. Si \n2. No");
                                    continuar = int.Parse(Console.ReadLine()) == 1 ? true : false;
                                }
                            }
                        else
                        {
                            Console.WriteLine("Solo se pueden agregar 2 notas de trabajos.");
                        }
                        break;
                    case "3":
                        if (estu.Notas.NotasParciales.Count() < 3)
                        {
                            while (continuar && estu.Notas.NotasParciales.Count() < 3)
                            {
                                Console.Clear();
                                Console.WriteLine("+{0}+", new string('-', 24));
                                Console.WriteLine("|     Nota Parciales     |");
                                Console.WriteLine("+{0}+", new string('-', 24));
                                Console.WriteLine($"Parcial {estu.Notas.NotasParciales.Count() + 1}: ");
                                estu.Notas.NotasParciales.Add(double.Parse(Console.ReadLine()));
                                if (estu.Notas.NotasParciales.Count() < 3)
                                {
                                    Console.WriteLine("Desea agregar otro parcial \n1. Si \n2. No");
                                    continuar = int.Parse(Console.ReadLine()) == 1 ? true : false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Solo se pueden agregar 3 notas de parciales.");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Enter para continuar");
                        estu = null;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                int lineaDeError = (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetFileLineNumber();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.WriteLine($"| error | {e.Message} |");
                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.WriteLine($"| Tipo  | {e.GetType()} |");
                Console.WriteLine("+{0}+", new string('-', Convert.ToString(e.GetType()).Length + 10));
                Console.WriteLine($"| Linea | {lineaDeError} |");
                Console.WriteLine("+{0}+", new string('-', Convert.ToString(lineaDeError).Length + 10));
                Console.ReadKey();
            }
        }
    }

    private static void VerListaNotas(List<Estudiantes> ListEst)
    {
        if (ListEst.Count() != 0)
        {
            string[] titulos = { "id", "nombre", "def quices", "def Trabajos", "def parciales", "Nota Final" };
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("+{0}+", new string('-', 117));
            Console.WriteLine("| {0, -15} | {1, -40} | {2, -7} | {3, -7} | {4, -7} | {5, -10} |", titulos[0], titulos[1], titulos[2], titulos[3], titulos[4], titulos[5]);
            Console.WriteLine("+{0}+", new string('-', 117));
            foreach (Estudiantes list in ListEst)
            {
                Console.WriteLine("| {0, -15} | {1, -40} {2, -7}", list.Id, list.Nombre, list.Notas.ToString());
                Console.WriteLine("+{0}+", new string('-', 117));
            }
            Console.ReadKey();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+{0}+", new string('-', 39));
            Console.WriteLine("| No se ha registrado ningun estudiante |");
            Console.WriteLine("+{0}+", new string('-', 39));
            Console.ReadKey();
        }
    }
}