﻿// Copyright (C) 2014-2016, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.IpTv.DvbStp.Client
{
    public partial class DvbStpEnhancedClient
    {
        public event EventHandler<DownloadStartedEventArgs> DownloadStarted;
        public event EventHandler<DownloadCompletedEventArgs> DownloadCompleted;
        public event EventHandler<DvbStpSimpleClient.SectionReceivedEventArgs> SectionReceived;
        public event EventHandler<SegmentSectionReceivedEventArgs> SegmentDownloadStarted;
        public event EventHandler<SegmentSectionReceivedEventArgs> SegmentSectionReceived;
        public event EventHandler<SegmentDownloadRestartedEventArgs> SegmentDownloadRestarted;
        public event EventHandler<SegmentDownloadCompletedEventArgs> SegmentDownloadCompleted;

        #region EventArgs classes

        public class DownloadStartedEventArgs : EventArgs
        {
            public int SegmentsCount
            {
                get;
                set;
            } // SegmentsCount
        } // class DvbStpEnhancedClient.DownloadStartedEventArgs

        public class DownloadCompletedEventArgs: EventArgs
        {
            public IList<DvbStpClientSegmentInfo> Payloads
            {
                get;
                set;
            } // Payloads
        } // DvbStpEnhancedClient.DownloadCompletedEventArgs

        public class SegmentSectionReceivedEventArgs : DvbStpSimpleClient.PayloadSectionReceivedEventArgs
        {
            public int SegmentListIndex
            {
                get;
                set;
            } // SegmentListIndex
        } // DvbStpEnhancedClient.SegmentSectionReceivedEventArgs

        public class SegmentDownloadRestartedEventArgs : DvbStpSimpleClient.DownloadRestartedEventArgs
        {
            public int SegmentListIndex
            {
                get;
                set;
            } // SegmentListIndex

            public int GlobalRestartCount
            {
                get;
                set;
            } // GlobalRestartCount

            public int RestartCount
            {
                get;
                set;
            } // RestartCount
        } // DvbStpEnhancedClient.SegmentDownloadRestartedEventArgs

        public class SegmentDownloadCompletedEventArgs : EventArgs
        {
            private SegmentAssembler SegmentData;

            public SegmentDownloadCompletedEventArgs(SegmentAssembler segmentData)
            {
                SegmentData = segmentData;
            } // constructor

            public int SegmentListIndex
            {
                get;
                set;
            } // SegmentListIndex

            public int SegmentsReceived
            {
                get;
                set;
            } // SegmentsReceived

            public int SegmentsPending
            {
                get;
                set;
            } // SegmentsPending

            public byte PayloadId;
            public short SegmentId;
            public byte SegmentVersion;
            public int SectionCount;

            public byte[] GetPayloadData(bool keep)
            {
                var data = SegmentData.GetPayload();
                if (!keep)
                {
                    SegmentData.Dispose();
                } // if

                return data;
            } // GetPayloadData
        } // DvbStpEnhancedClient.SegmentDownloadCompletedEventArgs

        #endregion

        #region FireEvent() methods

        protected virtual void FireDownloadStarted()
        {
            if (DownloadStarted == null) return;

            var e = new DownloadStartedEventArgs()
            {
                SegmentsCount = this.Payloads.Count
            };
            OnDownloadStarted(this, e);
        } // FireDownloadStarted

        protected virtual void FireDownloadCompleted()
        {
            if (DownloadCompleted == null) return;

            var e = new DownloadCompletedEventArgs()
            {
                Payloads = this.Payloads
            };
            OnDownloadCompleted(this, e);
        } // FireDownloadCompleted

        private void FireSectionReceived()
        {
            if (SectionReceived == null) return;

            var e = new DvbStpSimpleClient.SectionReceivedEventArgs()
            {
                DatagramCount = this.DatagramCount,
                PayloadId = Header.PayloadId,
                SegmentIdNetworkLo = Header.SegmentIdNetworkLo,
                SegmentIdNetworkHi = Header.SegmentIdNetworkHi,
                SegmentVersion = Header.SegmentVersion
            };

            OnSectionReceived(this, e);
        } // FireSectionReceived

        protected virtual void FireSegmentDownloadStarted(SegmentStatus status)
        {
            if (SegmentDownloadStarted == null) return;

            var e = GetSegmentSectionReceivedEventArgs(status);
            OnSegmentDownloadStarted(this, e);
        } // FireSegmentDownloadStarted

        protected virtual void FireSegmentSectionReceived(SegmentStatus status)
        {
            if (SegmentSectionReceived == null) return;

            var e = GetSegmentSectionReceivedEventArgs(status);
            OnSegmentSectionReceived(this, e);
        } // FireSegmentSectionReceived

        protected virtual void FireSegmentDownloadRestarted(SegmentStatus status, byte oldVersion)
        {
            if (SegmentDownloadRestarted == null) return;

            var e = new SegmentDownloadRestartedEventArgs()
            {
                PayloadId = status.PayloadId,
                SegmentListIndex = status.InfoIndex,
                OldVersion = oldVersion,
                NewVersion = status.SegmentVersion,
                SectionCount = status.SegmentData.LastSectionNumber + 1,
                RestartCount = status.DowloadRestartCount,
                GlobalRestartCount = this.DowloadRestartCount,
            };
            OnSegmentDownloadRestarted(this, e);
        } // FireSegmentDownloadRestarted

        protected virtual void FireSegmentDownloadCompleted(SegmentStatus status)
        {
            if (SegmentDownloadCompleted == null) return;

            var e = new SegmentDownloadCompletedEventArgs(status.SegmentData)
            {
                PayloadId = Header.PayloadId,
                SegmentId = Header.SegmentId,
                SegmentVersion = Header.SegmentVersion,
                SectionCount = status.SegmentData.LastSectionNumber + 1,
                SegmentListIndex = status.InfoIndex,
                SegmentsReceived = this.SegmentsReceived,
                SegmentsPending = this.SegmentsPending,
            };
            OnSegmentDownloadCompleted(this, e);
        } // SegmentDownloadCompleted

        #endregion

        #region OnEvent() methods

        protected virtual void OnDownloadStarted(object sender, DownloadStartedEventArgs e)
        {
            if (DownloadStarted == null) return;

            DownloadStarted(sender, e);
        } // OnDownloadStarted

        protected virtual void OnDownloadCompleted(object sender, DownloadCompletedEventArgs e)
        {
            if (DownloadCompleted == null) return;

            DownloadCompleted(sender, e);
        } // OnDownloadCompleted

        protected virtual void OnSectionReceived(object sender, DvbStpSimpleClient.SectionReceivedEventArgs e)
        {
            if (SectionReceived == null) return;

            SectionReceived(sender, e);
        } // OnSectionReceived

        protected virtual void OnSegmentDownloadStarted(object sender, SegmentSectionReceivedEventArgs e)
        {
            if (SegmentDownloadStarted == null) return;

            SegmentDownloadStarted(sender, e);
        } // OnSegmentDownloadStarted

        protected virtual void OnSegmentSectionReceived(object sender, SegmentSectionReceivedEventArgs e)
        {
            if (SegmentSectionReceived == null) return;

            SegmentSectionReceived(sender, e);
        } // OnSegmentSectionReceived

        protected virtual void OnSegmentDownloadRestarted(object sender, SegmentDownloadRestartedEventArgs e)
        {
            if (SegmentDownloadRestarted == null) return;

            SegmentDownloadRestarted(sender, e);
        } // SegmentDownloadRestarted

        protected virtual void OnSegmentDownloadCompleted(object sender, SegmentDownloadCompletedEventArgs e)
        {
            if (SegmentDownloadCompleted == null) return;

            SegmentDownloadCompleted(sender, e);
        } // OnSegmentDownloadCompleted

        #endregion

        #region Auxiliary methods

        protected SegmentSectionReceivedEventArgs GetSegmentSectionReceivedEventArgs(SegmentStatus status)
        {
            var e = new SegmentSectionReceivedEventArgs()
            {
                PayloadId = Header.PayloadId,
                SegmentId = Header.SegmentId,
                SegmentVersion = Header.SegmentVersion,
                SectionCount = status.SegmentData.LastSectionNumber + 1,
                SectionsReceived = status.SegmentData.ReceivedSections,
                SectionNumber = Header.SectionNumber,
                SegmentListIndex = status.InfoIndex
            };

            return e;
        } // GetSegmentSectionReceivedEventArgs

        #endregion
    } // class DvbStpEnhancedClient
} // namespace
