using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public byte[] Image { get; set; }
        public string UrlImage { get; set; }
        public int StudentToFacultyCoordinatorId { get; set; }
        public StudentToFacultyCoordinator StudentToFacultyCoordinator { get; set; }
    }
}