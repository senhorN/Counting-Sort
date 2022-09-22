using System;

namespace CountingSort
{
    class Program
    {

        //método iniciado...
        // <max> maximo de um elemento em array 
        static int getMax(int[] a, int n)
        {
            int max = a[0];
            for (int i = 1; i < n; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;  
        }

        static void countSort(int[] a, int n) // função de executar ordenação por contagem  
        {
            int[] output = new int[n + 1];
            int max = getMax(a, n);
            int[] count = new int[max + 1];
            
            // Inicializando a ordenação com zeros
            for (int i = 0; i <= max; ++i)
            {
                count[i] = 0; 
            }
            // Armazenando ordenação de cada elemento
            for (int i = 0; i < n; i++)   
            {
                count[a[i]]++;//incremento dos elementos 
            }

            for (int i = 1; i <= max; i++)
                count[i] += count[i - 1]; //acha a frequencia comulativa   

            /* Este loop encontrará o índice de cada elemento do array original no array de contagem, e
             coloque os elementos na matriz de saída*/
            
            
            //armazena a ordem de elementos na array
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[a[i]] - 1] = a[i];
                count[a[i]]--; // Diminui a ordenação de alguns números  
            }
            //elementos ordenados para array de entrada
            for (int i = 0; i < n; i++)
            {
                a[i] = output[i];   
            }
        }
        //valores e impressão do array
        static void Main()
        {
            int[] a = { 43, 31, 2, 7, 10, 1, 5, 6, 3 };// << os dados
            int n = a.Length;
            Console.Write("Antes de ordenar os elementos do array são: \n");
            printArr(a, n);
            countSort(a, n);
            Console.Write("Depois de ordernar os elementos do array são: \n");
            printArr(a, n);
        }

        static void printArr(int[] a, int n) /* função do print no array > impressão dos número */
        {
            int i;
            for (i = 0; i < n; i++)
                Console.Write(a[i] + " \n");
        }

         
    }

}
