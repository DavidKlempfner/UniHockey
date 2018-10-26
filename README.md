# UniHockey Web App

# Purpose
To provide a user friendly UI that allows score keeping during tournaments.

# Goals/Milestones
1.	Set up the application and the GitHub repo. The app should just display simple text.
2.	Set up CI/CD using VSTS and have it deploy to Azure when the master branch is written to.
3.	Set up DB and EntityFramework so that you can write one row to a dummy table.
4.	Begin the first feature of the app which will be to record scores in a game.

# Must have
1.	Dependency injection.
2.	Resource file to store strings so you can use different languages (German).
3.	Security (AntiForgeryTokens, CORS, Authorization and Authentication filters).
4.	Unit tests.
5.	Client-side model validation.
6.	Bundles/Minification (to save the number of HTTP requests for JS/CSS files).
7.  Logging (Elmah)
8.  Repository pattern/Unit of Work pattern
9.  Transactions in DB (everything is undone if just one command doesn't work)
