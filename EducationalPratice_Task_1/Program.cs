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
            int n = Convert.ToInt32(Console.ReadLine());

            List<int> particles = new List<int>(n);//Список частиц

            for (int i = 0; i < n; i++)//Заполнение частиц
                particles.Add(Convert.ToInt32(Console.ReadLine()));
            
            bool[,] destr = new bool[n,n];//Массив для удаления

            //Заполняем массив частицами
            for (int i = 0; i < destr.GetLength(1); i++)
            {
                for (int j = 0; j < destr.GetLength(0); j++)
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    destr[i, j] = (value != 0);
                }
            }

            List<List<int>> all_variants= new List<List<int>>(n);//Список всех элементов
            Queue<List<int>> queueVariant = new Queue<List<int>>();//Очередь для разбора всех вариантов
            all_variants.Add(particles);//Добавляем в все варианты частицы
            queueVariant.Enqueue(particles);//Добавление частиц в очередь
             /* Реализация поиска в ширину */
            while (queueVariant.Count!=0)//Проверка очереди на пустотуы
            {
                
            }

        }
    }
}
