Feature: Posts

Scenario Outline: Create a new post
	Given I create a new post using id '<id>' name '<name>' role '<role>' and email '<email>'
Examples: 
| id | name   | role      | email            |
| 11 | Harsha | Developer | harsha@gmail.com |

Scenario Outline: Retreive a post
	Given I should be able get the record using id '<id>'
Examples: 
| id |
| 11 |

Scenario Outline: Delete a post
	Given I should be able delete the record with id '<id>'
Examples: 
| id |
| 11 |

Scenario Outline: Update an existing post
	Given I update an existing emailID '<email>' for a post using id '<id>' name '<name>' role '<role>'
Examples: 
| email                    | id | name                   | role   |
| harsha_vardhan@gmail.com | 11 | Harsha Vardhan Tankala | Tester |