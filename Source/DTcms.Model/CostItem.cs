using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class CostItem
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// SortCode
        /// </summary>		
        private int _sortcode;
        public int SortCode
        {
            get { return _sortcode; }
            set { _sortcode = value; }
        }

    }
}
