using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures22.Controllers
{
    public class QueueController : Controller
    {
        //make a queue to hold the entries
        public static Queue<string> myQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count() + 1));
            ViewBag.Message = "One item was successfully added to the queue";
            return View("Index");
        }
        public ActionResult AddMultiple()
        {
            //empty the queue
            myQueue.Clear();
            //call the addone method 2000 times
            for (int i = 0; i < 2000; i++)
            {
                AddOne();
            }
            ViewBag.Message = "Two Thousand items were successfully added to the queue";
            return View("Index");
        }
        public ActionResult Display()
        {
            if (myQueue.Count() > 0)
            {
                ViewBag.Queue = myQueue;
                return View("DisplayQueue");
            }
            else
            {
                ViewBag.Message = "The queue is empty, there is nothing to display";
                return View("Index");
            }
        }
        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
                ViewBag.Message = "An item was removed (Dequeued) from the Queue";
            }
            else
            {
                ViewBag.Message = "The queue is already empty, nothing can be deleted";
            }
            return View("Index");
        }
        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.Message = "The Queue has been cleared";
            return View("Index");
        }
        public ActionResult Search()
        {
            //create a stopwatch, to time the search
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            bool contains = myQueue.Contains("New Entry 1234");
            sw.Stop();

            if (contains)
            {
                ViewBag.Message = "We found the entry 1234! It took:";
            }
            else
            {
                ViewBag.Message = "The entry 1234 is not in this queue";
            }

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts.ToString();

            //return the same view as the index
            return View("Index");
        }
    }
}