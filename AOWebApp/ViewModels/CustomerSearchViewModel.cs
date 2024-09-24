using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AOWebApp.Models;

namespace AOWebApp.ViewModels
{
	public class CustomerSearchViewModel
	{
		public string SearchText { get; set; }
		public string Suburb { get; set; }
		public SelectList SuburbList { get; set; }
        public List<Customer> CustomerList { get; set; } = new List<Customer>();

    }
}

