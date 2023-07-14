using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            /*Student s1 = new Student();
            s1.Id = 1;
            s1.Name = "Benz";
            s1.Score = 100;

            var s2 = new Student();
            s2.Id = 2;
            s2.Name = "Benzy";
            s2.Score = 80;

            Student s3 = new();
            s3.Id = 3;
            s3.Name = "Kaizer";
            s3.Score = 50;

            List<Student> allStudent = new List<Student>();
            allStudent.Add(s1);
            allStudent.Add(s2);*/

            IEnumerable <Student> allStudent = _db.Students;

            return View(allStudent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) 
        { 
            if(id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.Students.Find(id);
                if(obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.Students.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    _db.Students.Remove(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
