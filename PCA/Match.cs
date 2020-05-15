using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCA
{
    class Match: IComparable
    {
        public MyImage img;
        public int id;
        public double EucledianDist;

        public Match(MyImage img,double dist)
        {
            this.img = img;
            this.id = img.Id;
            this.EucledianDist = dist;
        }

        public int CompareTo(object obj)
        {
            Match other = (Match)obj;
            return (this.EucledianDist).CompareTo(other.EucledianDist);
            
        }
    }
}
