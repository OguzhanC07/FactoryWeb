using System.Threading.Tasks;
using FactoryWebAPI.Client.ApiServices.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FactoryWebAPI.Client.TagHelpers
{
    [HtmlTargetElement("getproductimage")]
    public class ProductImageTagHelper : TagHelper
    {
        private readonly IImageService _imageService;
    
        public ProductImageTagHelper(IImageService imageService)
        {
            _imageService=imageService;
        }

        public int Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageService.GetProductImageById(Id);
            string html= string.Empty;

            html =$"<img class='card-img-top' src='{blob}' alt=''>";
        
            output.Content.SetHtmlContent(html);
        }
    }
}