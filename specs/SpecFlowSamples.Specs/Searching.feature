Feature: Searching
    Rule: Travelers can search by departure, destination, and travel class

        Scenario Outline: Searching for flights by travel class
            Given Amy is logged on as registered Frequency Flyer member
            When she searches for flights with the following criteria
              | From   | To   | Travel Class   |
              | <From> | <To> | <Travel Class> |
            Then the returned flights should match the travel class <TravelClass>
            Then Amy closes her browser

            Examples:
              | From   | To        | Travel Class    |
              | Sydney | Hong Kong | Economy         |
              | London | New York  | Premium Economy |
              | Seoul  | Hong Kong | Business        |