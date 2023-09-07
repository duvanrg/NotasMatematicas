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
            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.edad = edad;
            this.Direccion = direccion;
        }

        public string Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }

    }
}