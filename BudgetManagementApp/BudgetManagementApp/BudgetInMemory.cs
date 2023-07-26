using BudgetManagementApp;

public class BudgetInMemory : BudgetBase
{
    private List<decimal> expenses;

    public override event AddedItemDelegate BudgetAdded;
    public override event AddedItemDelegate ExpenseAdded;

    public BudgetInMemory(string name)
        : base(name)
    {
        expenses = new List<decimal>();
    }

    public override void AddPlanningBudget(decimal budget)
    {
        if (budget > 0)
        {
            this.PlanningBudget = budget;
            
            if (BudgetAdded != null)
            {
                BudgetAdded(this, new EventArgs());
                Console.Write($"{budget} PLN\n");
            }
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

    public override void AddPlanningBudget(char budget)

    {
        switch (budget)
        {
            case 'a':
            case 'A':
                this.AddPlanningBudget(100000);
                break;
            case 'b':
            case 'B':
                this.AddPlanningBudget(10000);
                break;
            case 'C':
            case 'c':
                this.AddPlanningBudget(1000);
                break;
            case 'D':
            case 'd':
                this.AddPlanningBudget(100);
                break;
            default:
                throw new Exception("You can only use letter from Alphabet 'a - b' or numbers. Try Again\n");
        }
    }
    public override void AddExpenses(decimal expenses)
    {
        if (expenses > 0)
        {
            this.expenses.Add(expenses);

            if (ExpenseAdded != null)
            {
                ExpenseAdded(this, new EventArgs());
                Console.Write($"{expenses} PLN\n");
            }
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
            throw new Exception("Invalid expense value. Try use only numbers instead of words or letters");
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
