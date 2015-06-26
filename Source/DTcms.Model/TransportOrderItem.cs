using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class TransportOrderItem
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
        /// TransportOrderId
        /// </summary>		
        private int _transportorderid;
        public int TransportOrderId
        {
            get { return _transportorderid; }
            set { _transportorderid = value; }
        }
        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private string _orderCode;
        public string OrderCode
        {
            get { return _orderCode; }
            set { _orderCode = value; }
        }
        /// <summary>
        /// RoundStatus
        /// </summary>		
        private string _roundstatus;
        public string RoundStatus
        {
            get { return _roundstatus; }
            set { _roundstatus = value; }
        }
        /// <summary>
        /// ContractNumber
        /// </summary>		
        private string _contractnumber;
        public string ContractNumber
        {
            get { return _contractnumber; }
            set { _contractnumber = value; }
        }
        /// <summary>
        /// BillNumber
        /// </summary>		
        private string _billnumber;
        public string BillNumber
        {
            get { return _billnumber; }
            set { _billnumber = value; }
        }
        /// <summary>
        /// Shipper
        /// </summary>		
        private string _shipper;
        public string Shipper
        {
            get { return _shipper; }
            set { _shipper = value; }
        }
        /// <summary>
        /// Receiver
        /// </summary>		
        private string _receiver;
        public string Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }
        /// <summary>
        /// LoadingAddress
        /// </summary>		
        private string _loadingaddress;
        public string LoadingAddress
        {
            get { return _loadingaddress; }
            set { _loadingaddress = value; }
        }
        /// <summary>
        /// UnloadingAddress
        /// </summary>		
        private string _unloadingaddress;
        public string UnloadingAddress
        {
            get { return _unloadingaddress; }
            set { _unloadingaddress = value; }
        }
        /// <summary>
        /// Goods
        /// </summary>		
        private string _goods;
        public string Goods
        {
            get { return _goods; }
            set { _goods = value; }
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
        /// FactDispatchCount
        /// </summary>		
        private decimal _factdispatchcount;
        public decimal FactDispatchCount
        {
            get { return _factdispatchcount; }
            set { _factdispatchcount = value; }
        }

        private decimal _dispatchCount;
        public decimal DispatchCount
        {
            get { return _dispatchCount; }
            set { _dispatchCount = value; }
        }
        /// <summary>
        /// FactReceivedCount
        /// </summary>		
        private decimal _factreceivedcount;
        public decimal FactReceivedCount
        {
            get { return _factreceivedcount; }
            set { _factreceivedcount = value; }
        }
        /// <summary>
        /// CompensationCosts
        /// </summary>		
        private decimal _compensationcosts;
        public decimal CompensationCosts
        {
            get { return _compensationcosts; }
            set { _compensationcosts = value; }
        }
        /// <summary>
        /// MyCosts
        /// </summary>		
        private decimal _mycosts;
        public decimal MyCosts
        {
            get { return _mycosts; }
            set { _mycosts = value; }
        }
        /// <summary>
        /// Haulway
        /// </summary>		
        private string _haulway;
        public string Haulway
        {
            get { return _haulway; }
            set { _haulway = value; }
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
        private decimal _NoLoadingCapacityRunning;
        public decimal NoLoadingCapacityRunning
        {
            get { return _NoLoadingCapacityRunning; }
            set { _NoLoadingCapacityRunning = value; }
        }
        /// <summary>
        /// Formula
        /// </summary>		
        private string _formula;
        public string Formula
        {
            get { return _formula; }
            set { _formula = value; }
        }
        /// <summary>
        /// UnitPrice
        /// </summary>		
        private decimal _unitprice;
        public decimal UnitPrice
        {
            get { return _unitprice; }
            set { _unitprice = value; }
        }
        /// <summary>
        /// TotalPrice
        /// </summary>		
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }
        /// <summary>
        /// CompanyPrice
        /// </summary>		
        private decimal _companyprice;
        public decimal CompanyPrice
        {
            get { return _companyprice; }
            set { _companyprice = value; }
        }

    }
}
