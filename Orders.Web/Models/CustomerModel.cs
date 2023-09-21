using Orders.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Web.Models
{
	public class CustomerModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public Nullable<decimal> AnnualIncome { get; set; }

		public string FullName { get { return $"{FirstName} {LastName}"; } }

		public CustomerModel()
		{
			
		}

		public CustomerModel(Customer customer)
		{
			Id = customer.Id;
			FirstName = customer.FirstName;
			LastName = customer.LastName;
			PhoneNumber = customer.PhoneNumber;
			EmailAddress = customer.EmailAddress;
			AnnualIncome = customer.AnnualIncome;
		}
	}
}