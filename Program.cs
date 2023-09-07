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


    public static string GenerarIdentificadorCorto()
    {
        int contador = 4;
        contador++;
        return contador.ToString("D4"); // "D4" asegura que la cadena tenga al menos 4 dígitos
    }
}