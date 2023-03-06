using System;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Tests.Data
{
    public static class Shared
    {
        public static readonly Dictionary<string, InvoiceItem> InvoiceItems =
    new Dictionary<string, InvoiceItem>(){
                {"banana",  new InvoiceItem(){
                    Name = "banana",
                    Count = 9800,
                    Price = 3.0m
                }},
                {"apple",  new InvoiceItem(){
                    Name = "apple",
                    Count = 1000,
                    Price = 5.0m
                }},
                {"pomegranate",  new InvoiceItem(){
                    Name = "pomegranate",
                    Count = 3000,
                    Price = 7.0m
                }},
                {"orange",  new InvoiceItem(){
                    Name = "orange",
                    Count = 3000,
                    Price = 10.0m
                }},
                {"yourFavoriteFruit",  new InvoiceItem(){
                    Name = "yourFavoriteFruit",
                    Count = 10000,
                    Price = 12.0m
                }}
        };
    }
}

