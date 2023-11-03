using System;

namespace CategoryCRUD_31.Helpers
{
    public class PagingModel
    {
        public int currenpage { set; get; } 

        public int coutpage { set; get; } 

        public Func<int?, string> generateUrl { set; get; }
    }
}
