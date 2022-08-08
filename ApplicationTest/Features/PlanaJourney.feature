Feature: PlanaJourney
	Plan a journey through Transport for London

@mytag
Scenario: Verify that a valid journey can be planned using the widget
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Enter valid journey details From and To
	| From                  | To                                   |
	| London Borough of Hounslow Hounslow House 7 Bath Road Hounslow Middlesex TW3 3EB | 20 Maresfield Gardens, London NW3 5SX, UK |
	And Submit Plan my journey
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed

Scenario: Verify that the widget is unable to provide results when an invalid journey is planned
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Enter valid journey details From and To
	| From                  | To                                   |
	| 7 Bath Rd, Hounslow TW3 3EB, United Kingdom | 200 Above Bar St, Southampton SO14 7DW, UK |
	And Submit Plan my journey
	Then Verify landed on Journey results page
	And Verify error message Sorry, we can't find a journey matching your criteria is displayed

Scenario: Verify that the widget is unable to plan a journey if no locations are entered into the widget
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Without enter journey details Submit Plan my journey
	Then Verify error messages The From field is required. and The To field is required. are displayed

Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Enter valid journey details From and To
	| From                  | To                                   |
	| London Borough of Hounslow Hounslow House 7 Bath Road Hounslow Middlesex TW3 3EB | 20 Maresfield Gardens, London NW3 5SX, UK |
	And Change time Arriving, Tomorrow, 15:30 in Plan a journey page
	And Submit Plan my journey
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed

Scenario: On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button.
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Enter valid journey details From and To
	| From                  | To                                   |
	| London Borough of Hounslow Hounslow House 7 Bath Road Hounslow Middlesex TW3 3EB | 20 Maresfield Gardens, London NW3 5SX, UK |
	And Submit Plan my journey
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed
	When Edit journey
	And Change time Arriving, Tomorrow, 15:30 in Journey results page
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed

Scenario: Verify that the “Recents” tab on the widget displays a list of recently planned journeys.
	Given Navigate to the application
	And Navigate to tab Plan a journey
	When Enter valid journey details From and To
	| From                  | To                                   |
	| London Borough of Hounslow Hounslow House 7 Bath Road Hounslow Middlesex TW3 3EB | 20 Maresfield Gardens, London NW3 5SX, UK |
	And Submit Plan my journey
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed
	When Navigate to Home
	And Click Recents tab
	And Select recent journey plan
	Then Verify landed on Journey results page
	And Verify Fastest by public transport is displayed
