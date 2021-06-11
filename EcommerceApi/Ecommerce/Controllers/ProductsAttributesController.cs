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
    public class ProductsAttributesController : ControllerBase
    {
        private readonly IProductAttributes _pAttributeo;
        private readonly IMapper _mapper;

        public ProductsAttributesController(IProductAttributes pAttribute, IMapper mapper)
        {
            _pAttributeo = pAttribute;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of product Arrtribute
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       [ProducesResponseType(200, Type = typeof(List<ProductAttributeDTO>))]
        public IActionResult GetProductAttributes()
        {
            var productcAttributeList = _pAttributeo.GetProductAttributes();

            var productaatributeDTO = new List<ProductAttributeDTO>();
            foreach (var item in productcAttributeList)
            {
                productaatributeDTO.Add(_mapper.Map<ProductAttributeDTO>(item));
            }
            return Ok(productaatributeDTO);
        }


        /// <summary>
        /// Get individual ProductAttribute
        /// </summary>
        /// <param name="attributeId">The Id of the Attribute</param>
        /// <returns></returns>
        [HttpGet("{attributeId:int}", Name = "GetProductAttribute")]
        [ProducesResponseType(200, Type = typeof(ProductAttributeDTO))]
        [ProducesResponseType(404)]

        [ProducesDefaultResponseType]
        public IActionResult GetProductAttribute(int attributeId)
        {
            var obj = _pAttributeo.GetProductByAttributeId(attributeId);
            if (obj == null)
            {
                return NotFound();
            }
            ProductAttributeDTO attributeObjDTO = _mapper.Map<ProductAttributeDTO>(obj);

            return Ok(attributeObjDTO);
        }


        /// <summary>
        /// Create a product Attribute
        /// </summary>
        /// <param name="pAttributeDTO">The Id of the product</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductAttributeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromBody] ProductAttributeDTO pAttributeDTO)
        {
            if (pAttributeDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_pAttributeo.ProductAttributeExists(pAttributeDTO.AttributeName))
            {
                ModelState.AddModelError("", "Product category already Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductAttribute pAttributeObj = _mapper.Map<ProductAttribute>(pAttributeDTO);

            if (!_pAttributeo.CreateProductAttribute(pAttributeObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {pAttributeDTO.AttributeName}");
                return StatusCode(500, ModelState);
            }
           
           // return Ok();
            return CreatedAtRoute("GetProductAttribute", new { attributeId = pAttributeObj.Id }, pAttributeObj);
        }





    }
}
