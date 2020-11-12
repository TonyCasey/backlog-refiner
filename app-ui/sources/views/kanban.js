import "../plugins/kanban.css";
import { kanban } from "../plugins/kanban";
import {JetView} from "webix-jet";
import { TicketWindow } from "./ticket/ticket-summary/ticket-window";
import { getTeams } from "../services/team-service";
import { getBoards } from "../services/board-service";
import { getTickets, deleteTicket, updateTicket } from "../services/ticket-service";
import { searchTeamUsers } from "../services/team-user-service";
import { addNotification } from "../services/notification-service";
import { searchTicketMembers } from "../services/ticket-member-service"
import { addEmail } from "../services/email-service";

export default class KanbanView extends JetView {
		
	

	config(){
	
		var tickets = [];

		webix.type(webix.ui.kanbanlist,{
			name: "cards",
			icons:[
				{
					id: "comments",
					tooltip: "Comments",
					icon:"mdi mdi-comment",
					show: function(obj){ 
						return !!obj.comments 
					},
					template:"#comments.length#",
				},
				{
					id: "questions",
					tooltip: "Questions",
					icon:"mdi mdi-help",
					show: function(obj){ 
						return !!obj.questions 
					},
					template:"#questions.length#",
				},
				{
					id: "votes",
					tooltip: "Votes",
					icon:"mdi mdi-vote",
					show: function(obj){ 
						return !!obj.votes 
					},
					template:"#votes#",
				}
			],
			// displays images and text property in item content
			templateBody: function(obj,common){
				var html = "";
				if(obj.image)
					html += "<img class='image' src='../common/imgs/"+obj.image+"'/>";
				html += "<div><strong>" ; 
				html += obj.summary.substr(0, 100 );
				if(obj.summary.length > 100)
					html+="..."
				html += "</strong></div>";
				
				html += obj.creationTime
				return html;
			},
		});
		

		const _ = this.app.getService("locale")._;
		const teamUsers = searchTeamUsers( { teamGuid: webix.storage.local.get("backlog_refiner_board").teamGuid });
		//const projects = getProjects();
		// var win =   WindowView;

		return {
            rows :[
                {
					css: "toolbar",
					borderless: true,
					paddingY:7,
					paddingX:10,
					margin: 7,
					cols:[
						{
							view:"combo", 
							id: "filterBy",
							name: "filterBy",
							label:_("Assignee"), 
							options:{
								data: teamUsers,
								body:{
									template:"#firstName# #lastName#"           
								}
							},							
							width: 300
						}
					]
				},
                {
                    view:"kanban",
                    id: "myBoard",
					type: "wide",
            		cardActions: true,
					// cardActions:[
					// 	"edit", "copy", "remove", "complete"
					// ],
                    on:{
						onListAfterDrop: this.onAfterDrop,
						onListBeforeContextMenu: this.showMenu,
						onListItemClick: (id,e,node,list)=>{ 
							this.viewticket.showWindow(list.data.find(x=>x.id == id));
							this.app.callEvent("ticket:select",list.data.find(x=>x.id == id));
						}
					},
                    cols:[
                        { header:"To do",
                            body:{ view:"kanbanlist", status:"0ad8d818-cea5-4401-a851-614f37133ed1", type: "cards"}},
                        { header:"Dev",
                            body:{ view:"kanbanlist", status:"0ad8d818-cea5-4401-a851-614f37133ed9", type: "cards"}
                        },
                        { header:"QA",
                            body:{ view:"kanbanlist", status:"0ad8d818-cea5-4401-a851-614f37133ed2", type: "cards"}},
                        { header:"Ready",
                            body:{ view:"kanbanlist", status:"0ad8d818-cea5-4401-a851-614f37133ed3", type: "cards"}}
                    ],
					 //data:tickets
					scheme:{                                                                              
						$init:function(obj){
							var format = webix.Date.dateToStr("%d %M %y, %H:%i");
							obj.creationTime =  format( obj.creationTime.replace("T", " "));
							//obj.status = obj.statusGuid
							obj.id = obj.guid;
						}
					}
                },
                
        ]
				
	}
		
	}

	
	init(view){
		
		 this.viewticket = this.ui(TicketWindow);

		//this.viewticket.showWindow(null);

		this.eventListeners();
		this.loadData();		
		this.getContextMenu();
	}

	eventListeners(){

		this.on(this.app, "kanban:list-loaded", () => {			
			
			// just to speed up development, remove for production
			// $$("myBoard").select($$("myBoard").getFirstId());
			// var firstItem = $$("myBoard").find(x => x.id == "e22b8d3c-5f9b-4cd8-b419-872924c6c8b0"); //$$("myBoard").getFirstId());
			// this.app.callEvent("ticket:select", firstItem);                     
			// this.viewticket.showWindow(firstItem);
			var url = this.app.$router.get();
			var queryString = this.getJsonFromUrl(url);

			if(queryString != null && queryString.ticketGuid !== undefined && queryString.ticketGuid !== ""){
				
				var queryStringTicket = $$("myBoard").find(x => x.id == queryString.ticketGuid );
				this.app.callEvent("ticket:select", queryStringTicket);                     
				this.viewticket.showWindow(queryStringTicket);
			}

		});		

		this.on(this.app, "ticket:added", (ticket) => {			
			
			var id = $$("myBoard").add(ticket);			
			$$("myBoard").select(id);

		});

		this.on(this.app, "ticket:moved", (ticket) => {			
			
			searchTicketMembers({ ticketGuid: ticket.guid }, (x) => {

                var members = JSON.parse(x).data;
                
                if(members.length > 0){					
					
                    members.forEach(x => {                    

						
						// do not notify this user
						if( x.userGuid.toLowerCase() != webix.storage.local.get("backlog_refiner_user").id.toLowerCase()){

							// TODO: get the team member record and then get the userGuid from that 

							var notification = {
								ticketGuid : ticket.guid,
								boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
								title : "Status change",
								Body: `The ticket "${ticket.summary}" has been updated.`,
								StatusId : 2,
								userGuid : x.userGuid
							}

							addNotification(notification, (y) => {

								// send email
								var email = 
									{
										ticketGuid : ticket.guid,
										boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
										ToUserGuid : notification.userGuid,
										SendGridTemplate : 2
									}
								
									addEmail(email);
								
							});
						}

                    })
                }
                
            });

			

		});

		this.on(this.app, "notification:click", (notification) => {		
			
			$$("myBoard").select(notification.ticketGuid);
			var item = $$("myBoard").find(x=>x.id == notification.ticketGuid);
			this.app.callEvent("ticket:select", item);                     
			this.viewticket.showWindow(item);
			
		});

		
	}

	loadData(){

		// A series of nested ajax queries, with each next function executing as a callback.
		
		// get teams first
		getTeams( (x) => {

			var teams = JSON.parse(x).data;

			if(teams != null && teams.length > 0){
			
			// taking the first team, will need to change
			var selectedTeam = teams[0];
			
			
			// get the boards for that team
			getBoards(selectedTeam.guid, (y) => {

				var boards = JSON.parse(y).data;

				if(boards != null && boards.length > 0){

					// taking the first board, will need to change
					var selectedBoard = boards[0];

					webix.storage.local.put("backlog_refiner_board", selectedBoard);
					
					// get the tickets for that board
					getTickets(selectedBoard.guid, (z) =>{ 

						var tickets = JSON.parse(z).data;
						tickets.forEach(ticket => {
							ticket.id = ticket.guid;
						});

						// attach to board
						$$("myBoard").parse( tickets )
						this.app.callEvent("kanban:list-loaded");
						
					});
	
					
				}

			});

			
		}

		});

	}
  
    
    
   
    
        
	onAfterDrop(dragContext,e,list){

		// item id
		var item = this.getItem(dragContext.start);

		// if we move an item from one list to another
		if(dragContext.from != dragContext.to){

			var status = dragContext.to.config.status;
			item.statusGuid = status;

			updateTicket(item, () => {				
				list.getParentView().$scope.app.callEvent("ticket:moved", [item]);
			})

			// show a message with new status and order
			//webix.message("Item '"+item.id+"' was moved into '"+status+"' column to the "+item.$index +" position");
		}
		else{
			//webix.message("Item '"+item.id+"' was moved to the "+item.$index +" position");
		}
	}
	
	onClick(){

		// return webix.show(ViewTaskPopup);
		// getRoot().viewtask.showWindow()
		// this.getTopParentView().viewtask.showWindow();
		// $$("viewTaskform").show();
		// webix.ui(ViewTaskPopup).showWindow(); 
		// webix.message("Hello");

		// webix.ui(this.viewtask);
		
		// win.showWindow();

		// webix.ui({
		// 	win
		// }).show();
	}


	menuClick(id){
		
		var menu = this.getMenu(id);
		webix.message(menu.getItem(id).id);
	}

	getContextMenu(){
		webix.ui({
			view:"contextmenu",
			id: "kanbancmenu",
			data:["<i class='mdi mdi-trash-can-outline'></i> Delete"
				
				// { value: "Assign to ..."},
				// { value:"Modify", submenu:[
				// 	{id: "edit", value: "Edit"},
				// 	{id: "status", value: "Change Status"},
				// 	{id: "remove", value: "Remove"}
				// ]},
				// { value: "Add comment" }
			],
			on:{
				// onMenuItemClick: this.menuClick
				onMenuItemClick:function(id){
					var context = this.getContext();
					var list = context.obj;
					var listId = context.id;
					var ticket = list.getItem(listId);
					var userId = webix.storage.local.get("backlog_refiner_user").id;

					if(ticket.creationUserGuid.toLowerCase() != userId.toLowerCase() ){
						webix.message({type:"debug", text: "Unauthorized" });
						return;
					}

					deleteTicket(listId, () => {
						list.remove(listId);
						webix.message({type:"success", text: "Ticket removed" });
					})

					
					}
			}
		});
	}

	showMenu(id,e,node,list){

		// show context menu for list
		$$("kanbancmenu").attachTo(list);

		// block native context menu
		webix.html.preventEvent(e);
	}

	getJsonFromUrl(url) {
		var query = url.split("?")[1];
		var result = {};

		if(query){
		query.split("&").forEach(function(part) {
			var item = part.split("=");
			result[item[0]] = decodeURIComponent(item[1]);
		});
	}
		return result;
	}
}
