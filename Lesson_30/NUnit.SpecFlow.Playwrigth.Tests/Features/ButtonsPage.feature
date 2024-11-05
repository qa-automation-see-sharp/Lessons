
@notHeadless @slowMo @withVideo @args("--start-maximized")
Feature: Buttons page tests

    Scenario: 1_Double click the button
        Given I'm on the Buttons page
        When I double click the button
        Then I should see text for double click You have done a double click

    Scenario: 2_Right click the button
        When I right click the button
        Then I should see text for right click You have done a right click

    Scenario: 3_Click the button
        When I click the button
        Then I should see text for usual click You have done a dynamic click