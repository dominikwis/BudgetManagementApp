/*
 * Opis aplikacji
 * prosta aplikacja do ustalania budżetu początkowego a następnie wpisywanie kolejnych wydatków. Po kliknięciu jakiegoś przycisku można
 * podsumować wydatki i sprawdzić czy nie wyszło się ponad zaplanowany budżet.
 * Obiektem są kategorie danego budżetu np. Domowe, Rachunki itd.
 */

List<BudgetBase> categories = new List<BudgetBase> { new BudgetInMemory("Bills"), new BudgetInFile("Bills") };

int i = 0;
string inputFileOrMemory = null;
bool boolChar = true;

Console.WriteLine("***********************************\n Welcome in Budget Management App!\n***********************************");
Console.WriteLine("Do you want to save your calculation in memory => then write 'm' or file => then write 'f'?");

do
{
    inputFileOrMemory = Console.ReadLine();

    if (inputFileOrMemory == "m")
    {
        i = 0;
    }
    else if (inputFileOrMemory == "f")
    {
        i = 1;
    }
    else
    {
        Console.WriteLine("You have to use correct letter, please repeat correctly.");
        inputFileOrMemory = null;
    }
} while (inputFileOrMemory == null);


categories[i].BudgetAdded += SuccessfulAdded;
categories[i].ExpenseAdded += SuccessfulAdded;

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
                categories[i].AddPlanningBudget(character);
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
            categories[i].AddPlanningBudget(input);
            boolChar = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            boolChar = true;
        }
    }
} while (boolChar);

var summaryResults = categories[i].GetSummaryResults();

Console.WriteLine($"\nOk! Let's add some expenses, you have still {summaryResults.SummaryBudget} PLN to allocate.");
Console.WriteLine("If you want to summarize your budet, type 'q'");

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
            
            categories[i].AddExpenses(expensesInput);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

summaryResults = categories[i].GetSummaryResults();

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