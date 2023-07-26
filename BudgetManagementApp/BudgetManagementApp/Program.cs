var type = new BudgetInMemory("Bills");
bool boolChar = true;

type.BudgetAdded += SuccessfulAdded;
type.ExpenseAdded += SuccessfulAdded;

Console.WriteLine("***********************************\n Welcome in Budget Management App!\n***********************************");

do
{
    Console.WriteLine("What's your budget in PLN? ");
    string input = Console.ReadLine();
    if (input.Length == 1)
    {
        if (char.IsLetter(input[0]))
        {
            char character = input[0];

            try
            {
                type.AddPlanningBudget(character);
                boolChar = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                boolChar = true;
            }
        }
    }
    else
    {
        try
        {
            type.AddPlanningBudget(input);
            boolChar = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            boolChar = true;
        }
    }
} while (boolChar);

    Console.WriteLine("\nOk! Let's add some expenses:");

while (true)
{
    string expensesInput = Console.ReadLine();

    if (expensesInput == "q")
    {
        break;
    }
    else
    {
        try
        {
            type.AddExpenses(expensesInput);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

var summaryResults = type.GetSummaryResults();

if (summaryResults.SummaryBudget < 0)
{
    var positiveNumber = summaryResults.SummaryBudget;
    positiveNumber = Math.Abs(positiveNumber);
    Console.WriteLine($"Well, you really messed up! You exceeded your budget by {positiveNumber} PLN");
}
else if (summaryResults.SummaryBudget == 0)
{
    Console.WriteLine($"Congratulations, you've hit the budget on the dot!");
}
else
{
    Console.WriteLine($"You are the best! You stayed within the planned budget. You still have to allocate: {summaryResults.SummaryBudget} PLN");
}

void SuccessfulAdded (object sender, EventArgs args)
{
    Console.Write("Successfuly added ");
}

/*
 * Opis aplikacji
 * prosta aplikacja do ustalania budżetu początkowego a następnie wpisywanie kolejnych wydatków. Po kliknięciu jakiegoś przycisku można
 * podsumować wydatki i sprawdzić czy nie wyszło się ponad zaplanowany budżet.
 * Klasą będą kategorie danego budżetu np. Domowe, Rachunki itd.
 */