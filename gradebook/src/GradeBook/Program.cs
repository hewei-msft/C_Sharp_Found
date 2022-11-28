// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new[]{12.7, 10.3,6.11, 4.99};

            Book? book = new DiskBook("scotts grade book");
            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.5);
            book.GradeAdded += onGradeAdded;

            EnterGrades(book);

            Console.WriteLine(InMemoryBook.CATEGORY);

            /*Program p = new Program();
            p.Main(args);*/

            var stats = book.GetStatistics();
            Console.WriteLine($"Avereage grade are  {stats.Avereage:N1}");
            Console.WriteLine($"the high grade is {stats.High}");
            Console.WriteLine($"the low grade is {stats.Low}");
            Console.WriteLine($"the Letter is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Type a number");

                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    if(input != null)
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void onGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade has been added");
        }
    }


}

