namespace CountMe.Helpers
{
    public class Db
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