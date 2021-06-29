# Dependency Injection & Repository Design Pattern

When refactoring from a standard model / controller setup, as scaffolded out by Visual Studios, the following set of steps will guide the process

At the outset:

- Our startup file already maps the DbContext
- The Student Controller is bringing in our `SchoolDbContext` as `_context`
- Whenever we access `_context`, we're interacting with our database

Our goal is to change this setup to:

- Inject an Interface (IStudent) into the Student Controller as `_student`
- Now, when we access `_student`, we are going to get the behaviors from the interface
- `StudentRepository` will be the concrete class that implements `IStudent`
- Inject `DbContext` into this repository, so we are "live"

## Refactor our Controllers using Dependency Injection and a Repository

> The following procedures will be followed for each of your Model/Controller pathways

## Make a "Repository" for a model and implement it with an interface

### Phase 1: Build a Model Interface

1. Create a folder called `Interfaces` under `Models`
1. Within, create an interface, called `IStudent`
1. Define the required methods as a starting point (Likely to evolve this)
  - `Student Create(Student student)`
  - `List<Student> GetStudents()`
  - `Student GetStudent(int id)`
  - `Student UpdateStudent(int id, Student student)`
  - `Delete(int id)`
  - `Student Create(Student student)`


### Phase 2: Build a basic service

1. Create a folder under `Interfaces` called `Services`
1. Create a class in this folder called `StudentRepository.cs`
1. Implement the `IStudent` interface we just created
1. **Inject** our DbContext into this service in a constructor
   ```csharp
   private SchoolDbContext _context;

   public StudentRepository(SchoolDbContext context)
   {
     _context = context;
   }
   ```

### Phase 3: Database Logic: Create

Because `_context` is a reference to our database

1. Delete the exception under "Create"
1. We get our database calls directly as a part of `_context`
1. Put the new student object into pending state for the DB
1. Asynchronously call the save method
   ```csharp
   _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added;
   await _context.SaveChangesAsync();
   ```
1. Note the error that happens after you add `await`
  - Add `async` to the method
  - Return a `Task<>` which is how C# holds onto the async actions
  - `public async Task<Student> Create(Student student)`
1. You'll still have an error in your Interface implementation ...
  - Edit the IStudent.cs and change the Create signature to return a task

### Phase 4 Database Logic: Get All

1. `await` again. This time, we call the `ToListAsync()` method on our table
   ```csharp
   var students = await _context.Students.ToListAsync();
   return students;
   ```
1. Again, fix the async errors
1. But this time, we're nesting the `Task`
- It's a list of students
- `Task<List<Student>>`


### Phase 5 Database Logic: Get One

1. LINQ Query!
   ```csharp
   // The system knows we have a primary key and will use it
   Student student = await _context.Students.FindAsync(id);
   return student
   ```
1. Note the error ... it's an `await` thing again.
  - Perform the proper fixes as we did in the previous steps

### Phase 5: Database Logic: Delete

1. First, Get the student by ID
   ```csharp
   Student student = await GetStudent(id);
   _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
   await _context.SaveChangesAsync();
   ```
1. Note the error ... it's an `await` thing again.
- Perform the proper fixes as we did in the previous steps


### Phase 6 Database Logic: Update

1. Update it in place
  - Put the record into a "Modified" state
   ```csharp
   _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
   await _context.SaveChangesAsync();
   ```
1. Note the error ... it's an `await` thing again.
- Perform the proper fixes as we did in the previous steps

### Summary

Right now, we've created an IStudent interface that is implemented in the StudentRepository. Our current Student controller is getting `DbContexxt` injected into it. We need to change that, and replace it with our new Repository

### Phase 7: Refactor the Controller: Constructor

1. Change the constructor to bring in `IStudent` instead of `DbContext`
1. Change the private variable to `_student`
   ```csharp
   // private readonly DbSchoolContext _constructor;
   private readonly IStudent _student;
   public StudentsController(IStudent students)
   {
      // _context = context;
      _student = student;
   }
   ```
> HINT: At this point, you'll have a load of errors, wherever `_context` is in this file ... Leave those there, so that we have a visual "To Do List" of things to refactor

### Phase 8: Refactor the Controller: CRUD Methods

We now need to remove the `DbContext` based behaviors, replacing them with those that just created in the Student Service

We can holistically replace the logic in each of the CRUD methods, from something like this:

```csharp
// GET: api/Students/5
[HttpGet("{id}")]
public async Task<ActionResult<Student>> GetStudent(long id)
{
    var student = await _context.Students.FindAsync(id);

    if (student == null)
    {
        return NotFound();
    }

    return student;
}
```

To this, which calls on the proper method from the Student service

```csharp
// GET: api/Students/5
[HttpGet("{id}")]
public async Task<ActionResult<Student>> GetStudent(int id)
{
  Student student = await _student.GetStudent(id);
  return student;
}
```

### Phase 9: Run the app

Start your app and browse to your `/api/students` route and celebrate

... well, maybe be happy that the route resolved, but look at the error. It's telling us that it cannot resolve the IStudent service in the controller.

The fix: We need to tell the Startup system to register the correct dependency to fulfill this need.

1. In `Startup.cs`
1. In `ConfigureServices()`
1. Register the StudentRepository Service

```csharp
  services.AddTransient<IStudent, StudentRepository>();
```


