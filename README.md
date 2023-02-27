# uSync-membership-test

Sample project to test the issue with membership. Set up using the following steps:

    # Ensure we have the latest Umbraco templates
    dotnet new -i Umbraco.Templates::10.4.0

    # Create solution/project
    dotnet new umbraco --force -n "MyProject" --friendly-name "Administrator" --email "admin@test.com" --password "Pa55word!!" --development-database-type LocalDB

    #Add starter kit and uSync
    dotnet add "MyProject" package uSync --version 10.3.2
    dotnet add "MyProject" package clean
    
## Steps to reproduce

