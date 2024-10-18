Product CRUD Application
Overview
The Product CRUD application allows users to manage product information within a database. Users can perform operations such as adding new products, viewing a list of existing products, updating product details, and deleting products. The application is built using ASP.NET MVC, utilizing jQuery for asynchronous requests and Bootstrap for styling.

Features
Create (Add Product)

Users can add new products through a form that includes fields for product name and description.
Upon submission, the product is stored in the database, and success or error messages are displayed.
Read (View Products)

A list of existing products is displayed in a tabular format, showing product ID, name, description, and creation date.
Users can view all products at once.
Update (Edit Product)

Users can edit product details by clicking an edit icon next to the product entry.
The form is populated with the selected product’s current information, allowing for easy modifications.
Changes are saved back to the database upon form submission.
Delete (Remove Product)

Users can delete a product by clicking a delete icon next to the product entry.
A confirmation dialog prompts the user to confirm the deletion.
Upon successful deletion, the product is removed from the database and the table is updated without a full page reload.
Technology Stack
Frontend: ASP.NET MVC, HTML, CSS (Bootstrap), JavaScript (jQuery)
Backend: ASP.NET Core MVC, C#
Database: SQL Server
User Experience
The application is designed to be user-friendly with a responsive layout.
It provides feedback on user actions through success and error messages displayed on the interface.
Icons from Font Awesome are used to enhance the visual appeal of the action buttons.
