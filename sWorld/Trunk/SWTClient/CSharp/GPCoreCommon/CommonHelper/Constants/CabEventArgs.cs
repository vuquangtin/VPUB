using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelper.Constants
{
    public class CabEventArgs : EventArgs
    {
        private List<object> args = new List<object>();

        public int Count
        {
            get
            {
                return args.Count;
            }
        }

        public object this[int index]
        {
            get
            {
                return args[index];
            }
        }

        public CabEventArgs(params object[] objs)
        {
            foreach (object o in objs)
            {
                args.Add(o);
            }
        }
    }
}
