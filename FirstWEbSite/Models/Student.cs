using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWEbSite.Models
{
    public class Student
    {
        public Student()
        {
            IsCool = true;//defauilt
        }
        public int Id { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Range(20, 60)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"\w+", ErrorMessage = "Name Must be only characters")]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public bool IsCool { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Student { get; set; }

    }

    public class ITIEntity:DbContext//entity frame Core
    {
        public ITIEntity():base()
        {

        }
        public ITIEntity(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SatuDemo;Integrated Security=True");
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
