using System;
using System.Collections.Generic;


namespace EducationalPratice_Task_1
{
    class Program
    {
        private const int MAX_N = 4;//Максимальное количество частиц
        private const int MAX_A = 3;//Максимальное количество типов частиц
        private static int n; //Переменная для хранения количества частиц
        static  bool[,] destr = new bool[MAX_N, MAX_N];//Массив для удаления
        static bool[,,,] dp =new bool[MAX_A,MAX_A,MAX_A,MAX_A];//Массив для перебора вершин графа
        static List<List<int>> FinalStates = new List<List<int>>();
        /// <summary>
        /// Реализация поиска в ширину
        /// </summary>
        /// <param name="arr"></param>
        static void Bfs(int[] arr)
        {
            if(dp[arr[0], arr[1], arr[2], arr[3]]) // Если уже посещали вершину
                return;
            dp[arr[0], arr[1], arr[2], arr[3]] = true; // Вершина посещена
            bool flag = false; // Проверка на конечное состояние
            for (int i = 0; i < n; i++) // Бежим по взаимодействиям
                if(arr[i] > 0) // Если частицы данного вида ещё есть
                    for (int j = 0; j < n; j++) // Проверяем их на взаимодействие с другими
                        if (destr[i, j] && arr[j] > 0 && (i != j || i == j && arr[j] > 1)) // Если взаимодействие есть и есть что уничтожать
                        {
                            // Доп проверка (если частицы одного типа)
                            arr[j]--;
                            Bfs(arr);
                            arr[j]++;
                            flag = true;
                        }

            if (!flag) // Если состояние конечное, то добавляем
            {
                List<int> cur = new List<int>(n);
                for (int i = 0; i < n; i++)
                    cur.Add(arr[i]);
                FinalStates.Add(cur);
            }
        }
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            int [] arr = new int[MAX_N];
            string part = Console.ReadLine();
            int k = 0;

            for (int i = 0; i < n; i++)//Заполнение частиц
            {
                arr[i] = part[k] - '0';
                k+=2;
            }

            for (int i = n; i < MAX_N; i++)
                arr[i] = 0;

            //Заполняем массив частицами
            for (int i = 0; i <n; i++)
            {
                string pair = Console.ReadLine();
                int jk = 0;
                for (int j = 0; j <n; j++)
                {
                    int value = pair[jk] - '0';
                    jk+=2;
                    destr[i, j] = (value != 0);
                }
            }

            Bfs(arr);//Запускаем алгоритма
            Console.WriteLine(FinalStates.Count);//Печать количества вариантов
            foreach (var cur in FinalStates)
            {
                foreach (var value in cur)
                    Console.Write("{0} ", value); 
                Console.WriteLine();
            }
        }
    }
}
