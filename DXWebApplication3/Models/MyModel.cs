using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DXWebApplication3.Models
{
    public class MyModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Key]
        public int CustomerID { get; set; }
        public MyModel()
        {
        }
        public MyModel(string first, string last, DateTime birth, int id)
        {
            CustomerID = id;
            FirstName = first;
            LastName = last;
            BirthDate = birth;
        }
    }
    public static class CustomerList
    {
        public static List<MyModel> GetTypedListModel()
        {
            if (HttpContext.Current.Session["ModelList"] == null)
                HttpContext.Current.Session["ModelList"] = GenerateList();

            return (List<MyModel>)HttpContext.Current.Session["ModelList"];
        }

        public static List<MyModel> GenerateList()
        {
            List<MyModel> typedList = new List<MyModel>();
            for (int index = 0; index < 100; index++)
                typedList.Add(new MyModel("Name" + index, "Last" + index, new DateTime(1990, 10, 1), index));
            return typedList;
        }
        public static void UpdateCustomer(MyModel modelInfo)
        {
            MyModel editedModel = GetTypedListModel().Where(m => m.CustomerID == modelInfo.CustomerID).First();
            editedModel.FirstName = modelInfo.FirstName;
            editedModel.BirthDate = modelInfo.BirthDate;
            editedModel.LastName = modelInfo.LastName;
        }
    }
}