using System;
using System.Collections.Generic;

namespace ClashCards.Models
{
    public partial class StateModel
    {
        public List<string> AlreadySeen { get; set; }

        public List<CardsModel> Related { get; set; }


        public CardsModel Card { get; set; }

    }
}