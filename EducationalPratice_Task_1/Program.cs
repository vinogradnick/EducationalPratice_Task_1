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
            All_States.Add(particles);

            while (QueueParts.Count>0)
            {
                List<int> temp = QueueParts.Dequeue();//Получаем частицы из очереди и выполняем действия над ними
                Print(temp);
                bool final = true;

                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (i == j)
                        {
                            if (temp[i] >= 2 && destr[i, i])
                            {
                                List<int> next = temp; //переходим к следующему состояни.
                                next[i]--; //Уничтожаем частицы
                                final = false;
                                Print(next);
                                if (!All_States.Contains(next)
                                ) //Если данного варианта еще не было, то добавляем в очередь
                                {
                                    All_States.Add(next);
                                    QueueParts.Enqueue(next);
                                }
                            }
                        }
                        else if (temp[i] > 0 && temp[j] > 0)
                        {
                            /* Частица i уничтожает частицу j */
                            if (destr[i, j])
                            {
                                List<int> next = temp; //переходим к следующему состояни.
                                next[j]--; //Уничтожаем частицы
                                final = false;
                                Print(next);
                                if (!All_States.Contains(next)
                                ) //Если данного варианта еще не было, то добавляем в очередь
                                {
                                    All_States.Add(next);
                                    QueueParts.Enqueue(next);
                                }
                            }

                            /* Частица j уничтожает частицу i */
                            if (destr[j, i])
                            {
                                List<int> next = temp; //переходим к следующему состояни.
                                Print(next);
                                next[i]--; //Уничтожаем частицы
                                final = false;
                                if (!All_States.Contains(next)
                                ) //Если данного варианта еще не было, то добавляем в очередь
                                {
                                    All_States.Add(next);
                                    QueueParts.Enqueue(next);
                                }
                            }
                        }
                    }
                }

                if (final)//Если финальное состояние, то добавляем конечный список
                    FinalList.Add(temp);
            }
            Print(FinalList);
            Print(All_States);
            Console.ReadLine();
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
