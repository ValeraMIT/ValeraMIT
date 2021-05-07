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
            //Console.WriteLine("Привет КОТ!");
            string kot = "кот";
            //string you_t; //(В данную переменную записывается текст шифрования).
            Console.Write("Введите ваш текст для шифрования кошачим кодом: ");
            string str = Console.ReadLine();
            int len = 0; //(Длинна шифруемого текста)
            int p = 0; //(переменная для подсчета пробелов)

            //for (int i = 0; i < str.Length;i++)
            //{
            //    if ((int)str[i] == 32) p += 1; //(Подсчет пробелов)
            //    Console.WriteLine(str[i]);
            //}

            len = str.Length+str.Length*3; //(Определени длинны создаваемого массива)

            //Создаем массив для хранения текста, плюс три ячейки 
            //памяти на каждую букву.
            char[] m_n = new char[len];

            //Выполнение самого шифра
            int t = 0; //(переменная для контроля длинны заданного текста)
            while (t < str.Length)
            {
                for (int i = 0; i < m_n.Length; i++)
                {
                    m_n[i] = str[t];
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
