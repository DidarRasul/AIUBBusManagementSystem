# AIUB Bus Management System

## Project Overview

The **AIUB Bus Management System** is a C# Windows Forms application developed to manage university bus transportation efficiently.

The system provides separate functionalities for **Admin, Driver, and Student** users. It manages routes, buses, drivers, students, pickup locations, time slots, bus assignments, pickup confirmations, and travel/payment records.



## User Roles

### Admin

- Manage students
- Manage drivers
- Manage other administrators
- Create and manage bus routes
- Add pickup locations
- Manage buses
- Assign buses and drivers to routes
- Manage time slots
- View transportation reports
- Monitor travel and payment records

### Driver

- View assigned buses and routes
- View assigned time slots
- View pickup locations
- View students who requested pickup
- Confirm student pickup
- Process fare payment
- Update pickup status

### Student

- View available routes
- View pickup locations and fares
- Select a pickup location
- Select a time slot
- Submit bus pickup requests
- View pickup-related information



## Main Features

- User Login and Authentication
- Student Registration
- Driver Registration
- Admin Registration and Approval
- Student Activation/Blocking
- Driver Activation/Blocking
- Admin Approval/Blocking
- Route Management
- Pickup Location Management
- Bus Management
- Driver and Bus Assignment
- Time Slot Management
- Student Pickup Selection
- Pickup Request Cut-off System
- Bus Capacity Management
- Student Pickup Confirmation
- Fare Management
- Travel and Payment Records
- Admin Reports
- Role-Based Dashboard
- Change Password
- Logout

---

## Technologies Used

- C#
- .NET
- Windows Forms
- SQL Server
- Microsoft.Data.SqlClient
- Visual Studio

---

## Database

The project uses **Microsoft SQL Server** as the database.

### Main Database Tables

- `Users`
- `AdminProfiles`
- `StudentProfiles`
- `DriverProfiles`
- `Buses`
- `Routes`
- `RouteLocations`
- `TimeSlots`
- `BusAssignments`
- `StudentPickupSelections`
- `TravelLogs`

The complete database structure and demo data are included in:

`Database/AIUBBusManagementSystem_WithData.sql`

---

## Project Structure

```text
AIUBBusManagementSystem
│
├── Database
│   └── AIUBBusManagementSystem_WithData.sql
│
├── Forms
│   ├── LoginForm
│   ├── RegisterForm
│   └── MainDashboard
│
├── Models
│
├── Repositories
│
├── Services
│
├── UserControls
│   ├── AdminDashboardControl
│   ├── DriverDashboardControl
│   └── StudentDashboardControl
│
├── Utils
│
├── Resources
│
├── Sql Query
│
├── Diagram_0.txt
├── Program.cs
├── AIUBBusManagementSystem.csproj
├── AIUBBusManagementSystem.slnx
└── README.md
```

---

## Application Architecture

The application follows a layered architecture:

```text
Forms / UserControls
        ↓
     Services
        ↓
   Repositories
        ↓
    SQL Server
```

---

## Database Query Operations

The project includes different types of SQL query operations, such as:

- Advanced SQL Queries
- JOIN Queries
- Subqueries
- Aggregate Functions
- Filtering and Sorting
- Database Reporting Queries
- Dynamic Control Creation at Run-Time

The SQL query files are available in the `Sql Query` folder.

---

## How to Run

### Requirements

- Visual Studio
- .NET
- SQL Server Express
- SQL Server Management Studio (SSMS)

### Database Setup

1. Open SQL Server Management Studio.
2. Open the database script from:

   `Database/AIUBBusManagementSystem_WithData.sql`

3. Execute the script to create the database and insert the demo data.
4. Open the project in Visual Studio.
5. Make sure the SQL Server connection string is configured correctly.
6. Run the application.

---

## Project Documentation

The project report contains the detailed documentation of the **AIUB Bus Management System**, including database design, SQL queries, system implementation, and project-related information.

---

## Future Improvements

- Online payment integration
- Real-time bus tracking
- GPS-based bus location
- Automated notifications
- Mobile application support
- Improved reporting and analytics

---

## Author

**AIUB Bus Management System**

Developed as a university academic project.

---

## License

This project is developed for educational and academic purposes.
