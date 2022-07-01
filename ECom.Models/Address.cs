using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
    /// <summary>
    /// Model này k tạo bảng mà chuyển thành các cột trong các bảng khác có nó
    /// </summary>
    [Owned]
    public class Address
    {
        public Address(){}
        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }
        [MaxLength(256)]
        public string Street { get;  set; }
        [MaxLength(100)]
        public string City { get;  set; }
        [DisplayName("Zip Code")]
        [MaxLength(100)]
        public string ZipCode { get;  set; }
    }
}