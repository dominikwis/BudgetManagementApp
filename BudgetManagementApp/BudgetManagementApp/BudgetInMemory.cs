public class BudgetInMemory : BudgetBase
{
    private List<decimal> expenses = new List<decimal>();
    public BudgetInMemory(string name)
        : base(name)
    {
    }

    public override void AddPlanningBudget(decimal budget)
    {
        if (budget > 0)
        {
            this.PlanningBudget = budget;
        }
        else
        {
            throw new Exception("The budget must be greater than 0 PLN");
        }
    }

    public override void AddPlanningBudget(string budget)
    {
        if (decimal.TryParse(budget, out decimal resultFloat))
        {
            this.AddPlanningBudget(Math.Round(resultFloat, 2));
        }
        else
        {
            throw new Exception("Invalid budget value. Try use only numbers instead of words");
        }
    }

    public override void AddExpenses(decimal expenses)
    {
        if (expenses > 0)
        {
            this.expenses.Add(expenses);
            Console.WriteLine($"Succeesfuly added {expenses} PLN");
        }
        else
        {
            throw new Exception("The expenses must be greater than 0 PLN");
        }
    }

    public override void AddExpenses(string expenses)
    {
        if (decimal.TryParse(expenses, out decimal resultDecimal))
        {
            this.AddExpenses(Math.Round(resultDecimal, 2));
        }
        else
        {
            throw new Exception("Invalid expense value. Try use only numbers instead of words");
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
