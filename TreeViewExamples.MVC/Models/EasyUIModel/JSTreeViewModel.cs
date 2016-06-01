namespace TreeViewExamples.MVC.Models.EasyUIModel
{
    public class JSTreeViewModel
    {
        public long id { get; set; }
        public string text { get; set; }
        public bool Checked;
        public string state;
        public JSTreeViewModel[] children;
    }
}
