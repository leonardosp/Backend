namespace Test.Domain.Alugueis;

public static class Values
{
    private static readonly (decimal, int) sevenDays = (30m, 7);
    private static readonly (decimal, int) forteenDays = (28m, 15);
    private static readonly (decimal, int) thirtDays = (22m, 30);
    private static readonly (decimal, int) fortyFiveDays = (20m, 45);
    private static readonly (decimal, int) fiftyDays = (18m, 50);

    private static IEnumerable<(decimal, int)> PassValue = new List<(decimal, int)>
    {
        sevenDays, forteenDays, thirtDays, fiftyDays, fiftyDays
    };
}
