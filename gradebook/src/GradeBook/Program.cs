using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            // double[] numbers=new double[] {1.0,2.153645123456789,3,4,5,7};
            // numbers[0]=2.6;
            // var result=0.0;
            // foreach (double number in numbers)
            // {
            //     result+=number;
            // }
            // System.Console.Write(result);
            // List<double> grades=new List<double>();


            // Book book2 =null;
            // book2.AddGrade(30.5);// null point exception

            //static- is not associated with an object instance , they are associated with type that they are defines inside of.

            // var p= new Program();
            // p.Main(args); // main can not be refernced by object, it is associated with class
            // but
            // Program.Main(args);
            // We can acces static member using class refence 

            var book = new DiskBook("Sid's Grade Book");

            book.GradeAdded += OnGradeAdded;

            // var done=false;
            EnterGrades(book);

            var result = book.GetStatistics();

            // book.Name="sidd"; can not set now since set is private
            System.Console.WriteLine($"For book name is {book.Name}");
            System.Console.WriteLine($"lowest grade is {result.Low}");
            System.Console.WriteLine($"highest grade is {result.High}");
            System.Console.WriteLine($"Average grade is {result.average}");
            System.Console.WriteLine($"letter grade is {result.Letter}");


            // var book1 = GetBook("Book 1");
            // var book2 = book1;

            // GCHandle handle = GCHandle.Alloc(book1, GCHandleType.WeakTrackResurrection);

            // long address = (long)GCHandle.ToIntPtr(handle);
            // System.Console.WriteLine(address); //1597512488920

            // GCHandle handle2 = GCHandle.Alloc(book2, GCHandleType.WeakTrackResurrection);

            // long address2 = (long)GCHandle.ToIntPtr(handle2);
            // System.Console.WriteLine(address2); ///1597512488912
            // different output pointing to same obkject from different location


            // var book1 = GetBook("Book 1");
            // SetName(book1, "New Name");

            // GCHandle handle = GCHandle.Alloc(book1, GCHandleType.WeakTrackResurrection);

            // long address = (long)GCHandle.ToIntPtr(handle);
            // System.Console.WriteLine(address); //3024635697104


            // var book2 = GetBook("Book 2");
            // void SetName(Book book1, string v)
            // {
            //     book1.Name = v;
            //     GCHandle handle = GCHandle.Alloc(book1, GCHandleType.WeakTrackResurrection);

            //     long address = (long)GCHandle.ToIntPtr(handle);
            //     System.Console.WriteLine(address); //3024635697112

            //     // here the value stored in book1 is passed in function using different variable, means ram and shyam two different variable
            //     // pointing to same object
            // }
            // book.grades.Add(101);

            // Book.AddGrade(77.5);;//an object is required to refence the noe static member

            // result=Math.Acos(1);
            // Console.WriteLine(result);
            // var grades=new List<double>(){1.0,2.153645123456789,3,4,5,7};
            // grades.Add(10.2);

            // result=result/grades.Count;
            // System.Console.Write($"{result:N1}");// format specifier 1 place after decimal
            // if(args.Length>0)
            // {
            //     // Console.WriteLine("Hello "+grades[0]+"!");
            // }
            // else{
            //     Console.WriteLine("Hello");
            // }
            // Console.WriteLine();
            InMemoryBook GetBook(string name)
            {
                return new InMemoryBook(name);
            }


            static void OnGradeAdded(object sender, EventArgs e)
            {
                System.Console.WriteLine("Grade id Added");
            }
        }

        private static void EnterGrades(IBook book)
        {
            
            while (true)
            {
                System.Console.WriteLine("Please enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var d = double.Parse(input);
                    book.AddGrade(d);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    // throw; if I throw my program will terminate
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally//a piece of code we always want to execute
                {
                    System.Console.WriteLine("**");
                }
            }
        }
    }
}
// Console.WriteLine("Hello ");
