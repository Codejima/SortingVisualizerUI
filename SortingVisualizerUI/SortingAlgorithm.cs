using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SortingVisualizerUI
{
    public class SortingAlgorithm // TODO: make abstract
    {
        protected Rectangle[] rectangles;
        protected StackPanel panel;
        protected TabControl tabs;
        protected int count;
        public bool started;

        //static int bars = 100;
        //int[] ArrayToSort = new int[bars];
        ////rectangles.Height = rectangles.Height * int[i]; //TODO: the way to do it

        public SortingAlgorithm()
        {
        }
        public SortingAlgorithm(int count, StackPanel panel)
        {
            this.count = count;
            this.panel = panel;
            started = false;
            Init();
        }
        // swaps rectangles position
        protected void Swap(int index1, int index2)
        {
            double temp = rectangles[index1].Height;
            rectangles[index1].Height = rectangles[index2].Height;
            rectangles[index2].Height = temp;
        }
        public virtual void ApplicationLoop(object sender, EventArgs e)
        {

        }
        // initializes random rectangles
        protected void Init() // TODO: make this in ctor?
        {
            rectangles = new Rectangle[count];
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                rectangles[i] = new Rectangle();
                rectangles[i].Fill = Brushes.CornflowerBlue; // style instead
                rectangles[i].Stroke = Brushes.Black; // style instead
                rectangles[i].VerticalAlignment = VerticalAlignment.Bottom; // style instead
                rectangles[i].Width = panel.Width / count;
                rectangles[i].Height = random.NextDouble() * panel.Height;
                panel.Children.Add(rectangles[i]);
            }
        }
        // sets number of rectangles
        public void UpdateBarCount(int count)
        {
            this.count = count;
            panel.Children.Clear();
            Init();
        }
    }
}