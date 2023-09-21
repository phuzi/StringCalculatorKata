Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding strings of numbers

Link to a feature: [Calculator](StringCalculator.Tests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add empty string
  Given the entered string is ""
  When the string is added
  Then the result should be 0

Scenario: Add one number
  Given the entered string is "1"
  When the string is added
  Then the result should be 1

Scenario: Add two numbers
  Given the entered string is "1,2"
  When the string is added
  Then the result should be 3

Scenario Outline: Unknown number of numbers
    Given the entered string is "<expression>"
    When the string is added
    Then the result should be <result>

    Examples: 
        | expression   | result |
        | 1,2,3        | 6      |
        | 1,2,3,4      | 10     |
        | 1,2,3,4,5    | 15     |
        | 1,2,3,4,5,6  | 21     |

Scenario: New-line delimiter
  Given the entered string is "1\n2,3"
  When the string is added
  Then the result should be 6

Scenario Outline: Custom delimiter
    Given the entered string is "<expression>"
    When the string is added
    Then the result should be <result>

    Examples: 
        | expression        | result |
        | //\|\n1\|2\|3     | 6      |
        | //:\n1:2:3        | 6      |
        | //;\n1;2;3        | 6      |
        | //$\n1$2$3        | 6      |

Scenario Outline: Negative numbers not allowed
    Given the entered string is "<expression>"
    When the string is added
    Then an exception should be thrown
    And the exception message should be "<message>"

    Examples: 
        | expression | message                      |
        | -1,2       | Negatives not allowed: -1    |
        | 2,-4,3,-5  | Negatives not allowed: -4,-5 |
