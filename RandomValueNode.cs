using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadcrumb_style_with_WPF
{
    public class RandomValueNode : IParent
    {
        public const int MAXDEPTH = 10;
        public const int MAXCHILDREN = 10;

        private const int PROPERTYLENGTH = 10;

        public IParent Parent { get; set; }
        public List<RandomValueNode> Children { get; set; }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }

        public RandomValueNode(RandomValueNode Parent, Random Random, int Depth)
        {
            this.Parent = Parent;
            this.Children = new List<RandomValueNode>();

            this.Property1 = RandomString.Get(PROPERTYLENGTH);
            this.Property2 = RandomString.Get(PROPERTYLENGTH);
            this.Property3 = RandomString.Get(PROPERTYLENGTH);

            if (Depth <= 1)
                return;

            int numChildren = Random.Next(MAXCHILDREN);

            for (int i = 0; i < numChildren; i++)
            {
                Children.Add(new RandomValueNode(this, Random, Depth - 1));
            }
        }

        public override string ToString()
        {
            return Property1;
        }
    }
}