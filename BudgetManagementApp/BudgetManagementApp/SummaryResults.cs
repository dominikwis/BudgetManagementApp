public class SummaryResults
{
    private decimal budget;

    public decimal Sum { get; private set; }
    public decimal SummaryBudget
    {
        get
        {
            return this.budget - this.Sum;
        }
    }

    public SummaryResults(decimal budget)
    {
        this.Sum = 0;
        this.budget = budget;
    }

    public void AddExpenses (decimal expense)
    {
        this.Sum += expense;
    }
}
