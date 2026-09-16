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



## Technologies Used

- **C#**
- **.NET**
- **Windows Forms**
- **SQL Server**
- **Microsoft.Data.SqlClient**
- **Visual Studio**


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


## Project Structure

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
