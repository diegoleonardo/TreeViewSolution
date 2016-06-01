using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExamples.MVC.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            BookViewModel = new List<BookViewModel>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsAuthor { get; set; }
        public IList<BookViewModel> BookViewModel { get; set; }
    }
}
