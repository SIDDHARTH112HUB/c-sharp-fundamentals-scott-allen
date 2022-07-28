namespace GradeBook
{

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    //object is baap , anything is a object
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
        //abstract method is a way of telling c# compiler that I want anything that is BookBase to have addgrade 
        // member but I dont know implementation detail let the derived base class figure out implementation
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // var writer = File.AppendText($"{Name}.txt");
            // writer.WriteLine(grade);
            // writer.Dispose();

            // m2- we can warap idisposable object in using keyword- it will ask compiler to clean this thing after curly braces
            //   after curly braces compiler automatically dispose them after using it
            using(var writer = File.AppendText($"{Name}.txt")            )
            {
                writer.WriteLine(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var Reader=File.OpenText($"{Name}.txt"))
            {
                var line =Reader.ReadLine();
                while(line!=null){
                    var number=double.Parse(line);
                    result.Add(number);
                    line=Reader.ReadLine();
                }
            }
            
            return result;
        }

    }
    public class InMemoryBook : Book
    {
        private List<double> grades;// no longer variable it is a feild . cant use var keyword
                                    // private string name;

        // how to use getter and setter to set values----
        // public string Name // here Name is property of class 
        // {
        //     get{
        //         return name;
        //     }
        //     set{
        //         if(!String.IsNullOrEmpty(value))
        //         name=value;

        //     }
        // }

        // method 2 - autoproperty 
        // public string Name
        // {
        //     get;
        //     private set;
        // }


        public InMemoryBook(string name) : base(name)//accesing base class , so i have to pass a strign also
        {
            Name = name;
            // grades = new List<double>();
        }


        readonly string category = "Science";//as says redonly,, cant modify anyone except constructor

        public void AddGrade(char letter)
        {
            // default switch case we know for ages......
            switch (letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                case 'D':
                    AddGrade(60.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;

            }
        }

        public override void AddGrade(double grade) //since it is derived from abstract , we have to write override keyword
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");//name of will make string representation of symbol
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public int Count()
        {
            return grades.Count;
        }

        public void ShowStatistics()
        {
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (double number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
            }
            System.Console.WriteLine(lowGrade);
            System.Console.WriteLine(highGrade);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (double number in grades)
            {
                result.Add(number);
            }
            
            return result;
        }
    }



}