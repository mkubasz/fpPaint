Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 5 into the calculator
	Given I have entered 7 into the calculator
	When I called add
	Then the result should be 12
@mytag
Scenario: Substract two numbers
	Given I have entered 12 into the calculator
	Given I have entered 7 into the calculator
	When I called substraction
	Then the result should be 2