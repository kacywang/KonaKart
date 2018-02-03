Feature: Remove Item From Cart
	In order to update item from cart
	As a user of KonaKart eCommerce
	I want to remove item from cart 

@mytag
Scenario: Remove Item From Cart
	Given I Have Logged Into The Site
	When I Add Multiple Itmes To Cart
	Then I Remove Item From Cart
	Then The Cart Value Should Be Updated Correctly
