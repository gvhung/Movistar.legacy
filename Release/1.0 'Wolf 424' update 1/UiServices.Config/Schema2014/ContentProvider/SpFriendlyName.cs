﻿// Copyright (C) 2014-2015, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Project.DvbIpTv.UiServices.Configuration.Schema2014.ContentProvider
{
    [Serializable]
    [XmlType(Namespace=SerializationCommon.XmlNamespace, AnonymousType=true)]
    public class SpFriendlyName
    {
        private string fieldValue;

        [XmlAttribute("domainName")]
        public string Domain
        {
            get;
            set;
        } // Domain

        [XmlText]
        public string Name
        {
            get { return fieldValue; }
            set { fieldValue = (value != null) ? value.Trim() : null; }
        } // Name
    } // class SpFriendlyName
} // namespace
