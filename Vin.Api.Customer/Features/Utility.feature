Feature: Utility

Scenario Outline: Verify application health with healthcheck endpoint
	Given I am using Vin.Api.Customer
	When I hit the healthcheck endpoint
	Then the API returns OK

	Scenario Outline: Verify healthcheck endpoint does not requirer Bearer Token
	Given I am using Vin.Api.Customer
	When I hit the healthcheck endpoint
	Then the API does not return UnAuthorized