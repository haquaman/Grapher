using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Proje3
{
    class Program
    {
        static void WriteText(int[,] matris_x, StreamWriter file, string str)
        {
            file.WriteLine(str);
            for (int i = 0; i < matris_x.GetLength(0); i++)
            {
                for (int j = 0; j < matris_x.GetLength(1); j++)
                {
                    file.Write(matris_x[i, j]);
                }
                file.Write("\n");
            }
            for (int j = 0; j < matris_x.GetLength(1); j++)
            {
                file.Write("-");
            }
            file.Write("\n");
        }
        static int[,] Rler(int[,] matrix_1, int[,] matrix_2)
        {
            int[,] Resultmatrix = new int[matrix_1.GetLength(0), matrix_2.GetLength(1)];
            for (int i = 0; i < matrix_1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_1.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix_1.GetLength(0); k++)
                    {
                        Resultmatrix[i, j] += matrix_1[i, k] * matrix_2[k, j];
                        if (Resultmatrix[i, j] != 0)
                            Resultmatrix[i, j] = 1;
                    }
                }
            }
            return Resultmatrix;
        }
        static int[] Sayma()
        {
            StreamReader f = File.OpenText("graph.txt");
            string read_row = " ";
            int count = 0;
            while (!f.EndOfStream)
            {
                read_row = f.ReadLine();
                count++;
            }
            f.Close();
            int count2 = read_row.Length;
            int[] sayma = new int[2] { count, count2 };
            return sayma;
        }
        static int LoadGraph(char[,] arr) //Load Graph.
        {
            StreamReader f = File.OpenText("graph.txt");

            int row = 2, column;
            int n = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                string n_finder = f.ReadLine();
                string[] finder_n = n_finder.ToUpper().Split(' ');


                column = 2;
                for (int j = 0; j < arr.GetLength(1); j++)
                {

                    arr[i, j] = n_finder[j];
                    Console.SetCursorPosition(column, row);
                    Console.Write(arr[i, j]);
                    column += 1;
                }
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    if (finder_n[0][k] != '.' && finder_n[0][k] != '+' && finder_n[0][k] != 'X')
                    { n++; }
                }
                Console.WriteLine();
                row += 1;
            }
            return n;
        }
        static void DrawnGraph(char[,] area) // Drawn graph without load.
        {
            int row, colon = 2;
            for (int i = 0; i < area.GetLength(0); i++)
            {
                row = 2;
                for (int j = 0; j < area.GetLength(1); j++)
                {

                    area[i, j] = '.';
                    Console.SetCursorPosition(row, colon);
                    Console.Write(area[i, j]);
                    row = row + 1;
                }
                Console.WriteLine();
                colon = colon + 1;
            }
        }
        static void Menu() // Menu for choosing.
        {
            Console.WriteLine("             MENU");
            Console.WriteLine("1-Draw Graph");
            Console.WriteLine("2-Load Graph");
        }
        //Matrix yazdırma prosedürü
        static void Matrix(int[,] matrix_s, int cki, int n)
        {
            int c = 0;
            if (cki - 48 == 1)
            {
                Console.SetCursorPosition(51, 0);
                Console.WriteLine("R1 Matris");
                Console.SetCursorPosition(48, 1);
                Console.WriteLine("-------------------------------------------------");
            }

            else
            {
                if (cki - 48 == 0)
                {
                    c = 15;
                    Console.SetCursorPosition(51, 0 + c);
                    Console.WriteLine("R" + '*' + " Matris");
                    Console.SetCursorPosition(48, 1 + c);
                    Console.WriteLine("-------------------------------------------------");
                }
                else if (cki - 47 == 0)
                {
                    c = 15;
                    Console.SetCursorPosition(51, 0 + c);
                    Console.WriteLine("Rmin" + " Matris");
                    Console.SetCursorPosition(48, 1 + c);
                    Console.WriteLine("-------------------------------------------------");
                }
                else
                {
                    c = 15;
                    Console.SetCursorPosition(51, 0 + c);
                    Console.WriteLine("R" + (cki - 48) + " Matris");
                    Console.SetCursorPosition(48, 1 + c);
                    Console.WriteLine("-------------------------------------------------");
                }

            }
            int a = 0;
            for (int i = 65; i < 65 + n; i++)
            {
                Console.SetCursorPosition(51 + 2 * a, 2 + c);
                Console.Write(Convert.ToChar(i));
                a++;
            }
            a = 0;
            for (int i = 65; i < 65 + n; i++)
            {
                Console.SetCursorPosition(48, 4 + a + c);
                Console.Write(Convert.ToChar(i));
                a++;
            }
            for (int i = 0; i < matrix_s.GetLength(0); i++)
            {
                Console.WriteLine("");
                a = 0;
                for (int j = 0; j < matrix_s.GetLength(1); j++)
                {
                    a++;
                    Console.SetCursorPosition(50 + j + a, i + 4 + c);
                    Console.Write(matrix_s[i, j]);
                }
            }
        }
        static int Query(int[,] matrix_1, int[,] matrix_2, int[,] matrix_3, int[,] matrix_4, int[,] matrix_5, int[,] matrix_6, int[,] matrix_7, int[,] matrix_8, int[,] matrix_9)
        {
            ConsoleKeyInfo cki_1, cki_2;
            Console.SetCursorPosition(5, 30);
            Console.Write("From : ");
            cki_1 = Console.ReadKey();
            while (cki_1.KeyChar < 65 || cki_1.KeyChar > 80)
            {
                Console.SetCursorPosition(5, 30);
                Console.WriteLine("Wrong");
                Thread.Sleep(1000);
                Console.SetCursorPosition(5, 30);
                Console.Write("From : ");
                cki_1 = Console.ReadKey();
            }

            Console.SetCursorPosition(20, 30);
            Console.Write("To : ");
            cki_2 = Console.ReadKey();
            while (cki_2.KeyChar < 65 || cki_2.KeyChar > 80)
            {
                Console.SetCursorPosition(20, 30);
                Console.WriteLine("Wrong");
                Thread.Sleep(1000);
                Console.SetCursorPosition(20, 30);
                Console.Write("To : ");
                cki_2 = Console.ReadKey();
            }

            if (matrix_1[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 1;
            else if (matrix_2[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 2;
            else if (matrix_3[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 3;
            else if (matrix_4[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 4;
            else if (matrix_5[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 5;
            else if (matrix_6[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 6;
            else if (matrix_7[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 7;
            else if (matrix_8[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 8;
            else if (matrix_9[cki_1.KeyChar - 65, cki_2.KeyChar - 65] == 1)
                return 9;
            else
                return 0;
        }
        static int r_min(int[,] matrix_1, int[,] matrix_2, int[,] matrix_3, int[,] matrix_4, int[,] matrix_5, int[,] matrix_6, int[,] matrix_7, int[,] matrix_8, int[,] matrix_9, int i, int j)
        {
            if (matrix_1[i - 65, j - 65] == 1)
                return 1;
            else if (matrix_2[i - 65, j - 65] == 1)
                return 2;
            else if (matrix_3[i - 65, j - 65] == 1)
                return 3;
            else if (matrix_4[i - 65, j - 65] == 1)
                return 4;
            else if (matrix_5[i - 65, j - 65] == 1)
                return 5;
            else if (matrix_6[i - 65, j - 65] == 1)
                return 6;
            else if (matrix_7[i - 65, j - 65] == 1)
                return 7;
            else if (matrix_8[i - 65, j - 65] == 1)
                return 8;
            else if (matrix_9[i - 65, j - 65] == 1)
                return 9;
            else
                return 0;
        }
        static void Main(string[] args)
        {
            int holder;
            int c;
            char[,] area = new char[25, 40];
            int[] sayma = new int[2];
            char[,] oldpos = new char[100, 1000];
            int n = 0;
            Menu();
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (x == 1)
            {
                Console.Write("How many nodes do you want: ");
                n = Convert.ToInt32(Console.ReadLine());
                
            }
            // making screen
            Console.SetCursorPosition(1, 0);
            for (int i = 1; i <= 4; i++) for (int j = 0; j <= 9; j++) Console.Write(j);
            Console.SetCursorPosition(41, 0);
            Console.WriteLine("0");
            Console.SetCursorPosition(0, 1);
            for (int i = 1; i <= 2; i++) for (int j = 0; j <= 9; j++) Console.WriteLine(j);
            Console.SetCursorPosition(0, 21);
            for (int i = 0; i <= 5; i++) Console.WriteLine(i);
            Console.SetCursorPosition(1, 0);
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < area.GetLength(1) + 2; i++) Console.Write("#");
            for (int i = 2; i < area.GetLength(0) + 3; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(area.GetLength(1) + 2, i);
                Console.Write("#");
            }
            Console.SetCursorPosition(1, area.GetLength(0) + 2);
            for (int i = 1; i <= area.GetLength(1) + 1; i++) Console.Write("#");

            //Cursor Movement and Keys
            ConsoleKeyInfo cki;
            int a = 0;
            bool flag, flag1 = true;

            int row = 2; int column = 2;
            // Secime göre ekranın graphın olusumu.
            while (x != 1 && x != 2)
            {
                Console.WriteLine("Enter '1' or '2'");
                x = Convert.ToInt16(Console.ReadLine());
            }
            if (x == 1) DrawnGraph(area);
            else if (x == 2) n = LoadGraph(area);
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    int matrixlength = 0;
                    for (int i = 0; i < area.GetLength(0); i++)
                    {
                        for (int j = 0; j < area.GetLength(1); j++)
                        {
                            if (area[i, j] <= 80 && area[i, j] >= 65)
                            {
                                matrixlength++;
                            }
                        }
                    }
                    int[,] matrix_1 = new int[matrixlength, matrixlength];
                    int[,] matrix_2 = new int[matrixlength, matrixlength];
                    int[,] matrix_3 = new int[matrixlength, matrixlength];
                    int[,] matrix_4 = new int[matrixlength, matrixlength];
                    int[,] matrix_5 = new int[matrixlength, matrixlength];
                    int[,] matrix_6 = new int[matrixlength, matrixlength];
                    int[,] matrix_7 = new int[matrixlength, matrixlength];
                    int[,] matrix_8 = new int[matrixlength, matrixlength];
                    int[,] matrix_9 = new int[matrixlength, matrixlength];
                    int[,] matrix_star = new int[matrixlength, matrixlength];
                    int[,] matrix_min = new int[n, n];
                    for (int i = 0; i < matrix_1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix_1.GetLength(1); j++)
                        {
                            matrix_1[i, j] = 0;
                        }
                    }

                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.UpArrow)
                    {
                        row--;
                        if (row == 1)
                        {
                            row = 2;
                        }
                        Console.SetCursorPosition(column, row);
                    }
                    else if (cki.Key == ConsoleKey.DownArrow)
                    {
                        row++;
                        if (row == 27)
                        {
                            row = 26;
                        }
                        Console.SetCursorPosition(column, row);
                    }
                    else if (cki.Key == ConsoleKey.RightArrow)
                    {
                        column++;
                        if (column == area.GetLength(1) + 2)
                        {
                            column = area.GetLength(1) + 1;
                        }
                        Console.SetCursorPosition(column, row);
                    }
                    else if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        column--;
                        if (column == 1)
                        {
                            column = 2;
                        }
                        Console.SetCursorPosition(column, row);
                    }
                    else
                    {
                        if (cki.KeyChar >= 65 && cki.KeyChar <= 64 + n) //HARFİ SİLİP TEKRAR YAZMADA SIKINTI ************
                        {
                            flag = true;
                            for (int i = 0; i < area.GetLength(0); i++)
                            {
                                for (int j = 0; j < area.GetLength(1); j++)
                                {
                                    if (area[i, j] == cki.KeyChar)
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            if (flag == true)
                            {
                                Console.Write(cki.KeyChar);
                                Console.SetCursorPosition(column, row);
                                area[row - 2, column - 2] = cki.KeyChar;
                            }
                        }
                        else if (cki.KeyChar == 88)
                        {
                            Console.Write(cki.KeyChar);
                            Console.SetCursorPosition(column, row);
                            area[row - 2, column - 2] = cki.KeyChar;
                        }
                        else if (cki.Key == ConsoleKey.Spacebar)
                        {
                            Console.Write('+');
                            Console.SetCursorPosition(column, row);
                            area[row - 2, column - 2] = '+';
                        }
                        else if (cki.KeyChar == 46)
                        {
                            Console.Write(cki.KeyChar);
                            Console.SetCursorPosition(column, row);
                            area[row - 2, column - 2] = cki.KeyChar;
                        }
                    }

                    if ((cki.KeyChar >= 48 && cki.KeyChar < 58) || cki.KeyChar == 81 || cki.Key == ConsoleKey.Enter)
                    {

                        for (int i = 0; i < area.GetLength(0); i++)
                        {
                            for (int j = 0; j < area.GetLength(1); j++)
                            {

                                if (Convert.ToInt32(area[i, j]) <= 80 && Convert.ToInt32(area[i, j]) >= 65)
                                {
                                    bool edge, edge1, edge2, edge3;
                                    int tempj = j, tempi = i;
                                    for (int k = i - 1; k <= i + 1; k++)
                                    {
                                        if (k < 0 || k > area.GetLength(0) - 1) edge = false;
                                        else edge = true;
                                        for (int m = j - 1; m <= j + 1; m++)
                                        {
                                            if (m < 0 || m > area.GetLength(1) - 1) edge = false;
                                            else if (k >= 0 && m >= 0 && k < area.GetLength(0) && m < area.GetLength(1)) edge = true;
                                            if (edge)
                                            {
                                                if (area[k, m] == '+')
                                                {
                                                    tempi = i;
                                                    tempj = j;
                                                    flag1 = true;
                                                    int farki = k - tempi;
                                                    int farkj = m - tempj;
                                                    while (area[tempi + farki, tempj + farkj] == '+')
                                                    {
                                                        tempi = tempi + farki;
                                                        tempj = tempj + farkj;
                                                    }
                                                    while (flag1 == true)
                                                    {
                                                        for (int xbi = tempi - 1; xbi <= tempi + 1; xbi++)
                                                        {
                                                            if (xbi < 0 || xbi > area.GetLength(0) - 1) edge1 = false;
                                                            else edge1 = true;
                                                            if (edge1)
                                                            {
                                                                for (int xbj = tempj - 1; xbj <= tempj + 1; xbj++)
                                                                {
                                                                    if (xbj < 0 || xbj > area.GetLength(1) - 1) edge1 = false;
                                                                    else if (xbi >= 0 && xbj >= 0 && xbi < area.GetLength(0) && xbj < area.GetLength(1)) edge1 = true;
                                                                    if (edge1)
                                                                    {
                                                                        if (area[xbi, xbj] == 'X')
                                                                        {
                                                                            int Xi = xbi;
                                                                            int Xj = xbj;
                                                                            for (int xhi = Xi - 1; xhi <= Xi + 1; xhi++)
                                                                            {
                                                                                if (xhi < 0 || xhi > area.GetLength(0) - 1) edge2 = false;
                                                                                else edge2 = true;
                                                                                for (int xhj = Xj - 1; xhj <= Xj + 1; xhj++)
                                                                                {
                                                                                    if (xhj < 0 || xhj > area.GetLength(1) - 1) edge2 = false;
                                                                                    else if (xhi >= 0 && xhj >= 0 && xhi < area.GetLength(0) && xhj < area.GetLength(1)) edge2 = true;
                                                                                    if (edge2)
                                                                                    {
                                                                                        if (Convert.ToInt32(area[xhi, xhj]) <= 80 && Convert.ToInt32(area[xhi, xhj]) >= 65)
                                                                                        {
                                                                                            matrix_1[Convert.ToInt32(area[i, j]) - 65, Convert.ToInt32(area[xhi, xhj]) - 65] = 1;
                                                                                            flag1 = false;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        int noktati = tempi;
                                                        int noktatj = tempj;
                                                        int nfarki = farki;
                                                        int nfarkj = farkj;
                                                        for (int ni = noktati - 1; ni <= noktati + 1; ni++)
                                                        {
                                                            if (ni < 0 || ni > area.GetLength(0) - 1) edge3 = false;
                                                            else edge3 = true;
                                                            for (int nj = noktatj - 1; nj <= noktatj + 1; nj++)
                                                            {
                                                                if (nj < 0 || nj > area.GetLength(1) - 1) edge3 = false;
                                                                else if (nj >= 0 && ni >= 0 && ni < area.GetLength(0) && nj < area.GetLength(1)) edge3 = true;
                                                                if (edge3)
                                                                {
                                                                    if (area[ni, nj] == '+' && (ni != noktati || nj != noktatj) && (ni != noktati - nfarki || nj != noktatj - nfarkj))
                                                                    {
                                                                        farki = ni - tempi;
                                                                        farkj = nj - tempj;
                                                                        if (tempi + farki >= 0 && tempj + farkj >= 0)
                                                                        {
                                                                            while (area[tempi + farki, tempj + farkj] == '+')
                                                                            {
                                                                                tempi = tempi + farki;
                                                                                tempj = tempj + farkj;
                                                                            }
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //Matrislerin Oluşturulması
                        //------------------------------------------------------------------------------------------------------------------------------------
                        //R2:
                        //R2:
                        matrix_2 = Rler(matrix_1, matrix_1);
                        //R3
                        matrix_3 = Rler(matrix_2, matrix_1);
                        //R4
                        matrix_4 = Rler(matrix_3, matrix_1);
                        //R5
                        matrix_5 = Rler(matrix_4, matrix_1);
                        //R6
                        matrix_6 = Rler(matrix_5, matrix_1);
                        //R7
                        matrix_7 = Rler(matrix_6, matrix_1);
                        //R8
                        matrix_8 = Rler(matrix_7, matrix_1);
                        //R9
                        matrix_9 = Rler(matrix_8, matrix_1);
                        //R*
                        for (int i = 0; i < matrix_1.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix_1.GetLength(1); j++)
                            {
                                if (matrix_1[i, j] == 1 || matrix_2[i, j] == 1 || matrix_3[i, j] == 1 || matrix_4[i, j] == 1 || matrix_5[i, j] == 1 || matrix_6[i, j] == 1 || matrix_7[i, j] == 1 || matrix_8[i, j] == 1 || matrix_9[i, j] == 1)
                                {
                                    matrix_star[i, j] = 1;
                                }
                            }
                        }
                        for (int i = 65; i < 65 + n; i++)
                        {
                            for (int j = 65; j < 65 + n; j++)
                            {
                                matrix_min[i - 65, j - 65] = r_min(matrix_1, matrix_2, matrix_3, matrix_4, matrix_5, matrix_6, matrix_7, matrix_8, matrix_9, i, j);
                            }
                        }
                        //Matrixlerin yazdırılması
                        //------------------------------------------------------------------------------------------------------------------------------------
                        var matrix_s = new int[matrixlength, matrixlength];
                        if (cki.KeyChar == 49)
                            Matrix(matrix_1, cki.KeyChar, n);
                        if (cki.KeyChar == 50)
                            Matrix(matrix_2, cki.KeyChar, n);
                        if (cki.KeyChar == 51)
                            Matrix(matrix_3, cki.KeyChar, n);
                        if (cki.KeyChar == 52)
                            Matrix(matrix_4, cki.KeyChar, n);
                        if (cki.KeyChar == 53)
                            Matrix(matrix_5, cki.KeyChar, n);
                        if (cki.KeyChar == 54)
                            Matrix(matrix_6, cki.KeyChar, n);
                        if (cki.KeyChar == 55)
                            Matrix(matrix_7, cki.KeyChar, n);
                        if (cki.KeyChar == 56)
                            Matrix(matrix_8, cki.KeyChar, n);
                        if (cki.KeyChar == 57)
                            Matrix(matrix_9, cki.KeyChar, n);
                        if (cki.KeyChar == 49)
                            Matrix(matrix_star, cki.KeyChar - 1, n);
                        if (cki.KeyChar == 48) Matrix(matrix_min, cki.KeyChar - 1, n);
                        if (cki.KeyChar == 81)
                        {
                            holder = Query(matrix_1, matrix_2, matrix_3, matrix_4, matrix_5, matrix_6, matrix_7, matrix_8, matrix_9);
                            Console.SetCursorPosition(6, 32);
                            if (holder == 0)
                                Console.WriteLine("Not possible                                         ");
                            else
                                Console.WriteLine("Minumum is : " + holder);

                        }

                        if (cki.Key == ConsoleKey.Enter)
                        {
                            StreamWriter graph = new StreamWriter("yourgraph.txt");
                            for (int i = 0; i < area.GetLength(0); i++)
                            {
                                for (int j = 0; j < area.GetLength(1); j++)
                                {
                                    graph.Write(area[i, j]);
                                }
                                graph.Write("\n");
                            }
                            graph.Close();
                            string Mname = "R1 Matrix";
                            StreamWriter matr = new StreamWriter("matrices.txt");
                            WriteText(matrix_1, matr, Mname);
                            Mname = "R2 Matrix";
                            WriteText(matrix_2, matr, Mname);
                            Mname = "R3 Matrix";
                            WriteText(matrix_3, matr, Mname);
                            Mname = "R4 Matrix";
                            WriteText(matrix_4, matr, Mname);
                            Mname = "R5 Matrix";
                            WriteText(matrix_5, matr, Mname);
                            Mname = "R6 Matrix";
                            WriteText(matrix_6, matr, Mname);
                            Mname = "R7 Matrix";
                            WriteText(matrix_7, matr, Mname);
                            Mname = "R8 Matrix";
                            WriteText(matrix_8, matr, Mname);
                            Mname = "R9 Matrix";
                            WriteText(matrix_9, matr, Mname);
                            Mname = "R* Matrix";
                            WriteText(matrix_star, matr, Mname);
                            Mname = "Rmin Matrix";
                            WriteText(matrix_min, matr, Mname);
                            matr.Close();
                        }
                    }
                }
            }
        }
    }
}