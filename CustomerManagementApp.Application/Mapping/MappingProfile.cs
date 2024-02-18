using AutoMapper;
using CustomerManagementApp.Application.DTO;
using CustomerManagementApp.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Application.Mapping
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<CustomerDTO, Customer>().ReverseMap();
		}
	}
}
