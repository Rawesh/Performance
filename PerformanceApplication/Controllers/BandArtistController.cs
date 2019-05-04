using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PerformanceApplication.Models; // use the model to call methods from the model



namespace PerformanceApplication.Controllers
{
    public class BandArtistController : Controller
    {
        private BandArtist data = new BandArtist();

        // get list of all bands and artists
        public ActionResult Index()
        {
            //call model method getAll() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = data.getAll();

            // return the view with the dataset
            return View(ds);
        }

        // create an band or artist 
        public ActionResult Create()
        {
            return View();
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult CreateSave(string name, string description)
        {
            //call the insert method in the performance model with parameters
            data.insert(name, description);

            return Redirect("index");
        }

        public ActionResult Edit(int id)
        {
            //call model method getAll() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = data.getOne(id);

            // return the view with the dataset
            return View(ds);
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult EditSave(int id, string name, string description)
        {
            //call the insert method in the performance model with parameters
            data.saveOne(id, name, description);

            return Redirect("index");
        }

    }
}