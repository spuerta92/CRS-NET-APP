@user @ui
Feature: CRS User
Description: Tests all user functionalities

@globalsteps
Scenario: Log into CRS Application
Description: User signs in

	Given I am an '<role>' user
	When I enter my login credentials
	Then I am successfully logged in

Examples: 
| role      |
| admin     |
| professor |
| student   |

@globalsteps
Scenario: Update user information
Description: User updates their information

	Given I am an '<role>' user
	When I enter my login credentials
		And I update my user information
		| password    | roleId |
		| newpassword | 3      |
	Then I validate that my user information was successfully updated

Examples: 
| role      |
| professor |
| student   |

@globalsteps
Scenario: Add new user to the CRS system
Description: Admin user adds a new user to the system+

	Given I am an 'admin' user
	When I enter my login credentials
		And I add a new user to the system
	Then I validate that the new user was successfully created



