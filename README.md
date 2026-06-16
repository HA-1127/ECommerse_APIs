# E-Commerce Application

The E-Commerce Application is a comprehensive platform designed to manage the entire online shopping experience. It includes multiple modules to handle customer management, product cataloging, shopping cart, orders, payments, cancellations, refunds, and user feedback. The application is built with a focus on clean architecture, maintainability, and security, ensuring a robust and scalable solution.

---

## Features

### Customer and Address Management
- **Registration:** Enables new customers to create accounts with validated personal information.
- **Authentication:** Secure login using hashed passwords via BCrypt.
- **Profile Management:** Retrieve, update, and delete customer profiles.
- **Multiple Addresses:** Support for multiple billing and shipping addresses per customer.
- **Data Integrity & Security:** Validation rules and unique constraints (e.g., email) ensure accurate and secure data.

### Product and Category and brand and order Management
- **Category Management:** Create, read, update, and delete product categories. Each category can include multiple products.
- **Product Management:** CRUD operations for products, stock management, discounts, and image handling.
 - **brand Management:** CRUD operations for products, stock management, discounts, and image handling.

### Shopping Cart
- **Add to Cart:** Add products to the cart from product listings or detail pages.
- **View Cart:** View all items, quantities, individual prices, and totals.
- **Update Cart Items:** Modify quantities with real-time stock validation.
- **Remove from Cart:** Remove individual items or clear the cart.
- **Cart Persistence:** Retain cart data across sessions for authenticated users and guest sessions.

### Order Management
- **Order Creation:** Place orders with multiple items, automatic calculation of totals, discounts, and shipping costs.
- **Status Tracking:** Manage statuses such as Pending, Processing, Shipped, Delivered, and Canceled.
- **Financial Tracking:** Detailed breakdown of base amounts, discounts, shipping, and total costs.
- **Order Item Management:** Track product quantity, unit price, discounts, and total price. Update stock automatically.

### Payment Management
- **Payment Processing:** Integrates with payment gateways (e.g., Stripe, PayPal) or Cash on Delivery (COD).
- **Payment Records:** Maintain detailed transaction records.
- **Order Integration:** Link payments to orders and update statuses accordingly.
- **Transaction Management:** Track transaction IDs, statuses, and refunds.

### Cancellation Module
- **Cancellation Requests:** Handle requests for eligible orders.
- **Status Management:** Update order status to "Canceled."
- **Stock Restoration:** Restore canceled order items to stock.
- **Notification:** Inform stakeholders about cancellations.

### Refund Module
- **Refund Requests:** Process refunds for canceled orders or returned products.
- **Payment Integration:** Secure and efficient refund transactions via existing payment gateways.
- **Financial Tracking:** Maintain clear records of refund amounts and statuses.
- **Notification:** Notify customers about refund status.

### User Feedback Module
- **Feedback Submission:** Allow customers to submit ratings and reviews for purchased products.
- **Feedback Validation:** Ensure only legitimate buyers can leave feedback.
- **Update and Delete Feedback:** Modify or remove feedback entries.
- **Average Rating Calculation:** Compute average product ratings.
- **Detailed Feedback Listings:** Display customer names, ratings, comments, and submission dates.

---
## 📂 Project Structure

- **Controllers** → Handle the flow between Views and Services.  
- **Services** → Business logic layer.  
- **Repositories** → Data access layer using Repository Pattern.  
- **Data** → Contains `DbContext` and database configuration.  
- **Models** → Entity classes.  
- **DTOs** → Data Transfer Objects for communication between layers.  
- **ViewModels** → Bind data between Controllers and Views.  
- **Migrations** → EF Core migrations for database updates.  
- **Views** → Razor Views (UI layer).  
- **wwwroot** → Static files (CSS, JS, Images).  

---

## 🏗️ Architecture

### 🔹 Repository Pattern
- Provides a clean abstraction over the data layer.  
- **Generic Repository** → Common CRUD operations.  
- **Custom Repositories** → Specific queries per entity.  

### 🔹 Unit of Work (UoW)
- Manages database transactions.  
- Ensures multiple repository operations are committed as a single unit (all succeed or all fail).  

---


## 🧰 Technology Stack

| Type | Technologies |
|------|---------------|
| **Backend** | ASP.NET Core MVC |
| **ORM** | Entity Framework Core |
| **Database** | Microsoft SQL Server |
| **Frontend** | Razor Views + Bootstrap + Custom CSS |
| **Patterns** | Repository Pattern, Unit of Work, Dependency Injection |
| **Libraries** | AutoMapper for mapping between ViewModels and Entities |
