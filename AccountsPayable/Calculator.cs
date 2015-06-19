namespace AccountsPayable
{
    public class Calculator
    {
        public IAdder AddingMachine { get; set; }

        public int ComputeSum(int a, int b)
        {
            return AddingMachine.Add(a, b);
        }
    }
}