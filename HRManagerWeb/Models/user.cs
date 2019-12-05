namespace HRManagerWeb.Models
{
    using Newtonsoft.Json;
    using HRManagerWeb.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {

        }



        public long id { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(MicrosecondEpochConverter))]

        public DateTime created { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime updated { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Column(TypeName = "bit")]
        public bool? isActive { get; set; }
        [Required]
        [Display(Name = "Username")]
        [StringLength(255)]
        public string login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public String role { get; set; }
        public int workTime { get; set; }
        public int salary { get; set; }

    }

    internal class MicrosecondEpochConverter : Newtonsoft.Json.JsonConverter
    {

        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
