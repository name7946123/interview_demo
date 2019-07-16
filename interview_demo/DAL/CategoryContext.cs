using interview_demo.Models;
using System.Data.Entity;

namespace interview_demo.DAL
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("CategoryContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}