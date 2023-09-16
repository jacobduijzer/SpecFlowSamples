using Boa.Constrictor.Screenplay;
using OpenQA.Selenium.Remote;

namespace SpecFlowSamples.Specs.Tasks;

public class CloseBrowser : ITask
{
    private readonly RemoteWebDriver _browser;

    private CloseBrowser(RemoteWebDriver browser) => _browser = browser;
    
    public static CloseBrowser With(RemoteWebDriver browser) =>
        new CloseBrowser(browser);
    
    public void PerformAs(IActor actor)
    {
        _browser.Close();
    }
}