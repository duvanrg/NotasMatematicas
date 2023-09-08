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
        Console.Clear();
        bool run = true;
        List<Estudiantes> ListEst = new List<Estudiantes>();
        while (run)
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.WriteLine("+{0}+", new string('-', 30));
                Console.WriteLine("|         Menú Principal       |");
                Console.WriteLine("+{0}+", new string('-', 30));
                Console.WriteLine("| 1. Agregar Estudiante        |");
                Console.WriteLine("| 2. Agregar Notas             |");
                Console.WriteLine("| 3. Ver Lista de Estudiantes  |");
                Console.WriteLine("| 4. Ver Lista de Notas        |");
                Console.WriteLine("| 5. Salir                     |");
                Console.WriteLine("+{0}+", new string('-', 30));
                Console.Write("Seleccione una opción: ");

                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        AgregarEstudiante(ListEst);
                        Console.WriteLine($"{ListEst[0].Nombre}");
                        
                        break;
                    case "2":
                        AgregarNotas();
                        break;
                    case "3":
                        VerListaEstudiantes();
                        break;
                    case "4":
                        VerListaNotas();
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

    private static void VerListaNotas()
    {
        throw new NotImplementedException();
    }

    private static void VerListaEstudiantes()
    {
        throw new NotImplementedException();
    }

    private static void AgregarNotas()
    {
        throw new NotImplementedException();
    }

    public static void AgregarEstudiante(List<Estudiantes> ListEst)
    {
        var read = "";
        Console.Clear();
        Estudiantes estudiante = new Estudiantes();
        string n = Guid.NewGuid().ToString();
        string guid = n.Substring(n.Count() - 15);
        estudiante.Id = guid.Length <= 15 ? guid : throw new ArgumentException("El Codigo que Ingreso debe ser menor a 15 caracteres");
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
}