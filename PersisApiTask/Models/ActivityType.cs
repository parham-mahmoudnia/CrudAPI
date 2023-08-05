using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace PersisApiTask.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class ActivityType : BaseEntity
    {    
        [Required]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

      
    }
}
