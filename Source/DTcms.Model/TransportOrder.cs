using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class TransportOrder
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
        /// DispatchTime
        /// </summary>		
        private DateTime _dispatchtime;
        public DateTime DispatchTime
        {
            get { return _dispatchtime; }
            set { _dispatchtime = value; }
        }

        private DateTime _receiptTime;
        public DateTime ReceiptTime
        {
            get { return _receiptTime; }
            set { _receiptTime = value; }
        }
        /// <summary>
        /// FactDispatchTime
        /// </summary>		
        private DateTime? _factdispatchtime;
        public DateTime? FactDispatchTime
        {
            get { return _factdispatchtime; }
            set { _factdispatchtime = value; }
        }
        /// <summary>
        /// TimeLimit
        /// </summary>		
        private int _timelimit;
        public int TimeLimit
        {
            get { return _timelimit; }
            set { _timelimit = value; }
        }
        /// <summary>
        /// BackTime
        /// </summary>		
        private DateTime _backtime;
        public DateTime BackTime
        {
            get { return _backtime; }
            set { _backtime = value; }
        }
        /// <summary>
        /// FactBackTime
        /// </summary>		
        private DateTime? _factbacktime;
        public DateTime? FactBackTime
        {
            get { return _factbacktime; }
            set { _factbacktime = value; }
        }
        /// <summary>
        /// MotorcadeName
        /// </summary>		
        private string _motorcadename;
        public string MotorcadeName
        {
            get { return _motorcadename; }
            set { _motorcadename = value; }
        }
        /// <summary>
        /// CarNumber
        /// </summary>		
        private string _carnumber;
        public string CarNumber
        {
            get { return _carnumber; }
            set { _carnumber = value; }
        }
        /// <summary>
        /// Trailer
        /// </summary>		
        private string _trailer;
        public string Trailer
        {
            get { return _trailer; }
            set { _trailer = value; }
        }
        /// <summary>
        /// Driver
        /// </summary>		
        private string _driver;
        public string Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
        /// <summary>
        /// DispatchCount
        /// </summary>		
        private decimal _dispatchcount;
        public decimal DispatchCount
        {
            get { return _dispatchcount; }
            set { _dispatchcount = value; }
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
        /// Advance
        /// </summary>		
        private decimal _advance;
        public decimal Advance
        {
            get { return _advance; }
            set { _advance = value; }
        }
        /// <summary>
        /// Payee
        /// </summary>		
        private string _payee;
        public string Payee
        {
            get { return _payee; }
            set { _payee = value; }
        }
        /// <summary>
        /// Repayment
        /// </summary>		
        private decimal _repayment;
        public decimal Repayment
        {
            get { return _repayment; }
            set { _repayment = value; }
        }
        /// <summary>
        /// FactRepayment
        /// </summary>		
        private decimal _factrepayment;
        public decimal FactRepayment
        {
            get { return _factrepayment; }
            set { _factrepayment = value; }
        }
        /// <summary>
        /// Percentage
        /// </summary>		
        private decimal _percentage;
        public decimal Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }
        /// <summary>
        /// Carriage
        /// </summary>		
        private decimal _carriage;
        public decimal Carriage
        {
            get { return _carriage; }
            set { _carriage = value; }
        }
        /// <summary>
        /// FactCarriage
        /// </summary>		
        private decimal _factcarriage;
        public decimal FactCarriage
        {
            get { return _factcarriage; }
            set { _factcarriage = value; }
        }
        /// <summary>
        /// CostTotal
        /// </summary>		
        private decimal _costtotal;
        public decimal CostTotal
        {
            get { return _costtotal; }
            set { _costtotal = value; }
        }
        /// <summary>
        /// Profit
        /// </summary>		
        private decimal _profit;
        public decimal Profit
        {
            get { return _profit; }
            set { _profit = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
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
        /// <summary>
        /// 回单提醒
        /// </summary>		
        private DateTime? _warningTime;
        public DateTime? WarningTime
        {
            get { return _warningTime; }
            set { _warningTime = value; }
        }

    }
}
