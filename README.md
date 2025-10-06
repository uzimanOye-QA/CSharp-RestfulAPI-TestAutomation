# 🏨 RestfulBooker API Test Automation Framework

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![NUnit](https://img.shields.io/badge/NUnit-Testing-brightgreen)
![RestSharp](https://img.shields.io/badge/RestSharp-API-yellow)
![Reqnroll](https://img.shields.io/badge/Reqnroll-BDD-orange)
![ExtentReports](https://img.shields.io/badge/ExtentReports-Reporting-red)

---

## 🚀 Overview
A **fully automated API testing framework** for the ***[Restful Booker API](https://restful-booker.herokuapp.com/)**, demonstrating **end-to-end CRUD testing, authentication handling, data-driven scenarios, and rich reporting**. Designed to showcase **professional, maintainable, reliable and scalable automation skills**.

---

## 💡 Key Features

| Feature | Description |
|---------|-------------|
| **CRUD Operations** | Create, Retrieve, Update (PUT), Partial Update (PATCH), Delete bookings |
| **Negative Testing** | Delete without authentication and other error scenarios |
| **Data-Driven Testing** | Gherkin scenarios mapped to strongly-typed models (`BookingModel`) |
| **Authentication Handling** | Automatic token creation and management |
| **Reporting** | Step-level **ExtentReports**, HTML reports, API logs, and screenshots |
| **Validation** | Status codes, response payloads, and object-level comparison |

---
## 🛠 Technologies Used

- **C# (.NET 8.0)**  
- **RestSharp** – HTTP requests  
- **Newtonsoft.Json** – JSON serialization/deserialization  
- **NUnit** – Test execution and assertions  
- **Reqnroll & SpecFlow** – Gherkin-based BDD automation  
- **ExtentReports** – Professional HTML reporting
- - **Visual Studio 2022** - IDEs used

---
## 🎯 Example Test Scenarios

Scenario: Booking_01_Verify that a new booking can be created(POST) and retrieved(GET)
	Given that RestfulBooker web services with resource auth is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I retrieve the booking I just created
	Then the status code must be equal to OK
	And the following records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |
		
---
## 📊 Sample Test Execution Report

Below are sample screenshots from the **ExtentReports HTML Report** generated after running the automated API tests.

### 🧩 Dashboard Overview
Displays overall feature, scenario, and step-level execution summary.
![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/APi%20Result_Dashboard%20Overview.png)

---

### ✅ Detailed Scenario Report
Shows individual API test scenarios (POST, GET, PUT, PATCH, DELETE) and their pass/fail status.

![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/Detailed%20APi%20Scenario%20Report.png)

---

### 🧾 API Request & Response Logs
Each test saves its request and response details automatically for traceability.

![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/API%20result_logs%20file.png)

---

## 💡 Key Features

| Feature | Description |
|---------|-------------|
| **CRUD Operations** | Create, Retrieve, Update (PUT), Partial Update (PATCH), Delete bookings |
| **Negative Testing** | Delete without authentication and other error scenarios |
| **Data-Driven Testing** | Gherkin scenarios mapped to strongly-typed models (`BookingModel`) |
| **Authentication Handling** | Automatic token creation and management |
| **Reporting** | Step-level **ExtentReports**, HTML reports, API logs, and screenshots |
| **Validation** | Status codes, response payloads, and object-level comparison |

---

## 🛠 Technologies Used

- **C# (.NET 8.0)**  
- **RestSharp** – HTTP requests  
- **Newtonsoft.Json** – JSON serialization/deserialization  
- **NUnit** – Test execution and assertions  
- **Reqnroll & SpecFlow** – Gherkin-based BDD automation  
- **ExtentReports** – Professional HTML reporting
- - **Visual Studio 2022** - IDEs used   
---
## 📂 Project Structure  
```text
📦 RestfulAPITestAutomationFramework  
├── 📂 Features          # Gherkin BDD feature files  
├── 📂 StepDefinitions   # Step definitions (Reqnroll/NUnit)  
├── 📂 SetUp             # Context & setup classes (API client, auth handling)  
├── 📂 Model             # DTOs for requests & responses  
├── 📂 Reports           # Generated HTML reports (ExtentReports)  
├── 📂 Screenshots       # Screenshots/logs for failed tests  
└── 📜 README.md         # Documentation  

---
## 🎯 Example Test Scenarios

Scenario: Booking_01_Verify that a new booking can be created(POST) and retrieved(GET)
	Given that RestfulBooker web services with resource auth is loaded for POST call
	When I create a new booking with the following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |
	Then the status code must be equal to OK
	And a new booking ID is generated
	When I retrieve the booking I just created
	Then the status code must be equal to OK
	And the following records must be retrieved from Booking table
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
		| Usman     | Oye      | 523        | false       | 2017-08-09 | 2022-06-26 | Breakfast       |
---


## 📊 Sample Test Execution Report

Below are sample screenshots from the **ExtentReports HTML Report** generated after running the automated API tests.

### 🧩 Dashboard Overview
Displays overall feature, scenario, and step-level execution summary.
![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/APi%20Result_Dashboard%20Overview.png)
---

### ✅ Detailed Scenario Report
Shows individual API test scenarios (POST, GET, PUT, PATCH, DELETE) and their pass/fail status.

![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/Detailed%20APi%20Scenario%20Report.png)
---

### 🧾 API Request & Response Logs
Each test saves its request and response details automatically for traceability.

![image alt](https://github.com/uzimanOye-QA/CSharp-RestfulAPI-TestAutomation/blob/3b37e003debaab056905fe71c6a30793d422f4a0/API%20result_logs%20file.png)
---


## 🚀 Getting Started  
### 1️⃣ Clone the repo  
```bash
git clone https://github.com/your-username/CSharp-RestfulAPI-TestAutomation.git
cd RestfulAPITestAutomationFramework
---
2️⃣ Install Dependencies

Make sure you have installed:
.NET 6 SDK or higher
NUnit Test Adapter (for Visual Studio / Rider)
NuGet packages: RestSharp, Newtonsoft.Json, Reqnroll, ExtentReports

Restore dependencies:
dotnet restore
---
3️⃣ Run the tests

dotnet test
--- 


