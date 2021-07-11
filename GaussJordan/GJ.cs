using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GaussJordan
{
    class GJ
    {

        public GJ()
        {
        
        }

        public void PrintMatrix(float[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n; j++)
                    Console.Write(a[i, j] + " ");   //Se recorre la matriz para imprimirla

                Console.WriteLine();
            }
        }

        public int PerformOperation(float[,] a, int n) //Funcion que reduce los elementos de cada fila de la matriz
        {
            int i, j, k = 0, c, flag = 0;

            for (i = 0; i < n; i++)
            {
                if (a[i, i] == 0)
                {
                    c = 1;
                    while ((i + c) < n && a[i + c, i] == 0)
                        c++;
                    if ((i + c) == n)
                    {
                        flag = 1;
                        break;
                    }
                    for (j = i, k = 0; k <= n; k++)
                    {
                        float temp = a[j, k];
                        a[j, k] = a[j + c, k];
                        a[j + c, k] = temp;
                    }
                }

                for (j = 0; j < n; j++)
                {
                    if (i != j) //Se excluye cada i == j
                    {
                        //Se convierte cada elemento de la matriz de forma escalonada
                        //a los elementos que se necesitan para la matriz identidad
                        float p = a[j, i] / a[i, i];

                        for (k = 0; k <= n; k++)
                            a[j, k] = a[j, k] - (a[i, k]) * p;
                    }
                }
            }
            return flag;
        }

        public void PrintResult(float[,] a, //Funcion que imprime y verifica que los resultados sean los adecuados
                                int n, int flag)
        {

            if (flag == 2)
                Console.WriteLine("Existen soluciones infinitas");
            else if (flag == 3)
                Console.WriteLine("No existen soluciones reales a la matriz");

            else
            {
                Console.Write("El resultado para x y z es: ");
                for (int i = 0; i < n; i++)
                    Console.Write(a[i, n] / a[i, i] + " ");
            }
        }

        public int CheckConsistency(float[,] a, int n, int flag) //Funcion para verificar si existen soluciones infinitas o que no haya soluciones
        {
            int i, j;
            float sum;

            // Si flag == 2 existen soluciones infinitas
            // Si flag == 3 no existen soluciones reales
            flag = 3;   //La bandera se inicializa en 3 porque para que se verifique la consistencia de la matriz se tuvo que haber comprobado
                        //que no hay soluciones, entonces solo se verifica que no sea el caso de que existan soluciones infinitas
            for (i = 0; i < n; i++)
            {
                sum = 0;
                for (j = 0; j < n; j++)     //Se recorre la matriz 
                    sum = sum + a[i, j];
                if (sum == a[i, j])
                    flag = 2;
            }
            return flag;
        }
    }
}
