using AutoMapper;
using EcommerceAPI.DTO;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _pcRepo;
        private readonly IMapper _mapper;

        public ProductsCategoryController(IProductCategoryRepository pcRepo, IMapper mapper)
        {
            _pcRepo = pcRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of product Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       [ProducesResponseType(200, Type = typeof(List<ProductCategoryDTO>))]
        public IActionResult GetProductCategories()
        {
            var productcatList = _pcRepo.GetProductCategories();

            var productcutegoryDTO = new List<ProductCategoryDTO>();
            foreach (var item in productcatList)
            {
                productcutegoryDTO.Add(_mapper.Map<ProductCategoryDTO>(item));
            }
            return Ok(productcutegoryDTO);
        }



        /// <summary>
        /// Create a product category
        /// </summary>
        /// <param name="pCategoryDTO">The Id of the product</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromBody] ProductCategoryDTO pCategoryDTO)
        {
            if (pCategoryDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_pcRepo.ProductCategoryExists(pCategoryDTO.CategoryName))
            {
                ModelState.AddModelError("", "Product category already Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductCategory pCategoryObj = _mapper.Map<ProductCategory>(pCategoryDTO);

            if (!_pcRepo.CreateProductCategory(pCategoryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {pCategoryDTO.CategoryName}");
                return StatusCode(500, ModelState);
            }
           
            return Ok();
        }





    }
}
