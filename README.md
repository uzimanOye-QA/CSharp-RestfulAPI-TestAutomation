# 🧪 Restful API Test Automation Framework  

[![.NET 6](https://img.shields.io/badge/.NET-6.0-blueviolet)](https://dotnet.microsoft.com/)  
[![NUnit](https://img.shields.io/badge/Tested%20With-NUnit-green)](https://nunit.org/)  
[![SpecFlow / Reqnroll](https://img.shields.io/badge/BDD-Reqnroll-orange)](https://reqnroll.net/)  
[![Extent Reports](https://img.shields.io/badge/Reports-ExtentReports-red)](https://extentreports.com/)  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)  

---

## 📌 Overview  
This is a **C# BDD automation framework** for testing the [Restful Booker](https://restful-booker.herokuapp.com/) API endpoints.  
It covers **CRUD operations (GET, POST, PUT, PATCH, DELETE)** and verifies API responses with assertions.  

The framework provides:  
✅ Easy-to-read **Gherkin feature files**  
✅ **Reusable Context** for API calls (using RestSharp)  
✅ **HTML Reports with ExtentReports**  
✅ **Request/Response logging** (saved as text/images)  
✅ **Screenshot-on-failure support** (UI/logs)  

---

## ⚙️ Tech Stack  

- [C# / .NET 6](https://dotnet.microsoft.com/)  
- [Reqnroll (SpecFlow alternative)](https://reqnroll.net/) for BDD  
- [RestSharp](https://restsharp.dev/) for API requests  
- [Newtonsoft.Json](https://www.newtonsoft.com/json) for JSON serialization  
- [NUnit](https://nunit.org/) as test runner  
- [ExtentReports](https://github.com/extent-framework/extentreports-csharp) for rich reports  

---

## 📂 Project Structure  

📂 RestfulAPITestAutomationFramework
┣ 📂 Features # BDD Feature files (Gherkin)
┣ 📂 StepDefinitions # Step definitions (Reqnroll/NUnit)
┣ 📂 SetUp # Context & Base setup classes
┣ 📂 Model # Request/Response DTOs
┣ 📂 Reports # HTML reports
┣ 📂 Screenshots # Captured screenshots/logs
┣ 📜 README.md # Project documentation



---

## 🚀 Getting Started  

### 1️⃣ Clone the repo  
```bash
git clone https://github.com/your-username/RestfulAPITestAutomationFramework.git
cd RestfulAPITestAutomationFramework

2️⃣ Install dependencies

Make sure you have:
.NET 6 SDK or higher
NUnit Test Adapter
RestSharp, Reqnroll, ExtentReports, Newtonsoft.Json

Restore dependencies:
dotnet restore

3️⃣ Run the tests

dotnet test

🧪 Example Feature

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


✅ Future Enhancements

🔹 JSON Schema Validation
🔹 CI/CD Integration (GitHub Actions, Azure DevOps, Jenkins)
🔹 Parallel Execution support
🔹 Environment-based config (QA, Staging, Prod)

