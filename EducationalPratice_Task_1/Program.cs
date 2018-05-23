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
                List<int> current = queueVariant.Peek();//Получаем текущее состояние
                queueVariant.Dequeue();//Удаляем элемент из очереди
                bool finalize = true;//Проверка что все варианты рассмотрены
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)//Проверка на реагирование частиц
                        {

                            if (current[i] >= 2 && destr[i,i])//Проверка что частица себя уничтожает
                            {
                                var next = current;
                                next[i] -= 2;
                                finalize = false;//Переход произошел
                                if (all_variants.Contains(next) == false)//Проверка на существование такого варианта
                                {
                                    all_variants.Add(next);//Добавленяем в конечное финальную матрицу
                                    queueVariant.Enqueue(next);//Добавляем в очередь состояний
                                }
                            }
                        }
                        else
                        {
                            if (current[i] > 0 && current[j] > 0 && (destr[i][j] || destr[j][i]))
                            {
                                //Реагирование частиц, но не обязательно
                                var next = current;//Копирование текущего состояния
                                if (destr[i][j])
                                    next[i]--;
                                if (destr[j][i])
                                    next[j]--;
                                isFinal = false;
                                if (all.Contains(next) == false)//Проверка на существование такого варианта
                                {
                                    all.Add(next);//Добавленяем в конечное финальную матрицу
                                    q.Enqueue(next);//Добавляем в очередь состояний
                                }
                            }
                        }
                    }
                }

            }

        }
    }
}
