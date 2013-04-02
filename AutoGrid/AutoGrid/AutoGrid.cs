using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Controls
{
    public class AutoGrid : Grid
    {
        #region Private members
        #endregion

        #region Constructor

        public AutoGrid()
        {
            SetRows();
            OrderChildren();
        }

        private void OrderChildren()
        {
            int currColumn = 0;
            int currRow = 0;

            foreach (FrameworkElement item in Children)
            {
                item.SetValue(Grid.ColumnProperty, currColumn++);
                item.SetValue(Grid.RowProperty, currRow);

                if (currColumn >= this.ColumnDefinitions.Count)
                {
                    currColumn = 0;
                    currRow++;
                }
            }
        }

        private void SetRows()
        {
            if (this.Children.Count > 0 && this.ColumnDefinitions.Count > 0)
            {
                for (int i = 0; i < this.Children.Count / this.ColumnDefinitions.Count; i++)
                {
                    this.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                }
            }

        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            SetRows();
            OrderChildren();
        }

        static AutoGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoGrid), new FrameworkPropertyMetadata(typeof(AutoGrid)));
        }

        #endregion

        #region Private methods
        #endregion
    }
}
