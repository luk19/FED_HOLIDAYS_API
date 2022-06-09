# LB_API_Project
Simple API built in C# that returns information on US Federal Holidays given dates from 2021-2023.



### Instructions to Build and Run Project
1. If not already installed, download and install your preferred API Platform ([Postman](https://www.postman.com/downloads/) recommended)
2. If not already installed, download and install your preferred C# IDE ([JetBrains Rider](https://www.jetbrains.com/rider/download/#section=mac) or [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/) recommended)
3. Clone the [LB_API_Project](https://github.com/luk19/LB_API_Project) Repository to your installed C# IDE
4. Open the LB_API_Project
5. If not already installed, install the "System.Data.SQLite" package on your C# IDE

    a. In Rider --> right click on the main "ProjectFile" folder, click "Manage NuGet Packages", seach for "System.Data.SQLite", click the appropriate package in the left pane and click the green + symbol in the right pane to install
   
    b. In Visual Studio -->

6. With the LB_API_Project open in your C# IDE, open "Program.cs"
7. Run "Program.cs"

    a. In Rider --> Click the "Run" button near the top right corner of the application

    b. In Visual Studio --> 

9. In the output/console, the script should print the url and port number that this app is "listening" on, example: Now listening on: https://localhost:5001
10. Copy the secure url and paste it into a browser or in a postman get request and hit Send/Enter. This should return the text "Hello World!"
11. Using the same url as above add the endpoint "/isHoliday/{iso-formatted-date}" to the url. Example: https://localhost:5001/isHoliday/2021-01-01 14:05:00:123




### API Endpoints that can be Called
1. /
2. /isHoliday




### External Libraries Used
1. System.Data.SQLite   -->   version # 1.0.116




### SQLite Database Schema




### Assumptions Made
1. I assumed the accepted date could be simply added at the end of the url request (https://localhost:9999/endpoint/date) rather than submitted as a parameter.
2. I assumed it was okay for the user/evaluator of this project to use an IDE to build and run the project rather than building and running it on a server or command line interface.




### Feedback




### General Notes
Overall, I'm extremely happy with the outcome of this project. When I read the first sentence of the Assignment description "Build a simple API, preferably in C#",
I was a bit overwhelmed because I've never built an API and I've never coded a single line of C# before. It was challenging in many ways and I was seriously ecstatic
that I was able to dive in and complete this project. I think my lack of C# experience is evident in the code, which I think is okay because I had fun, learned a ton, 
and understand I have a lot more to learn.




### Time Spent
- So far: 15 hours




### Problems/Issues
- Returning an actual JSON object...




### Enhancements
1. Adding user authentication logic with an API token
2. Adding a user input option and endpoint for a date range rather than a specific date that would return all holidays in the specified date range.


