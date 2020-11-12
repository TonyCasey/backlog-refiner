import {JetView} from "webix-jet";
import NotificationPopup from "views/notifications";
import SettingsPopup from "views/settings";
import NewTicketPopup from "views/newticket";
import { getUrl } from "../environments"

export default class ToolbarView extends JetView {
	config(){
		const _ = this.app.getService("locale")._;
		const theme = this.app.config.theme;
		

		return {
			view:"toolbar",
			css:theme,
			height:56,
			elements:[
				//  { cols: [logout] },
				{
					paddingY:5,
					rows:[
						{
							margin:8,
							cols:[
								{
									view:"label",
									template:_("Backlog Refiner"),
									width:175,
									css:"main_label",
									batch:"default"
								},
								{ 
									view:"button",
									type:"form",
									label:_("Add a ticket"),
									autowidth:true,
									inputHeight:40,
									batch:"default",
									click:() => this.newticket.showWindow()
								},
								{ batch:"default" },
								{
									localId:"search",
									margin:0,
									batch:"search",
									hidden:true,
									cols:[
										{ width:11 },
										{
											view:"text", localId:"lookup",
											placeholder:"Type in to look for a task",
											on:{
												onKeyPress(code){
													const lookup = this.getValue();
													if (lookup && code === 13){
														const nav_btn = this.$scope.$$("favs");
														if (nav_btn.config.icon.indexOf("check") !== -1){
															nav_btn.config.icon = "mdi mdi-view-dashboard";
															nav_btn.config.tooltip = "Go back to the kanban";
															nav_btn.refresh();
														}
														this.$scope.show("projects?lookup="+lookup);
													}
												}
											}
										},
										{
											view:"icon", icon:"mdi mdi-close",
											click:() => this.toggleBatches("default","search")
										}
									]
								},
								// {
								// 	view:"icon", icon:"mdi mdi-magnify",
								// 	tooltip:_("Click to search a task"),
								// 	click:() => {
								// 		const lookup = this.$$("lookup");
								// 		const lookuptext = this.$$("lookup").getValue();
								// 		if (!this.$$("search").isVisible())
								// 			this.toggleBatches("search","default");
								// 		else if (lookup)
								// 			this.show("projects?lookup="+lookuptext);
								// 		lookup.focus();
								// 	}
								// },
								// {
								// 	view:"icon", icon:"mdi mdi-bookmark-check",
								// 	tooltip:_("Open the list of all tasks"),
								// 	localId:"favs", batch:"default",
								// 	click:function(){
								// 		if (this.config.icon.indexOf("check") !== -1)
								// 			this.$scope.show("projects");
								// 		else
								// 			this.$scope.show("kanban");
								// 	}
								// },
								{
									view:"icon",
									icon:"mdi mdi-bell",
									// badge:3,
									batch:"default",
									localId:"bell",
									tooltip:_("View the latest notifications"),
									click:function(){
										this.$scope.notifications.showWindow(this.$view);
									}
								}
							]
						}
					]
				},
				{
					template:`<image class="mainphoto" src="data/photos/avatar.png" title="settings & log out">`,
					width:60,
					borderless:true,
					batch:"default",
					onClick:{
						"mainphoto":function(){
							this.$scope.settings.showWindow(this.$view);
							return false;
						}
					}
				},
				{ width:4 }
			]
		};
	}
	init(){
		
		this.eventListeners();

		this.notifications = this.ui(NotificationPopup);
		this.settings = this.ui(SettingsPopup);
		this.newticket = this.ui(NewTicketPopup);
		
		//this.newticket.showWindow();

		
		
	}
	// urlChange(ui,url){
	// 	const _ = this.app.getService("locale")._;
	// 	let nav_btn = this.$$("favs");
	// 	if (url[1].page === "projects"){
	// 		nav_btn.config.icon = "mdi mdi-view-dashboard";
	// 		nav_btn.config.tooltip = _("Go back to the kanban");
	// 	}
	// 	else if (url[1].page === "kanban"){
	// 		nav_btn.config.icon = "mdi mdi-bookmark-check";
	// 		nav_btn.config.tooltip = _("Open the list of all tasks");
	// 	}
	// 	nav_btn.refresh();
	// }
	// toggleBatches(a,b){
	// 	const s_btns = this.getRoot().queryView({ batch:a },"all");
	// 	for (let i = 0; i < s_btns.length; i++)
	// 		s_btns[i].show();
	// 	const h_btns = this.getRoot().queryView({ batch:b },"all");
	// 	for (let i = 0; i < h_btns.length; i++)
	// 		h_btns[i].hide();
	// }

	eventListeners(){

		// this.on(this.app,"read:notifications",() => {
		// 	this.$$("bell").config.badge = 0;
		// 	this.$$("bell").refresh();

		// 	setTimeout(() => {
		// 		if (this.app){
		// 			this.$$("bell").config.badge += 1;
		// 			this.$$("bell").refresh();
		// 			this.app.callEvent("new:notification");
		// 		}
		// 	},10000);
		// });

		this.on(this.app,"notifications:loaded",(notifications) => {
			
			// var notifications = JSON.parse(notifications).data;
			
			this.$$("bell").config.badge = notifications.length;
			this.$$("bell").refresh();

		});

	}
}
