# LicenFlow 🚗💳

**LicenFlow** is a comprehensive Driving and Vehicle Licensing Department (DVLD) management system. It is designed to automate, organize, and streamline all operations related to driving applications, license issuance, tests management, and user permissions with a secure and intuitive desktop interface.

---

## 📺 Project Demo

You can watch the full video demonstration of the system in high quality on Google Drive from the link below:
👉 **https://drive.google.com/file/d/1ttHlNKUhG_ZQ1HOu91pndxTCF-4JER8P/view?usp=sharing**

*Make sure to update this link with your Google Drive shareable link.*

---

## 📐 System Architecture & Design Patterns

The project is built using an **N-Tier Architecture** (Multi-Tier) to ensure a strict separation of concerns, maintainability, and scalability:

1. **Presentation Layer (WinForms UI):** Built with highly reusable **Custom Controls** to eliminate code duplication and maintain a consistent UI/UX across all forms.
2. **Business Logic Layer (BLL):** Handles all core validation, business rules, and decision-making logic before interacting with the database.
3. **Data Access Layer (DAL):** Manages direct database communication securely using structured queries and performance-optimized execution.

---

## ✨ Key Features & Workflows

* **People Management:** A centralized system to register, update, and manage national and personal data for citizens and applicants.
* **Users & Permissions Management:** Admin controls to manage employee accounts, assign roles, and handle account activation states.
* **Application Tracking:** Comprehensive workflows for handling application states (New, In-Progress, Completed, Cancelled).
* **Driving Tests Management:** Structured flows for capturing and locking test results (Vision Test, Theory Test, and Practical Street Test).
* **License Operations:** Full support for issuing new licenses, renewals, replacements for damaged or lost licenses, and managing detained/released licenses.

---

## 🗄️ Database Design (`DVLD_DB`)

The system utilizes a robust relational database schema carefully mapped out to support all operations:
* **People:** Stores master records (National No, Name, Date of Birth, Contact Info).
* **Users:** Holds employee credentials linked to their person records and authorization status.
* **Applications:** Tracks application types, sub-types, fees, and real-time status.
* **Licenses:** Stores issued licenses, issue dates, expiration dates, and custom notes.

---

## 🛠️ Tech Stack

* **Programming Language:** C# (.NET Framework)
* **UI Framework:** Windows Forms (WinForms)
* **Database Management:** Microsoft SQL Server
* **Architecture:** N-Tier Architecture (DAL, BLL, PL)

---

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2022 or later.
* Microsoft SQL Server.

### Installation & Setup
1. **Clone the repository:**
```bash
   git clone [https://github.com/HananNosirat/LicenFlow.git](https://github.com/HananNosirat/LicenFlow.git)

2.Open the solution file LicenFlow.sln using Visual Studio.

3.Restore the SQL Server database using the backup or scripts found in the DVLD_DB folder.

4.Update the connection string inside the App.config file to match your local SQL Server instance.

5.Build and Run the application.
