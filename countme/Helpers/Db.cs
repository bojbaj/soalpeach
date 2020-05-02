using System.Threading.Tasks;

namespace CountMe.Helpers
{
    public class Db
    {
        public Db()
        {
            SetNewNumber(0);
        }
        private int SumOfNumbers = 0;

        public Task<int> GetSumOfNumbers()
        {
            return Task.FromResult(SumOfNumbers);
        }

        public Task<int> SetNewNumber(int input_number)
        {
            SumOfNumbers += input_number;
            return GetSumOfNumbers();
        }
    }
}