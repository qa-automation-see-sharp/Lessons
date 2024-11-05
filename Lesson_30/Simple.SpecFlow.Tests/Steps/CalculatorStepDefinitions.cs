using Simple.SpecFlow.Tests.Drivers;
using TechTalk.SpecFlow;

namespace Simple.SpecFlow.Tests.Steps;

[Binding]
public class CalculatorStepDefinitions
{
    private readonly Calculator _calculator;

    public CalculatorStepDefinitions(Calculator calculator)
    {
        _calculator = calculator;
    }

    [Given(@"Add (.*) and (.*)")]
    public void GivenIHaveEnteredIntoTheCalculator(int firstNumber, int secondNumber)
    {
        _calculator.Add(firstNumber, firstNumber);
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.That(_calculator.Result, Is.EqualTo(result));
    }

    [Given(@"Subtract (.*) from (.*)")]
    public void GivenSubtractFrom(int firstNumber, int numberTwo)
    {
        _calculator.Subtract(firstNumber, numberTwo);
    }
}