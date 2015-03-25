using System;

namespace MobiliTips.MvxPlugin.MvxAms.Data
{
    public interface ITableData
    {
        // Summary:
        //     Gets or sets the date and time the entity was created.
        DateTimeOffset? CreatedAt { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the entity has been deleted.
        bool Deleted { get; set; }
        //
        // Summary:
        //     Gets or sets the unique ID for this entity.
        string Id { get; set; }
        //
        // Summary:
        //     Gets or sets the date and time the entity was last modified.
        DateTimeOffset? UpdatedAt { get; set; }
        //
        // Summary:
        //     Gets or sets the unique version identifier which is updated every time the
        //     entity is updated.
        string Version { get; set; }
    }
}
