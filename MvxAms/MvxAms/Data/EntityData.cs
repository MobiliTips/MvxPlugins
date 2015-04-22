using System;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    public abstract class EntityData : ITableData
    {
        public string Id { get; set; }
        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }
        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
        [Version]
        public string Version { get; set; }
        [Deleted]
        public bool Deleted { get; set; }
    }
}
