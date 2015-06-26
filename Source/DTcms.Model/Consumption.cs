using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Consumption
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
        /// TransportOrderId
        /// </summary>		
        private int _transportorderid;
        public int TransportOrderId
        {
            get { return _transportorderid; }
            set { _transportorderid = value; }
        }
        /// <summary>
        /// Money
        /// </summary>		
        private decimal _money;
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

    }
}
