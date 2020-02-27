Feature: Utility


Scenario Outline: Verify application health with healthcheck endpoint
	Given I am using Vin.DataAcess.Customer
	When I hit the healthcheck endpoint
	Then the API returns OK

	