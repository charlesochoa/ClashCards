using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClashCards.Models;

namespace ClashCards.Services
{
    public interface ICardsService
    {
        Task<List<CardsModel>> RefreshDataAsync();
    }
}
