using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace UnitTestProjectSpecflow.StepDefinations
{
    [Binding]
    public sealed class LoginPageSteps
    {
        [Given(@"user is on LoginPage")]
        public void GivenUserIsOnLoginPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User gets Title of the Page")]
        public void WhenUserGetsTitleOfThePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User page Title should be ""(.*)""")]
        public void ThenUserPageTitleShouldBe(string p0)
        {
            
        }

        [Given(@"user is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            
        }

        [Then(@"forgot your password link should be displayed")]
        public void ThenForgotYourPasswordLinkShouldBeDisplayed()
        {
            
        }

        [When(@"user enters username ""(.*)""")]
        public void WhenUserEntersUsername(string p0)
        {
            
        }

        [When(@"user enters password ""(.*)""")]
        public void WhenUserEntersPassword(string p0)
        {
            
        }

        [When(@"user clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user gets the title of the page")]
        public void ThenUserGetsTheTitleOfThePage()
        {
            
        }

        [Then(@"page title should be ""(.*)""")]
        public void ThenPageTitleShouldBe(string p0)
        {
            
        }

    }
}
