using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Vehicle
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
        /// CarCode
        /// </summary>		
        private string _carcode;
        public string CarCode
        {
            get { return _carcode; }
            set { _carcode = value; }
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
        /// MotorcadeName
        /// </summary>		
        private string _motorcadename;
        public string MotorcadeName
        {
            get { return _motorcadename; }
            set { _motorcadename = value; }
        }
        /// <summary>
        /// MotorcycleType
        /// </summary>		
        private string _motorcycletype;
        public string MotorcycleType
        {
            get { return _motorcycletype; }
            set { _motorcycletype = value; }
        }
        /// <summary>
        /// LoadingCapacity
        /// </summary>		
        private decimal _loadingcapacity;
        public decimal LoadingCapacity
        {
            get { return _loadingcapacity; }
            set { _loadingcapacity = value; }
        }
        /// <summary>
        /// EngineType
        /// </summary>		
        private string _enginetype;
        public string EngineType
        {
            get { return _enginetype; }
            set { _enginetype = value; }
        }
        /// <summary>
        /// FrameNumber
        /// </summary>		
        private string _framenumber;
        public string FrameNumber
        {
            get { return _framenumber; }
            set { _framenumber = value; }
        }
        /// <summary>
        /// ChassisNumber
        /// </summary>		
        private string _chassisnumber;
        public string ChassisNumber
        {
            get { return _chassisnumber; }
            set { _chassisnumber = value; }
        }
        /// <summary>
        /// InsuranceNumber
        /// </summary>		
        private string _insurancenumber;
        public string InsuranceNumber
        {
            get { return _insurancenumber; }
            set { _insurancenumber = value; }
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
