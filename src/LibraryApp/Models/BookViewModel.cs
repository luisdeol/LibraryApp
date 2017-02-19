using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string PublishYear { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
        public string EmployeeId { get; set; }
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        public SelectList Authors { get; set; }
        public SelectList Publishers { get; set; }
    }
}