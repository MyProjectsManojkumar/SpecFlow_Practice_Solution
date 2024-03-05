Feature: Checkboxes


@tag1
Scenario: Checkboxes
	Given I open the browser
	When click on the link - 'Checkboxes'
	Then get title of page
	When Select the Checkbox

@tag1
Scenario: Form Authentication
	Given I open the browser
	When click on the link - 'Form Authentication'
	Then get title of page
	Then get the text of the page
	When Enter the details of login page