# University Academic & Exams Module – Master Task List

This task list is ordered. Complete sections in order unless there is a strong reason to skip.

---

## Section 0 – Repo and Structure (one-time setup)

- [x] Ensure solution and project live under `UniversityERP.Portal/` (no unrelated folders in repo root).
- [x] Confirm `.gitignore` includes:
  - [x] `.vs/`
  - [x] `bin/`
  - [x] `obj/`
- [x] Confirm `README.md` exists, is committed, and describes the actual project.
- [x] Confirm initial branch (`main` or `master`) is pushed to GitHub.
- [ ] Set GitHub repo description and topics (aspnet-core, csharp, sql-server, erp, academic-portal, etc.).

---

## Section 1 – EF Core and Database Wiring

**Goal:** The application talks to SQL Server through a DbContext.

- [ ] Install EF Core packages via NuGet:
  - [ ] `Microsoft.EntityFrameworkCore`
  - [ ] `Microsoft.EntityFrameworkCore.SqlServer`
  - [ ] `Microsoft.EntityFrameworkCore.Tools`
- [ ] Add `ConnectionStrings:DefaultConnection` to `appsettings.json` (LocalDB or SQL Server).
- [ ] Create `Data/ApplicationDbContext.cs`:
  - [ ] Inherit from `DbContext`.
  - [ ] Add a constructor with `DbContextOptions<ApplicationDbContext>`.
  - [ ] Add a placeholder `DbSet<School>` (even if School is empty for now).
- [ ] Register `ApplicationDbContext` in `Program.cs` using `UseSqlServer` and `DefaultConnection`.
- [ ] Run first migration:
  - [ ] `Add-Migration InitialCreate` (or `dotnet ef migrations add InitialCreate`).
  - [ ] `Update-Database` (or `dotnet ef database update`).
- [ ] Verify database created in SQL Server.

---

## Section 2 – Academic Structure: School and Program

**Goal:** Basic academic structure exists and is manageable via UI.

- [ ] Create `Models/School.cs`:
  - [ ] Properties: `Id`, `Code`, `Name`, `Description`, `IsActive`.
- [ ] Add `DbSet<School>` to `ApplicationDbContext`.
- [ ] Create EF migration for School:
  - [ ] `Add-Migration AddSchool`
  - [ ] `Update-Database`
- [ ] Scaffold `SchoolsController` with Razor views:
  - [ ] Index, Create, Edit, Details, Delete.
  - [ ] Confirm you can create, edit, delete Schools from the UI.
- [ ] Create `Models/Program.cs`:
  - [ ] Properties: `Id`, `Code`, `Name`, `SchoolId`, `DurationYears`, `IsActive`.
  - [ ] Navigation: `School` (many Programs to one School).
- [ ] Add `DbSet<Program>` to `ApplicationDbContext`.
- [ ] Create EF migration for Program:
  - [ ] `Add-Migration AddProgram`
  - [ ] `Update-Database`
- [ ] Scaffold `ProgramsController` with Razor views:
  - [ ] Dropdown selection for School when creating/editing Program.
  - [ ] Confirm Programs list shows the School name.

---

## Section 3 – Academic Year, Semester, Course

**Goal:** Model the time dimension and course catalog.

- [ ] Create `Models/AcademicYear.cs`:
  - [ ] Properties: `Id`, `Name`, `StartDate`, `EndDate`, `IsCurrent`.
- [ ] Create `Models/Semester.cs`:
  - [ ] Properties: `Id`, `Name`, `AcademicYearId`, `StartDate`, `EndDate`, `IsCurrent`.
  - [ ] Navigation: `AcademicYear`.
- [ ] Create `Models/Course.cs`:
  - [ ] Properties: `Id`, `Code`, `Name`, `Credits`, `ProgramId`, `SemesterId` (or Level/Semester design you choose).
  - [ ] Navigation: `Program`, `Semester`.
- [ ] Add `DbSet<AcademicYear>`, `DbSet<Semester>`, `DbSet<Course>` to `ApplicationDbContext`.
- [ ] Create EF migration for academic structure:
  - [ ] `Add-Migration AddAcademicStructure`
  - [ ] `Update-Database`
- [ ] Scaffold controllers and views:
  - [ ] `AcademicYearsController`
  - [ ] `SemestersController`
  - [ ] `CoursesController`
- [ ] Verify UI:
  - [ ] Can create Academic Years and mark one as current.
  - [ ] Can create Semesters linked to AcademicYear.
  - [ ] Can create Courses linked to Program and Semester.

---

## Section 4 – Students and Enrollment

**Goal:** Represent which student is in which program and which courses they are taking.

- [ ] Create `Models/Student.cs`:
  - [ ] Properties: `Id`, `RegistrationNumber`, `FirstName`, `LastName`, `Email`, `ProgramId`, `EnrollmentYear`, etc.
  - [ ] Navigation: `Program`.
- [ ] Create `Models/Enrollment.cs`:
  - [ ] Properties: `Id`, `StudentId`, `CourseId`, `SemesterId`.
  - [ ] Navigation: `Student`, `Course`, `Semester`.
- [ ] Add `DbSet<Student>` and `DbSet<Enrollment>` to `ApplicationDbContext`.
- [ ] Create EF migration for Students and Enrollments:
  - [ ] `Add-Migration AddStudentAndEnrollment`
  - [ ] `Update-Database`
- [ ] Scaffold `StudentsController` and views:
  - [ ] Support linking Student to Program.
- [ ] Implement Enrollment management:
  - [ ] Either scaffold `EnrollmentsController`
  - [ ] Or manage enrollments inside Student details page.
- [ ] Verify:
  - [ ] Can create a Student.
  - [ ] Can assign courses to a Student for a given Semester.

---

## Section 5 – Exams, Assessments, and Grading Configuration

**Goal:** Add configurable grading configuration and raw marks capture.

- [ ] Create `Models/ExamType.cs`:
  - [ ] Properties: `Id`, `Name`, `Description`, `IsDefault`.
- [ ] Create `Models/GradingScale.cs`:
  - [ ] Properties: `Id`, `Name`, `Description`.
- [ ] Create `Models/GradingBand.cs`:
  - [ ] Properties: `Id`, `GradingScaleId`, `MinMark`, `MaxMark`, `GradeLetter`, `GradePoint`.
  - [ ] Navigation: `GradingScale`.
- [ ] Create `Models/ExamWeighting.cs`:
  - [ ] Properties: `Id`, `ProgramId` (or `CourseId`), `ExamTypeId`, `WeightPercentage`.
- [ ] Create `Models/Assessment.cs`:
  - [ ] Properties: `Id`, `EnrollmentId`, `ExamTypeId`, `RawMark`, `CreatedAt`.
  - [ ] Navigation: `Enrollment`, `ExamType`.
- [ ] Add DbSets for all above to `ApplicationDbContext`.
- [ ] Create EF migration for grading config:
  - [ ] `Add-Migration AddExamAndGradingConfig`
  - [ ] `Update-Database`
- [ ] Scaffold admin controllers for:
  - [ ] Exam Types
  - [ ] Grading Scales and Bands
  - [ ] Exam Weightings
- [ ] Verify:
  - [ ] You can define a grading scale and bands.
  - [ ] You can define exam types and weightings for a program or course.

---

## Section 6 – Grade Calculation and Results

**Goal:** Compute total marks, grades, GPA, and show them to users.

- [ ] Create a `Services/GradeCalculationService` (or similar):
  - [ ] Method to fetch Assessments for a given Enrollment.
  - [ ] Method to apply ExamWeightings and compute total mark.
  - [ ] Method to resolve GradeLetter and GradePoint using GradingBands.
- [ ] Create a Result view model (no table yet):
  - [ ] Course
  - [ ] Raw marks per exam type
  - [ ] Total mark
  - [ ] Grade letter
  - [ ] Grade point
- [ ] Implement a Student Results page:
  - [ ] Given Student + Semester:
    - [ ] List all Enrollments and computed results.
- [ ] Implement GPA/CGPA calculation:
  - [ ] GPA per semester using grade points and credits.
  - [ ] CGPA across semesters.
- [ ] (Optional but recommended) Add unit tests for GradeCalculationService.

---

## Section 7 – Progression Rules

**Goal:** Evaluate whether a student proceeds, repeats, or is discontinued.

- [ ] Create `Models/ProgramRule.cs`:
  - [ ] Properties: `Id`, `ProgramId`, `MinPassMark`, `MaxFailedUnitsForProgression`, optional `MinGPAForProgression`.
- [ ] Add `DbSet<ProgramRule>` to `ApplicationDbContext`.
- [ ] Create EF migration for ProgramRule and update database.
- [ ] Implement `ProgressionService`:
  - [ ] Input: Student, Semester, Results, ProgramRule.
  - [ ] Output: PROCEED, PROCEED WITH CARRY, REPEAT, DISCONTINUE.
- [ ] Add Admin view:
  - [ ] Show progression status per student for a given Semester.
  - [ ] Summary report of who proceeds vs repeats.

---

## Section 8 – Authentication and Roles

**Goal:** Separate responsibilities for admins, lecturers, and students.

- [ ] Add ASP.NET Identity to the project (scaffold or template integration).
- [ ] Define roles:
  - [ ] Admin
  - [ ] Lecturer
  - [ ] Student
- [ ] Link `Student` entity to Identity user:
  - [ ] Add `UserId` to `Student` pointing to `AspNetUsers`.
- [ ] Apply authorization:
  - [ ] Only Admins can manage academic structure and configuration.
  - [ ] Students can only view their own enrollments and results.
  - [ ] Lecturers (future enhancement) can manage Assessments for assigned courses.

---

## Section 9 – UX, Navigation, and Validation

**Goal:** Make the system usable beyond pure scaffolding.

- [ ] Update `_Layout.cshtml` navigation to group menus:
  - [ ] Academic Setup (Schools, Programs, Years, Semesters, Courses).
  - [ ] Students & Enrollment.
  - [ ] Exams & Grading.
  - [ ] Reports.
- [ ] Add data annotations for validation on models (required fields, ranges, max lengths).
- [ ] Display validation messages in views.
- [ ] Add a simple Admin dashboard:
  - [ ] Counts: students, programs, open semesters, ungraded assessments, etc.

---

## Section 10 – Observability and Deployment

**Goal:** Make it operable like a real system.

- [ ] Configure logging using ASP.NET Core logging abstractions.
  - [ ] Log key events: grade calculation, progression evaluation, rule changes.
- [ ] Add basic audit trail:
  - [ ] Track changes to Assessments and ProgramRules (who changed what and when).
- [ ] Introduce environment-specific settings:
  - [ ] `appsettings.Development.json`
  - [ ] `appsettings.Production.json`
- [ ] Prepare for deployment:
  - [ ] Configure connection string for Azure SQL or other managed DB.
  - [ ] Deploy to Azure App Service or equivalent.
  - [ ] Verify migration and basic smoke tests in deployed environment.
