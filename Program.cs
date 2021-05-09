using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_cat_shifr
{
    class Program
    {
        static void Main(string[] args)
        {
            #region begining auxiliary the code
            /*
            char z = ',';
            int code = (int)z;
            int c = 0; //(количество запятых)
            int d = 0; //(количество точек)
            string str = "пес, 97.,,...,pwd";

            
            for (int i = 0; i < str.Length; i++)
            {
                if ((int)str[i] == 44) c += 1;
                if ((int)str[i] == 46) d += 1;
                
                Console.Write(str[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Кол-во запятых равно " + c);
            Console.WriteLine("Кол-во точек равно " + d);

            //Console.WriteLine(code);
            */
            #endregion End auxiliary the code
            
            //Console.WriteLine("Привет КОТ!");
            string kot = "кот";
            
            Console.Write("Введите ваш текст для шифрования кошачим кодом: ");
            string str = Console.ReadLine();
            int len = 0; //(Длинна шифруемого текста)
            int p = 0; //(переменная для подсчета пробелов)

            len = str.Length+str.Length*3; //(Определени длинны создаваемого массива)
            //(В данном случае умножение на 3 происходит потому, что длина слова,
            //которым шифруем, составляет 3 символа.)

            //Создаем массив для хранения текста, плюс три ячейки 
            //памяти на каждую букву.
            char[] m_n = new char[len];

            //Выполнение самого шифра
            int t = 0; //(переменная для контроля длинны заданного текста)
            while (t < str.Length)
            {
                for (int i = 0; i < m_n.Length; i++)
                {
                    if (t == str.Length) break; //(Полный выход из внешнего цикла for.)
                    //(Полный выход нужен для того, чтобы заданная строка
                    //str[t] не вышла за границы)

                    m_n[i] = str[t];

                    if ((int)m_n[i] == 32)
                    {
                        p += 1; //(Подсчет пробелов)
                        t++; //(пропуск пробела)
                        continue; //(переход на следующую итерацию)

                    }

                    if((int)m_n[i] == 44)
                    {
                        t++; //(пропуск запятой)
                        continue; //(переход на следующую итерацию)
                    }

                    if((int)m_n[i] == 46)
                    {
                        t++; //(пропуск точки)
                        continue; //(переход на следующую итерацию)
                    }
                        
                    for (int j = 0; j < kot.Length; j++)
                    {
                        i += 1;
                        m_n[i] = kot[j];
                    }
                t++;
                }
            }

            //(Выводим в консоль)
            for (int i=0; i < m_n.Length; i++)
            {
                Console.Write(m_n[i]);
            }
        
            Console.WriteLine();
            Console.WriteLine("Количество пробелов = " + p);
            //Console.WriteLine("Длинна массива равна " + m_n.Length);
            
        }
    }
}
