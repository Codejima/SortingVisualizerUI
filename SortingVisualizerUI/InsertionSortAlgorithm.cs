using System;
using System.Windows.Controls;

namespace SortingVisualizerUI
{
    public class InsertionSortAlgorithm : SortingAlgorithm
    {
        private int index;
        public InsertionSortAlgorithm(int count, StackPanel panel, TabControl tb)
        {
            this.count = count;
            this.panel = panel;
            tabs = tb;
            index = 1;
            Init();
        }
        public override void ApplicationLoop(object sender, EventArgs e)
        {

            var current = rectangles[index].Height;
            int j = index - 1;
            while (j >= 0 && rectangles[j].Height > current)
            {
                rectangles[j + 1].Height = rectangles[j].Height;
                j--;
            }
            index++;
            rectangles[j + 1].Height = current;
            if (index == count)
                started = false;

        }
    }
}