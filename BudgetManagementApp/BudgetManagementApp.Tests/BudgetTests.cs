namespace BudgetManagementApp.Tests
{
    public class BudgetTests
    {
        [Test]
        public void CheckIfAddPlanningBudgetWorks()
        {
            var budget = new BudgetInMemory("Bills");

            budget.AddPlanningBudget(1000);

            Assert.AreEqual(budget.PlanningBudget, 1000);
        }

        [Test]
        public void CheckIfAddPlanningBudgetStringValidadtionWorks()
        {
            var budget = new BudgetInMemory("Bills");

            budget.AddPlanningBudget("500");

            Assert.AreEqual(budget.PlanningBudget, 500);
        }

        [Test]
        public void CheckIfAddPlanningBudgetExceptionWorks()
        {
            var budget = new BudgetInMemory("Bills");

            Exception ex = Assert.Throws<Exception>(() => budget.AddPlanningBudget("piecset"));

            Assert.AreEqual(ex.Message, "Invalid budget value. Try use only numbers instead of words");
        }

        [Test]
        public void CheckIfAddExpensesExceptionWorks()
        {
            var budget = new BudgetInMemory("Bills");

            Exception ex = Assert.Throws<Exception>(() => budget.AddExpenses("cztery"));

            Assert.AreEqual(ex.Message, "Invalid expense value. Try use only numbers instead of words or letters");
        }

        [Test]
        public void CheckIfAddPlanningBudgetWorksInFile()
        {
            var budget = new BudgetInFile("Bills");

            budget.AddPlanningBudget(1000);

            Assert.AreEqual(budget.PlanningBudget, 1000);
        }

        [Test]
        public void CheckIfAddPlanningBudgetStringValidadtionWorksInFile()
        {
            var budget = new BudgetInFile("Bills");

            budget.AddPlanningBudget("500");

            Assert.AreEqual(budget.PlanningBudget, 500);
        }

        [Test]
        public void CheckIfAddPlanningBudgetExceptionWorksInFile()
        {
            var budget = new BudgetInFile("Bills");

            Exception ex = Assert.Throws<Exception>(() => budget.AddPlanningBudget("piecset"));

            Assert.AreEqual(ex.Message, "Invalid budget value. Try use only numbers instead of words");
        }

        [Test]
        public void CheckIfAddExpensesExceptionWorksInFile()
        {
            var budget = new BudgetInFile("Bills");

            Exception ex = Assert.Throws<Exception>(() => budget.AddExpenses("cztery"));

            Assert.AreEqual(ex.Message, "Invalid expense value. Try use only numbers instead of words or letters");
        }
    }
}