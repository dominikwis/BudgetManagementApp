public class BudgetInMemory : BudgetBase
{
    private List<decimal> expenses;
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
            Console.WriteLine($"Succeesfuly added {budget} PLN");
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
                throw new Exception("You can only use letter from Alphabet 'a - b'");
        }
                // Dodając litery np. a lub A dodaje się odrazu 100 000 zł
                // dalej jeśli b to 10 000 zł
                // jeśli c to 1000 zł
                // jeśli d to 100 zł.
                // jesli e to 10 zł.
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
