using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTechniques
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int []{ 50,40,30,20,10};
            //DisplaySortedArray("********** Bubble Sort *************", SortingTechniques.BubbleSort(a));
            //DisplaySortedArray("********** Selection Sort *************", SortingTechniques.SelectionSort(a));
            DisplaySortedArray("********** Insertion Sort *************", SortingTechniques.InsertionSort(a));

            Console.Read();
        }

        public static void DisplaySortedArray(string message, int[] a)
        {
            Console.WriteLine(message);
            for (int i = 0; i < a.Length; i++) {
                Console.WriteLine(a[i].ToString());
            }
        }
    }

    public class SortingTechniques {

        public static int[] BubbleSort(int[] a) {
            bool swapped = false;
            int temp;
            for (int i = 0; i < a.Length - 1; i++) {
                swapped = false;
                for (int j = 0; j < a.Length -(i+ 1); j++) {
                    if (a[j] > a[j + 1]) {
                        temp = a[j];
                        a[j] = a[j+1];
                        a[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    return a;
            }

            return a;
        }


        public static int[] SelectionSort(int[] a) {
            int min_index;
            for (int i = 0; i < a.Length - 1; i++) {
                min_index = i;
                for (int j = i + 1; j < a.Length; j++) {
                    if (a[j] < a[min_index])
                        min_index = j;
                }

                Swap(ref a[min_index], ref a[i]);
            }

            return a;
        }

        public static int[] InsertionSort(int[] a) {
            int j = 0;
            int key;
            for (int i = 1; i < a.Length; i++) {
                j = i - 1;
                key = a[i];
                while (j >= 0 && a[j] > key) {
                    a[j + 1] = a[j];
                    j = j - 1;
                }
                a[j + 1] = key;
            }


            return a;
        }

        public static void Swap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
