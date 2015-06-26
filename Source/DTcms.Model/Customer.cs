using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Customer
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
        /// ShortName
        /// </summary>		
        private string _shortname;
        public string ShortName
        {
            get { return _shortname; }
            set { _shortname = value; }
        }
        /// <summary>
        /// FullName
        /// </summary>		
        private string _fullname;
        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        /// <summary>
        /// TypeName
        /// </summary>		
        private string _typename;
        public string TypeName
        {
            get { return _typename; }
            set { _typename = value; }
        }
        /// <summary>
        /// Category
        /// </summary>		
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
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
        /// LinkMan
        /// </summary>		
        private string _linkman;
        public string LinkMan
        {
            get { return _linkman; }
            set { _linkman = value; }
        }
        /// <summary>
        /// LinkTel
        /// </summary>		
        private string _linktel;
        public string LinkTel
        {
            get { return _linktel; }
            set { _linktel = value; }
        }
        /// <summary>
        /// MobileNumber
        /// </summary>		
        private string _mobilenumber;
        public string MobileNumber
        {
            get { return _mobilenumber; }
            set { _mobilenumber = value; }
        }
        /// <summary>
        /// LinkAddress
        /// </summary>		
        private string _linkaddress;
        public string LinkAddress
        {
            get { return _linkaddress; }
            set { _linkaddress = value; }
        }
        /// <summary>
        /// TaxRegistrationNumber
        /// </summary>		
        private string _taxregistrationnumber;
        public string TaxRegistrationNumber
        {
            get { return _taxregistrationnumber; }
            set { _taxregistrationnumber = value; }
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
