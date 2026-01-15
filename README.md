# University Exams and Academic ERP Module

A structured learning and demonstration project built using ASP.NET Core MVC to model a university academic portal. The focus is on exams, grading, GPA/CGPA computation, academic structure, and configurable rules as implemented in enterprise ERP systems for higher education.

This project reflects typical workflows found in university ERP solutions and is intended to develop practical experience in C#, .NET, SQL Server, Entity Framework Core, and backend-oriented business domain design.

---

## Objectives

- Implement an academic and examinations domain for university environments.
- Utilize ASP.NET Core (MVC), SQL Server, and Entity Framework Core in a realistic context.
- Support configurable grading scales, exam types, and progression rules.
- Model academic structure (schools, programs, courses, semesters, enrollments).
- Produce reporting outputs commonly required by academic administration.
- Target future cloud deployment for operational learning.

---

## Current Status

- Initial ASP.NET Core project structure created (MVC prioritized).
- Application builds and runs successfully in a local development environment.
- Database integration and core domain model implementation pending.

---

## Technology Stack

- Language: C#
- Framework: ASP.NET Core (.NET 8)
- IDE: Visual Studio 2022 or newer
- Database: SQL Server (LocalDB or full instance)
- ORM: Entity Framework Core (planned)
- Authentication: ASP.NET Identity (planned)
- Hosting (future): Azure or AWS

---

## Domain Overview (Planned)

Core domain entities:

- School / Faculty
- Program
- AcademicYear
- Semester
- Course
- Student
- Enrollment
- ExamType
- Assessment
- GradingScale
- GradingBand
- ProgramRule

Key domain capabilities:

- Configurable grading scales per program.
- Configurable exam types and assessment weightings.
- GPA and CGPA computation.
- Progression evaluation (proceed, retake, discontinue).
- Administrative and analytical reporting.

---

## Phase Roadmap

Phase 1 — Academic Structure
- Configure Entity Framework Core with SQL Server.
- Implement School, Program, Course, AcademicYear, and Semester models.
- Build administrative CRUD interfaces for academic setup.

Phase 2 — Exams and Grading
- Implement ExamType, Assessment, GradingScale, and GradingBand models.
- Implement grade calculation driven by configuration.
- Display results and GPA/CGPA for students.

Phase 3 — Progression and Rules
- Introduce ProgramRule for progression criteria.
- Evaluate per-student progression state.
- Provide academic reports and summaries.

Phase 4 — Portals and Authentication
- Add ASP.NET Identity roles (Student, Lecturer, Admin).
- Student portal for results and transcripts.
- Admin portal for configurations, approvals, and publication.

Phase 5 — Deployment and Operations
- Implement logging and audit trails.
- Deploy to Azure or AWS.
- Document deployment steps and operational considerations.

---

## Repository Structure (Initial)

- `UniversityERP.Portal/` - main ASP.NET Core MVC project
- `README.md` - project overview and roadmap

---

## Remote Repository

Repository: https://github.com/owuorviny109/UniversityERP.Portal.git

---

Contributions, issues, and suggestions are welcome. This README will be expanded as the project progresses.
