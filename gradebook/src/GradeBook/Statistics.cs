namespace GradeBook
{
    public class Statistics
    {
        public double average
        {
            get
            {
                return sum / Count;
            }
        }
        public double Low;
        public double High;
        public double sum;
        public char Letter
        {
            get
            {
                switch (average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                        
                }

            }
        }
        public int Count;

        public void Add(double number)
        {
            sum += number;
            Count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
        public Statistics()
        {
            Count = 0;
            sum = 0.0;
            Low = double.MaxValue;
            High = double.MinValue;
        }


    }
}