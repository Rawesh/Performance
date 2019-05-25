using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PerformanceApplication.Models; // use the model to call methods from the model

namespace PerformanceApplication.Controllers
{
    public class PerformanceController : Controller
    {
        // use data to acces te model (bandArtist, stage, performance)
        private Performance performance = new Performance();
        private BandArtist bandArtist = new BandArtist();
        private Stage stage = new Stage();

        // get a list of the performances
        public ActionResult Index()
        {
            //call model method getAll() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = performance.GetAll();
            
            // return the view with the dataset
            return View(ds);
        }

        // create an band or artist 
        public ActionResult Create()
        {
            DataSet ds = bandArtist.GetAll();
            DataSet ds1 = stage.GetAll();

            // array of the datasets to acces in the view
            DataSet[] dsArray = { ds, ds1 };

            // set error 
            var message = TempData["error"];
            if (message != null)

                ViewData["error"] = message;

            return View(dsArray);
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult CreateSave(string band_artist_id, string stage_id, DateTime start_date, DateTime end_date)
        {
            // check if start isn't bigger than end and end isn,t smaller than start
            if(start_date > end_date)
            {
                TempData["error"] = "startdate may not be bigger than enddate and enddate may not be smaller than startdate";
                return RedirectToAction("create");
            }


            //call the insert method in the performance model with parameters
            performance.Insert(band_artist_id, stage_id, start_date, end_date);

            //redirect to index
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            //call model method getOne() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = performance.GetOne(id);
            DataSet ds1 = bandArtist.GetAll();
            DataSet ds2 = stage.GetAll();

            // array of the datasets to acces in the view
            DataSet[] dsArray = { ds, ds1, ds2 };

            // return the view with the dataset
            return View(dsArray);
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult EditSave(int id, string band_artist_id, string stage_id, DateTime start_date, DateTime end_date)
        {
            //call the update method in the performance model with parameters
            performance.SaveOne(id, band_artist_id, stage_id, start_date, end_date);

            // redirect to index
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //call model method getOne() that returns a dataset
            //put the data in a dataset to use it in the view
            DataSet ds = performance.GetOne(id);

            // return the view with the dataset
            return View(ds);
        }

        public ActionResult Delete(int id)
        {
            //call model method DeleteOne()
            performance.DeleteOne(id);

            //redirect to index
            return RedirectToAction("Index");
        }
    }
}