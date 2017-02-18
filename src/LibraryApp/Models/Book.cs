using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishYear { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string EmployeeId { get; set; }

        public ApplicationUser Employee { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }
    }
}
