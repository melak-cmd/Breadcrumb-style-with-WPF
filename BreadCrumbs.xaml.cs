using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Breadcrumb_style_with_WPF
{
    /// <summary>
    /// Interaction logic for BreadCrumbs.xaml
    /// </summary>
    public partial class BreadCrumbs : UserControl
    {

        public IParent SelectedItem
        {
            get { return (IParent)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(IParent), typeof(BreadCrumbs), new PropertyMetadata(null, OnSelectedItemChanged));


        public BreadCrumbs()
        {
            InitializeComponent();
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            IParent selectedItem = (IParent)((Button)sender).Tag;
            SelectedItem = selectedItem;
        }

        private void BuildPath(IParent Node)
        {
            pnlContent.Children.Clear();
            while (Node != null)
            {
                Button b = new();
                b.Content = Node.ToString();
                b.Click += b_Click;
                b.Tag = Node;
                pnlContent.Children.Insert(0, b);
                Node = Node.Parent;
                //if we have more parents then we want a seperator
                if (Node != null)
                {
                    Label seperator = new()
                    {
                        Content = ">>"
                    };
                    pnlContent.Children.Insert(0, seperator);
                }
            }
        }

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((BreadCrumbs)d).BuildPath((IParent)e.NewValue);
        }
    }
}
