using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadcrumb_style_with_WPF
{
    public static class RandomString
    {
        private static readonly Lazy<Random> _lazyRandom = new(() => new Random((int)DateTime.Now.Ticks));

        public static Random Random
        {
            get => _lazyRandom.Value;          
        }

        public static string Get(int Length)
        {
            StringBuilder builder = new();
            char ch;
            for (int i = 0; i < Length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}