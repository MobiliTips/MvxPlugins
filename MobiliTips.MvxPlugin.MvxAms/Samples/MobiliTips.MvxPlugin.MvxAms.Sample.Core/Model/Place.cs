using System;
using Microsoft.WindowsAzure.MobileServices;
using Motip.Resources.Model;

namespace MobiliTips.MvxPlugin.MvxAms.Sample.Core.Model
{
    public class Place : PlaceData, ITableData
    {
        #region System
        public string Id { get; set; }
        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }
        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
        [Version]
        public string Version { get; set; }
        [Deleted]
        public bool Deleted { get; set; }
        #endregion
    }
}
