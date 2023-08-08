using BudgetManagementApp;

public abstract class BudgetBase : IBudget
{
    public string Name { get; private set; }
    public decimal PlanningBudget { get; protected set; }

    public BudgetBase(string name)
    {
        this.Name = name;
    }

    public delegate void AddedItemDelegate(object sender, EventArgs args);

    public event AddedItemDelegate BudgetAdded;
    public event AddedItemDelegate ExpenseAdded;

    public abstract void AddExpenses(decimal expenses);
    public abstract SummaryResults GetSummaryResults();

    protected void OnExpenseAdded()
    {
        BudgetAdded?.Invoke(this, EventArgs.Empty);
    }

    public void AddPlanningBudget(decimal budget)
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

    public void AddPlanningBudget(string budget)
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

    public void AddPlanningBudget(char budget)

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

    public void AddExpenses(string expenses)
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
}
