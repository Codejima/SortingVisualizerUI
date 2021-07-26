using System;
using System.Windows.Controls;

namespace SortingVisualizerUI
{
    public class SelectionSortAlgorithm : SortingAlgorithm
    {
        private int minIndex;
        private int index;
        public SelectionSortAlgorithm(int count, StackPanel panel, TabControl tb)
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

            minIndex = index;
            for (int j = index + 1; j < count; j++)
                if (rectangles[j].Height < rectangles[minIndex].Height)
                    minIndex = j;
            Swap(index, minIndex);
            index++;
            if (index == count)
                started = false;

        }
    }
}