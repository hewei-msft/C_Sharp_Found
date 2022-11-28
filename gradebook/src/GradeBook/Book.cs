

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            set;
            get;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;

    }

    public abstract class Book: NamedObject , IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate? GradeAdded ;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }

        }

        public override Statistics GetStatistics()
        {
            //throw new NotImplementedException();
            
            var result = new Statistics();

            using(var reader =File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line !=null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();

                }
            }

            return result;
        }
    }

    public class InMemoryBook :  Book
    {
 
        private List<double> grades; 

        /*private string name;

        public string Name
        {
            get{
                return name;
            }
            set{
                if(!String.IsNullOrEmpty(value)) 
                name = value;
            }
        }*/
        
        /*
        public string Name{
            get;
            set; //readonly properties
        }
        */

        public const string CATEGORY ="Science";

        
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.Name = name;

        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
               case 'A': 
               AddGrade(90); 
               break;
               case 'B': 
               AddGrade(80); 
               break;
               case 'C': 
               AddGrade(70); 
               break;
               default: 
               AddGrade(0);
               break;
            }
        }

        public override event GradeAddedDelegate? GradeAdded;
        public override void AddGrade(double grade)
        {
            if(grade <=100 && grade >=0)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else{
                throw new ArgumentException($"invalid grade {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {


            var result = new Statistics();

            /*
            foreach(var grade in grades)
            {
                // if(number>highGrade)
                // {
                //     highGrade = number;
                // }
                result.High = Math.Max(grade,result.High);
                result.Low = Math.Min(grade,result.Low);
                result.Avereage += grade;
            }*/

            //var index = 0;
            //while(index<grades.Count)
            for(int index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            } 

            return result;

        }

    }
}