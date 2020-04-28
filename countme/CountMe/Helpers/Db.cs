namespace CountMe.Helpers
{
    public interface IDb
    {
        int GetSumOfNumbers();
        int SetNewNumber(int input_number);
    }
    public class Db : IDb
    {
        private static int SumOfNumbers = 0;

        public int GetSumOfNumbers()
        {
            return SumOfNumbers;
        }

        public int SetNewNumber(int input_number)
        {
            SumOfNumbers += input_number;
            return GetSumOfNumbers();
        }
    }
}