﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class OrderDetail
    {
        
        public int OrderDetailID { get; set; }
        public Goods OrderGoods { get;  set; }
        public int Amount { get; set; }

        public double Money
        {
            get
            {
                return OrderGoods.Price * Amount;
            }
        }

        public OrderDetail() {
            OrderGoods = new Goods();
        }

        public OrderDetail(Goods orderGoods, int amount)
        {
            OrderGoods = orderGoods;
            Amount = amount;
        }

        public OrderDetail(string name,double price, int amount)
        {
            OrderGoods = new Goods(name, price);
            Amount = amount;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetail detail &&
                   OrderGoods.Equals(detail) &&
                   Amount == detail.Amount;
        }

        public override int GetHashCode()
        {
            int hashCode = -197546992;
            hashCode = hashCode * -1521134295 + OrderGoods.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{OrderGoods}\t ×{Amount}\t" + "total: "+ Money;
        }


    }
}
