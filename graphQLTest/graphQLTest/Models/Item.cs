﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphQLTest.Models
{
    public class Item
    {
        public string Barcode { get; set; }

        public string Title { get; set; }

        public decimal SellingPrice { get; set; }
    }

    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
        }
    }

    public class DataSource
    {
        public IList<Item> Items
        {
            get;
            set;
        }

        public DataSource()
        {
            Items = new List<Item>(){
            new Item { Barcode= "123", Title="Headphone", SellingPrice=50},
            new Item { Barcode= "456", Title="Keyboard", SellingPrice= 40},
            new Item { Barcode= "789", Title="Monitor", SellingPrice= 100}
        };
        }

        public Item GetItemByBarcode(string barcode)
        {
            return Items.First(i => i.Barcode.Equals(barcode));
        }
    }
}
