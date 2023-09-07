using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasMatematicas.Entities
{

    public class Estudiantes
    {
        private string id;
        private string nombre;
        private string email;
        private int edad;
        private string direccion;

        public Estudiantes()
        {
        }

        public Estudiantes(string id, string nombre, string email, int edad, string direccion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Email = email;
            this.Edad = edad;
            this.Direccion = direccion;
        }

        public string Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }

        public void ImprimirDatos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" {0,15}  {0,40}  {0,40}  {0,7}  {0,35}", "id", "nombre", "email", "edad", "direccion");
            Console.WriteLine("{0, 40} {1, -20} {2, -30} {3, -4} {4, -35}", id, nombre, email, edad, direccion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}