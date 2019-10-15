using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures22.Controllers
{
    public class StackController : Controller
    {
        //make a stack
        static public Stack<string> myStack = new Stack<string>();
        // GET: Stack
        public ActionResult Index()
        { 
            return View();
        }
        
        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count() + 1));
            ViewBag.Message = "One item was successfully added to the stack";
            return View("Index");
        }
        public ActionResult AddMultiple()
        {
            //empty the stack
            myStack.Clear();
            //call the addone method 2000 times
            for(int i = 0; i < 2000; i++)
            {
                AddOne();
            }
            ViewBag.Message = "Two Thousand items were successfully added to the stack";
            return View("Index");
        }
        public ActionResult Display()
        {
            //only show the display page if there is something in the stack
            if (myStack.Count() > 0)
            {
                ViewBag.Stack = myStack;
                return View("DisplayStack");
            }
            else
            {
                ViewBag.Message = "The stack is empty, there is nothing to display";
                return View("Index");
            }
        }
        public ActionResult Delete()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
                ViewBag.Message = "An item was popped from the stack";
            }
            else
            {
                ViewBag.Message = "The stack is already empty, nothing can be deleted";
            }
            return View("Index");
        }
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.Message = "The stack has been cleared";
            return View("Index");
        }
        public ActionResult Search()
        {
            //create a stopwatch, to time the search
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            bool contains = myStack.Contains("New Entry 1234");
            sw.Stop();

            if (contains)
            {
                ViewBag.Message = "We found the entry 1234! It took:";
            }
            else
            {
                ViewBag.Message = "The entry 1234 is not in this stack";
            }

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts.ToString();

            //return the same view as the index
            return View("Index");
        }
    }
}