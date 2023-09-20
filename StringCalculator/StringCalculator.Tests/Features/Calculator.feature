﻿Feature: Calculator
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
