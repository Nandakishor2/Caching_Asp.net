using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASP_Caching.Models
{
	public class ProductResponse
	{
		[JsonPropertyName("products")]
		public List<Product>? Products { get; set; }

		[JsonPropertyName("total")]
		public int Total { get; set; }

		[JsonPropertyName("skip")]
		public int Skip { get; set; }

		[JsonPropertyName("limit")]
		public int Limit { get; set; }
	}

	public class Product
	{
		[Key]
		[JsonPropertyName("id")]
		public int productId { get; set; }
		[JsonPropertyName("title")]
		public string? productTitle { get; set; }
		[JsonPropertyName ("description")]
		public string? productDescription { get; set; }
		[JsonPropertyName("category")]
		public string? productCategory { get; set; }
		[JsonPropertyName("price")]
		public double productPrice { get; set; }
		public double productDiscountPercentage { get; set; }
		[JsonPropertyName("rating")]
		public double productRating { get; set; }
		[JsonPropertyName("stock")]
		public int productStock { get; set; }
		public List<string>? productTags { get; set; }
		[JsonPropertyName("brand")]
		public string? productBrand { get; set; }
		public string? productSku { get; set; }
		public double productWeight { get; set; }
		public object? productDimensions { get; set; }
		public string? productWarranty { get; set; }
		public string? productShippingInformation { get; set; }
		public string? productAvailabilityStatus { get; set; }
		public List<object>? productReviews { get; set; }

		public string? productReturnPolicy { get; set; }

		public int productMinQuantity {  get; set; }
		public object? productMeta {  get; set; }

		[JsonPropertyName("images")]
		public List<string>? productImages { get; set; }

		public string? productThumbnail { get; set; }


	}
}
