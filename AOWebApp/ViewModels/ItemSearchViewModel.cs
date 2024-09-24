using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AOWebApp.Models;

namespace AOWebApp.ViewModels
{
	public class ItemSearchViewModel
	{
		
		// Create a ViewModel class with the following getter- setter properies 
		public string SearchText { get; set; }
		public int? CategoryId { get; set; }
		public SelectList CategoryList { get; set; }
        //public List<Models.Item> ItemList { get; set; }
        public List<ItemRatingViewModel> ItemList { get; set; }

    }
}

