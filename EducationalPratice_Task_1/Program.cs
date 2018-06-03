using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//Количество частиц
            bool[,] destr = new bool[n, n];//Массив для удаления
            List<int> particles = new List<int>(n);//Список частиц
            for (int i = 0; i < n; i++)//Заполнение частиц
                particles.Add(Convert.ToInt32(Console.ReadLine()));//Типы частиц




            //Заполняем массив частицами
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    destr[i, j] = (value != 0);
                }
                Console.WriteLine();
            }
            List<List<int>> FinalList = new List<List<int>>(n);
            Queue<List<int>> QueueParts = new Queue<List<int>>(n);//Очередь частиц

            List<List<int>> All_States = new List<List<int>>();//Набор всех состояний
                
            QueueParts.Enqueue(particles);//Добавляем частицы в очередь
            All_States.Add();

            
        }

        static void Print(List<List<int>> list)
        {
            foreach (var item in list)
            {
                foreach (var number in item)
                    Console.Write($"{number} ");
                Console.WriteLine();
            }
        }
        static void Print(List<int> list)
        {
            foreach (var item in list)
                Console.Write($"{item} ");
            Console.WriteLine();
        }
    }
}
