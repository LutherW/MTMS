using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Goods
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
        /// CategoryName
        /// </summary>		
        private string _categoryname;
        public string CategoryName
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }
        /// <summary>
        /// Unit
        /// </summary>		
        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        /// <summary>
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}
