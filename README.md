

# Web UI Automation Framework – C# / Selenium / NUnit

This project is a Web UI Automation Framework built with C#, Selenium, and NUnit. It is designed to automatically test a web application by performing actions such as logging in, selecting products, adding items to the cart, and completing checkout. The framework follows a clean architecture with separate folders for pages, tests, and utilities, making the code easy to maintain, extend, and scale. When a test fails, the framework captures a screenshot and error details to support debugging. The roadmap includes improvements such as reporting, parallel execution, environment configuration.

## Technology Stack
- C# .NET 8  
- Selenium WebDriver  
- NUnit  
- ChromeDriver  
- VS Code  
- Linux (Ubuntu), Windows, macOS  

## Prerequisites
- .NET SDK 8.0 or later  
- Google Chrome (latest stable version)  
- ChromeDriver matching the installed Chrome version  
- Git  
- A C#‑compatible IDE (VS Code, Rider, Visual Studio)

### OS‑Specific Notes
**Windows:**  
ChromeDriver must be added to the system PATH or placed in the project root.

**macOS:**  
ChromeDriver must be made executable using:  
`chmod +x chromedriver`  
Ensure the driver version matches the installed Chrome version.

**Linux (Ubuntu):**  
Ensure execution permissions and correct driver version.

## How to Run Tests
Restore dependencies:  
```
dotnet restore
```

Run all tests:  
```
dotnet test
```

Run a specific test class:  
```
dotnet test --filter TestClassName
```

---



## How to Pull the Project from GitHub

To download the project locally, use the following steps:

### Clone the repository
```
git clone https://github.com/alexchal1990/WebsiteAutomationFramework.git
```

### Navigate into the project folder
```
cd WebsiteAutomationFramework
```

### Pull the latest changes (if the project already exists locally)
```
git pull origin main
```

If your default branch is **master**, use:
```
git pull origin master
```

---

If you want, I can also add:

- A **Git workflow section** (branching, commits, PRs)  
- A **“How to contribute”** section  
- A **“How to update dependencies”** section  

Just tell me.
