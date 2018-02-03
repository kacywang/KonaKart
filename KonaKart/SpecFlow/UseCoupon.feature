Feature: Use Coupon
	In order to apply 10% discount
	As a user of KonaKart eCommerce
	I want to use coupon

@mytag
Scenario: Use Coupon
	Given I Have Logged Into The Site
	When I Add Multiple Itmes To Cart
	And  I Enter Coupon Code
	Then I Should Be Able To Apply 10% Discount
