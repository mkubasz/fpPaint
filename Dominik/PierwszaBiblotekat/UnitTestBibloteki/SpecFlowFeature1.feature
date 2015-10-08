Feature: SpecFlowFeature1
  In order to avoid silly mistakes
       As a math idiot
       I want to be told the sum of two numbers
@mytag
Scenario: Add two numbers
	Given I have entered 6 into the class
	Given I have entered 5 into the class too
	When I call method
	Then the result should be 11 
