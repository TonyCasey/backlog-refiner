
import {JetView} from "webix-jet";
import { addTask } from "../../../services/tasks-service"

export default class TaskFormView extends JetView {

    config(){

		var ticket = null;  

        return {
            view:"form",
            localId:"addTaskForm",
                elements:[
                    
                        { 
							id: 'body', 
							name: "body", 
							view:"textarea", 
							placeholder : "description", 
							height: 100, 
							invalidMessage: "cannot be empty",
							required: true
						 },
                        {
							cols:[
								{
									//view:"button", value:_("Cancel"), width : 150, align: "left",
									//click:() => this.getBack()
								},
								{},
								{
									view:"button", value:"Add", type:"form", width : 150, align: "right",
									click:() => this.saveForm()
								}
							]
						},                   
                    
                ]
        }
	}

	init(){
		this.eventListeners();
	}
	
	eventListeners(){

		this.on(this.app,"ticket:select", ticket => {			
            this.ticket = ticket;
        });
	}

	saveForm(){

		if(!this.$$("addTaskForm").validate()){
			webix.message({ type:"debug", text:"Form data is invalid" });
			return;
		}

		var formValues = this.$$("addTaskForm").getValues();

		var taskRequest = {
			body: formValues.body,
			ticketGuid : this.ticket.guid,
			boardGuid : this.ticket.boardGuid
		}
		
		addTask(taskRequest, (x) => {

			var task = JSON.parse(x);
			
			this.app.callEvent("task:created", [task]);
			this.$$("addTaskForm").reconstruct();
			webix.message({type:"success", text: "Task added"});

		})

	}

}