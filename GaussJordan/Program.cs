using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussJordan
{
    class Program
    {
        static void Main(string[] args)
        {
            GJ m1 = new GJ();
            int n = 3, flag = 0;

            float[,] a = {{ 4, 12, 7, 74 },
                          { -3, 5, 2, 56 },
                          { 2, 9, -1, 27 }};

            Console.WriteLine("Matriz Argumentada: ");
            m1.PrintMatrix(a, n);
            Console.WriteLine("");

            //Se llama a la funcion para simplicar la matriz y obtener los resultados, se iguala a la bandera por si hay algùn error
            flag = m1.PerformOperation(a, n);

            if (flag == 1)  //Se regresa una bandera de la funcion PerformOperation si hay un error
                flag = m1.CheckConsistency(a, n, flag); //Se verifica si hay soluciones infinitas o no hay soluciones reales

            //Se imprime la matriz reducida
            Console.WriteLine("Matriz reducida: ");
            m1.PrintMatrix(a, n);
            Console.WriteLine("");

            //Se muestran los resultados en pantalla
            m1.PrintResult(a, n, flag);

            Console.ReadKey();
        }
    }
}
