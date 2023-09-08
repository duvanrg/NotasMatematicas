using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasMatematicas.Entities
{
    public class Notas
    {
        private List<double> notasQuices;
        private List<double> notasTrabajos;
        private List<double> notasParciales;

        public Notas()
        {
        }

        public Notas(List<double> notasQuices, List<double> notasTrabajos, List<double> notasParciales)
        {
            this.NotasQuices = notasQuices;
            this.NotasTrabajos = notasTrabajos;
            this.NotasParciales = notasParciales;
        }

        public List<double> NotasQuices { get { return notasQuices; } set { notasQuices = value; } }
        public List<double> NotasTrabajos { get { return notasTrabajos; } set { notasTrabajos = value; } }
        public List<double> NotasParciales { get { return notasParciales; } set { notasParciales = value; } }

        public override string ToString()
        {
            try
            {
                double defQuices = notasQuices.Sum() / notasQuices.Count;
                double defTrabajos = notasTrabajos.Sum() / notasTrabajos.Count;
                double defParciales = notasParciales.Sum() / notasParciales.Count;
                double definitiva = (defQuices*0.25)+(defTrabajos*0.15)+(defParciales*0.60);
                return  $"| {defQuices,-15} | {defTrabajos,-40} | {defParciales,-40} | {definitiva,-7} |";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}