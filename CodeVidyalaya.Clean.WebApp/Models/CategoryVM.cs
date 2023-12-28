﻿namespace CodeVidyalaya.Clean.WebApp.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }


    public class CategoryDetailsVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public SubCategoryVM? SubCategory { get; set; }
    }
}
