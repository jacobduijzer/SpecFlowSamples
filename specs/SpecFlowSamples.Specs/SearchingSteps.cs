using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SpecFlowSamples.Specs.Actions;
using SpecFlowSamples.Specs.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowSamples.Specs;

[Binding]
public class SearchingSteps
{
    private readonly Actor _actor;
    private readonly RemoteWebDriver _browser;
    
    public SearchingSteps()
    {
        _actor = new Actor("Jacob", new ConsoleLogger());
        _browser = new ChromeDriver();
        _actor.Can(BrowseTheWeb.With(_browser));
    }

    [Given(@"Amy is logged on as registered Frequency Flyer member")]
    public void GivenAmyIsLoggedOnAsRegisteredFrequencyFlyerMember()
    {
        _actor.AttemptsTo(Navigate.ToUrl(SearchPage.Url));
    }

    [When(@"she searches for flights with the following criteria")]
    public void WhenSheSearchesForFlightsWithTheFollowingCriteria(Table table)
    {
        var searchCriteria = table.CreateInstance<SearchCriteria>();
        _actor.AttemptsTo(SearchDuckDuckGo.For(
            $"Flying from {searchCriteria.From} to {searchCriteria.To} in {searchCriteria.TravelClass} class"));
    }

    [Then(@"the returned flights should match the travel class (.*)")]
    public void ThenTheReturnedFlightsShouldMatchTheTravelClassEconomy(string testing)
    {
        _actor.WaitsUntil(Appearance.Of(SearchPage.ResultLinks), IsEqualTo.True()); 
    }

    [Then(@"Amy closes her browser")]
    public void ThenAmyClosesHerBrowser()
    {
        _actor.AttemptsTo(CloseBrowser.With(_browser));
    }
}