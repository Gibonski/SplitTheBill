public static class BillCalculator
{
    public static decimal SplitAmount(decimal amount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
        {
            throw new ArgumentException("Number of people must be greater than 0.", nameof(numberOfPeople));
        }
        return amount / numberOfPeople;
    }

    public static Dictionary<string, decimal> CalculateIndividualTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        var tipPerPerson = new Dictionary<string, decimal>();
        decimal totalBill = mealCosts.Values.Sum();
        decimal tipAmount = totalBill * (tipPercentage / 100);

        foreach (var person in mealCosts)
        {
            decimal individualPercentage = person.Value / totalBill;
            tipPerPerson.Add(person.Key, tipAmount * individualPercentage);
        }

        return tipPerPerson;
    }

    public static decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPeople, float tipPercentage)
    {
        if (numberOfPeople <= 0)
        {
            throw new ArgumentException("Number of people must be greater than 0.", nameof(numberOfPeople));
        }
        decimal tipAmount = totalPrice * (tipPercentage / 100);
        return tipAmount / numberOfPeople;
    }
}
