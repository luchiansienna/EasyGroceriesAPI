using System;
using System.Collections.Generic;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.Business.UnitTests.MockData
{
    public class MockedOrders
    {
        public static Order EmptyOrder = new Order() { };
        public static Order SimpleOrderWithNoTotalPrice =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },
                Customer = new Customer() { CustomerId = 2 },

            };

        public static Order SimpleOrderWithNoItems =
                new Order()
                {
                    Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },
                    Customer = new Customer() { CustomerId = 2 },
                    TotalPrice = 10
                };

        public static Order SimpleOrderWithNoCity =
            new Order()
            {
                Address = new Address() { AddressId = 1, CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },

                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10
            };


        public static Order SimpleOrderWithNoCountryCode =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", PostCode = "sw140tb", Street = "125 bentstreet" },

                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10
            };


        public static Order SimpleOrderWithNoPostCode =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", Street = "125 bentstreet" },

                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10
            };


        public static Order SimpleOrderWithNoStreet =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb" },

                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10
            };

        public static Order SimpleOrderWithNoItems2 =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },
                CreatedDate = new DateTime(2022, 10, 10),
                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10,
                HasOrderLoyaltyDiscountApplied = true
            };

        public static Order SimpleOrderWithItemsThatAreEmpty =
            new Order()
            {
            Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },
            CreatedDate = new DateTime(2022, 10, 10),
            Customer = new Customer() { CustomerId = 2 },
            TotalPrice = 10,
            HasOrderLoyaltyDiscountApplied = true,
            Items = { new OrderItem() { }, new OrderItem() { } }
            };

        public static OrderItem SimpleOrderItems1 =
            new OrderItem() { OrderId = 1, IsLoyaltyMembershipItem = true, Quantity = 1, TotalPrice = 10, UnitPrice = 10 };
        public static OrderItem SimpleOrderItems2 =
                    new OrderItem() { OrderId = 1, IsLoyaltyMembershipItem = false, Quantity = 2, TotalPrice = 10, UnitPrice = 10 };

        public static Order SimpleOrderWithItems =
            new Order()
            {
                Address = new Address() { AddressId = 1, City = "London", CountryCode = "UK", PostCode = "sw140tb", Street = "125 bentstreet" },
                CreatedDate = new DateTime(2022, 10, 10),
                Customer = new Customer() { CustomerId = 2 },
                TotalPrice = 10,
                HasOrderLoyaltyDiscountApplied = true,
                Items = {
                   SimpleOrderItems1, SimpleOrderItems2
                }
            };

        }

}