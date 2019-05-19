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



            return View(dsArray);
        }

        //Get the post, to save it in the database
        [HttpPost]
        public ActionResult CreateSave(string band_artist_id, string stage_id, DateTime start_date, DateTime end_date)
        {
            //call the insert method in the performance model with parameters
            performance.Insert(band_artist_id, stage_id, start_date.ToString(), end_date.ToString());

            //redirect to index
            return RedirectToAction("Index");
        }
    }
}