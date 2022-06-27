# TTD Kata Exercise

TDD (Test-Driven Development) practice taken from https://osherove.com/. Personal journal and record only.


# TDD Kata Exercise Summary

### TDD Kata 1 - String Calculator
Practice Scenario: [TDD Kata 1 - String Calculator — Roy Osherove](https://osherove.com/tdd-kata-1)
Progress can be found here: [cuppyzh/TDD-Kata-Exercise at feature/tdd-kata-1 (github.com)](https://github.com/cuppyzh/TDD-Kata-Exercise/tree/feature/tdd-kata-1)
Time Taken: 59m25s

**Summary**
Step 1--6 quite simple and easy, it was done under 20 minute, the issue occurred when more complex substring required during the remain step. 

On the middle of Step 7, I just realized that some of the requirement is missing, so need to fix something from Step 6.
Also, the code was changed from using Substring to Regex to simplify the code. 

**Room to Improve**
- Application of Substring sometimes confusing me
- Need to learn to be Native on Regex

### TDD Kata 2 - Interaction
Practice Scenario: [TDD Kata 1 - String Calculator — Roy Osherove](https://osherove.com/tdd-kata-2)
Progress can be found here: [cuppyzh/TDD-Kata-Exercise at feature/tdd-kata-1 (github.com)](https://github.com/cuppyzh/TDD-Kata-Exercise/tree/feature/tdd-kata-2)
Time Taken: 29m09s

**Summary**
Applying ILogger feature that need to works when the program is run, but also not block the unit test. Since I had used the Moq before, so the steps is not difficult. The issue is when applying the ILogger it self. Since I'm using Console Application, so I need to find and install the dependencies by my self.

**Room to Improve**
- Still doing this on Visual Studio, need to be fluent in Visual Code to more versatile language/framework
