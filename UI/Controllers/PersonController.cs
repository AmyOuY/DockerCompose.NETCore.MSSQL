using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonData _data;

        public PersonController(IPersonData data)
        {
            _data = data;
        }


        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> InsertPerson(PersonDisplayModel person)
        {
            if (ModelState.IsValid)
            {
                Person newPerson = new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Phone = person.Phone
                };

                await _data.InsertPerson(newPerson);

                return RedirectToAction("ViewAllPersons");
            }

            return View();
        }


        public async Task<IActionResult> ViewAllPersons()
        {
            List<PersonDisplayModel> displayPersons = new List<PersonDisplayModel>();
            List<Person> allPersons = await _data.GetPersonAll();

            foreach (var person in allPersons)
            {
                displayPersons.Add(new PersonDisplayModel { 
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Phone = person.Phone
                });
            }

            return View(displayPersons);
        }


        public async Task<IActionResult> EditPerson(int id)
        {
            Person foundPerson = await _data.GetPerson(id);
            PersonDisplayModel displayPerson = new PersonDisplayModel
            {
                Id = foundPerson.Id,
                FirstName = foundPerson.FirstName,
                LastName = foundPerson.LastName,
                Email = foundPerson.Email,
                Phone = foundPerson.Phone
            };

            return View(displayPerson);
        }


        public async Task<IActionResult> UpdatePerson(PersonDisplayModel person)
        {
            if (ModelState.IsValid)
            {
                Person updatePerson = new Person
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Phone = person.Phone
                };

                await _data.UpdatePerson(updatePerson);

                return RedirectToAction("ViewAllPersons");
            }

            return View(person);
        }


        public async Task<IActionResult> DeletePerson(int id)
        {
            await _data.DeletePerson(id);

            return RedirectToAction("ViewAllPersons");
        }
    }
}