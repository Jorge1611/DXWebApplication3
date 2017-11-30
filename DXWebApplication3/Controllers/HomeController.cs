using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXWebApplication3.Models;
using DevExpress.Web.Mvc;

namespace DXWebApplication3.Controllers
{
    public class HomeController : Controller
    {
        List<MyModel> clist = CustomerList.GetTypedListModel();
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            
            //return View(NorthwindDataProvider.GetCustomers());
            return View(clist);
        }
        
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            //return PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers());
            return PartialView(clist);
        }
        public ActionResult UpdateRecordFromGrid([ModelBinder(typeof(DevExpressEditorsBinder))] MyModel updateModel)
        {
            if (ModelState.IsValid)
                CustomerList.UpdateCustomer(updateModel);
            return PartialView("GridViewPartial", clist);
        }

    }
}