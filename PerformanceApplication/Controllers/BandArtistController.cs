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
            DataSet ds = data.GetAll();

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
            data.Insert(name, description);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            //call model method getOne() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = data.GetOne(id);

            // return the view with the dataset
            return View(ds);
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult EditSave(int id, string name, string description)
        {
            //call the update method in the performance model with parameters
            data.SaveOne(id, name, description);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //call model method getOne() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = data.GetOne(id);

            // return the view with the dataset
            return View(ds);
        }

        public ActionResult Delete(int id)
        {
            //call model method DeleteOne()
            data.DeleteOne(id);

            //redirect to index
            return RedirectToAction("Index");
        }

    }
}