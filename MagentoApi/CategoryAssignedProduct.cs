﻿/* 
MagentoApi CSharp Library
Copyright (c) 2009 ez.newsletter, LLC <ezmagento@ez-llc.com>
ez.newsletter - Advanced Targeted Email Marketing for Magento Store Owners
http://www.ez-llc.com/studio/site/eznewsletter/email-marketing-info-magento-customer-management.aspx
Contributions By:
	Keith Smyth keith@kkl.com.au

XML-RPC.NET library
Copyright (c) 2001-2006, Charles Cook <charlescook@cookcomputing.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/

using System;
using CookComputing.XmlRpc;

namespace Ez.Newsletter.MagentoApi
{
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CategoryAssignedProduct
    {
        #region Private Member Variables
        private string _type;
        private string _product_id;
        private string _sku;
        private string _position;
        private string _set;
        private string _price;
        private string _imageurl;
        private string _name;
        private int _qty_in_stock;
        private bool _is_in_stock;
        #endregion

        #region Private Properties

        #endregion

        #region Public Properties
        public bool is_in_stock
        {
            get { return _is_in_stock; }
            set { _is_in_stock = value; }
        }
        public int qty_in_stock
        {
            get { return _qty_in_stock; }
            set { _qty_in_stock = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        public string sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }
        public string set
        {
            get { return _set; }
            set { _set = value; }
        }

        private string _color;
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }
        

        #region Taglie

        private string _tg_36;
        public string tg_36
        {
            get { return _tg_36; }
            set { _tg_36 = value; }
        }

        private string _tg_37;
        public string tg_37
        {
            get { return _tg_37; }
            set { _tg_37 = value; }
        }

        private string _tg_38;
        public string tg_38
        {
            get { return _tg_38; }
            set { _tg_38 = value; }
        }

        private string _tg_39;
        public string tg_39
        {
            get { return _tg_39; }
            set { _tg_39 = value; }
        }

        private string _tg_40;
        public string tg_40
        {
            get { return _tg_40; }
            set { _tg_40 = value; }
        }

        private string _tg_41;
        public string tg_41
        {
            get { return _tg_41; }
            set { _tg_41 = value; }
        }

        private string _tg_42;
        public string tg_42
        {
            get { return _tg_42; }
            set { _tg_42 = value; }
        }

        private string _tg_43;
        public string tg_43
        {
            get { return _tg_43; }
            set { _tg_43 = value; }
        }

        private string _tg_44;
        public string tg_44
        {
            get { return _tg_44; }
            set { _tg_44 = value; }
        }

        private string _tg_45;
        public string tg_45
        {
            get { return _tg_45; }
            set { _tg_45 = value; }
        }

        private string _tg_46;
        public string tg_46
        {
            get { return _tg_46; }
            set { _tg_46 = value; }
        }

        private string _tg_47;
        public string tg_47
        {
            get { return _tg_47; }
            set { _tg_47 = value; }
        }
        #endregion Taglie
        #endregion

        #region Constructor

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Interfaces

        #endregion
    }
}
