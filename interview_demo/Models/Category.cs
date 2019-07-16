using System;

namespace interview_demo.Models
{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public bool is_published { get; set; }
    }
}