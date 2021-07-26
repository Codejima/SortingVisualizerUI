using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingVisualizerUI
{
    public class BubbleSortAlgorithm : SortingAlgorithm
    {
        private int index;
        public BubbleSortAlgorithm(int count, StackPanel panel, TabControl tb)
        {
            this.count = count;
            this.panel = panel;
            tabs = tb;
            started = false;
            index = 0;
            Init();
        }
        public override void ApplicationLoop(object sender, EventArgs e)
        {
            for (int j = 0; j < count; j++)
                if (rectangles[index].Height < rectangles[j].Height)
                {
                    //rectangles[index].Fill = Brushes.Orange; // untested
                    //rectangles[j].Fill = Brushes.Orange; // untested
                    //Thread.Sleep(1000); // untested
                    Swap(index, j);
                    rectangles[index].Fill = Brushes.CornflowerBlue;
                    rectangles[j].Fill = Brushes.CornflowerBlue;
                }
            index++;
            if (index == count)
                started = false;
        }
    }
}