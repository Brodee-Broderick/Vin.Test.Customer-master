Feature: FInd or Create

Scenario Outline: Using Find and Create to add a New Customer
Given I have a proper json payload
When sending the New Customer payload to the find and create endpoint
Then I get a unique customer id