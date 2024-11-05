Feature: Calculator tests

    Scenario: Add two numbers
        Given Add 60 and 60
        Then the result should be 120

    Scenario: Subtract two numbers
        Given Subtract 120 from 60
        Then the result should be 61