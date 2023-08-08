using static BudgetBase;

public class BudgetInFile : BudgetBase
{
    private const string fileName = "expenses.txt";

    public BudgetInFile(string name)
        : base(name)
    {
        ClearFile();
    }

    public override void AddExpenses(decimal expenses)
    {
        if (expenses > 0)
        {

            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(expenses);
            }

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

        if (File.Exists(fileName))
        {
            using (var reader = File.OpenText(fileName))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var number = decimal.Parse(line);

                    summaryResults.AddExpenses(number);

                    line = reader.ReadLine();
                }
            }
        }
            return summaryResults;
    }

    private void ClearFile()
    {
        File.WriteAllText(fileName, string.Empty);
    }
}
