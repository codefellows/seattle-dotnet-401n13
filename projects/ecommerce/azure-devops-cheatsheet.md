# Azure DevOps Cheat Sheet

The documentation on how to work with Azure DevOps is located [HERE](https://docs.microsoft.com/en-us/vsts/git/share-your-code-in-git-vs-2017?view=vsts){:target="_blank"} 

The expectation is that you will get comfortable with Azure DevOps and use this documenation as reference for questions you may have.

### Create a Repo
1. Visit [Azure DevOps](https://visualstudio.microsoft.com/team-services/) and create an account using the same email you used for your Azure account
2. Create a new organization 
3. Create a new project
4. Add your partner.
5. Add your assigned TA
6. Add your Instructor(s)
7. Select "Repos" on the left hand side
8. Clone in Visual Studio
9. There may be a yellow box that appears that says "Create a new project or solution for this repository"
10. Create an empty MVC web app project as your intial commit. 
11. Name your project the name of your Ecommerce site
12. Push your project up to Azure Repos
13. You can now refresh your Azure DevOps dashboard, select Repos, and you will see your newly added files.

### Beginning of Each Sprint:
Create a new sprint at the beginning of each sprint. To create a new sprint, follow these directions:
1. Under the "Boards" tab on the left, select "Sprints"
2. Select "New Sprint" in the top right corner
3. Name your sprint "{NAME OF PROJECT} - Sprint 1"

### Create a User Story/Work item
   - Go to Work Items
   - select "Add Work Item" and select "User Story"
   - Fill out the title with as "Milestone##-US##-{DescriptionOfFeature}"
   - In the description, transfer the user story (I, as a ..., want to ..., so that...)
   - In the same description box, on a new line under the user story, provide a short description of what is expected for this user story.
   - In the "iteration" drop down, select "Sprint 1"
   - Add Acceptance criteria (min 2, max 3)
   - Add your story points/effort. 
		- Evaluate this on a 1-5 basis. 
			- 5 means this will take all day
			- 1 means it will take just a few moments
   - Assign the user story to yourself or your partner (Reference the Milestone provided)
   - SAVE your Story

### Add Tasks to a User story
   - Under "Related Work" select "Add Link"
   - select "New item"
   - Link Type: Child
   - Work item type: Task
   - Title: Name of your tasks (i.e. create Register Action)
   - Select OK
   - Fill out the description with more information about the task
   - Under the "Planning" section:
	   - Select the appropriate Activity (Development, documentation, Design, testing etc... )
	   - Set your priority
	   - Set an estimate of time in hours
	   - Assign the task to yourself or your partner (whoever will do that task)
   - Save and close
   - Follow the above steps for each task required for the user story. Each User story should approx 3 tasks per user story.

### Kanban Board

1. If you and your partner are ok with the user stories created, go to the "boards" view and drag/drop the user story to "Active" To the ones you are working on first.
2. Be sure to actively use this board and manage user stories in the appropriate column. 

### Branching a user story
When you are ready to start working on a User Story
  - Open up the user story that you want to start working on...
  - Select a specific task you are going to work on first
  - in the top right hand corner of the pop-up you will see an ellipses (...) 
  -  Upon selection choose the option that says "New Branch"
  - Name your new branch in the following format `US##-TASK##-{DescriptonOFTask}`
  - link the Branch to the task you are building
  - Select create Branch
   

### Work on your User Story
Go to your Visual Studio local code base and be sure to sync your changes first
   - Go to your branches >> Manage Branches
   - See your newly created branch
   - select your branch and do your development
   - Commit often
 
### Submit a PR
Upon completion, Push your code up to Azure DevOps
  - Go back to Azure DevOps
  - Select "Code"
  - You will see a notification at the top that says "you updated {BranchName} just now -- create a pull request"
  - select the Pull Request link in that message
  - Fill out the required details of the PR
  - Select Create
  - Assign  your partner as a reviewer (they should get an email)
 

### Review a PR
Review and approve a pull request
  - When reviewing a PR, Review the code, make notes as needed, and complete/approve as necessary
  - Select the appropriate action from the approve menu
  - Complete once approved (Blue Button top right corner)
  - complete the merge (make sure the top 2 boxes are checked)
  - Wait for merge to complete
  - Your old branch will delete and confirm that your code has the changes
 
### Complete a Task
Completing a task
 - When you complete a PR for a task, that completes the task
 - Go back to the task, and in the discussion, say how long it actually took you (in comparison to the remaining work that you estimated)

Go to the Sprints view - and move the task to "Done"


### Change Remote URL Origin (Final Submission)
These steps are only to be done for your **FINAL E-Com Submission, after Sprint 3**.

On your final submission of your project, you will be required to change the remote URL to point to a GH 
repository. Here are the steps to complete this process:

#### Add Alternative Credentials
1. Login
2. select your project
3. select your avatar in top right
4. select "security"
5. Select Alternate Creds
6. set up the alt name and password

### Changing Repos

1. Go to your local git repo on you machine
2. Confirm the current origin with the following command: `git remote show origin`
3. You will be prompted for the credentials you specified above in the setup
4. confirm that you see `fetch` and `push` url to point to Azure DevOps. 
5. Run this command `git remote set-url origin {Github Repo URL}}` (
**Example:** `git remote set-url origin https://github.com/Aiverson1011/DotNetBusMall`)
6. Conduct a `git push` on your local repo
7. Confirm your GH repo has updated,

Source: [Changing a remote url](https://help.github.com/articles/changing-a-remote-s-url/)
