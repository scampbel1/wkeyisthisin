using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JsonDemoController : Controller
    {
        /// <summary>  
        /// Welcome Note Message  
        /// </summary>  
        /// <returns>In a Json Format</returns>  
        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)  
            string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        /// <summary>  
        /// Get tthe Users data in Json Format  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetUsersData()
        {
            var users = GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        /// <summary>  
        /// Sample View  
        /// </summary>  
        /// <returns></returns>  
        public ActionResult Sample()
        {
            return View();
        }

        /// <summary>  
        /// Update the user details  
        /// </summary>  
        /// <param name="usersJson">users list in JSON Format</param>  
        /// <returns></returns>  
        [HttpPost]
        public JsonResult UpdateUsersDetail(string usersJson)
        {
            var js = new JavaScriptSerializer();
            UserModel[] user = js.Deserialize<UserModel[]>(usersJson);

            //TODO: user now contains the details, you can do required operations  
            return Json("User Details are updated");
        }

        /// <summary>  
        /// Get the huge list of Users  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetUsersHugeList()
        {
            var users = GetUsersHugeData();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        /// <summary>  
        /// Get the Users  
        /// </summary>  
        /// <returns></returns>  
        private List<UserModel> GetUsers()
        {
            var usersList = new List<UserModel>
            {
                new UserModel
                {
                    UserId = 1,
                    UserName = "Ram",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "chand",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "Abc",
                    Company = "Abc Solutions"
                }
            };

            return usersList;
        }

        /// <summary>  
        /// Get the huge list of users  
        /// </summary>  
        /// <returns></returns>  
        private List<UserModel> GetUsersHugeData()
        {
            var usersList = new List<UserModel>();
            UserModel user;
            for (int i = 1; i < 51000; i++)
            {
                user = new UserModel
                {
                    UserId = i,
                    UserName = "User-" + i,
                    Company = "Company-" + i
                };
                usersList.Add(user);
            }

            return usersList;
        }

        /// <summary>  
        /// Override the JSON Result with Max integer JSON lenght  
        /// </summary>  
        /// <param name="data">Data</param>  
        /// <param name="contentType">Content Type</param>  
        /// <param name="contentEncoding">Content Encoding</param>  
        /// <param name="behavior">Behavior</param>  
        /// <returns>As JsonResult</returns>  
        protected override JsonResult Json(object data, string contentType,
            Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}