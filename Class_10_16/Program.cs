using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Class_10_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[50];
            string[] undergradClasses = new string[50];
            int[] grades = new int[50];

            int count = ReadStudentFile(names, undergradClasses, grades);

            PrintData(names, undergradClasses, grades, count);

            SortByClasses(names, undergradClasses, grades, count);
            Console.WriteLine("\nAfter sorting by undergrad classes: ");
            PrintData(names, undergradClasses, grades, count);

            WriteStudentFile(names, undergradClasses, grades, count);

            Console.WriteLine("\nAverage grades for each undergraduate class: ");

            GradesByClassesReport(names, undergradClasses, grades, count);

            Console.ReadKey();
        }


        static int ReadStudentFile(string[] myNames, string[] myUndergradClasses, int[] myGrades)
        {
            StreamReader inFile = new StreamReader("input.txt");

            int count = 0;
            string delimiter = "#";
            string[] tempArray = new string[3];

            string inputLine = inFile.ReadLine();

            while (inputLine != null)
            {
                tempArray = inputLine.Split(delimiter);

                myNames[count] = tempArray[0];
                myUndergradClasses[count] = tempArray[1];
                myGrades[count] = int.Parse(tempArray[2]);

                count++;

                inputLine = inFile.ReadLine();
            }

            inFile.Close();

            return count;
        }


        static void WriteStudentFile(string[] names, string[] undergradClasses, int[] grades, int count)
        {
            StreamWriter outFile = new StreamWriter("output.txt");

            for (int i = 0; i < count; i++)
            {
                outFile.WriteLine(names[i] + "#" + undergradClasses[i] + "#" + grades[i]);
            }

            outFile.Close();
        }


        static void PrintData(string[] myNames, string[] myUnderGradClasses, int[] myGrades, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(myNames[i] + "\t\t" + myUnderGradClasses[i] + "\t\t\t" + myGrades[i]);
            }
        }


        static void SortByClasses(string[] names, string[] undergradClasses, int[] grades, int count)
        {
            int minIndex;

            for (int i = 0; i < count - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (undergradClasses[j].CompareTo(undergradClasses[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(names, minIndex, i);
                    Swap(undergradClasses, minIndex, i);
                    Swap(grades, minIndex, i);
                }
            }
        }


        static void Swap(string[] myArray, int x, int y)
        {
            string temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }


        static void Swap(int[] myArray, int x, int y)
        {
            int temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }


        static void GradesByClassesReport(string[] names, string[] undergradClasses, int[] grades, int count)
        {
            string currentClass = undergradClasses[0];
            double totalGrade = grades[0];
            int classCount = 1;
            double averageGrade;

            for (int i = 1; i < count; i++)
            {
                if (undergradClasses[i] == currentClass)
                {
                    totalGrade += grades[i];
                    classCount++;
                }
                else
                {
                    averageGrade = totalGrade / classCount;
                    Console.WriteLine("The average grade of " + currentClass + "s is " + averageGrade);

                    currentClass = undergradClasses[i];
                    totalGrade = grades[i];
                    classCount = 1;
                }
            }

            averageGrade = totalGrade / classCount;
            Console.WriteLine("The average grade of " + currentClass + "s is " + averageGrade);
        }
    }
}
