# User Stories



## What are User Stories?
- Are short, simple, and open for interpretation
- Should clearly communicate the end goal of the user
- Includes Acceptance Testing

## INVEST In Your User Stories
- **Independent**: The user story should be self-contained, in a way that there is no inherent dependency on another user story
- **Negotiable**: user stories, up until they are part of an iteration, can always be changed and rewritten
- **Valuable** to users or Customers: a user story must deliver value to the end user
- **Estimable**: You must always be able to estimate the size of a user story.
- **Small**: User stories should not be so big as to become impossible to plan/task/prioritize  with a certain level of certainty
- **Testable**: the user story or it's related description must provide the necessary information to make test development possible.

## What Does It Look like?
- "As a \<role>, I want \<goal> so that \<benefit>" ("so that ..." is optional if no explanation is needed)
- As a user, I want to search for my customers by their first and last names so that I can quickly navigate to their accounts.
- As a non-administrative user, I want to modify my own schedules but not the schedules of other users.

## Example
- As an administrative user, I want the ability to modify all employee's schedules.

### Features:
- Admin can choose which users schedules to view/edit
- Show the options for all employees schedules
- Select ability to have recurring schedules
- Save schedule changes

### Acceptance:
- Ensure that the employee the admin picked links to the correct schedule
- Ensure the scheduling does not interfere with requested time off
- Ensure that the schedules successfully save into database
- Provide error message and abort transaction if system becomes unavailable
