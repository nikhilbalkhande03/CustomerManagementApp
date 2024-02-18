using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Application.DTO
{
	public class CustomerDTO
	{

       
        [Range(18, 90, ErrorMessage = "Age must be between 18 and 90")]
		public int Age { get; set; }
		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last Name is required")]
		public string LastName { get; set; }
	}
}
