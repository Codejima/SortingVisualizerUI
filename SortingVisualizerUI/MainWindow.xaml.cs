using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SortingVisualizerUI
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly SortingAlgorithm bubbleAlgo;
        private readonly SortingAlgorithm selectionAlgo;
        private readonly SortingAlgorithm insertionAlgo;
        private int bars = 100;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            BarBox.Text = bars.ToString();
            bubbleAlgo = new BubbleSortAlgorithm(bars, bubblePanel, tabs);
            selectionAlgo = new SelectionSortAlgorithm(bars, selectionPanel, tabs);
            insertionAlgo = new InsertionSortAlgorithm(bars, insertionPanel, tabs);
        }
        // sends updated bars to corresponding algorithm
        public void UpdateSortingChanges(object sender, RoutedEventArgs e)
        {
            int newBars = bars;
            ObtainControlValues(ref newBars); // TODO: tryparse instead
            if (bars != newBars)
            {
                bars = newBars;
                switch (tabs.SelectedIndex)
                {
                    case 2:
                        selectionAlgo.UpdateBarCount(bars);
                        break;
                    case 3:
                        bubbleAlgo.UpdateBarCount(bars);
                        break;
                    case 4:
                        insertionAlgo.UpdateBarCount(bars);
                        break;
                }
            }
        }
        public void ObtainControlValues(ref int bar)
        {
            try
            {
                bar = int.Parse(BarBox.Text);
            }
            catch (Exception e){ }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}