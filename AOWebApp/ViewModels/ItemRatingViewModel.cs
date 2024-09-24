using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AOWebApp.Models;

namespace AOWebApp.ViewModels
{
	public class ItemRatingViewModel
	{
        public Item TheItem { get; set; }
        public int ReviewCount { get; set; }
        public double AverageRating { get; set; }
    }
}

