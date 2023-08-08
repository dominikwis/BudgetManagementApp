using BudgetManagementApp;

public class BudgetInMemory : BudgetBase
{
    private List<decimal> expenses= new List<decimal>();

    public BudgetInMemory(string name)
        : base(name)
    {
    }

    public override void AddExpenses(decimal expenses)
    {
        if (expenses > 0)
        {
            this.expenses.Add(expenses);

            OnExpenseAdded();    

            Console.Write($"{expenses} PLN\n");
        }
        else
        {
            throw new Exception("The expenses must be greater than 0 PLN");
        }
    }

    public override SummaryResults GetSummaryResults()
    {
        var summaryResults = new SummaryResults(this.PlanningBudget);

        foreach (var expense in this.expenses)
        {
            summaryResults.AddExpenses(expense);
        }

        return summaryResults;
    }
}
