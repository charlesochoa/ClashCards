using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ClashCards.Models;
using ClashCards.Views;
using Xamarin.Forms;

namespace ClashCards.ViewModels
{
    public class ClashCardsListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ClashCardsListViewModel()
        {
            Cards = new ObservableCollection<CardsModel>();
            GetDetailViewCommand = new Command(GetDetailView);
            LoadCards();
        }
        private CardsModel selectedCard;


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
                }
            }
        }
        private async Task LoadCards()
        {
            List<CardsModel> cardList = await App.CardsManager.GetTaskAsync();
            Cards = new ObservableCollection<CardsModel>(cardList);
        }

        public Command GetDetailViewCommand { get; set; }

        public void GetDetailView()
        {

            if (SelectedCard != null)
            {

                Console.WriteLine("Trying to load detail page");
                Console.WriteLine(SelectedCard.IdName);
                var newState = new StateModel
                {
                    AlreadySeen = new List<string>
                    {
                        SelectedCard.IdName
                    },
                    Card = SelectedCard,
                };

                var detailPage = new ClashCardsDetailViewPage()
                {
                    BindingContext = new ClashCardsDetailViewModel(newState)
                };
                SelectedCard = null;
                Application.Current.MainPage.Navigation.PushAsync(detailPage);
            }
        }

    }
}
