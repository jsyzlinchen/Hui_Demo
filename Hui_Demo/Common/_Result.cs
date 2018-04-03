using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Common
{
    public class _Result
    {

        public string statusCode { set; get; }
        public string message { set; get; }
        public string tabid { set; get; }
        public string dialogid { set; get; }
        public string divid { set; get; }
        public bool closeCurrent { set; get; }
        public string forward { set; get; }
        public string forwardConfirm { set; get; }


        public _Result Message(string Message)
        {
            this.message = Message;
            return this;
        }

        public _Result MessageException(string Exception)
        {
            this.message += String.Format(",{0}", Exception);
            return this;
        }


        public _Result MessageAppend(string Message)
        {
            this.message += Message;
            return this;
        }

        public _Result TabID(string TabID)
        {
            this.tabid = TabID;
            return this;
        }

        public _Result DialogID(string DialogID)
        {
            this.dialogid = DialogID;
            return this;
        }

        public _Result DivID(string DivID)
        {
            this.divid = DivID;
            return this;
        }
        public _Result CloseCurrent(bool CloseCurrent)
        {
            this.closeCurrent = CloseCurrent;
            return this;
        }

        public _Result Forward(string Forward)
        {
            this.forward = Forward;
            return this;
        }

        public _Result ForwardConfirm(string ForwardConfirm)
        {
            this.forwardConfirm = ForwardConfirm;
            return this;
        }
    }
}