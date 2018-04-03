using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Common
{
    public class Pager
    {
        public Controller Controller;
        private int _PagerTotal;
        private int _PagerIndex;
        private int _PagerSize;
        public int Index
        {
            set
            {
                _PagerIndex = value;
                Controller.ViewBag.PagerIndex = _PagerIndex;
                Controller.ViewBag.PagerNumber = _PagerIndex + 1;
            }
            get
            {
                return _PagerIndex;
            }
        }
        public int Size
        {
            set
            {
                _PagerSize = value;
                Controller.ViewBag.PagerSize = _PagerSize;
            }
            get
            {
                return _PagerSize;
            }
        }
        public int Number
        {
            get
            {
                return _PagerIndex + 1;
            }
        }
        public int Offset
        {
            get { return _PagerIndex * _PagerSize; }
        }
        public int Total
        {
            set
            {
                _PagerTotal = value;
                Controller.ViewBag.PagerTotal = _PagerTotal;
            }
            get
            {
                return Total;
            }
        }
        public void SetContext(Controller c)
        {
            Controller = c;
        }
    }
}