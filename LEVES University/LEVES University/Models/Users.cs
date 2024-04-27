using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LEVES_University.Models
{
    [Index(nameof(NTID), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Users
    {
        [Key]
        public string Id { get; set; }


        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }


        [Remote(action: "IsNTIDUnique", controller: "Validation", ErrorMessage = "NTID is already in use.")]
        [Required(ErrorMessage = "The NTID is required.")]
        public long NTID { get; set; }


        [Required(ErrorMessage = "The first name is required.")]
        [StringLength(50, ErrorMessage = "The first name cannot exceed 50 characters.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "The last name is required.")]
        [StringLength(150, ErrorMessage = "The last name cannot exceed 50 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Password)]
        [MinLength(9, ErrorMessage = "The password must be at least 8 characters long.")]
        public string Password { get; set; }

        public Address Address { get; set; }


        public bool IsActive { get; set; }

        public UserProfilePicture UserProfilePicture { get; set; }

        [Required(ErrorMessage = "The date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Users()
        {
            Id = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds():0000000000}";
            HashPassword(Id);
            IsActive = true;
        }

        private void HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<Users>();
            Password = passwordHasher.HashPassword(this, password);
        }
    }
}
