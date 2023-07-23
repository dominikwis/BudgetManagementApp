namespace BudgetManagementApp
{
    public interface IBudget
    {
        string Name { get; }
        decimal PlanningBudget { get; }

        void AddPlanningBudget(decimal budget);
        void AddPlanningBudget(string budget);
        void AddExpenses(decimal expenses);
        void AddExpenses(string expenses);
        void AddPlanningBudget(char expenses);
        SummaryResults GetSummaryResults();
    }
}
