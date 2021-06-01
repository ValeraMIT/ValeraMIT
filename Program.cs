using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_cat_shifr
{
    class Program
    {

        [STAThread] //The directory need in order to main (директива нужна для того, чтобы главный)
        //stream has become single-threaded COM object. (поток стал однопоточным COM объектом)
        static void Main(string[] args)
        {   

            string kot = "кот"; //The value of the variable 'kot' encrypt a text. (значением переменной 'kot' шифруется текст)

            //Begining code choice (Начало кода выбора)
            string ch = null; //The variable for choice (Переменная для выбора)
            string path = null; //The Path to text file, which should be encrypted. (Путь к текстовому файлу, который нужно зашифровать)
            string str = null; //A text encrypted (шифруемый текст)

            Console.WriteLine("Если вы хотите выбрать файл, введите yes.\n"+
                              "Если вы хотите ввести текст для шифрования" +
                              "через консоль введите no.");
            ch = Console.ReadLine();

            switch (ch)
            {
                case "yes":
                    {
                        Console.WriteLine("Выбор файла");
                        //Choose the Path to file (Выбрать путь к файлу)
                        OpenFileDialog F = new OpenFileDialog();
                        F.Title = "Выберите текстовый файл для шифрования";
                        F.Filter = "Text File(*.txt)|*.txt";
                        F.ShowDialog();

                        path = F.FileName;
                        if(path =="") //Checking the name on the empty string. (Проверка имени на пустую строку)
                        {
                            Console.WriteLine("Вы не выбрали файл.");
                            Console.WriteLine("Закрытие программы");
                            Environment.Exit(0);
                        }
                       
                        //Open stream for reading. (Открыть поток для чтения.)
                        StreamReader F_R;
                        F_R = new StreamReader(path);
                        str = F_R.ReadToEnd(); //We read a data from a file. (Читаем данные из файла до конца.)
                        F_R.Close(); //Clear the memory. (Очистка памяти.)
                    }
                    break;
                case "no":
                    {
                        Console.Write("Введите ваш текст для шифрования кошачим кодом: ");
                        str = Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Вы ввели неверную команду");
                    break;
            }
            //end code choice (конец кода выбора)

            if (ch != "no" && ch != "yes")
            {
                Console.WriteLine("Закрытие программы");
                Environment.Exit(0); //Close the console (закрытие консоли).
            }

            int len = 0; //The length encrypted text. (Длинна шифруемого текста.)
            int p = 0; //The variable for counting spaces. (Переменная для подсчета пробелов.)

            len = str.Length+str.Length*3; //Determining the length creating the array.(Определени длинны создаваемого массива.)
            //In this case multiplying by 3 occurs because a word length (В данном случае умножение на 3 происходит потому, что длина слова,
            //,which encrypt, it is 3 characters long. (,которым шифруем, составляет 3 символа.)
            //We are adding three memory cells to each letter. (Добавляем три ячейки памяти на каждую букву.)

            //We create the array for a text storage. (Создаем массив для хранения текста.)
            char[] m_n = new char[len];

            //Begining the code on data encryption. (Начало кода на шифрование данных)
            int t = 0; //The variable for length control specified text. (Переменная для контроля длинны заданного текста.)
            while (t < str.Length)
            {
                for (int i = 0; i < m_n.Length; i++)
                {
                    if (t == str.Length) break; //Full exit from the external loop 'for'. (Полный выход из внешнего цикла 'for'.)
                    //Full exit is needed in order to specified string (Полный выход нужен для того, чтобы заданная строка
                    //'str[t]' didn't go abroad. ('str[t]' не вышла за границу.)

                    m_n[i] = str[t];

                    if ((int)m_n[i] == 32)
                    {
                        p += 1; //Counting spaces (Подсчет пробелов.)
                        t++; //Skipping spaces. (Пропуск пробелов.)
                        continue; //Moving to the next iteration. (Переход к следующей итерации.)

                    }

                    if((int)m_n[i] == 44)
                    {
                        t++; // Skipping comma.(Пропуск запятой.)
                        continue; //Moving to the next iteration. (Переход к следующей итерации.)
                    }

                    if((int)m_n[i] == 46)
                    {
                        t++; // Skipping dot. (Пропуск точки.)
                        continue; //Moving to the next iteration. (Переход к следующей итерации.)
                    }
                    
                    if((int)m_n[i] == 10)
                    {
                        t++; //Skipping symbol moving the carriage to a new line. (Пропускаем символ переноса каретки на новую строку.)
                        continue; //Moving to the next iteration. (Переход к следующей итерации.)
                    }

                    if((int)m_n[i] == 13) 
                    {
                        t++; //Skipping symbol the carriage returns to the beginning of the line. (Пропускаем символ возврата каретки к началу строки.)
                        continue; //Moving to the next iteration. (Переход к следующей итерации.)
                    }

                    for (int j = 0; j < kot.Length; j++)
                    {
                        i += 1;
                        m_n[i] = kot[j];
                    }
                t++;
                }
            }

            //The end code on data encryption. (Конец кода на шифрование данных.)

            //We write in the console. (Пишем в консоль.)
            for (int i=0; i < m_n.Length; i++)
            {
                Console.Write(m_n[i]);
            }


            //We write the encrypted text to a file. (Записываем шифрованный текст в файл.)

            //Choose a path for saving a file. (Выбрать путь для сохранения файла.)
            SaveFileDialog S = new SaveFileDialog();
            S.Title = "Сохранение зашифрованного файла";
            S.CreatePrompt = true; //Create the new file if such a file not exist (Создать новый файл, если такого не существует.)
            S.OverwritePrompt = true; //Overwrite the file. (Перезапись файла.)
            S.Filter = "Text File (*.txt)|*.txt";
            S.ShowDialog();
            path = S.FileName;

            if(path == "") //Checking the name on empty string. (Проверка имени на пустую строку)
            {
                Console.WriteLine("\nВы не указали путь к файлу\n" +
                    "для сохранения зашифрованной информации.");
                Console.WriteLine("Выход из программы.");
                Environment.Exit(0);
            }
            
            //Opening a stream for writing to a file. (Открыть поток для записи в файл)
            StreamWriter F_w;
            F_w = new StreamWriter(path);
            F_w.Write(m_n);
            F_w.Close(); //Clear memory (очистка памяти)

            Console.WriteLine();
            Console.WriteLine("Количество пробелов = " + p);

        }
    }
}
