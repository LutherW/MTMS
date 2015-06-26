using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Order
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
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// AcceptOrderTime
        /// </summary>		
        private DateTime _acceptordertime;
        public DateTime AcceptOrderTime
        {
            get { return _acceptordertime; }
            set { _acceptordertime = value; }
        }
        /// <summary>
        /// ArrivedTime
        /// </summary>		
        private DateTime _arrivedtime;
        public DateTime ArrivedTime
        {
            get { return _arrivedtime; }
            set { _arrivedtime = value; }
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
        /// ShipperLinkMan
        /// </summary>		
        private string _shipperlinkman;
        public string ShipperLinkMan
        {
            get { return _shipperlinkman; }
            set { _shipperlinkman = value; }
        }
        /// <summary>
        /// ShipperLinkTel
        /// </summary>		
        private string _shipperlinktel;
        public string ShipperLinkTel
        {
            get { return _shipperlinktel; }
            set { _shipperlinktel = value; }
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
        /// ReceiverLinkMan
        /// </summary>		
        private string _receiverlinkman;
        public string ReceiverLinkMan
        {
            get { return _receiverlinkman; }
            set { _receiverlinkman = value; }
        }
        /// <summary>
        /// ReceiverLinkTel
        /// </summary>		
        private string _receiverlinktel;
        public string ReceiverLinkTel
        {
            get { return _receiverlinktel; }
            set { _receiverlinktel = value; }
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
        /// IsCharteredCar
        /// </summary>		
        private int _ischarteredcar;
        public int IsCharteredCar
        {
            get { return _ischarteredcar; }
            set { _ischarteredcar = value; }
        }
        /// <summary>
        /// Quantity
        /// </summary>		
        private decimal _quantity;
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// DispatchedCount
        /// </summary>		
        private decimal _dispatchedcount;
        public decimal DispatchedCount
        {
            get { return _dispatchedcount; }
            set { _dispatchedcount = value; }
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
        /// BillNumber
        /// </summary>		
        private string _billnumber;
        public string BillNumber
        {
            get { return _billnumber; }
            set { _billnumber = value; }
        }
        /// <summary>
        /// WeighbridgeNumber
        /// </summary>		
        private string _weighbridgenumber;
        public string WeighbridgeNumber
        {
            get { return _weighbridgenumber; }
            set { _weighbridgenumber = value; }
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
        /// SettleAccountsWay
        /// </summary>		
        private string _settleaccountsway;
        public string SettleAccountsWay
        {
            get { return _settleaccountsway; }
            set { _settleaccountsway = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Remarks
        /// </summary>		
        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

    }
}
