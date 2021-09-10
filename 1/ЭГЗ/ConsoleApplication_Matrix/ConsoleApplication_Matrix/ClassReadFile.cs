using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication_Matrix
{
    class ClassReadFile
    {
        /// <summary>
        /// Функция чтения матрицы из файла
        /// </summary>
        public static List<int> ReadFiles(string path) //--- Ф-я чтения матрицы из файла
        {
            string text = File.ReadAllText(path, Encoding.UTF8);

            char[] sep = new char[] { ' ', '\n', '\r', '|', ',', '.', '(', ')', '\\', '/' };
            string[] mass_str = text.Split(sep);
            List<int> lst_int = new List<int>(); //--- Список чисел из считанной матрицы

            foreach (string item in mass_str) //--- Набираем список чисел, находящихся в матрице
            {
                int value;
                bool Flag = int.TryParse(item, out value);
                if (Flag) lst_int.Add(value);
            }

            return lst_int;
        }


        public static int Counter(List<int> lst) //Функция счётчик
        {
            /// <summary>
            /// Счётчик кол-ва чисел, у которых сумма кудов цифр числа равна самому числу
            /// </summary>
            int count = 0; 

            foreach (int item in lst)
            {
                List<int> lst_tmp = new List<int>();

                string s_tmp = item.ToString();
                for (int i = 0; i < s_tmp.Length; i++) lst_tmp.Add(Convert.ToInt32(((char)s_tmp[i]).ToString()));

                int tmp_res = 0;
                foreach (int it in lst_tmp) tmp_res += (int)Math.Pow(it, 3);

                if (item == tmp_res) count++; //--- Если сумма кубов всех цифр числа совпала с самим числом => увеличиваем счётчик
            }

            return count;
        }

        /// <summary>
        ///Ф-я записи результата работы в файл
        /// </summary>
        public static void WriteFile(string str)
        {
            string pth_folder = "";
            while (true)
            {
                pth_folder = "";
                Console.Write("\nВведите полный путь к папке, веоторой вы хотите сохранить файл с результатом:");
                pth_folder = @"\\main\RDP\44П\ГоршенинАА\Desktop\пере\";
                
                if (pth_folder[pth_folder.Length - 1] == '\\') break;
                Console.WriteLine("ERROR\nПуть должен заканчиваться обратным слешем.\n\n");
                Console.ReadKey();
            }
            pth_folder += "Result.txt";

            File.WriteAllText(pth_folder, str, Encoding.UTF8);
        }

    }
}
