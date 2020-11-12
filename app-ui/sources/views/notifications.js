import {JetView} from "webix-jet";

import { newNotification } from "models/newnotifications";
import { searchNotifications, updateNotificationSynchronous, updateNotification } from "../services/notification-service"

export default class NotificationPopup extends JetView {


	config(){
		const _ = this.app.getService("locale")._;

		var notifications = [];

		return {
			view:"popup",
			body:{
				view:"list",
				localId:"notifications-list",
				borderless:true,
				css:"notifications",
				width:450,
				template:obj => {
					return "<span class='m_title'>" + obj.title + "</span>" +
						"<span class='message'>" + obj.body + "</span>";
				},
				type:{
					height:"auto"
				}
			},
			on:{
				onHide:() => {
					const list = this.$$("notifications-list");
					// list.clearAll();
					// list.showOverlay(`<div style='margin:20px; font-size:14px;'>${_("No new notifications")}</div>`);
					// list.define({ height:80 });
        			// list.resize();
					this.app.callEvent("notifications:list-expanded");
				}
			}
		};
	}

	init(){

		this.loadData();

		const list = this.$$("notifications-list");

		webix.extend(list,webix.OverlayBox);

		this.attachEvents();

		this.eventListeners();
		
	}

	attachEvents(){

		// check timer
		setInterval(() => {
			if (this.app){
				this.loadData();
			}
		},1000 * 60 * 5);


		this.$$("notifications-list").attachEvent("onItemClick", function(id, e, node){

            var item = this.getItem(id);                 
			this.$scope.app.callEvent("notification:click", [item]); 
			this.remove(id);
			this.resize();
			this.hide();

			var groupedTicketNotifications = this.$scope.notifications.filter(x => x.ticketGuid == item.ticketGuid );
			
			var index = 0;
			groupedTicketNotifications.forEach(notification => {
				
				notification.statusId = 3;
				notification.clickDate = new Date().toUTCString();
				notification.boardGuid = webix.storage.local.get("backlog_refiner_board").guid;				
				++index

				if(index == groupedTicketNotifications.length) // if last one, reload 
				{
					updateNotificationSynchronous(notification, this.$scope.loadData());
				} else {
					updateNotificationSynchronous(notification);
				}
				

			})		
			

		});


		
		
		
	}

	showWindow(pos){
		this.getRoot().show(pos);
	}

	loadData(){

		const list = this.$$("notifications-list");
		list.clearAll();
		list.resize();

		searchNotifications({
			boardGuid: webix.storage.local.get("backlog_refiner_board").guid
		}, (notifications) => {
			
			this.notifications = JSON.parse( notifications ).data;

			// group all notifcations for ech ticket
			var grouped = this.groupBy( JSON.parse(notifications).data, x => x.ticketGuid);

			var parsedNotifications = [];

			grouped.forEach(group => {				

				parsedNotifications.push(group[0])

			})

			list.parse(parsedNotifications);
			
			this.app.callEvent("notifications:loaded", [parsedNotifications]);
			list.resize();
		})
	}

	eventListeners(){

		const list = this.$$("notifications-list");

		this.on(this.app,"new:notification",() => {
			list.hideOverlay();
			list.add(newNotification(),0);
			list.define({ height:list.count()*84 });
        	list.resize();
		});

		this.on(this.app,"notifications:list-expanded",() => {
			
			// list.data.forEach(notification => {
				
			// });

		});

		this.on(this.app,"ticket:select", ticket => {
			
			// mark any notifications as read
			const list = this.$$("notifications-list");
			list.clearAll();
			list.resize();

			searchNotifications({
				ticketGuid: ticket.guid,
				userGuid : webix.storage.local.get("backlog_refiner_user").id
			}, (notifications) => {
				
				
				JSON.parse( notifications ).data.forEach( notification => {				

					notification.statusId = 3;
					notification.clickDate = new Date().toUTCString();
					notification.boardGuid = webix.storage.local.get("backlog_refiner_board").guid;	
					updateNotificationSynchronous(notification);
					
				})

				this.loadData();
			})

		});
		

		
	}

	groupBy(list, keyGetter) {
		const map = new Map();
		list.forEach((item) => {
			const key = keyGetter(item);
			const collection = map.get(key);
			if (!collection) {
				map.set(key, [item]);
			} else {
				collection.push(item);
			}
		});
		return map;
	}
}
