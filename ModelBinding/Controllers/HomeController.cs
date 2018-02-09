using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;


namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        //uses route data to determine which item to return
        //if no data found, it will use 0 and get an error
        //if wrong data found, like "apple" that cannot convert to int, you will also get an error
        //to be able to determine errors -- use defensive programming in next example
        public ViewResult Index(int id=1) => View(_repository[id]);

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        //to ensure proper binding of elements where asp-for is a nested datastructure -- add prefix path
        public ViewResult DisplaySummary([Bind(Prefix=nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        //=============================================
        //ARRAY BINDING
        //binds input values to an array, if action meth receives form data, it will send it to the view, if it doesn't, it will create an array of 0
        //logic in the view will render appropriate html if list is 0 (a form) or of a diff length(list of names)
        public ViewResult ArrayBinding(string[] names) => View(names ?? new string[0]);


        //binding inputs from a form to a List of strings
        public ViewResult CollectionBinding(List<string> names) => View(names ?? new List<string>());


        //binging form inputs to a list of address summary objects, each object accessible by [i].property
        public ViewResult ComplexCollectionBinding(List<AddressSummary> addresses)
        {
            return View(addresses ?? new List<AddressSummary>());
        }
    }
     
    }

