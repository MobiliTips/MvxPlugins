using System;
using MobiliTips.MvxPlugins.MvxAms.Data;
using MvxAms.Sample.Model.Enums;

namespace MvxAms.Sample.Model
{
    public class User : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public GenderType Gender { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
