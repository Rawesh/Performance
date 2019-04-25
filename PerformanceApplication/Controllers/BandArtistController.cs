using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PerformanceApplication.Models;

namespace PerformanceApplication.Controllers
{
    public class BandArtistController : Controller
    {


        // get list of all bands and artists
        public ActionResult Index()
        {
            //call the model function getAll
            BandArtist band_artist = new BandArtist();
            band_artist.getAll();

            // return the view with the band_artist data
            return View();
        }

        // create an band or artist 
        public ActionResult Create()
        {
            return View();
        }

        //Get the post, to save it in the database.
        [HttpPost]
        public ActionResult CreateSave(string name, string description)
        {
            BandArtist band_artist = new BandArtist();
            band_artist.insert(name, description);

            return Redirect("index");
        }

    }
}