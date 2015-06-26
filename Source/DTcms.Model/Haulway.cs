using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Haulway
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
        /// LoadingCapacityRunning
        /// </summary>		
        private decimal _loadingcapacityrunning;
        public decimal LoadingCapacityRunning
        {
            get { return _loadingcapacityrunning; }
            set { _loadingcapacityrunning = value; }
        }
        /// <summary>
        /// NoLoadingCapacityRunning
        /// </summary>		
        private decimal _noLoadingCapacityRunning;
        public decimal NoLoadingCapacityRunning
        {
            get { return _noLoadingCapacityRunning; }
            set { _noLoadingCapacityRunning = value; }
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
