using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.StudentStore.Services.Core.Features.Product;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
         => this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        #region Products
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllProductQuery(), cancellationToken);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("GetProduct")]
        [ProducesResponseType(typeof(DefaulListResponse<ProductViewResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilterProduct([FromBody] ProductFilterRequest request, CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetProductByFilterQuery() { productFilterRequest = request }, cancellationToken);
            return this.Ok(response);
        }


        [HttpGet("getproductId/{id}")]
        public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetProductByIdQuery() { Id = id }, cancellationToken);
            return this.Ok(response);
        }
        [HttpGet("getproducttype/{productId}")]
        public async Task<IActionResult> GetProductType(long productId, CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetProductTypeByProductIdQuery() { ProductId = productId }, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("productmapping/{productId}")]
        public async Task<IActionResult> GetProductTypeMappping(long productId, CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetProductTypeMappingByProductIdQuery() { ProductId = productId }, cancellationToken);
            return this.Ok(response);
        }
        [Authorize]
        [HttpGet("getuseronlineproducts")]
        public async Task<IActionResult> GetUserOrderedOnlineProductType(CancellationToken cancellationToken)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var response = await this._mediator.Send(new GetUserOnlineProductsByEmailQuery() { UserEmail = userEmail }, cancellationToken);
            return this.Ok(response);
        }

        #endregion

        #region Categories

        [HttpGet]
        [Route("GetCategories")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllCategoryQuery(), cancellationToken);
            return this.Ok(response);
        }
        #endregion

        #region SubCategories

        [HttpGet]
        [Route("GetSubCategories")]
        [ProducesResponseType(typeof(SubCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubCategories(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllSubCategoryQuery(), cancellationToken);
            return this.Ok(response);
        }

        #endregion

        #region Sections

        [HttpGet]
        [Route("GetSections")]
        [ProducesResponseType(typeof(SectionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSections(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllSectionQuery(), cancellationToken);
            return this.Ok(response);
        }

        #endregion

        #region Grades

        [HttpGet]
        [Route("GetGrades")]
        [ProducesResponseType(typeof(GradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetGrades(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllGradeQuery(), cancellationToken);
            return this.Ok(response);
        }
        #endregion

        #region Brands

        [HttpGet]
        [Route("GetBrands")]
        [ProducesResponseType(typeof(BrandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBrands(CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetAllBrandQuery(), cancellationToken);
            return this.Ok(response);
        }

        #endregion
    }
}
