# StudLib

A desktop application for managing student, book, and loan records in a database.

## 📱 Overview

StudLib is a desktop application designed to manage records related to students, books, and loans. It provides a user-friendly interface for performing CRUD (Create, Read, Update, Delete) operations on a Microsoft SQL Server database.

## 🚀 Technologies

- C# (.NET Framework)  
- Windows Forms  
- Microsoft SQL Server  
- ADO.NET  
- Visual Studio  

## ✨ Features

- Manage student records  
- Manage book records  
- Track loan records  
- Perform CRUD operations on the database  
- User-friendly Windows Forms interface  

## 👢 Project Structure

```
StudLib/
├── StudLib.sln               # Visual Studio solution file
├── StudLib/                  # Main project folder
│   ├── Properties/           # Project properties
│   ├── Forms/                # Windows Forms UI files
│   ├── Models/               # Data models
│   ├── Database/             # Database interaction logic (ADO.NET)
│   └── Program.cs            # Application entry point
└── README.md                 # Project documentation
```

## 🛠️ Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/GingerCRO/StudLib.git
   ```

2. Open the solution file `StudLib.sln` in Visual Studio.

3. Ensure you have Microsoft SQL Server installed and running.

4. Configure the database connection string inside the project to point to your SQL Server instance.

5. Build the solution.

## ▶️ Running the App

In Visual Studio, press **F5** or click **Start** to run the application.

## ✅ Testing

Make sure your SQL Server is running and accessible. Test database operations via the UI by creating, reading, updating, and deleting student, book, and loan records.

## 🤝 Contributing

If you would like to contribute:

- Fork the project  
- Create a new branch: `git checkout -b feature/feature-name`  
- Commit your changes: `git commit -m 'Add new feature'`  
- Push to GitHub: `git push origin feature/feature-name`  
- Open a Pull Request  

## 📄 License

This project is licensed under the MIT License. For more details, see the LICENSE file.

## 🙏 Acknowledgments

Inspired by the need for efficient management of student and library records.
