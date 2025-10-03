# 🏨 RestfulBooker API Test Automation Framework

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![NUnit](https://img.shields.io/badge/NUnit-Testing-brightgreen)
![RestSharp](https://img.shields.io/badge/RestSharp-API-yellow)
![Reqnroll](https://img.shields.io/badge/Reqnroll-BDD-orange)
![ExtentReports](https://img.shields.io/badge/ExtentReports-Reporting-red)

---

## 🚀 Overview
A **fully automated API testing framework** for the ***[Restful Booker API](https://restful-booker.herokuapp.com/)**, demonstrating **end-to-end CRUD testing, authentication handling, data-driven scenarios, and rich reporting**. Designed to showcase **professional, maintainable, and scalable automation skills**.

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

## **The framework provides: ** 
✅ Easy-to-read **Gherkin feature files**  
✅ **Reusable Context** for API calls (using RestSharp)  
✅ **HTML Reports with ExtentReports**  
✅ **Request/Response logging** (saved as text/images)  
✅ **Screenshot-on-failure support** (UI/logs)

---
## ✅ **Future Enhancements**

🔹 JSON Schema Validation
🔹 CI/CD Integration (GitHub Actions, Azure DevOps, Jenkins)
🔹 Parallel Execution support
🔹 Environment-based config (QA, Staging, Prod)

