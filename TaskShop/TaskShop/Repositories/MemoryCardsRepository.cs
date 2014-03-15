using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskShop.Repositories;

namespace TaskShop.Repositories
{
    //public interface IMemoryCardsRepository
    //{
    //    void AddMemoryCard(MemoryCard memoryCard);
    //    List<MemoryCard> GetMemoryCards();
    //}


    //public class MemoryCardsRepository : IMemoryCardsRepository
    //{

    //    public void AddMemoryCard(MemoryCard memoryCard)
    //    {
    //        using (var db = new ShopContext())
    //        {
    //            db.MemoryCards.Add(memoryCard);
    //            db.SaveChanges();
    //        }
    //    }

    //    public List<MemoryCard> GetMemoryCards()
    //    {
    //        using (var db = new ShopContext())
    //        {
    //            var memoryCards = (from entity in db.MemoryCards
    //                            select entity).ToList();
    //            return memoryCards;
    //        }
    //    }
    //}
}