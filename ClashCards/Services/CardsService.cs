using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ClashCards.Context;
using ClashCards.Models;
using Newtonsoft.Json;

namespace ClashCards.Services
{
    public class CardsService : ICardsService
    {
        readonly HttpClient _client;

        public List<CardsModel> Items { get; private set; }


        public CardsService()
        {
            _client = new HttpClient();
        }

        public async Task<List<CardsModel>> RefreshDataAsync()
        {
            Items = new List<CardsModel>();

            var uri = new Uri(string.Format(Constants.CardsUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<CardsModel>>(content);
                    foreach (var item in Items)
                    {
                        item.Avatar = string.Format(Constants.CardsImageUrl, item.IdName);
                        item.Related = RelateCards(Items, item);
                    }
                }
                Items.Sort(SortByNameAscending);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Items;
        }

        public int SortByNameAscending(CardsModel c1, CardsModel c2)
        {
            return string.Compare(c1.Name, c2.Name, StringComparison.Ordinal);
        }

        public List<CardsModel> RelateCards(List<CardsModel> allCards, CardsModel card)
        {
            var related = new List<CardsModel>();
            foreach (var cardJ in allCards)
            {
                var nameWords = cardJ.Name.Split(' ');
                foreach (var word in nameWords)
                {

                    if (card.IdName != cardJ.IdName && card.Description != null && card.Description.ToLower().Contains(word.ToLower()))
                    {
                        related.Add(cardJ);
                        break;
                    }
                }
            }
               
            return related;
            
        }
    }
}
