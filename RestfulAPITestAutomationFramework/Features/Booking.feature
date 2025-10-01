Feature: Booking API Tests
  As a user of the Booking API
  I want to perform CRUD operations on bookings
  So that I can manage hotel reservations

Scenario: Booking_01_Verify that a new booking can be created(POST) and retrieved(GET)
	Given that RestfulBooker web services with resource auth is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I retrieve the booking I just created
	Then the status code must be equal to OK
	And the following records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |

Scenario: Booking_02_Verify that new Booking record can be created(POST), retrieved(GET) and modified(PUT).
	Given that RestfulBooker web services with resource Booking is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Akin      | Oye      | 200        | false       | 2025-09-01 | 2025-09-07 | Lunch           |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I update the booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Tobi      | Ola      | 250        | true        | 2025-10-01 | 2025-10-07 | Dinner          |
	Then the status code must be equal to OK
	When I retrieve the booking I just created
	Then the status code must be equal to OK
	And the following records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Tobi      | Ola      | 250        | true        | 2025-10-01 | 2025-10-07 | Dinner          |


Scenario: Booking_03_Verify that booking can be Deleted
	Given that RestfulBooker web services with resource Booking is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Invalid   | Delete   | 500        | true        | 2025-01-01 | 2025-01-10 | Guarded         |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I delete the booking I just created 
	Then the status code must be equal to Created
	When I retrieve the booking I just created
	Then the status code must be equal to NotFound
	

Scenario: Booking_04_Verify deletion fails without token (DELETE Negative)
	Given that RestfulBooker web services with resource Booking is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Invalid   | Delete   | 500        | true        | 2025-01-01 | 2025-01-10 | Guarded         |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I delete the booking I just created without Authetication token
	Then the status code must be equal to Forbidden
	When I retrieve the booking I just created
	Then the status code must be equal to OK
	And the following records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Invalid   | Delete   | 500        | true        | 2025-01-01 | 2025-01-10 | Guarded         |
	
Scenario: Booking_05_Verify that an existing Booking record can be partially modified (PATCH)
	Given that RestfulBooker web services with resource Booking is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| John      | Doe      | 300        | true        | 2024-05-15 | 2024-05-20 | WiFi            |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I partially update the booking with the following details
		| firstname | lastname |
		| Jane      | Smith    |
	Then the status code must be equal to OK
	And the partially updated records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Jane      | Smith    | 300        | true        | 2024-05-15 | 2024-05-20 | WiFi            |

Scenario: Ping_08_Verify API health check
	Given that RestfulBooker web services with resource ping is loaded for GET call
	Then the status code must be equal to Created
