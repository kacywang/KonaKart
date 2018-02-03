Feature: Search Microsoft
	In order to see Windows 8
	As a user of KonaKart eCommerce
	I want to search under Software category for "Microsoft"

@mytag
Scenario: Search Microsoft
	Given I Have Logged Into The Site
    When I Click Software Category
    And I Click Microsoft Link
    Then I Should Be Albe To See Windows8 