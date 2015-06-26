using System;
namespace DTcms.Model
{
    /// <summary>
    /// ³µ¶Ó
    /// </summary>
    [Serializable]
    public partial class Motorcade
    {
        public Motorcade()
        { }
        #region Model
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name = "";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _code = "";

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private bool _isOutOfTeam = true;

        public bool IsOutOfTeam
        {
            get { return _isOutOfTeam; }
            set { _isOutOfTeam = value; }
        }
        private string _linkMan = "";

        public string LinkMan
        {
            get { return _linkMan; }
            set { _linkMan = value; }
        }
        private string _linkTel = "";

        public string LinkTel
        {
            get { return _linkTel; }
            set { _linkTel = value; }
        }
        private string _linkAddress = "";

        public string LinkAddress
        {
            get { return _linkAddress; }
            set { _linkAddress = value; }
        }
        private string _remarks = "";

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        #endregion Model

    }
}