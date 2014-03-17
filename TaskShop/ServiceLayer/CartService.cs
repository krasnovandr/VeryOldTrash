using System.Collections.Generic;
using DataLayer.Models;

namespace ServiceLayer
{
    public interface ICartService
    {
        void AddBattery(Battery battery, List<Cart> list);
        void AddMonitor(Monitor monitor, List<Cart> list);
        void AddEarphone(Earphone earphone, List<Cart> list);
        void AddMemoryCard(MemoryCard memoryCard, List<Cart> list);
        void Delete(Cart cart, List<Cart> list);
    }


    public class CartService : ICartService
    {

        public void AddBattery(Battery battery, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = battery.Id,
                GoodsCategory = "Batteries",
                Price = battery.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == battery.Id && item.GoodsCategory == "Batteries")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }
        }
        public void AddMonitor(Monitor monitor, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = monitor.Id,
                GoodsCategory = "Monitors",
                Price = monitor.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == monitor.Id && item.GoodsCategory == "Monitors")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }

        }

        public void AddEarphone(Earphone earphone, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = earphone.Id,
                GoodsCategory = "Earphones",
                Price = earphone.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == earphone.Id && item.GoodsCategory == "Earphones")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }

        }

        public void AddMemoryCard(MemoryCard memoryCard, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = memoryCard.Id,
                GoodsCategory = "MemoryCards",
                Price = memoryCard.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == memoryCard.Id && item.GoodsCategory == "MemoryCards")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }

        }

        public void Delete(Cart cart, List<Cart> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (cart.GoodsCategory == list[i].GoodsCategory && cart.GoodsId == list[i].GoodsId)
                {
                    switch (list[i].Count)
                    {
                        case 1:
                            list.RemoveAt(i);
                            break;
                        default:
                            list[i].Count--;
                            break;
                    }
                }
            }

        }
    }
}