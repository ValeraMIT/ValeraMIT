using System;
using System.IO;
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
            #region begining auxiliary the code (начало вспомогательного кода)
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
            #endregion End auxiliary the code (конец вспомогательного кода)

            //Console.WriteLine("Привет КОТ!");
            string kot = "кот"; //(значением в переменной kot шифруется текст)

            //begining  code choice (начало кода выбора)
            string ch = null; //переменная для выбора
            string path = null; //(Путь до текстового файла, который нужно зашифровать)
            string str = null; //(шифруемый текст)

            Console.WriteLine("Если вы хотите выбрать файл, введите yes.\n"+
                              "Если вы хотите ввести текст для шифрования" +
                              "через консоль введите no.");
            ch = Console.ReadLine();

            switch (ch)
            {
                case "yes":
                    {
                        Console.WriteLine("Выбор файла");
                        path = @"C:\Users\Valera\Desktop\Lesson CSharp\Project_cat_shifr\text_fs.txt";
                        //Open stream for reading (открыть поток для чтения).
                        StreamReader F_R;
                        F_R = new StreamReader(path);
                        str = F_R.ReadToEnd(); //(Читаем данные из файла до конца)
                        F_R.Close(); //Clear the memory (очистка памяти)
                    }
                    break;
                case "no":
                    {
                        //Console.WriteLine("Введите файл для шифрования");
                        Console.Write("Введите ваш текст для шифрования кошачим кодом: ");
                        str = Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Вы ввели неверную команду");
                    break;
            }
            //end code choice (конец кода выбора)

            //Console.WriteLine(ch);

            if (ch != "no" && ch != "yes")
            {
                Console.WriteLine("Закрытие программы");
                Environment.Exit(0); //Close the console (закрытие консоли).
            }

            //Console.Write("Введите ваш текст для шифрования кошачим кодом: ");
            //string str = Console.ReadLine();
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

            //(Записываем шифрованный текст в файл)
            path = @"C:\Users\Valera\\Desktop\Lesson CSharp\Project_cat_shifr\shifr_text.txt";
            //(открыть поток для записи в файл)
            StreamWriter F_w;
            F_w = new StreamWriter(path);
            F_w.Write(m_n);
            F_w.Close(); //Clear memory (очистка памяти)

            Console.WriteLine();
            Console.WriteLine("Количество пробелов = " + p);
            //Console.WriteLine("Длинна массива равна " + m_n.Length);

        }
    }
}
