using System.Xml.Linq;

public abstract class BudgetBase
{
    public string Name { get; private set; }
    public decimal PlanningBudget { get; protected set; }

    public BudgetBase(string name)
    {
        this.Name = name;
    }

    public abstract void AddPlanningBudget(decimal budget);
    public abstract void AddPlanningBudget(string budget);
    public abstract void AddExpenses(decimal expenses);
    public abstract void AddExpenses(string expenses);
    public abstract SummaryResults GetSummaryResults();
}
