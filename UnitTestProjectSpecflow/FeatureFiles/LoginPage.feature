Feature: LoginPageTest
	Usedto test LoginSteps

Scenario: Verify theLogin  page title
	Given user is on LoginPage
	When User gets Title of the Page
	Then User page Title should be "Login - My Store"

Scenario: Forgot Password link
Given user is on the login page
Then forgot your password link should be displayed

Scenario: Login with correct credentials
Given user is on the login page
When user enters username "borawakepp4@gmail.com"
And user enters password "borawake81"
And user clicks on Login button
Then user gets the title of the page
And page title should be "My account - My Store"
