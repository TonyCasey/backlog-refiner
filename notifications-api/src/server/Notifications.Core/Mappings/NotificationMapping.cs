using AutoMapper;
using Notifications.Core.Models.DTO;
using Notifications.Data.Entities;

namespace Notifications.Core.Mappings
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<NotificationRequest, Notification>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                ;

            CreateMap<Notification, NotificationResponse>();
        }
    }
}
