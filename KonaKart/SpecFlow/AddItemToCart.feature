Feature: Add Items To Cart
	In order to buy multiple items
	As a user of KonaKart eCommerce
	I want to add items to shopping cart

@mytag
Scenario: Add Items To Cart
	Given I Have Logged Into The Site
	When I Add The First Item 
	And I Add The Second Item 
	And I Add The Third Item
	Then The Line Items And Quantity/Total Price Should Be All Correct
