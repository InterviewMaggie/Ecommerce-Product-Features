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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _pRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository pRepo, IMapper mapper)
        {
            _pRepo = pRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       [ProducesResponseType(200, Type = typeof(List<ProductDTO>))]
        public IActionResult GetProducts()
        {
            var productList = _pRepo.GetProducts();

            var productDTO = new List<ProductDTO>();
            foreach (var item in productList)
            {
                productDTO.Add(_mapper.Map<ProductDTO>(item));
            }
            return Ok(productDTO);
        }


        /// <summary>
        /// Get individual product
        /// </summary>
        /// <param name="productId">The Id of the product</param>
        /// <returns></returns>
        [HttpGet("{productId:int}", Name = "GetProduct")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)]
        
        [ProducesDefaultResponseType]
        public IActionResult GetProduct(int productId)
        {
            var obj = _pRepo.GetProductByProductId(productId);
            if (obj == null)
            {
                return NotFound();
            }
            ProductDTO prouctObjDTO = _mapper.Map<ProductDTO>(obj);

            return Ok(prouctObjDTO);
        }

        /// <summary>
        /// Get individual product
        /// </summary>
        /// <param name="categoryId">The Id of the product</param>
        /// <returns></returns>
        [HttpGet("[action]/{categoryId:int}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)]

        [ProducesDefaultResponseType]
        public IActionResult GetProductWithCategory(int categoryId)
        {
            var obj = _pRepo.GetProductByProductId(categoryId);
            if (obj == null)
            {
                return NotFound();
            }
            ProductDTO prouctObjDTO = _mapper.Map<ProductDTO>(obj);

            return Ok(prouctObjDTO);
        }


        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="productsDTO">The Id of the product</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromBody] ProductDTO productsDTO)
        {
            if (productsDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_pRepo.ProductExists(productsDTO.ProductName))
            {
                ModelState.AddModelError("", "Product already Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product productObj = _mapper.Map<Product>(productsDTO);

            if (!_pRepo.CreateProduct(productObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {productsDTO.ProductName}");
                return StatusCode(500, ModelState);
            }
           
            return CreatedAtRoute("GetProduct", new {  productId = productObj.Id }, productObj);
        }


        [HttpPatch("{productId:int}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null || productDTO.Id != productId)
            {
                return BadRequest(ModelState);
            }

            Product productObj = _mapper.Map<Product>(productDTO);

            if (!_pRepo.UpdateProduct(productObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {productObj.ProductName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProduct", new { productId = productObj.Id }, productObj);

        }



    }
}
