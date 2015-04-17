using MobiliTips.MvxPlugins.MvxAms.Data;
using MvxAms.Sample.Model.Enums;

namespace MvxAms.Sample.Model
{
    public class Place : EntityData
    {
        public string Name { get; set; }
        public PlaceType Type { get; set; }
        public double? Score { get; set; }
    }
}
