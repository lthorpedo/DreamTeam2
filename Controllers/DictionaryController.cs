using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures22.Controllers
{
    public class DictionaryController : Controller
    {
        // Create a dictionary
        static public Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count() + 1), myDictionary.Count() + 1);
            ViewBag.Message = "One item was successfully added to the dictionary";
            return View("Index");
        }
        public ActionResult AddMultiple()
        {
            //empty the dictionary
            myDictionary.Clear();
            //Add 2000 items to the dictionary
            //call the addone method 2000 times
            for(int i = 0; i < 2000; i++)
            {
                AddOne();
            }
            ViewBag.Message = "2000 entries were added to the dictionary";
            return View("Index");
        }
        public ActionResult Display()
        {
            ViewBag.ADictionary = myDictionary;
            if (myDictionary.Count() > 0)
            {
                return View("DisplayDictionary");
            }
            else
            {
                ViewBag.Message = "The dictionary is empty, there is nothing to display";
                return View("Index");
            }
        }
        public ActionResult Delete()
        {
            if(myDictionary.Count() >= 1)
            {
                myDictionary.Remove("New Entry " + (myDictionary.Count()));
                ViewBag.Message = "Successfully deleted one item from the dictionary";
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Could not delete any item from the dictionary. It's already empty";
                return View("Index");
            }

        }
        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.Message = "Dictionary is empty";
            return View("Index");
        }
        public ActionResult Search()
        {
            //create a stopwatch, to time the search
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            bool contains = myDictionary.ContainsKey("New Entry 1234");            
            sw.Stop();

            if (contains)
            {
                ViewBag.Message = "We found the entry 1234! It took:";
            }
            else
            {
                ViewBag.Message = "The entry 1234 is not in this dictionary";
            }

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts.ToString();

            //return the same view as the index
            return View("Index");
        }
    }
}