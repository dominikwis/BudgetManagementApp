using System.Diagnostics.CodeAnalysis;

var type = new BudgetInMemory("Bills");

Console.WriteLine("***********************************\n Welcome in Budget Management App!\n***********************************");
Console.WriteLine("What's your budget in PLN? ");
string input = Console.ReadLine();
type.AddPlanningBudget(input);
Console.WriteLine("Ok! Let's add some expenses:");

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
Console.WriteLine(summaryResults.SummaryBudget);

//if (type.PlanningBudget < 0)
//{
//    Console.WriteLine($"Well, you really messed up! You exceeded your budget by {summaryResults.Sum}");
//}


/*
 * Opis aplikacji
 * prosta aplikacja do ustalania budżetu początkowego a następnie wpisywanie kolejnych wydatków. Po kliknięciu jakiegoś przycisku można
 * podsumować wydatki i sprawdzić czy nie wyszło się ponad zaplanowany budżet.
 * Klasą będą kategorie danego budżetu np. Domowe, Rachunki itd.
 */