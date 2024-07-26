**Git**

Git is a version control system that allows you to track changes in your codebase.
It is a distributed version control system, which means that you can work on your
codebase offline and then push your changes to a remote repository
when you are ready to share them with others.
Git is widely used in the software development industry and is an essential tool for any developer.

**Git commands:**

- git init - initialize a new Git repository
- git clone - clone a repository into a new directory
- git add - add file contents to the index
- git commit - record changes to the repository
- git push - update remote refs along with associated objects
- git pull - fetch from and integrate with another repository or a local branch
- git status - show the working tree status
- git log - show commit logs
- git branch - list, create, or delete branches
- git checkout - switch branches or restore working tree files

**Create a new repository locally and push it to GitHub:**

- echo "# Homeworks" >> README.md
- git init
- git add README.md
- git commit -m "first commit"
- git branch -M main or mater
- git remote add origin https://link-to-your-repository.git
- git push -u origin main or master

**Push an existing repository from the command line**

- git remote add origin https://link-to-your-repository.git
- git branch -M main
- git push -u origin main

**dotnet terminal/console commands:**

- dotnet new - create a new project
- dotnet build - build a project and all of its dependencies
- dotnet run - run a project
- dotnet test - run tests using a test runner

**How to create a dotnet Solution with a project from a terminal:**

- dotnet new sln --output MySolution
- cd MySolution
- dotnet new console --output MyProject
- dotnet sln add MyProject

Here is a link to documentation for [dotnet new sln](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln) command.

Here is a link to documentation for [dotnet new ](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) command.