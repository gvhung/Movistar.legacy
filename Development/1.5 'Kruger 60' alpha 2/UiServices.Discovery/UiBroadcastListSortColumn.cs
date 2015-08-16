﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Project.DvbIpTv.UiServices.Discovery
{
    [Serializable]
    public struct UiBroadcastListSortColumn
    {
        public UiBroadcastListSortColumn(UiBroadcastListColumn column, bool descending)
            : this()
        {

            Column = column;
            Descending = descending;
        } // constructor

        public UiBroadcastListColumn Column
        {
            get;
            set;
        } // Column

        [DefaultValue(false)]
        public bool Descending
        {
            get;
            set;
        } // Descending

        [XmlIgnore]
        public bool IsAscending
        {
            get { return !Descending; }
            set { Descending = !value; }
        } // IsAscending

        public override bool Equals(object obj)
        {
            // if parameter is null return false
            if (object.ReferenceEquals(obj, null)) return false;

            try
            {
                // return true if the fields match
                return this.Equals((UiBroadcastListSortColumn)obj);
            }
            catch (InvalidCastException)
            {
                // if parameter cannot be cast to this type return false
                return false;
            } // try-catch
        } // Equals

        public bool Equals(UiBroadcastListSortColumn column)
        {
            if (this.Column != column.Column) return false;
            if (this.IsAscending == column.IsAscending) return true;
            // special case
            if (this.Column == UiBroadcastListColumn.None) return true;

            return false;
        } // Equals

        public override int GetHashCode()
        {
            return IsAscending ? (int)Column : -1 * (int)Column;
        } // GetHashCode

        public static bool operator == (UiBroadcastListSortColumn column1, UiBroadcastListSortColumn column2)
        {
            return column1.Equals(column2);
        } // operator ==

        public static bool operator !=(UiBroadcastListSortColumn column1, UiBroadcastListSortColumn column2)
        {
            return !column1.Equals(column2);
        } // operator !=
    } // class UiBroadcastListViewSortColumn
} // namespace
