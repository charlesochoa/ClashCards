using System;
using System.Collections.Generic;
namespace ClashCards.Models
{
    public partial class CardsModel
    {
        public string Id { get; set; }

        public string  IdName { get; set; }

        public string Avatar { get; set; }

        public string Rarity { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long ElixirCost { get; set; }

        public long CopyId { get; set; }

        public long Arena { get; set; }

        public long Order { get; set; }

        public List<CardsModel> Related { get; set; }

    }
}
