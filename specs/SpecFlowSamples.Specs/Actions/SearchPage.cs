using OpenQA.Selenium;
using Boa.Constrictor.WebDriver;

namespace SpecFlowSamples.Specs.Actions;

public static class SearchPage
{
    public const string Url =
        "https://www.duckduckgo.com/";

    public static IWebLocator SearchInput => new WebLocator(
        "DuckDuckGo Search Input",
        By.Id("searchbox_input"));

    public static IWebLocator SearchButton => new WebLocator(
        "Google Search Button",
        By.ClassName("searchbox_searchButton__F5Bwq"));
    
    public static IWebLocator ResultLinks => new WebLocator(
        "DuckDuckGo Result Page Links",
        By.ClassName("At_VJ9MlrHsSjbfCtz2_"));
}