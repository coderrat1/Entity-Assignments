using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asssignments_C_sharp
{
    class Average_Marks
    {
        public static void Main()
        {
            int total = 0;
            int greater_50 = 0;
            int highmrks = 0;
            Console.WriteLine("Enter Number of Students in class: ");
            int students = int.Parse(Console.ReadLine());

            for (int i = 0; i < students; i++)
            {
                Console.WriteLine("Enter Name of Student : ");
                string studname = Console.ReadLine();

                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("Enter your marks: ");
                    int studmarks = int.Parse(Console.ReadLine());

                    if (studmarks > 100 || studmarks < 0)
                    {
                        Console.WriteLine("Invalid marks entered, Enter the new marks again which is valid ");
                        int newmarks = int.Parse(Console.ReadLine());
                        studmarks = newmarks;
                    }
                    total += studmarks;

                    if (studmarks > highmrks)
                    {
                        highmrks = studmarks;
                    }
                    if (studmarks > greater_50)
                    {
                        greater_50++;
                    }

                }
                Console.WriteLine("Studnets Name : {0} and TotalMarks : {1} and HighestMarks : {2}", studname, total, highmrks);

                double average = (total / 5.0) * 1.00;
                Console.WriteLine("Average marks of Student {0} is {1}", studname, average);
                Console.WriteLine("Marks having grater than 50 : {0}", greater_50);
                total = 0;
                greater_50 = 0;
            }
        }
    }
}
