🧱 MVC Architecture
This project follows the MVC (Model-View-Controller) architectural pattern, which is widely used to organize code in a structured and maintainable way.

🔹 Model
Represents the data layer of the application.

Manages the logic for data storage, retrieval, and rules.

Handles communication with the SQL Database.

In this project, it includes:

Product details

Billing records

Customer information

🔹 View
Represents the presentation layer.

Displays data to the user and captures user input.

Implemented using Windows Forms (WinForms) in C#.NET.

Provides interfaces such as:

Product entry form

Billing screen

Summary reports

🔹 Controller
Acts as the intermediary between Model and View.

Handles user actions, processes business logic, and updates the view accordingly.

Coordinates between the database (Model) and UI (View).

✅ Benefits of MVC
Separation of Concerns: Each component (Model, View, Controller) has a specific role.

Maintainability: Easier to debug, test, and enhance specific parts of the application.

Scalability: Modular structure allows for easier future expansion.

Reusability: Logic and UI are independent, enabling code reuse.

