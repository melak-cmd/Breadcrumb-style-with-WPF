using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Breadcrumb_style_with_WPF
{
    public class TreeSampleViewModel: BindableBase
    {
        ObservableCollection<RandomValueNode> childNodes;
        public ObservableCollection<RandomValueNode> ChildNodes
        {
            get { return childNodes; }
            set { SetProperty(ref childNodes, value); }
        }

        RandomValueNode selectedNode;
        public RandomValueNode SelectedNode
        {
            get { return selectedNode; }
            set { SetProperty(ref selectedNode, value); }
        }

        public TreeSampleViewModel()
        {
            childNodes = new ObservableCollection<RandomValueNode>();
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < RandomValueNode.MAXCHILDREN; i++)
            {
                childNodes.Add(new RandomValueNode(null, random, random.Next(RandomValueNode.MAXDEPTH)));
            }
        }
    }
}