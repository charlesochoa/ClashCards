using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClashCards.Models;

namespace ClashCards.Services
{
    public class ClashCardsManager
    {
        readonly ICardsService cardsService;
        public ClashCardsManager(ICardsService service)
        {
            cardsService = service;
        }

        public Task<List<CardsModel>> GetTaskAsync()
        {
            return cardsService.RefreshDataAsync();
        }
    }
}
