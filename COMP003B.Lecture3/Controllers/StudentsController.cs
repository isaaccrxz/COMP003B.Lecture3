// TODO: reference Models space
using COMP003B.Lecture3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Lecture3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>();
        // GET: Students
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // use to keep using create new for new sessions
        public IActionResult Create(Student student)
        {
            // TDOD: check if student already exists
            if (ModelState.IsValid)
            {
                if (!_students.Any(s => s.Id == student.Id))
                {
                    //TODO: any student to list
                    _students.Add(student);
                }
                // TODO: redirect back to index
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Students/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // TODO: check if id is null
            if (id == null)
            {
                return NotFound();
            }
            // TODO: find student id
            var Student = _students.FirstOrDefault(p => p.Id == id);

            // TODO: check again if student is null after searching list
            if (Student == null)
            {
                return NotFound();
            }

            // TODO: return student to view
            return View(Student);
        }

        // POST: Students/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student) 
        { 
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid) 
            {
                var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);

                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(student);

        }


    }
}
