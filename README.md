# 🚀 Playwright .NET Test Automation Framework

## 📌 Overview

This project is a scalable **UI test automation framework** built using **Playwright (.NET)** and **C#**, designed to support **maintainable, reliable, and high-performance** end-to-end testing.

The framework follows modern automation best practices such as **Page Object Model (POM)**, **data-driven testing**, and **CI/CD integration**.

---

## ✨ Key Features

- **Page Object Model (POM)** for clean separation of concerns
- **Modular architecture** for scalability and maintainability
- **Data-driven testing** using structured test data providers
- **Parallel test execution** for faster feedback cycles
- **CI/CD integration** with GitHub Actions
- **Reusable components and utilities** to reduce duplication
- **Robust assertions** using Playwright’s `expect` API

---

## 🧰 Tech Stack

| Category | Technology |
|---|---|
| Language | **C#** |
| Framework | **.NET** |
| Automation | **Playwright (.NET)** |
| Test Runner | **MSTest** |
| CI/CD | **GitHub Actions** |
| Version Control | **Git** |

---

## 🏗️ Project Structure

```text
Playwright-Framework/
├── .github/
│   └── workflows/        # CI/CD pipeline configuration
├── Components/           # Reusable UI components
├── Extensions/           # Extension methods
├── Factories/            # Object creation and setup patterns
├── Fixtures/             # Test setup and teardown logic
├── Models/               # Data models
├── Pages/                # Page Object Models
├── TestData/             # Static test data
├── TestDataProviders/    # Data-driven test sources
├── Tests/                # Test cases
├── Utilities/            # Helper methods and shared utilities
├── appsettings.json      # Test configuration
└── Playwright-Framework.csproj
```

---

## ▶️ How to Run Tests

### Prerequisites

- Install **.NET SDK**
- Install Playwright dependencies

### Run tests locally

```bash
dotnet test
```

---

## ⚙️ CI/CD Integration

This framework includes a **GitHub Actions pipeline** that:

- Runs tests on **push and pull requests**
- Provides **continuous validation**
- Helps detect defects early in the development cycle

---

## 🧪 Sample Test Flow

Example scenario covered in this framework:

1. Navigate to application
2. Search for a product
3. Validate search results
4. Add product to cart
5. Verify cart behavior

---

## 💻 Example Test

```csharp
[TestMethod]
public async Task Search_Should_Return_Results()
{
    await homePage.Search("laptop");
    await Expect(resultsPage.ProductItems.First).ToBeVisibleAsync();
}
```

---

## 🎯 Design Principles

- **Maintainability** → Clean structure using POM
- **Scalability** → Modular architecture supports growth
- **Reliability** → Playwright auto-waiting reduces flakiness
- **Reusability** → Shared utilities minimize duplication

---

## 🚧 Future Enhancements

- Cross-browser testing using **Chromium, Firefox, and WebKit**
- Advanced reporting integration
- Environment-based configuration
- Visual regression testing

---

