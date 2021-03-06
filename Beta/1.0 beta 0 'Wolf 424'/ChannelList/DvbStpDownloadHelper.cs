﻿// Copyright (C) 2014, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

using Microsoft.SqlServer.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.DvbIpTv.ChannelList
{
    public sealed class DvbStpDownloadHelper
    {
        // "Input" properties

        public DvbStpDownloadRequest Request
        {
            get;
            set;
        } // Request

        public string CaptionUserCancelled
        {
            get;
            set;
        } // CaptionUserCancelled

        public string TextUserCancelled
        {
            get;
            set;
        } // TextUserCancelled

        public string CaptionDownloadException
        {
            get;
            set;
        } // CaptionDownloadException

        public string TextDownloadException
        {
            get;
            set;
        } // TextDownloadException

        // "Return" properties

        public bool IsOk
        {
            get;
            private set;
        } // IsOk

        public DvbStpDownloadResponse Response
        {
            get;
            private set;
        } // Response

        public DvbStpDownloadHelper()
        {
            CaptionUserCancelled = "Request cancelled";
            CaptionDownloadException = "An error has ocurred while fetching data";
        } // constructor

        public void ShowDialog(IWin32Window owner)
        {
            using (var dlg = new DvbStpDownloadDialog()
                {
                    Request = this.Request,
                })
            {
                dlg.ShowDialog(owner);
                Response = dlg.Response;
            } // using

            IsOk = ((Response.UserCancelled == false) && (Response.DownloadException == null));

            if (Response.UserCancelled)
            {
                var box = new ExceptionMessageBox()
                {
                    Caption = CaptionUserCancelled,
                    Text = TextUserCancelled,
                    Beep = true,
                    Symbol = ExceptionMessageBoxSymbol.Information
                };
                box.Show(owner);

                return;
            } // if

            if (Response.DownloadException != null)
            {
                MyApplication.HandleException(owner, CaptionDownloadException, TextDownloadException, Response.DownloadException);
                return;
            } // if
        } // ShowDialog
    } // DownloadHelper
} // namespace
