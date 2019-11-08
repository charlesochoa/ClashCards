using ClashCards.Models;
using ClashCards.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClashCards.ViewModels
{
    public class ClashCardsDetailViewModel : INotifyPropertyChanged
    {

        //public StateModel state;
        public ClashCardsDetailViewModel(StateModel newState)
        {
            State = newState;
            GetNextViewCommand = new Command(GetNextView);
            Cards = new ObservableCollection<CardsModel>(State.Card.Related.Where(x => !State.AlreadySeen.Contains(x.IdName)));
        }

        public Command GetNextViewCommand { get; set; }
        private CardsModel selectedCard;
        private StateModel state;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CardsModel> cards;

        public ObservableCollection<CardsModel> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                var args = new PropertyChangedEventArgs(nameof(Cards));
                PropertyChanged?.Invoke(this, args);
            }
        }


        public StateModel State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    var args = new PropertyChangedEventArgs(nameof(State));
                    PropertyChanged?.Invoke(this, args);
                }
            }

        }
        public CardsModel SelectedCard
        {
            get { return selectedCard; }
            set
            {
                if (selectedCard != value)
                {
                    selectedCard = value;
                    var args = new PropertyChangedEventArgs(nameof(SelectedCard));
                    PropertyChanged?.Invoke(this, args);
                    GetNextView();
                }
            }
        }


        public void GetNextView()
        {
            Console.WriteLine("Trying to load next detail page");
            Console.WriteLine(SelectedCard.IdName);
            var newState = new StateModel
            {
                AlreadySeen = new List<string>(State.AlreadySeen),
                Card = SelectedCard,
            };
            newState.AlreadySeen.Add(SelectedCard.IdName);
            var detailPage = new ClashCardsDetailViewPage()
            {
                BindingContext = new ClashCardsDetailViewModel(newState)
            };
            Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

    }
}