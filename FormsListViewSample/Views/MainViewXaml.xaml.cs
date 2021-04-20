using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FormsListViewSample
{
	
	public partial class MainViewXaml : ContentPage
	{
		public ObservableCollection<VeggieViewModel> veggies { get; set; }
        public MainViewXaml()
        {
            InitializeComponent();

            veggies = new ObservableCollection<VeggieViewModel>();
            for (int i = 0; i < 20; i++) {
                veggies.Add(new VeggieViewModel { Name = "Tomato", Type = "Fruit", Image = "tomato.png" });
                veggies.Add(new VeggieViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "lettuce.png" });
                veggies.Add(new VeggieViewModel { Name = "Zucchini", Type = "Vegetable", Image = "zucchini.png" });
            }
            lstView.ItemsSource = veggies;
            refreshButton.Clicked += RefreshButton_Clicked;
            memoryStatusLabel.Text = "Memory used : " + GC.GetTotalMemory(true);

        }


        private void RefreshButton_Clicked(object sender, System.EventArgs e)
        {
            lstView.ItemsSource = veggies;
            lstView.ScrollTo(veggies[0], ScrollToPosition.MakeVisible, true);
            // For simplicity, but simple Console.WriteLine will show the memory usage growing constantly
            // Console.WriteLine("Memory used : " + GC.GetTotalMemory(true));
            // 
            memoryStatusLabel.Text = "Memory used : " + GC.GetTotalMemory(true);
        }
    }
}

