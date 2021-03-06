// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Email.Business.AutoRrest.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class TeamUserResponse
    {
        /// <summary>
        /// Initializes a new instance of the TeamUserResponse class.
        /// </summary>
        public TeamUserResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TeamUserResponse class.
        /// </summary>
        public TeamUserResponse(System.Guid? guid = default(System.Guid?), System.Guid? userGuid = default(System.Guid?), System.Guid? teamGuid = default(System.Guid?), string firstName = default(string), string lastName = default(string), string avatar = default(string))
        {
            Guid = guid;
            UserGuid = userGuid;
            TeamGuid = teamGuid;
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "guid")]
        public System.Guid? Guid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userGuid")]
        public System.Guid? UserGuid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "teamGuid")]
        public System.Guid? TeamGuid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

    }
}
