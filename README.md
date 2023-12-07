# STGenetics Web Application

Welcome to the ST Genetics Web Application! Our goal is to create a user-friendly web platform that enables users to manage the listing, creation, editing, deletion, and selling of bulls and cows from our farms. As a developer, your responsibility is to build a web page adhering to the specified business rules outlined below. Let's work together to make this application a success!
## Installation

Provide clear instructions on how to install and set up your project. Include dependencies and any other necessary configurations.

git clone https://github.com/gasierram/STGenetics

cd STGenetics

dotnet build

dotnet ef dbcontext scaffold "Server=(local); DataBase=AnimalDatabase; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


## Business Rules:
Data Model:

Animal:
AnimalId / Name / Breed / BirthDate / Sex (Male/Female) / Price / Status (Active/Inactive).
Create a fictitious database with 20 animals.
Web Application:

## Default Page:

Main page of the web application with a suggested Navigation Menu.


## Farm Page:

The Page contents form with all the existing fields in the Animal database, including a "Filter" button to filter data in the grid.

### Grid:

Based on the provided requirements, I've implemented the following features for the grid component:

Displaying Data:

Created a grid below the form that displays all data and columns from the Animal database.
CRUD Operations:

Implemented support for insertion, updating, and deletion of lines in the grid. Users can add new animals, edit existing ones, and delete entries directly from the grid.
Pagination:

Implemented pagination functionality, with each page displaying 10 animals. This ensures a user-friendly experience when navigating through a large dataset.
Footer Summary:

Included a footer in the grid showing the sum of values in the Price column. This allows users to quickly see the total value of the displayed animals.
Checkbox Selection:

Added a checkbox column in the grid to enable users to select animals for further actions. This could include bulk updates or deletions.
Dropdown Menu (Optional):

Optionally, included a dropdown menu in the grid line to provide users with the ability to select an item from a list. This feature enhances the functionality and user interaction within the grid.
With these features in place, the grid component becomes a comprehensive and user-friendly tool for managing animal data. Users can efficiently navigate, modify, and interact with the data in a seamless manner. The optional dropdown menu provides additional flexibility for specific actions or selections within the grid.

Feel free to provide more details or ask specific questions if you have further inquiries or if there are additional features you'd like to discuss!
Page:

Display all selected animals in the grid grouped by breed.
Show the total purchase amount, discount percentage, and shipping amount.

### Business Rules:

If the customer adds an animal with a quantity greater than 5 in the cart, apply a 5% discount on the value of this animal.
If the customer buys more than 10 animals in the order, add an additional 3% discount to the total purchase price.
If the customer buys more than 20 animals in the order, the freight value must be free; otherwise, charge $1,000.00 for freight.
Avoid duplicating animals in the order; display an error message if a duplicate is identified.
Menu:


## Contact
gusvo21@hotmail.com is my contact information for other developers or users to reach out if they have questions or comments.

## Acknowledgements
Thank anyone or any resources that have been helpful for this project.
