using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TreeViewExamples.MVC.Models;
using TreeViewExamples.MVC.Models.EasyUIModel;

namespace TreeViewExamples.MVC.Controllers
{
    public class TreeViewsController : Controller
    {
        private JSTreeViewModel[] GetArrayTreeViewModel()
        {
            var tree = new JSTreeViewModel[]
            {
                new JSTreeViewModel {
                    id = 2,
                    text = "Fruits",
                    state = "closed",
                    children = new JSTreeViewModel[] {
                        new JSTreeViewModel {
                            text = "apple",
                            Checked = true
                        },
                        new JSTreeViewModel
                        {
                            text="orange"
                        }
                    }
                },
                new JSTreeViewModel {
                    id = 3,
                    text = "Vegetables",
                    state = "open",
                    children = new JSTreeViewModel[] {
                        new JSTreeViewModel {
                            text = "tomato",
                            Checked = true
                        },
                        new JSTreeViewModel
                        {
                            text = "carrot",
                            Checked = true
                        },
                        new JSTreeViewModel
                        {
                            text = "cabbage"
                        },
                        new JSTreeViewModel
                        {
                            text = "potato",
                            Checked = true
                        },
                        new JSTreeViewModel
                        {
                            text = "lettuce"
                        }
                    }
                }
            };
            return tree;
        }
        // GET: TreeViews
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TreeViewBootstrap()
        {
            List<AuthorViewModel> model = new List<AuthorViewModel>();
            AuthorViewModel firstAuthor = new AuthorViewModel
            {
                Id = 1,
                Name = "John",
                BookViewModel = new List<BookViewModel> {
                    new BookViewModel {
                        Id=1,
                        Title = "JQuery",
                        IsWritten = false
                    },
                    new BookViewModel
                    {
                        Id=2,
                        Title = "C#",
                        IsWritten = false
                    }
                }
            };
            AuthorViewModel secondAuthor = new AuthorViewModel
            {
                Id = 2,
                Name = "Deo",
                BookViewModel = new List<BookViewModel> {
                    new BookViewModel {
                        Id=3,
                        Title = "Entity Framework",
                        IsWritten = false
                    },
                    new BookViewModel
                    {
                        Id=4,
                        Title = "Javascript",
                        IsWritten = false
                    }
                }
            };
            model.Add(firstAuthor);
            model.Add(secondAuthor);
            return View("TreeViewBootstrap", model);
        }

        [HttpPost]
        public ActionResult TreeViewBootstrap(List<AuthorViewModel> model)
        {
            List<AuthorViewModel> selectedAuthors = model.Where(x => x.IsAuthor).ToList();
            List<BookViewModel> selectedBooks = model.Where(a => a.IsAuthor)
                .SelectMany(a => a.BookViewModel.Where(b => b.IsWritten)).ToList();
            return View();
        }

        public ActionResult TreeViewEasyUI()
        {
            return View();
        }

        public JsonResult GetDataJsonTreeView()
        {
            var dataResponse = new JSTreeViewModel
            {
                id = 1,
                text = "Foods",
                Checked = true,
                children = GetArrayTreeViewModel()
            };
            var jsonResponse = new JavaScriptSerializer().Serialize(dataResponse);
            var objeto = JObject.Parse(jsonResponse);
            var objetoString = objeto.ToString();
            return Json(new { d = objetoString });
        }
    }
}