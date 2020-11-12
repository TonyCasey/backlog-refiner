import {JetView} from "webix-jet";

import { addTicket } from "../services/ticket-service"

export default class NewTicketPopup extends JetView {
	config(){
		const _ = this.app.getService("locale")._;
		

		

		return {
			view:"window",
			position:"center",
			modal:true,
			width:700,
			  height: 500,
			  move: true,
			head: {
				view:"toolbar", 
				cols:[
					{ view: "label", label: "New"},
					{ 
				  view:"button", label: 'x', 
				  inputWidth: 20, align: 'right', 
				  click:function(){ this.getTopParentView().hide()} 
				}]
			  },
			body:{

				view:"form",
				localId:"newTicketForm",
				scroll:true,
				rules:{
					description: webix.rules.isNotEmpty
				}, 
				elementsConfig:{
					bottomPadding: 18
				},             
					elements:[

						{ id: 'summary', name: "summary", view:"textarea", placeholder : "title", height: 50, invalidMessage: "cannot be empty", required: true},
						
						{ id:'description', name:"description",  view:"tinymce-editor", height: 300, invalidMessage:"Can not be empty"}

						// { view: "label", label: "Questions"},
						// { cols:[
						// 	{ view:"text", placeholder: "question", width :400 },
						// 	{ view:"richselect", placeholder: "to", name:"user", options:persons },
						// 	{
						// 		cols:[
						// 			{
						// 				view:"button", label: '+ Add', 
						// 				inputWidth: 60, align: 'left',
						// 				click:() => this.addQuestion()
						// 			}
						// 		]
						// 	}
						// 	]
						// },
						


						// { view: "label", label: "Acceptance Checklist"},
						// { cols:[
						// 	{ view:"text", placeholder: "criteria", width :400 },
						// 		{
						// 			view:"button", label: '+ Add', 
						// 			inputWidth: 60, align: 'left'
						// 			//click:() => this.addQuestion()
						// 		}
						// 	]
						// },


						// { view: "label", label: "Test steps"},
						// { cols:[
						// 	{ view:"text", placeholder: "How to test", width :400 },
						// 		{
						// 			view:"button", label: '+ Add', 
						// 			inputWidth: 60, align: 'left'
						// 			//click:() => this.addQuestion()
						// 		}
						// 	]
						// },

						
						,
						{
							cols:[
								{
									view:"button", value:"Cancel", width : 150, align: "left",
									click:() => this.getBack()
								},
								{},
								{
									view:"button", value:"Add", type:"form", width : 150, align: "right",
									click:() => this.saveTicket()
								}
							]
						},
						
					]
			}
			
		};
	}
	showWindow(){
		this.getRoot().show();
	}
	getBack(){
		this.getRoot().hide();
		this.$$("newTicketForm").clear();
		this.$$("newTicketForm").clearValidation();
	}
	saveTicket(){

			

		if (this.$$("newTicketForm").validate()){
			

			const ticket = this.$$("newTicketForm").getValues();
			ticket.statusGuid = "0ad8d818-cea5-4401-a851-614f37133ed1"
			ticket.boardGuid = webix.storage.local.get("backlog_refiner_board").guid;

			addTicket(ticket, (x) => {
				var newTicket = JSON.parse(x);
				newTicket.Id = newTicket.guid;
				this.app.callEvent("ticket:added",[newTicket]);
				webix.message({type:"success", text: "Ticket created"});
			})

			this.getBack();
		}
		else{
			webix.message({ type:"debug", text:"Form data is invalid" });
		}
	}
	
}
