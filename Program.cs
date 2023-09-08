using System.ComponentModel.Design;
using NotasMatematicas.Entities;

internal class Program
{

    /**
el profesor del area de matematicas necesita un programa que le permita registrar los estudiantes que se encuentran matriculados, la informacion que el docente posee de cada estaudiante es la siguiente:
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
el programa debe permitirle al docente hacer el ingreso de Quices, Trabajos y Parciales
*/
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
                        Console.WriteLine($"{ListEst[0].Nombre}");
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
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("+{0}+", new string('-', e.Message.Count() + 10));
                Console.WriteLine($"| error | {e.Message} |");
                Console.WriteLine("+{0}+", new string('-', e.Message.Count() + 10));
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
            // string n = Guid.NewGuid().ToString();
            // string guid = n.Substring(n.Count() - 15);
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
            ListEst.Add(estudiante);
            estudiante.ImprimirDatos();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("+{0}+", new string('-', e.Message.Count() + 10));
            Console.WriteLine($"| error | {e.Message} |");
            Console.WriteLine("+{0}+", new string('-', e.Message.Count() + 10));
            Console.ReadKey();
        }
    }
    private static void VerListaEstudiantes(List<Estudiantes> ListEst)
    {
        string[] titulos = { "id", "nombre", "email", "notas quices", "notas Trabajos", "notas parciales", "edad", "direccion" };
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("+{0}+", new string('-', 151));
        Console.WriteLine("| {0, -15} | {1, -40} | {2, -40} | {3, -7} | {4, -35} |", titulos[0], titulos[1], titulos[2], titulos[6], titulos[7]);
        Console.WriteLine("+{0}+", new string('-', 151));
        foreach (Estudiantes list in ListEst)
        {
            Console.WriteLine($"{list.ToString()}");
            Console.WriteLine("+{0}+", new string('-', 151));
        }
        Console.ReadKey();
    }
    private static void AgregarNotas(List<Estudiantes> ListEst)
    {
        bool continuar = true;
        Console.WriteLine("Ingrese el código del estudiante");
        string cod = Console.ReadLine();
        Estudiantes estu = ListEst.Find(estudiante => estudiante.Id == cod);

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
            Console.Write("Seleccione una opción: ");
            try
            {
                Console.Clear();
                string opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        if (estu.Notas.NotasQuices.Count < 4)
                        {
                            Console.WriteLine("+{0}+", new string('-', 26));
                            Console.WriteLine("|         Nota Quizes       |");
                            Console.WriteLine("+{0}+", new string('-', 26));
                            while (continuar || estu.Notas.NotasQuices.Count >= 4)
                            {
                                Console.WriteLine($"Quiz {estu.Notas.NotasQuices.Count + 1}: ");
                                estu.Notas.NotasQuices.Add(int.Parse(Console.ReadLine()));
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
                        if (estu.Notas.NotasTrabajos.Count < 2)
                        {
                            Console.WriteLine("+{0}+", new string('-', 28));
                            Console.WriteLine("|       Nota Trabajos      |");
                            Console.WriteLine("+{0}+", new string('-', 28));
                            while (continuar || estu.Notas.NotasTrabajos.Count < 2)
                            {
                                Console.WriteLine($"Trabajo {estu.Notas.NotasTrabajos.Count + 1}: ");
                                estu.Notas.NotasTrabajos.Add(int.Parse(Console.ReadLine()));
                                Console.WriteLine("Desea agregar otro trabajo \n1. Si \n2. No");
                                continuar = int.Parse(Console.ReadLine()) == 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Solo se pueden agregar 2 notas de trabajos.");
                        }
                        break;
                    case "3":
                        if (estu.Notas.NotasParciales.Count < 3)
                        {
                            Console.WriteLine("+{0}+", new string('-', 29));
                            Console.WriteLine("|     Nota Parciales     |");
                            Console.WriteLine("+{0}+", new string('-', 29));
                            while (continuar && estu.Notas.NotasParciales.Count < 3)
                            {
                                Console.WriteLine($"Parcial {estu.Notas.NotasParciales.Count + 1}: ");
                                estu.Notas.NotasParciales.Add(int.Parse(Console.ReadLine()));
                                Console.WriteLine("Desea agregar otro parcial \n1. Si \n2. No");
                                continuar = int.Parse(Console.ReadLine()) == 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Solo se pueden agregar 3 notas de parciales.");
                        }
                        break;
                    case "4":
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
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.WriteLine($"| error | {e.Message} |");
                Console.WriteLine("+{0}+", new string('-', e.Message.Length + 10));
                Console.ReadKey();
            }
        }
    }

    private static void VerListaNotas(List<Estudiantes> ListEst)
    {
        string[] titulos = { "id", "nombre", "def quices", "def Trabajos", "def parciales", "Nota Final"};
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("+{0}+", new string('-', 151));
        Console.WriteLine("| {0, -15} | {1, -40} | {2, -7} | {3, -7} | {4, -7} | {5, -10} |", titulos[0], titulos[1], titulos[3], titulos[4], titulos[5], titulos[6]);
        Console.WriteLine("+{0}+", new string('-', 151));
        foreach (Estudiantes list in ListEst)
        {
            Console.WriteLine("| {0, -15} | {1, -40} {2, -7}",list.Id, list.Nombre, list.Notas.ToString());
            Console.WriteLine("+{0}+", new string('-', 100));
        }
        Console.ReadKey();
    }
}