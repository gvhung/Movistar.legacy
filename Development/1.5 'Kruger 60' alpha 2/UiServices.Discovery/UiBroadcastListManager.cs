﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project.DvbIpTv.UiServices.Common.Properties;
using System.Drawing;
using Project.DvbIpTv.UiServices.Common.Controls;
using Project.DvbIpTv.UiServices.Configuration.Logos;

namespace Project.DvbIpTv.UiServices.Discovery
{
    public class UiBroadcastListManager: IDisposable
    {
        public const LogoSize SmallLogoSize = LogoSize.Size32;
        public const LogoSize LargeLogoSize = LogoSize.Size48;

        private IList<UiBroadcastService> fieldBroadcastServices;
        private IEnumerable<UiBroadcastService> SortedBroadcastServices;
        private UiBroadcastListSettings fieldSettings;
        private UiBroadcastService fieldSelectedService;
        private const int MinColumnWidth = 25;
        private ImageList SmallImageList, LargeImageList;

        // TODO: Use fonts from Settings
        private Font FontDetails;
        private Font FontDetailsNameItem;
        private Font FontNormal;
        private Font FontNormalDisabled;
        private Font FontNormalNotAvailable;

        #region Static public methods

        public static List<KeyValuePair<UiBroadcastListColumn, string>> GetColumnNames(bool withNone = false)
        {
            var result = new List<KeyValuePair<UiBroadcastListColumn, string>>(withNone? 22 : 21);

            if (withNone)
            {
                result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.None, Properties.ListViewManager.ColumnNone));
            } // if
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.Name, Properties.ListViewManager.ColumnName));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.Number, Properties.ListViewManager.ColumnNumber));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.NumberAndName, Properties.ListViewManager.ColumnNumberAndName));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.NumberAndNameCrlf, Properties.ListViewManager.ColumnNumberAndNameCrlf));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.NameAndNumber, Properties.ListViewManager.ColumnNameAndNumber));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.Description, Properties.ListViewManager.ColumnDescription));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.DvbType, Properties.ListViewManager.ColumnDvbType));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.LocationUrl, Properties.ListViewManager.ColumnLocationUrl));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.ShortName, Properties.ListViewManager.ColumnShortName));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.Genre, Properties.ListViewManager.ColumnGenre));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.GenreCode, Properties.ListViewManager.ColumnGenreCode));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.ParentalRating, Properties.ListViewManager.ColumnParentalRating));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.ParentalRatingCode, Properties.ListViewManager.ColumnParentalRatingCode));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.ServiceId, Properties.ListViewManager.ColumnServiceId));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.FullServiceId, Properties.ListViewManager.ColumnFullServiceId));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.UserName, Properties.ListViewManager.ColumnUserName));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.UserNumber, Properties.ListViewManager.ColumnUserNumber));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.OriginalName, Properties.ListViewManager.ColumnOriginalName));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.OriginalNumber, Properties.ListViewManager.ColumnOriginalNumber));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.IsActive, Properties.ListViewManager.ColumnIsActive));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.IsEnabled, Properties.ListViewManager.ColumnIsEnabled));
            result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.LockLevel, Properties.ListViewManager.ColumnLockLevel));

            return result;
        } // ColumnNames

        public static List<KeyValuePair<UiBroadcastListColumn, string>> GetSortedColumnNames(bool withNone = false)
        {
            var names = GetColumnNames();
            var q = from item in names
                    orderby item.Value
                    select item;

            var count = withNone ? (names.Count + 1) : names.Count;
            var result = new List<KeyValuePair<UiBroadcastListColumn, string>>(names.Count);
            if (withNone)
            {
                result.Add(new KeyValuePair<UiBroadcastListColumn, string>(UiBroadcastListColumn.None, Properties.ListViewManager.ColumnNone));
            } // if
            result.AddRange(q);

            return result;
        } // SortedColumnNames

        public static string GetColumnName(UiBroadcastListColumn column)
        {
            switch (column)
            {
                case UiBroadcastListColumn.Number: return Properties.ListViewManager.ColumnNumberShort;
                case UiBroadcastListColumn.Name: return Properties.ListViewManager.ColumnNameShort;
                case UiBroadcastListColumn.NumberAndName: return Properties.ListViewManager.ColumnNumberAndNameShort;
                case UiBroadcastListColumn.NumberAndNameCrlf: return Properties.ListViewManager.ColumnNumberAndNameShort;
                case UiBroadcastListColumn.NameAndNumber: return Properties.ListViewManager.ColumnNameAndNumberShort;
                case UiBroadcastListColumn.Description: return Properties.ListViewManager.ColumnDescriptionShort;
                case UiBroadcastListColumn.DvbType: return Properties.ListViewManager.ColumnDvbTypeShort;
                case UiBroadcastListColumn.LocationUrl: return Properties.ListViewManager.ColumnLocationUrlShort;
                case UiBroadcastListColumn.ShortName: return Properties.ListViewManager.ColumnShortNameShort;
                case UiBroadcastListColumn.Genre: return Properties.ListViewManager.ColumnGenreShort;
                case UiBroadcastListColumn.GenreCode: return Properties.ListViewManager.ColumnGenreCodeShort;
                case UiBroadcastListColumn.ParentalRating: return Properties.ListViewManager.ColumnParentalRatingShort;
                case UiBroadcastListColumn.ParentalRatingCode: return Properties.ListViewManager.ColumnParentalRatingCodeShort;
                case UiBroadcastListColumn.ServiceId: return Properties.ListViewManager.ColumnServiceIdShort;
                case UiBroadcastListColumn.FullServiceId: return Properties.ListViewManager.ColumnFullServiceIdShort;
                case UiBroadcastListColumn.UserName: return Properties.ListViewManager.ColumnUserNameShort;
                case UiBroadcastListColumn.UserNumber: return Properties.ListViewManager.ColumnUserNumberShort;
                case UiBroadcastListColumn.OriginalName: return Properties.ListViewManager.ColumnOriginalNameShort;
                case UiBroadcastListColumn.OriginalNumber: return Properties.ListViewManager.ColumnOriginalNumberShort;
                case UiBroadcastListColumn.IsActive: return Properties.ListViewManager.ColumnIsActiveShort;
                case UiBroadcastListColumn.IsEnabled: return Properties.ListViewManager.ColumnIsEnabledShort;
                case UiBroadcastListColumn.LockLevel: return Properties.ListViewManager.ColumnLockLevelShort;
                default:
                    throw new IndexOutOfRangeException();
            } // switch
        } // GetColumnName

        public static int GetColumnDefaultWidth(UiBroadcastListColumn column)
        {
            switch (column)
            {
                case UiBroadcastListColumn.Number: return 45;
                case UiBroadcastListColumn.Name: return 180;
                case UiBroadcastListColumn.NumberAndName: return 210;
                case UiBroadcastListColumn.NumberAndNameCrlf: return 210;
                case UiBroadcastListColumn.NameAndNumber: return 210;
                case UiBroadcastListColumn.Description: return 200;
                case UiBroadcastListColumn.DvbType: return 60;
                case UiBroadcastListColumn.LocationUrl: return 150;
                case UiBroadcastListColumn.ShortName: return 90;
                case UiBroadcastListColumn.Genre: return 150;
                case UiBroadcastListColumn.GenreCode: return 100;
                case UiBroadcastListColumn.ParentalRating: return 150;
                case UiBroadcastListColumn.ParentalRatingCode: return 100;
                case UiBroadcastListColumn.ServiceId: return 75;
                case UiBroadcastListColumn.FullServiceId: return 125;
                case UiBroadcastListColumn.UserName: return 180;
                case UiBroadcastListColumn.UserNumber: return 45;
                case UiBroadcastListColumn.OriginalName: return 180;
                case UiBroadcastListColumn.OriginalNumber: return 45;
                case UiBroadcastListColumn.IsActive: return 45;
                case UiBroadcastListColumn.IsEnabled: return 45;
                case UiBroadcastListColumn.LockLevel: return 120;
                default:
                    throw new IndexOutOfRangeException();
            } // switch
        } // GetColumnDefaultWidth

        public static string GetColumnData(UiBroadcastService service, UiBroadcastListColumn column)
        {
            switch (column)
            {
                case UiBroadcastListColumn.Number:
                    return service.DisplayLogicalNumber;
                case UiBroadcastListColumn.Name:
                    return service.DisplayName;
                case UiBroadcastListColumn.NumberAndName:
                    return string.Format(Properties.ListViewManager.NumberAndNameFormat, service.DisplayLogicalNumber, service.DisplayName);
                case UiBroadcastListColumn.NumberAndNameCrlf:
                    return string.Format(Properties.ListViewManager.NumberAndNameCrlfFormat, service.DisplayLogicalNumber, service.DisplayName);
                case UiBroadcastListColumn.NameAndNumber:
                    return string.Format(Properties.ListViewManager.NameAndNumberFormat, service.DisplayName, service.DisplayLogicalNumber);
                case UiBroadcastListColumn.Description:
                    return service.DisplayDescription;
                case UiBroadcastListColumn.DvbType:
                    return service.DisplayServiceType;
                case UiBroadcastListColumn.LocationUrl:
                    return service.DisplayLocationUrl;
                case UiBroadcastListColumn.ShortName:
                    return service.DisplayShortName;
                case UiBroadcastListColumn.Genre:
                    return service.DisplayGenre;
                case UiBroadcastListColumn.GenreCode:
                    return service.DisplayGenreCode;
                case UiBroadcastListColumn.ParentalRating:
                    return service.DisplayParentalRating;
                case UiBroadcastListColumn.ParentalRatingCode:
                    return service.DisplayParentalRatingCode;
                case UiBroadcastListColumn.ServiceId:
                    return service.ServiceName;
                case UiBroadcastListColumn.FullServiceId:
                    return service.FullServiceName;
                case UiBroadcastListColumn.UserName:
                    return service.UserDisplayName ?? "";
                case UiBroadcastListColumn.UserNumber:
                    return service.UserLogicalNumber ?? Properties.Texts.ChannelNumberNone;
                case UiBroadcastListColumn.OriginalName:
                    return service.DisplayOriginalName;
                case UiBroadcastListColumn.OriginalNumber:
                    return service.ServiceLogicalNumber ?? Properties.Texts.ChannelNumberNone;
                case UiBroadcastListColumn.IsActive:
                    return (service.IsInactive) ? Properties.Texts.No : Properties.Texts.Yes;
                case UiBroadcastListColumn.IsEnabled:
                    return (service.IsHidden) ? Properties.Texts.No : Properties.Texts.Yes;
                case UiBroadcastListColumn.LockLevel:
                    return service.DisplayLockLevel;
                default:
                    throw new IndexOutOfRangeException();
            } // switch
        } // GetColumnData

        #endregion

        public UiBroadcastListManager(ListViewSortable listView, UiBroadcastListSettings settings, ImageList smallImageList, ImageList largeImageList, bool overrideDesignSettings)
        {
            if (listView == null) throw new ArgumentNullException("listView");
            if (settings == null) throw new ArgumentNullException("settings");

            ListView = listView;
            SmallImageList = smallImageList;
            LargeImageList = largeImageList;

            InitListViewControl(overrideDesignSettings);
            ApplySettings(settings);
        } // constructor

        public event EventHandler<ListStatusChangedEventArgs> StatusChanged;
        public event EventHandler<ListSelectionChangedEventArgs> SelectionChanged;

        public bool Disposed
        {
            get;
            private set;
        } // Disposed

        public ListViewSortable ListView
        {
            get;
            protected set;
        } // ListView

        public IList<UiBroadcastService> BroadcastServices
        {
            get
            {
                return fieldBroadcastServices;
            } // get
            set
            {
                fieldBroadcastServices = value;
                fieldSelectedService = null;
                ApplySorting();
                FillList(false);
                FireStatusChanged();
                FireSelectionChanged();
            } // set
        } // BroadcastServices

        public UiBroadcastListSettings Settings
        {
            get
            {
                return fieldSettings;
            } // get
            set
            {
                if (object.ReferenceEquals(fieldSettings, value))
                {
                    throw new InvalidOperationException();
                } // if

                ApplySettings(value);
            } // set
        } // Settings

        public UiBroadcastListSettings ClonedSettings
        {
            get { return Settings.CloneSettings(); }
        } // ClonedSettings

        public UiBroadcastService SelectedService
        {
            get
            {
                return fieldSelectedService;
            } // get
            set
            {
                // remove current selection
                for (int index = 0; index < ListView.SelectedItems.Count; index++)
                {
                    ListView.SelectedItems[0].Selected = false;
                } // for

                // select given item
                if (value != null)
                {
                    var listItem = ListView.Items[value.Key];
                    listItem.Selected = true;
                    listItem.EnsureVisible();
                } // if
                
                // save selected service
                fieldSelectedService = value;
            } // set
        } // SelectedService

        public UiBroadcastListSortColumn SelectedSort
        {
            get;
            private set;
        } // SelectedSort

        #region Events

        protected virtual void OnStatusChanged(object sender, ListStatusChangedEventArgs e)
        {
            if (StatusChanged != null)
            {
                StatusChanged(sender, e);
            } // if
        } // OnStatusChanged

        protected virtual void OnSelectionChanged(object sender, ListSelectionChangedEventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(sender, e);
            } // if
        } // OnSelectionChanged

        private void FireStatusChanged()
        {
            OnStatusChanged(this, new ListStatusChangedEventArgs(ListView.Items.Count > 0));
            FireSelectionChanged();
        } // FireStatusChanged

        private void FireSelectionChanged()
        {
            var listItem = (ListView.SelectedItems.Count == 0) ? null : ListView.SelectedItems[0];
            fieldSelectedService = (listItem == null) ? null : (UiBroadcastService)listItem.Tag;
         
            OnSelectionChanged(this, new ListSelectionChangedEventArgs(fieldSelectedService));
        } // FireSelectionChanged

        #endregion

        #region IDisposable implementation

        public virtual void Dispose()
        {
            if (Disposed) return;

            BroadcastServices = null;
            HookupEvents(false);
            ListView = null;

            if (FontNormal != null) FontNormal.Dispose();
            if (FontNormalDisabled != null) FontNormalDisabled.Dispose();
            if (FontNormalNotAvailable != null) FontNormalNotAvailable.Dispose();
            if (FontDetails != null) FontDetails.Dispose();
            if (FontDetailsNameItem != null) FontDetailsNameItem.Dispose();

            Disposed = true;
        } // Dispose

        #endregion

        #region ListView event handlers

        private void HookupEvents(bool add)
        {
            if (add)
            {
                ListView.SelectedIndexChanged += ListView_SelectedIndexChanged;
                ListView.ColumnClick += ListView_ColumnClick;
            }
            else
            {
                ListView.SelectedIndexChanged -= ListView_SelectedIndexChanged;
                ListView.ColumnClick -= ListView_ColumnClick;
            } // if-else
        }  // HookupEvents

        void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            FireSelectionChanged();
        } // ListView_SelectedIndexChanged

        void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var sortColumn = new UiBroadcastListSortColumn();
            sortColumn.Column = Settings.CurrentColumns[e.Column];
            sortColumn.IsAscending = sortColumn.Column == SelectedSort.Column? !SelectedSort.IsAscending : true;

            Settings.GlobalSortColumns = ServiceSortComparer.GetSuggestedSortColumns(sortColumn.Column, sortColumn.IsAscending, 3);
            Settings[Settings.CurrentMode].SortColumns = ServiceSortComparer.GetSuggestedSortColumns(sortColumn.Column, sortColumn.IsAscending, 3);

            ApplySorting();
            FillList(false);
        } // ListView_ColumnClick

        #endregion

        #region ListView management

        private void InitListViewControl(bool overrideDesignSettings)
        {
            FontNormal = new Font("Tahoma", 10.5f, FontStyle.Bold);
            FontNormalDisabled = new Font("Segoe UI Semibold", 9, FontStyle.Regular);
            FontNormalNotAvailable = new Font("Segoe UI", 9, FontStyle.Regular);
            FontDetails = new Font("Segoe UI Semibold", 9, FontStyle.Regular);
            FontDetailsNameItem = new Font("Tahoma", 11.0f, FontStyle.Bold);

            ListView.FullRowSelect = true;
            ListView.HideSelection = false;
            ListView.MultiSelect = false;
            ListView.SmallImageList = SmallImageList;
            ListView.LargeImageList = LargeImageList;
            ListView.SelfSorting = false;
            ListView.OwnerDraw = true;

            if (overrideDesignSettings)
            {
                ListView.HeaderStyle = ColumnHeaderStyle.Clickable;
                ListView.ShowItemToolTips = true;
                ListView.HeaderCustomFont = new Font(ListView.Font.OriginalFontName, 9, FontStyle.Bold);
                ListView.HeaderCustomTextAlignment = ContentAlignment.MiddleCenter;
                ListView.HeaderUsesCustomFont = true;
                ListView.HeaderUsesCustomTextAlignment = true;
                ListView.IsDoubleBuffered = true;
            } // if
            HookupEvents(true);
        } // InitListViewControl

        private void ApplySettings(UiBroadcastListSettings newSettings)
        {
            // save existing settings
            var oldSettings = fieldSettings;
            var savedSelectedService = fieldSelectedService;

            // save new settings
            fieldSettings = newSettings;

            // rebuild list?
            if (NeedToRebuildList(oldSettings, newSettings))
            {
                BuildListLayout();
            }
            else
            {
                ListView.BeginUpdate();

                // apply new sorting?
                if (NeedToApplySorting(oldSettings, newSettings))
                {
                    ApplySorting();
                    FillList(true);
                }
                else
                {
                    // apply cosmetic changes?
                    ApplyCosmeticSettings(oldSettings, newSettings);
                    savedSelectedService = null;
                } // if-else

                ListView.EndUpdate();
            } // if-else

            if (savedSelectedService != null) SelectedService = savedSelectedService;
        } // ApplySettings

        private void BuildListLayout()
        {
            ListView.BeginUpdate();
            ListView.Items.Clear();
            ListView.Columns.Clear();
            ListView.View = Settings.CurrentMode;
            ListView.Font = (Settings.CurrentMode == View.Details) ? FontDetails : FontNormal;

            var columns = Settings.CurrentColumns;
            foreach (var column in columns)
            {
                ListView.Columns.Add(GetColumnName(column), GetColumnWidth(column));
            } // foreach
            ListView.Columns[0].Width += SmallImageList.ImageSize.Width + 5;

            ApplyCosmeticSettings(null, fieldSettings);
            ApplySorting();
            FillList(true);
            ListView.EndUpdate();
        } // BuildListLayout

        private void FillList(bool insideUpdate)
        {
            if (!insideUpdate) ListView.BeginUpdate();

            ListView.Items.Clear();
            if ((BroadcastServices == null) || (BroadcastServices.Count == 0)) return;

            var items = new List<ListViewItem>(BroadcastServices.Count);
            var columns = Settings.CurrentColumns;
            if (columns.Count < 1) throw new InvalidOperationException();

            foreach (var service in SortedBroadcastServices)
            {
                if ((service.IsInactive) && (!Settings.ShowInactiveServices)) continue;
                if ((service.IsHidden) && (!Settings.ShowHiddenServices)) continue;

                var item = new ListViewItem();
                item.Tag = service;
                item.Name = service.Key;
                item.Text = GetColumnData(service, columns[0]);
                EnableListItem(item, service, !service.IsInactive, !service.IsHidden);

                var subItems = new string[columns.Count - 1];
                var index = (int)0;
                foreach (var column in columns.Skip(1))
                {
                    subItems[index++] = GetColumnData(service, column);
                } // foreach
                item.SubItems.AddRange(subItems);

                items.Add(item);
            } // foreach

            ListView.Items.AddRange(items.ToArray());

            if (!insideUpdate) ListView.EndUpdate();
        } // FillList

        private bool ApplyCosmeticSettings(UiBroadcastListSettings oldSettings, UiBroadcastListSettings newSettings)
        {
            var changed = false;

            if ((oldSettings == null) || (oldSettings.ShowGridlines != newSettings.ShowGridlines))
            {
                ListView.GridLines = newSettings.ShowGridlines;
                changed = true;
            } // if

            return changed;
        } // ApplyCosmeticSettings

        private void ApplySorting()
        {
            if ((BroadcastServices == null) || (BroadcastServices.Count == 0)) return;

            // select sorting column
            var sortingColumns = Settings.ApplyGlobalSortColumn ? Settings.GlobalSortColumns : Settings[Settings.CurrentMode].SortColumns;
            var sortingColumn = sortingColumns[0];
            SelectedSort = sortingColumn;

            if (sortingColumn.Column == UiBroadcastListColumn.None)
            {
                SortedBroadcastServices = fieldBroadcastServices;
            }
            else
            {
                var comparer = new ServiceSortComparer(Settings, sortingColumns);
                SortedBroadcastServices = fieldBroadcastServices.OrderBy(item => item, comparer);
            } // if-else

            FillList(true);

            // update 'arrow'
            if (Settings.CurrentMode == View.Details)
            {
                var q = from index in Enumerable.Range(0, Settings.CurrentColumns.Count)
                        where Settings.CurrentColumns[index] == sortingColumn.Column
                        select index;

                var columnIndex = q.DefaultIfEmpty(-1).First();
                ListView.Sort(columnIndex, sortingColumn.IsAscending);
            } // if
        } // ApplySorting

        private bool NeedToRebuildList(UiBroadcastListSettings oldSettings, UiBroadcastListSettings newSettings)
        {
            // new settings? 
            if (oldSettings == null) return true;

            //view mode changed?
            if (oldSettings.CurrentMode != newSettings.CurrentMode) return true;

            // number of columns changed?
            var oldColumns = oldSettings.CurrentColumns;
            var newColums = newSettings.CurrentColumns;
            if (oldColumns.Count != newColums.Count) return true;

            // columns changed
            for (int index = 0; index < oldColumns.Count; index++)
            {
                if (oldColumns[index] != newColums[index])
                {
                    return true;
                } // if
            } // for

            return false;
        } // NeedToRebuildList

        private bool NeedToApplySorting(UiBroadcastListSettings oldSettings, UiBroadcastListSettings newSettings)
        {
            // global sort column changed?
            if (oldSettings.ApplyGlobalSortColumn != newSettings.ApplyGlobalSortColumn) return true;

            if (newSettings.ApplyGlobalSortColumn)
            {
                return !CompareSortColumns(oldSettings.GlobalSortColumns, newSettings.GlobalSortColumns);
            } // if

            // current mode sort column changed?
            var oldModeSettings = oldSettings[oldSettings.CurrentMode];
            var newModeSettings = newSettings[newSettings.CurrentMode];

            return !CompareSortColumns(oldModeSettings.SortColumns, newModeSettings.SortColumns);
        } // NeedToApplySorting

        private bool CompareSortColumns(List<UiBroadcastListSortColumn> oldColumns, List<UiBroadcastListSortColumn> newColumns)
        {
            if (oldColumns.Count != newColumns.Count) return false;

            for (int index = 0; index < oldColumns.Count; index++)
            {
                if (oldColumns[index] != newColumns[index]) return false;
            } // if

            return true;
        } // CompareSortColumns

        private int GetColumnWidth(UiBroadcastListColumn column)
        {
            var width = Settings.ColumnWidth[(int)column];
            if (width <= 0) return GetColumnDefaultWidth(column);
            else if (width < MinColumnWidth) return MinColumnWidth;
            else return width;
        } // GetColumnWidth

        private void EnableListItem(ListViewItem item, UiBroadcastService service, bool available, bool enabled)
        {
            if (available && enabled)
            {
                item.UseItemStyleForSubItems = false;
                item.ForeColor = ListView.ForeColor;
                item.Font = (Settings.CurrentMode != View.Tile) ? FontDetailsNameItem : null;
                item.ImageKey = GetServiceLogoImageKey(service, false);
            }
            else
            {
                item.UseItemStyleForSubItems = (Settings.CurrentMode == View.Details);
                item.ForeColor = SystemColors.GrayText;
                item.Font = available? FontNormalDisabled : FontNormalNotAvailable;
                item.ImageKey = GetServiceLogoImageKey(service, true);
            } // if-else
        } // EnableListItem

        private string GetServiceLogoImageKey(UiBroadcastService service, bool disabled)
        {
            var logo = service.Logo;
            if (SmallImageList.Images.ContainsKey(logo.Key))
            {
                return disabled ? "<Disabled> " + logo.Key : logo.Key;
            } // if

            var key = logo.Key;
            var disabledKey = "<Disabled> " + key;

            // load small logo and add it to small image list
            using (var image = logo.GetImage(SmallLogoSize, true))
            {
                SmallImageList.Images.Add(logo.Key, image);
                using (var disabledImage = PictureBoxEx.ToGrayscale(image))
                {
                    SmallImageList.Images.Add(disabledKey, disabledImage);
                } // using image
            } // using image

            // load large logo and add it to large image list
            using (var image = logo.GetImage(LargeLogoSize, true))
            {
                LargeImageList.Images.Add(logo.Key, image);
                using (var disabledImage = PictureBoxEx.ToGrayscale(image))
                {
                    LargeImageList.Images.Add(disabledKey, disabledImage);
                } // using image
            } // using image

            return disabled ? disabledKey : key;
        } // GetChannelLogoKey

        #endregion
    } // UiBroadcastListViewManager
} // namespace