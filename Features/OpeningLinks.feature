Feature: Opening Links of Page

@mytag
Scenario: Links - A/B Testing
	Given I open the browser
	When click on the link - 'A/B Testing'
	Then get title of page
	
@mytag
Scenario: Links - Basic Auth
	Given I open the browser
	When click on the link - 'Basic Auth'
	Then get title of page

@mytag
Scenario: Links - Checkboxes
	Given I open the browser
	When click on the link - 'Checkboxes'
	Then get title of page
	