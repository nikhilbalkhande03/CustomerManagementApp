﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Domain.Customer
{
	public class Customer
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
