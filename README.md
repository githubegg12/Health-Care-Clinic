## Health-Care-Clinic
As a development team, we want to build a complete system for Clinica Salud that allows registering, consulting, and modeling information about patients and their pets.we aim to ensure a scalable, maintainable, and professional system for managing veterinary clinical operations.

## ClinicaSalud

ClinicaSalud is a modular C# .NET application designed to manage a veterinary clinic’s operations. 
It provides a structured approach to handle **patients, pets, veterinarians, and appointments**, while following **object-oriented programming** and **SOLID** design principles. 

This project is organized for scalability, code clarity, and easy maintenance — ideal for educational or small enterprise use cases.

---

## Features

- Veterinarian and patient management 
- Pet registration and tracking 
- Appointment scheduling and management 
- Modular architecture (Services, Models, Interfaces, DTOs) 
- Built with clean code and reusable components 
- Includes UML design diagram (`Docs/UML-Clinica.drawio.png`)

---

## Project Structure

```
ClinicaSalud/
│
├── ClinicaSalud.sln               # Visual Studio solution
├── LICENSE
├── README.md
│
└── ClinicaSalud/
    ├── Program.cs                 # Entry point
    ├── ClinicaSalud.csproj        # Project file
    │
    ├── Models/                    # Data entities
    │   ├── Patient.cs
    │   ├── Pet.cs
    │   ├── Person.cs
    │   ├── Veterinarian.cs
    │   └── Appointment.cs
    │
    ├── Interfaces/                # Interface definitions
    │   ├── IVetService.cs
    │   ├── IRegistrable.cs
    │   └── IAppointment.cs
    │
    ├── Services/                  # Business logic and features
    │   ├── PatientService.cs
    │   ├── VeterinarianService.cs
    │   ├── AppointmentService.cs
    │   ├── MenuService.cs
    │   ├── InputValidator.cs
    │   └── LinQ.cs
    │
    ├── Utils/                     # Helpers and console menus
    │   ├── MenuServiceView.cs
    │   └── MenuRegistrationView.cs
    │
    ├── Repositories/              # (If implemented) data storage logic
    │
    ├── Dtos/                      # Data transfer objects (empty or WIP)
    │
    └── Docs/                      # Documentation & UML
        └── UML-Clinica.drawio.png
```

---

## ⚙️ Requirements

- **.NET SDK 6.0 or later** 
- **Visual Studio 2022** or compatible IDE 
- (Optional) **Git** for version control 

---

## Installation & Execution

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/ClinicaSalud.git
   ```

2. **Open the project**
   - Launch Visual Studio
   - Open `ClinicaSalud.sln`

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Build and run**
   ```bash
   dotnet run --project ClinicaSalud/ClinicaSalud.csproj
   ```

---

## Architecture Overview

- **Models:** Represent the main entities like `Patient`, `Pet`, `Veterinarian`, and `Appointment`. 
- **Interfaces:** Define contracts for services and registrable entities. 
- **Services:** Contain the business logic and interaction between components. 
- **Utils:** Contain user interface elements and helpers. 
- **Dtos:** Define data structures for communication between layers. 
- **Repositories:** Handle data access and persistence (can be extended). 

---

## Design Principles

- Object-Oriented Programming (OOP) 
- SOLID Principles 
- Separation of Concerns 
- Reusability and Scalability 

---

## License

This project is distributed under the terms of the **MIT License**. 
See the `LICENSE` file for more details.

---

## Author

* **Name:** David Felipe Vargas Varela
* **ID:** 1140893306
* **Clan:** Caiman
* **Email:** davidvargas1224@gmail.com
