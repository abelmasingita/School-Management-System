using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static AspnetCoreMvcFull.Models.AuthViewModel;
using static AspnetCoreMvcFull.Models.SchoolViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class SchoolManagement : Controller
{

  private readonly UserManager<User> userManager;
  private readonly DataLayer db;

  public SchoolManagement(UserManager<User> userManager, DataLayer db)
  {
    this.userManager = userManager;
    this.db = db;
  }
  public IActionResult School()
  {
    var model = db.Schools.ToList();
    return View(model);
  }
  public IActionResult SchoolAdd()
  {
    return View();
  }

  [HttpPost]
  public IActionResult SchoolAdd(SchoolVM model)
  {
    if (ModelState.IsValid)
    {
      School school = new School()
      {
        SchoolName = model.SchoolName,
        Address = model.Address,
        PhoneNumber = model.PhoneNumber,
        Email = model.Email,
        PrincipalName = model.PrincipalName,
        EstablishedYear = model.EstablishedYear,
        SchoolType = model.SchoolType,
        Website = model.Website,
      };

      db.Schools.Add(school);
      db.SaveChanges();
    }
    return View();
  }
  public IActionResult SchoolEdit(string id)
  {
    var model = db.Schools.Where(sc => sc.Id == int.Parse(id)).FirstOrDefault();
    return View(model);
  }

  [HttpPost]
  public IActionResult SchoolEdit(SchoolVM model)
  {
    if (ModelState.IsValid)
    {
      School toUpdate = db.Schools.Find(model.Id);

      if (toUpdate != null)
      {
        toUpdate.SchoolName = model.SchoolName;
        toUpdate.Address = model.Address;
        toUpdate.PhoneNumber = model.PhoneNumber;
        toUpdate.Email = model.Email;
        toUpdate.PrincipalName = model.PrincipalName;
        toUpdate.EstablishedYear = model.EstablishedYear;
        toUpdate.SchoolType = model.SchoolType;
        toUpdate.Website = model.Website;

        db.Entry(toUpdate).State = EntityState.Modified;
        db.SaveChanges();

        TempData["GlobalNotiError"] = "School Successfully Updated.";
        return RedirectToAction("School");
      }

    }
    return View();
  }
  public IActionResult Stream()
  {
    var model = db.Streams.Include(st => st.School).ToList();
    return View(model);
  }
  public IActionResult StreamAdd()
  {
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  [HttpPost]
  public IActionResult StreamAdd(StreamVM model)
  {
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
      DataAccessLayer.Models.Stream stream = new DataAccessLayer.Models.Stream()
      {
        StreamName = model.StreamName,
        SchoolId = model.SchoolId,
      };

      db.Streams.Add(stream);
      db.SaveChanges();
    }

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  public IActionResult StreamEdit(string id)
  {
    var model = db.Streams.Where(sc => sc.Id == int.Parse(id)).FirstOrDefault();

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View(model);
  }

  [HttpPost]
  public IActionResult StreamEdit(StreamVM model)
  {
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
      DataAccessLayer.Models.Stream toUpdate = db.Streams.Find(model.Id);

      if (toUpdate != null)
      {
        toUpdate.StreamName = model.StreamName;
        toUpdate.SchoolId = model.SchoolId;

        db.Entry(toUpdate).State = EntityState.Modified;
        db.SaveChanges();

        TempData["GlobalNotiError"] = "Stream Successfully Updated.";
        return RedirectToAction("Stream");
      }

    }
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  public IActionResult Grade()
  {
    var model = db.Grades.Include(st => st.School).ThenInclude(st => st.Streams).ToList();
    return View(model);
  }

  public IActionResult GradeAdd()
  {
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    ViewBag.Streams = new SelectList(db.Streams, "Id", "StreamName");
    return View();
  }

  [HttpPost]
  public IActionResult GradeAdd(GradeVM model)
  {
    ModelState.Remove("Students");
    ModelState.Remove("Teachers");
    ModelState.Remove("Stream");
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
      Grade grade = new Grade()
      {
        GradeName = model.GradeName,
        SchoolId = model.SchoolId,
        StreamId = model.StreamId,
      };

      db.Grades.Add(grade);
      db.SaveChanges();
    }

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    ViewBag.Streams = new SelectList(db.Streams, "Id", "StreamName");
    return View();
  }

  public IActionResult GradeEdit(string id)
  {
    var model = db.Grades.Where(sc => sc.Id == int.Parse(id)).FirstOrDefault();

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    ViewBag.Streams = new SelectList(db.Streams, "Id", "StreamName");
    return View(model);
  }

  [HttpPost]
  public IActionResult GradeEdit(GradeVM model)
  {
    ModelState.Remove("Stream");
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
     Grade toUpdate = db.Grades.Find(model.Id);

      if (toUpdate != null)
      {
        toUpdate.GradeName = model.GradeName;
        toUpdate.StreamId = model.StreamId;
        toUpdate.SchoolId = model.SchoolId;

        db.Entry(toUpdate).State = EntityState.Modified;
        db.SaveChanges();

        TempData["GlobalNotiError"] = "Grade Successfully Updated.";
        return RedirectToAction("Grade");
      }

    }
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    ViewBag.Streams = new SelectList(db.Streams, "Id", "StreamName");
    return View();
  }


  public IActionResult Subject()
  {
    var model = db.Subjects.Include(st => st.School).ToList();
    return View(model);
  }

  public IActionResult SubjectAdd()
  {
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  [HttpPost]
  public IActionResult SubjectAdd(SubjectVM model)
  {
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
      Subject subject = new Subject()
      {
        SubjectName = model.SubjectName,
        SchoolId = model.SchoolId,
      };

      db.Subjects.Add(subject);
      db.SaveChanges();
    }

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  public IActionResult SubjectEdit(string id)
  {
    var model = db.Subjects.Where(sc => sc.Id == int.Parse(id)).FirstOrDefault();

    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View(model);
  }

  [HttpPost]
  public IActionResult SubjectEdit(SubjectVM model)
  {
    ModelState.Remove("School");
    if (ModelState.IsValid)
    {
      Subject toUpdate = db.Subjects.Find(model.Id);

      if (toUpdate != null)
      {
        toUpdate.SubjectName = model.SubjectName;
        toUpdate.SchoolId = model.SchoolId;

        db.Entry(toUpdate).State = EntityState.Modified;
        db.SaveChanges();

        TempData["GlobalNotiError"] = "Subject Successfully Updated.";
        return RedirectToAction("Subject");
      }

    }
    ViewBag.Schools = new SelectList(db.Schools, "Id", "SchoolName");
    return View();
  }

  public IActionResult Attendance() => View();
  public IActionResult Fee() => View();
}
