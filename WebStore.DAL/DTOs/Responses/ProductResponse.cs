﻿namespace WebStore.DAL.DTOs.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
		//public string ErrorMessage { get; set; }
		//public bool Success { get; set; }
	}
}
