using System;
using System.Collections.Generic;
using Xunit;

public class BillCalculatorTests
{
    [Fact]
    public void SplitAmount_ShouldSplitEqually_WhenPeopleGreaterThanZero()
    {
        decimal amount = 100;
        int people = 4;
        decimal expectedSplit = 25;

        decimal actualSplit = BillCalculator.SplitAmount(amount, people);

        Assert.Equal(expectedSplit, actualSplit);
    }

    [Fact]
    public void SplitAmount_ShouldThrowException_WhenPeopleZero()
    {
        decimal amount = 100;
        int people = 0;

        Assert.Throws<ArgumentException>(() => BillCalculator.SplitAmount(amount, people));
    }

    [Fact]
    public void SplitAmount_ShouldThrowException_WhenPeopleNegative()
    {
        decimal amount = 100;
        int people = -2;

        Assert.Throws<ArgumentException>(() => BillCalculator.SplitAmount(amount, people));
    }

    [Fact]
    public void CalculateIndividualTips_ShouldCalculateCorrectTip_ForMultiplePeople()
    {
        var mealCosts = new Dictionary<string, decimal>
        {
            {"Alice", 25m},
            {"Bob", 30m},
            {"Charlie", 20m}
        };
        float tipPercentage = 15f;
        var expectedTip = new Dictionary<string, decimal>
        {
            {"Alice", 3m},
            {"Bob", 3.6m},
            {"Charlie", 2.4m}
        };

        var actualTip = BillCalculator.CalculateIndividualTips(mealCosts, tipPercentage);

        Assert.Equal(expectedTip, actualTip);
    }

    [Fact]
    public void CalculateIndividualTips_ShouldThrowException_WhenMealCostsEmpty()
    {
        var mealCosts = new Dictionary<string, decimal>();
        float tipPercentage = 15f;

        Assert.Throws<ArgumentException>(() => BillCalculator.CalculateIndividualTips(mealCosts, tipPercentage));
    }

    [Fact]
    public void CalculateIndividualTips_ShouldCalculateCorrectTip_ForSinglePerson()
    {
        var mealCosts = new Dictionary<string, decimal>
        {
            {"Alice", 100m}
        };
        float tipPercentage = 20f;
        var expectedTip = new Dictionary<string, decimal>
        {
            {"Alice", 20m}
        };

        var actualTip = BillCalculator.CalculateIndividualTips(mealCosts, tipPercentage);

        Assert.Equal(expectedTip, actualTip);
    }

    [Fact]
    public void CalculateIndividualTip_ShouldThrowException_WhenPeopleZero()
    {
        decimal totalPrice = 100m;
        int people = 0;
        float tipPercentage = 20f;

        Assert.Throws<ArgumentException>(() => BillCalculator.CalculateIndividualTip(totalPrice, people, tipPercentage));
    }

    [Fact]
    public void CalculateIndividualTip_ShouldCalculateCorrectTip_WhenTipPercentageZero()
    {
        decimal totalPrice = 100m;
        int people = 4;
        float tipPercentage = 0f;
        decimal expectedTipPerPerson = 0m;

        decimal actualTipPerPerson = BillCalculator.CalculateIndividualTip(totalPrice, people, tipPercentage);

        Assert.Equal(expectedTipPerPerson, actualTipPerPerson);
    } 
}
