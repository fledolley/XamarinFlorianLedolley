using System;
using System.Collections.Generic;
using System.Text;

namespace fourplaceproject.Model
{
    public class ListeLieux
    {
        public List<PlaceItemSummary> LLieux{ get; set; }

        public ListeLieux()
        {
            LLieux = new List<PlaceItemSummary>();
        }

        public ListeLieux(List<PlaceItemSummary> list)
        {
            LLieux = list;
        }
        

    }
}
