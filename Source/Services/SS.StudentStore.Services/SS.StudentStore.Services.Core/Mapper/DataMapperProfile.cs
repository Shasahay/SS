using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SS.StudentStore.Services.Core.Mapper
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            this.CreateMap<ProductView, ProductViewResponse>();
            this.CreateMap(typeof(ProductView), typeof(ProductViewResponse));
            this.CreateMap(typeof(IListWithCount<>), typeof(DefaulListResponse<>));
            this.CreateMap<ProductType, ProductTypeResponse>();
            this.CreateMap<ProductTypeMapping, ProductTypeMappingResponse>();
            this.CreateMap<Category, CategoryResponse>();
            this.CreateMap<SubCategory, SubCategoryResponse>();
            this.CreateMap<Section, SectionResponse>();
            this.CreateMap<Grade, GradeResponse>();
            this.CreateMap<Brand, BrandResponse>();

            // Basket
            this.CreateMap<BasketItemRequest, BasketItem>();
            this.CreateMap<BasketItem, BasketItemResponse>();

            this.CreateMap<BasketView, BasketResponse>()
                .ForMember(destination => destination.BasketId,
                source => source.MapFrom(data => data.BasketId))
                .ForMember(destination => destination.BasketUId,
                source => source.MapFrom(data => data.BasketUId))
                .ForMember(destination => destination.DeliveryMethodId,
                source => source.MapFrom(data => data.DeliveryMethodId))
                .ForMember(destination => destination.ClientSecret,
                source => source.MapFrom(data => data.clientSecret))
                .ForMember(destination => destination.PaymentIntendId,
                source => source.MapFrom(data => data.PaymentIntendId))
                .ForMember(destination => destination.ShippingPrice,
                source => source.MapFrom(data => data.ShippingPrice));


            this.CreateMap<BasketView, BasketItemResponse>()
                .ForMember(destination => destination.BasketId,
                source => source.MapFrom(data => data.BasketId))
                .ForMember(destination => destination.BasketItemId,
                source => source.MapFrom(data => data.BasketItemId))
                .ForMember(destination => destination.ProductId,
                source => source.MapFrom(data => data.ProductId))
                .ForMember(destination => destination.ProductTypeId,
                source => source.MapFrom(data => data.ProductTypeId))
                .ForMember(destination => destination.ProductName,
                source => source.MapFrom(data => data.ProductName))
                .ForMember(destination => destination.ProductTypeName,
                source => source.MapFrom(data => data.ProductTypeName))
                .ForMember(destination => destination.Quantity,
                source => source.MapFrom(data => data.Quantity))
                .ForMember(destination => destination.PictureUrl,
                source => source.MapFrom(data => data.PictureUrl))
                .ForMember(destination => destination.Price,
                source => source.MapFrom(data => data.Price))
                .ForMember(destination => destination.NumberOfMonths,
                source => source.MapFrom(data => data.NumberOfMonths));

            this.CreateMap<BasketView, BasketItem>()
                .ForMember(destination => destination.BasketId,
                source => source.MapFrom(data => data.BasketId))
                .ForMember(destination => destination.BasketItemId,
                source => source.MapFrom(data => data.BasketItemId))
                .ForMember(destination => destination.ProductId,
                source => source.MapFrom(data => data.ProductId))
                .ForMember(destination => destination.ProductTypeId,
                source => source.MapFrom(data => data.ProductTypeId))
                .ForMember(destination => destination.ProductName,
                source => source.MapFrom(data => data.ProductName))
                .ForMember(destination => destination.Quantity,
                source => source.MapFrom(data => data.Quantity))
                .ForMember(destination => destination.PictureUrl,
                source => source.MapFrom(data => data.PictureUrl))
                .ForMember(destination => destination.Price,
                source => source.MapFrom(data => data.Price))
                .ForMember(destination => destination.NumberOfMonths,
                source => source.MapFrom(data => data.NumberOfMonths));

            this.CreateMap<UserView, UserResponse>()
                .ForMember(destination => destination.UserId,
                source => source.MapFrom(data => data.UserId))
                .ForMember(destination => destination.DisplayName,
                source => source.MapFrom(data => data.DisplayName))
                .ForMember(destination => destination.Email,
                source => source.MapFrom(data => data.Email));

            this.CreateMap<Address, AddressResponse>();

            this.CreateMap<AddressRequest, Address>();

            this.CreateMap<Users, UserView>()
                .ForMember(destination => destination.UserId,
                source => source.MapFrom(data => data.UserId))
                .ForMember(destination => destination.FirstName,
                source => source.MapFrom(data => data.FirstName))
                .ForMember(destination => destination.MiddleName,
                source => source.MapFrom(data => data.MiddleName))
                .ForMember(destination => destination.LastName,
                source => source.MapFrom(data => data.LastName))
                .ForMember(destination => destination.DisplayName,
                source => source.MapFrom(data => data.DisplayName))
                .ForMember(destination => destination.UserName,
                source => source.MapFrom(data => data.UserName))
                .ForMember(destination => destination.Email,
                source => source.MapFrom(data => data.Email))
                .ForMember(destination => destination.LastLoginDate,
                source => source.MapFrom(data => data.LastLoginDate))
                .ForMember(destination => destination.IsLocked,
                source => source.MapFrom(data => data.IsLocked))
                .ForMember(destination => destination.AccessFailedCount,
                source => source.MapFrom(data => data.AccessFailedCount));


            this.CreateMap<CreateUserRequest, Users>()
                .ForMember(destination => destination.DisplayName,
                source => source.MapFrom(data => data.DisplayName))
                .ForMember(destination => destination.Email,
                source => source.MapFrom(data => data.Email))
                .ForMember(destination => destination.ClearPassword,
                source => source.MapFrom(data => data.Password));

            this.CreateMap<DeliveryMethod, DeliveryMethodResponse>();

            this.CreateMap<BasketItem, OrderItem>()
                .ForMember(destinaton => destinaton.ProductId,
                source => source.MapFrom(data => data.ProductId))
                .ForMember(destinaton => destinaton.ProductTypeId,
                source => source.MapFrom(data => data.ProductTypeId))
                .ForMember(destinaton => destinaton.Quantity,
                source => source.MapFrom(data => data.Quantity))
                .ForMember(destinaton => destinaton.Price,
                source => source.MapFrom(data => data.Price))
                .ForMember(destinaton => destinaton.NumberOfMonths,
                source => source.MapFrom(data => data.NumberOfMonths));

            //this.CreateMap<OrderView, OrderResponse>();


            this.CreateMap<OrderView, OrderResponse>()
                    .ForMember(destination => destination.OrderId,
                    source => source.MapFrom(data => data.OrderId))
                    .ForMember(destination => destination.UserEmail,
                    source => source.MapFrom(data => data.UserEmail))
                    .ForMember(destination => destination.AddressId,
                    source => source.MapFrom(data => data.AddressId))
                    .ForMember(destination => destination.SubTotal,
                    source => source.MapFrom(data => data.SubTotal))
                    .ForMember(destination => destination.Status,
                    source => source.MapFrom(data => data.Status))
                    .ForMember(destination => destination.SubTotal,
                    source => source.MapFrom(data => data.SubTotal))
                    .ForMember(destination => destination.DeliveryMethodId,
                    source => source.MapFrom(data => data.DeliveryMethodId))
                    .ForMember(destination => destination.CreatedDate,
                    source => source.MapFrom(data => data.OrderCreatedDate));


            this.CreateMap<OrderView, OrderItemResponse>()
                        .ForMember(destination => destination.OrderId,
                        source => source.MapFrom(data => data.OrderId))
                        .ForMember(destination => destination.OrderItemId,
                        source => source.MapFrom(data => data.OrderItemId))
                        .ForMember(destination => destination.ProductId,
                        source => source.MapFrom(data => data.ProductId))
                        .ForMember(destination => destination.ProductTypeId,
                        source => source.MapFrom(data => data.ProductTypeId))
                        .ForMember(destination => destination.ProductName,
                        source => source.MapFrom(data => data.ProductName))
                        .ForMember(destination => destination.ProductTitle,
                        source => source.MapFrom(data => data.ProductTitle))
                        .ForMember(destination => destination.ProductTypeName,
                        source => source.MapFrom(data => data.ProductTypeName))
                        .ForMember(destination => destination.PictureUrl,
                         source => source.MapFrom(data => data.PictureUrl))
                        .ForMember(destination => destination.Quantity,
                         source => source.MapFrom(data => data.Quantity))
                        .ForMember(destination => destination.Price,
                        source => source.MapFrom(data => data.Price))
                        .ForMember(destination => destination.NumberOfMonths,
                        source => source.MapFrom(data => data.NumberOfMonths))
                        .ForMember(destination => destination.CreatedDate,
                         source => source.MapFrom(data => data.OrderItemCreatedDate));

            this.CreateMap<StagingProductView, SProductResponse>();
            this.CreateMap<StagingProductRequest , StagingProduct>();

        }
    }
}
