# University Academic & Exams Module – Master Task List

A step-by-step roadmap for building the University ERP Custom Module.

---

## Section 0 – Repo and Structure

- [x] Ensure solution and project live under `UniversityERP.Portal/`.
- [x] Confirm `.gitignore` includes:
  - [x] `.vs/`
  - [x] `bin/`
  - [x] `obj/`
- [x] Confirm `README.md` exists and describes the project.
- [x] Confirm initial branch (`main` or `master`) is pushed to GitHub.
- [ ] Set GitHub repo description and topics (aspnet-core, csharp, sql-server, erp).

---

## Section 1 – EF Core and Database Wiring

**Goal:** Establish SQL Server connectivity via Entity Framework Core.

- [ ] Install EF Core packages via NuGet:
  - [ ] `Microsoft.EntityFrameworkCore`
  - [ ] `Microsoft.EntityFrameworkCore.SqlServer`
  - [ ] `Microsoft.EntityFrameworkCore.Tools`
- [ ] Add `ConnectionStrings:DefaultConnection` to `appsettings.json`.
- [ ] Create `Data/ApplicationDbContext.cs`:
  - [ ] Inherit from `DbContext`.
  - [ ] Add constructor with options.
  - [ ] Add placeholder `DbSet<School>`.
- [ ] Register `ApplicationDbContext` in `Program.cs`.
- [ ] Run initial migration:
  - [ ] `dotnet ef migrations add InitialCreate`
  - [ ] `dotnet ef database update`
- [ ] Verify database creation in SQL Server.

---

## Section 2 – Academic Structure: School and Program

**Goal:** Implement basic academic hierarchy management.

- [ ] Create `Models/School.cs`:
  - [ ] Properties: `Id`, `Code`, `Name`, `Description`, `IsActive`.
- [ ] Add `DbSet<School>` to DbContext.
- [ ] Create EF migration for School.
- [ ] Scaffold `SchoolsController` with Razor views.
  - [ ] Verify School creation, editing, and deletion.
- [ ] Create `Models/Program.cs`:
  - [ ] Navigation: `School` (many Programs to one School).
- [ ] Add `DbSet<Program>`.
- [ ] Create EF migration for Program.
- [ ] Scaffold `ProgramsController`.
  - [ ] Verify School selection dropdown functionality.

---

## Section 3 – Academic Year, Semester, Course

**Goal:** Model the time dimension and course catalog.

- [ ] Create `Models/AcademicYear.cs`.
- [ ] Create `Models/Semester.cs` (linked to AcademicYear).
- [ ] Create `Models/Course.cs` (linked to Program and Semester).
- [ ] Add DbSets and run migrations.
- [ ] Scaffold controllers and views.
- [ ] Verify creation of full academic schedule.

---

## Section 4 – Students and Enrollment

**Goal:** Represent student program affiliation and course enrollment.

- [ ] Create `Models/Student.cs`.
- [ ] Create `Models/Enrollment.cs` (linking Student, Course, Semester).
- [ ] Add DbSets and run migrations.
- [ ] Scaffold `StudentsController`.
- [ ] Implement enrollment management.
- [ ] Verify student course enrollment for a semester.

---

## Section 5 – Exams, Assessments, and Grading Configuration

**Goal:** Build the configurable grading engine.

- [ ] Create `Models/ExamType.cs` (CAT, Final).
- [ ] Create `Models/GradingScale.cs` & `GradingBand.cs`.
- [ ] Create `Models/ExamWeighting.cs`.
- [ ] Create `Models/Assessment.cs` (raw marks).
- [ ] Add DbSets and run migrations.
- [ ] Scaffold admin screens for configuration.
- [ ] Verify definition of different grading scales for different programs.

---

## Section 6 – Grade Calculation and Results

**Goal:** Compute grades dynamically and display results.

- [ ] Create `Services/GradeCalculationService`.
  - [ ] Logic to fetch assessments and apply weights.
  - [ ] Logic to lookup grades from GradingBands.
- [ ] Create a Result view model.
- [ ] Build the Student Results page.
- [ ] Implement GPA/CGPA calculation logic.

---

## Section 7 – Progression Rules

**Goal:** Automate progression evaluation (Proceed vs Repeat).

- [ ] Create `Models/ProgramRule.cs` (MinPassMark, MaxFailedUnits).
- [ ] Implement `ProgressionService` for evaluation.
- [ ] Build Admin view for progression status.

---

## Section 8 – Authentication and Roles

**Goal:** Secure the system and separate permissions using Identity.

- [ ] Add ASP.NET Identity.
- [ ] Define roles: Admin, Lecturer, Student.
- [ ] Link `Student` record to Identity User.
- [ ] Apply authorization rules.

---

## Section 9 – UX, Navigation, and Validation

**Goal:** Enhance usability and validation.

- [ ] Group navigation menus logically.
- [ ] Add data annotations for validation.
- [ ] Build simple Admin Dashboard.

---

## Section 10 – Observability and Deployment

**Goal:** Prepare for production operation.

- [ ] Configure structured logging.
- [ ] Add audit trails for sensitive changes.
- [ ] Prepare appsettings for Production.
- [ ] Verify deployment readiness.
