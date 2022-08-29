using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        #region Create Customer
        public ActionResult Index()
        {
            return View("CreateCustomer");
        }

        [HttpPost]
        public ActionResult Index(CUSTOMER customer)
        {
            int i = new Repository().CreateCustomer(customer);

            ViewBag.SuccessMessage = "Customer Created Successfully...";
            ViewBag.DangerMessage = string.Empty;

            if (i == -1)
            {
                ViewBag.SuccessMessage = string.Empty;
                ViewBag.DangerMessage = "Customer Created UnSuccessfull...";
                
            }
            else
            {
                ViewBag.ID = "Generated Customer ID is: " + i; 
            }
            
                
            return View("CreateCustomer");
        }
        #endregion

        #region Update Customer
        public ActionResult Edit(int id)
        {
            TempData["res"] = id.ToString();
            return View("UpdateCustomer", new Repository().SearchCustomer(id));
        }

        public ActionResult Update()
        {            
            return View("SearchForUpdate");
        }


        [HttpPost]
        public ActionResult SearchForUpdate()
        {
            CUSTOMER cust = null;
            ViewBag.NoData = string.Empty;

            if (Request["input"] != null)
            {
                TempData["res"] = Request["input"].ToString();

                if (int.TryParse(Request["input"].ToString(), out int id))
                {
                    cust = new Repository().GetCustomer(id);
                }
                else
                {
                    cust = new Repository().GetCustomer(Request["input"].ToString());
                }
            }

            
            if (cust == null)
            {
                ViewBag.NoData = "No Data Found...";
                return View("SearchForUpdate");
            }
            return View("UpdateCustomer", cust);
        }


        [HttpPost]
        public ActionResult Update(CUSTOMER customer)
        {
            int t = -10;
            if (TempData["res"] != null)
            {
                if (int.TryParse(TempData["res"].ToString(), out int id))
                {
                    t = new Repository().ModifyCustomer(customer, id);
                }
                else
                {
                    t = new Repository().ModifyCustomer(customer, TempData["res"].ToString());
                }
            }

            if (t == 1)
            {
                ViewBag.SuccessMessage = "Customer Updated Successfully...";
                ViewBag.DangerMessage = string.Empty;
            }
            else if (t == -1)
            {
                ViewBag.SuccessMessage = string.Empty;
                ViewBag.DangerMessage = "Customer Updated UnSuccessfull...";
            }
            else
            {
                ViewBag.SuccessMessage = string.Empty;
                ViewBag.DangerMessage = "Something Went Wrong...";
            }

            return View("SearchForUpdate");
        }
        #endregion



        #region Delete Customer
        public ActionResult DeleteFromAllDetails(int id)
        {
            TempData["resDel"] = id.ToString();
            return View("DeleteCustomer", new Repository().SearchCustomer(id));
        }

        public ActionResult Delete()
        {
            return View("SearchForDelete");
        }

        [HttpPost]
        public ActionResult SearchForDelete()
        {
            CUSTOMER cust = null;
            ViewBag.NoData = string.Empty;

            if (Request["input"].ToString() != null)
            {
                TempData["resDel"] = Request["input"].ToString();

                if (int.TryParse(Request["input"].ToString(), out int id))
                {
                    cust = new Repository().GetCustomer(id);
                }
                else
                {
                    cust = new Repository().GetCustomer(Request["input"].ToString());
                }
            }

            
            if (cust == null)
            {
                ViewBag.NoData = "No Data Found...";
                return View("SearchForDelete");
            }
            return View("DeleteCustomer", cust);
        }


        [HttpPost]
        public ActionResult Remove()
        {
            try
            {
                int t = -10;
                if (TempData["resDel"] != null)
                {
                    if (int.TryParse(TempData["resDel"].ToString(), out int id))
                    {
                        t = new Repository().RemoveCustomer(id);
                    }
                    else
                    {
                        t = new Repository().RemoveCustomer(TempData["resDel"].ToString());
                    }
                }

                if (t == 1)
                {
                    ViewBag.SuccessMessage = "Customer Removed Successfully...";
                    ViewBag.DangerMessage = string.Empty;
                }
                else if (t == -1)
                {
                    ViewBag.SuccessMessage = string.Empty;
                    ViewBag.DangerMessage = "Customer Removed UnSuccessfully...";
                }
                else
                {
                    ViewBag.SuccessMessage = string.Empty;
                    ViewBag.DangerMessage = "Something Went Wrong...";
                }
            }
            catch{ }

            return View("SearchForDelete");
        }
        #endregion


        #region Search Customer

        public ActionResult Search()
        {
            return View("SearchCustomer");
        }

        [HttpPost]
        public ActionResult Search(CUSTOMER customer)
        {
            CUSTOMER cust = null;
            ViewBag.NoData = string.Empty;

            if (Request["input"] != null)
            {
                TempData["res"] = Request["input"].ToString();

                if (int.TryParse(Request["input"].ToString(), out int id))
                {
                    cust = new Repository().GetCustomer(id);
                }
                else
                {
                    cust = new Repository().GetCustomer(TempData["res"].ToString());
                }
            }

            
            if (cust == null)
            {
                ViewBag.NoData = "No Data Found...";
                return View("SearchCustomer");
            }

            return View("Details", cust);
        }
        #endregion


        #region All Details
        public ActionResult Display()
        {

            return View("AllDetails", new Repository().GetAllCustomers());
        }
        #endregion

    }
}