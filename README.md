# 🧪 Restful API Test Automation Framework  

A **BDD-style automation framework** built with:  
- ✅ [NUnit](https://nunit.org/) – Test runner  
- ✅ [Reqnroll](https://reqnroll.net/) – Gherkin-based BDD  
- ✅ [RestSharp](https://restsharp.dev/) – API testing client  
- ✅ [ExtentReports](https://extentreports.com/) – Reporting  
- ✅ [Newtonsoft.Json](https://www.newtonsoft.com/json) – JSON serialization/deserialization  

This **C# BDD automation framework** automates the **[Restful Booker API](https://restful-booker.herokuapp.com/)** API endpoints for CRUD (Create, Read, Update, Delete) operations with authentication and reporting.  

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
# The framework provides:  
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
- [Newtonsoft.Json](https://www.newtonsoft.com/json) for JSON serialization/deserialization
- [NUnit](https://nunit.org/) as test runner  
- [ExtentReports](https://github.com/extent-framework/extentreports-csharp) for rich reports  
---

## 🚀 Getting Started  
✅ Prerequisites

Make sure you have installed:
.NET 6.0 SDK
 or later
Visual Studio 2022
 or Rider/VS Code
NuGet packages:
NUnit
Reqnroll
RestSharp
Newtonsoft.Json
AventStack.ExtentReports

---
✅ Future Enhancements

🔹 JSON Schema Validation
🔹 CI/CD Integration (GitHub Actions, Azure DevOps, Jenkins)
🔹 Parallel Execution support
🔹 Environment-based config (QA, Staging, Prod)

