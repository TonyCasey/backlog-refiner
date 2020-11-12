using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Data;
using Notifications.Data.Entities;

namespace Notifications.Business.Extensions
{
    public static class NotificationExtensions
    {
        public static IQueryable<Notification> NotDeleted(this IQueryable<Notification> notifications)
        {
            return notifications.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Notification> ForCompany(this IQueryable<Notification> notifications, Guid questionGuid)
        {

            if (questionGuid == Guid.Empty)
                return notifications;

            return notifications.Where(x => x.CompanyGuid == questionGuid);
        }


        public static IQueryable<Notification> ForUser(this IQueryable<Notification> notifications, Guid? guid)
        {

            if (guid == null)
                return notifications;

            return notifications.Where(x => x.UserGuid == guid);
        }

        public static IQueryable<Notification> ForTicket(this IQueryable<Notification> notifications, Guid? ticketGuid)
        {

            if (ticketGuid == null)
                return notifications;

            return notifications.Where(x => x.TicketGuid == ticketGuid);
        }

        public static IQueryable<Notification> ForQuestion(this IQueryable<Notification> notifications, Guid? questionGuid)
        {

            if (questionGuid == null || questionGuid == Guid.Empty)
                return notifications;

            return notifications.Where(x => x.QuestionGuid == questionGuid);
        }

        public static IQueryable<Notification> ForStatus(this IQueryable<Notification> notifications, Enumerations.StatusEnum statusId)
        {
            if (statusId == 0)
            {
                notifications = notifications.Where(x => x.StatusId == Enumerations.StatusEnum.Unread || x.StatusId == Enumerations.StatusEnum.Seen);
                return notifications;
            }


            return notifications.Where(x => x.StatusId == statusId);
        }

        public static IQueryable<Notification> ForBoard(this IQueryable<Notification> notifications, Guid? guid)
        {

            if (guid == null)
                return notifications;

            return notifications.Where(x => x.BoardGuid == guid);
        }
    }
}
