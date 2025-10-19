using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class CheckOutService : ICheckOutService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IEmailSender _emailSender;
        private readonly IOrderItemRepo _orderItemRepo;
        private readonly IProductRepo _productRepo;

        public  CheckOutService(ICartRepo cartRepo,IOrderRepo orderRepo,IEmailSender emailSender,IOrderItemRepo orderItemRepo,IProductRepo productRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _emailSender = emailSender;
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
        }

        public async Task<bool> handlePaymentasync(int orderId)
        {
            var order = await _orderRepo.GetUserByOrderAsync(orderId);
            var subject = "";
            var body = "";
            if (order.PaymentMethod == PaymentMethodEnum.Visa)
            {

                order.Status = OrderStatusEnum.Approved;
                var carts = await _cartRepo.GetUserCartAsync(order.UserId);

                // لحل مشكلة n+1
                var orderItems = new List<OrderItems>();
                var productUpdated = new List<(int productId, int quantity)>();
                foreach (var cartItem in carts)
                {

                 
                    var orderItem = new OrderItems
                    {
                        OrderId = orderId,
                        ProductId = cartItem.ProductId,
                        TotalPrice = cartItem.Product.Price * cartItem.Count,
                        Count = cartItem.Count,
                        Price=cartItem.Product.Price,
                    };
              orderItems.Add(orderItem);
                    productUpdated.Add((cartItem.ProductId,productUpdated.Count));

               
            
                  }

                await _orderItemRepo.AddRangeAsync(orderItems);
                await _cartRepo.ClearCartAsync(order.UserId);
                await _productRepo.DecreaseQuantityAsync(productUpdated);


                subject = "Payment successful - S&shop";
                body = "<h1> thank you for your payment</h1>" +
                    $"<p> your payment for ordrer {orderId} <p/>"+
                    $"Total Amount {order.TotalPrice}";

               
            }
            if (order.PaymentMethod == PaymentMethodEnum.Cash)
            {
                subject = "order placed successfully- S&shop";
                body = "<h1> thank you for your order</h1>" +
                    $"<p> your  ordrer {orderId} <p/>" +
                    $"Total Amount {order.TotalPrice}";
            }


        await _emailSender.SendEmailAsync(order.User.Email,subject, body);

            return true;
        }

    

        public async Task<CheckOutResponse> processPaymentasync(CheckOutRequest request, string UserId, HttpRequest httpRequest)
        {
            var cartItems =await _cartRepo.GetUserCartAsync(UserId);

            if (!cartItems.Any())
            {
                return new CheckOutResponse
                {
                    Success = false,
                    Message = "cart is empty"
                };
            }

            Order order = new Order
            {
                UserId = UserId,
                PaymentMethod= request.PaymentMethod,
                TotalPrice=cartItems.Sum(c=>c.Product.Price * c.Count)

            };

            await _orderRepo.AddAsync(order);


            if (request.PaymentMethod == PaymentMethodEnum.Cash)
            {
                return new CheckOutResponse
                {
                    Success = true,
                    Message = "chash"

                };

            }
            if (request.PaymentMethod == PaymentMethodEnum.Visa)
            {
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
            {
               
            },
                    Mode = "payment",
                    SuccessUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/Customer/CheckOuts/success/{order.Id}",
                    CancelUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/checkout/cancel",
                };

                foreach (var item in cartItems) {
                    options.LineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency ="USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Name,
                                Description = item.Product.Description,
                            },
                            UnitAmount = (long)item.Product.Price,
                        },
                        Quantity = item.Count,
                    });
                }
                var service = new SessionService();
                var session = service.Create(options);
                order.PaymentId = session.Id;

                return new CheckOutResponse
                {
                    Success = true,
                    Message = "payment session created succrssfully",
                    PaymentId=session.Id,
                    Url=session.Url
                }
            ;
        }


            return new CheckOutResponse
            {
                Success = true,
                Message = "invalid",

            };
        }

    }
}
