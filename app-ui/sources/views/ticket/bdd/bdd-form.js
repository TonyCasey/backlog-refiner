
import {JetView} from "webix-jet";
import { addScenario, addScenarioSynchronous } from "../../../services/bdd-scenario-service";
import { addConditionSynchronous } from "../../../services/bdd-condtions-service";
import { Transform } from "stream";

export default class BddForm extends JetView {

    config(){

		var ticket = null;   

        return {
            view:"form",
			localId:"addBddForm",
			scroll:true,
			css : "bdd-form",
                elements:[
                    
						{ 
							id: 'name', 
							name: "scenario_name", 
							view:"textarea", 
							placeholder : "title ..", 
							height: 50, 
							invalidMessage: "cannot be empty",
							required: true
						},
						{ 
							cols : [
								{
									id: "operator_1",
									name: "operator_1",
									view:"combo", 
									value:"Given", 
									options:["Given", "When", "Then", "And", "But"],
									width: 85
								},
								{  
									id: 'condtion_1', 
									name: "condition_1", 
									view:"textarea",  
									placeholder : "condition..", 
									height: 50, 
									invalidMessage: "cannot be empty",
									required: true
								 }
							]
						},
						{ 
							cols : [
								{
									id: "operator_2",
									name: "operator_2",
									view:"combo", 
									value:"When", 
									options:["Given", "When", "Then", "And", "But"],
									width: 85
								},
								{  
									id: 'condtion_2', 
									name: "condition_2", 
									view:"textarea",  
									placeholder : "condition..", 
									height: 50, 
									invalidMessage: "cannot be empty",
									required: true
								 }
							]
						},
						{ 
							cols : [
								{
									id: "operator_3",
									name: "operator_3",
									view:"combo", 
									value:"Then", 
									options:["Given", "When", "Then", "And", "But"],
									width: 85
								},
								{  
									id: 'condtion_3', 
									name: "condition_3", 
									view:"textarea",  
									placeholder : "condition..", 
									height: 50, 
									invalidMessage: "cannot be empty",
									required: true
								 }
							]
						},						
						{
							cols:[								
								{
								
									view:"button", type: "htmlbutton", css: "icon_back_btn", 
									label:'<span class="webix_icon fas fa-angle-left"></span>'+
										'<span class="text">+ add</span>', 
									inputWidth:100,
									click:() => this.addRow()
								},
								{},
								{}
							]
						},  
						{
							css:"bdd-form-save-row",
							cols:[
								{},
								{},
								{
									view:"button", value:"Save", type:"form", width : 150, align: "right",
									click:() => this.saveForm()
								}
							]
						}                  
                    
				],
				
        }
	}

	init(){

		this.eventListeners();
	}
	
	addRow(){

		var viewCount = this.$$("addBddForm").getChildViews().length;
		var index = viewCount - 2;

				
			this.$$("addBddForm").addView(
				{ 
					cols : [
						{
							name: "operator_" + index,
							view:"combo", 
							value:"Given", 
							options:["Given", "When", "Then", "And", "But"],
							width: 85
						},
						{  
							id: 'condtion_' + index, 
							name: "condition_" + index, 
							view:"textarea",  
							placeholder : "condition..", 
							height: 50, 
							invalidMessage: "cannot be empty"
						 }
					]
				},
				index
			) 
	}

	saveForm(){

		

		// console.log(this.$$('addBddForm').getValue("condtion-1"));
		

		if(!this.$$("addBddForm").validate()){
			webix.message({ type:"debug", text:"Form data is invalid" });
			return;
		}
		
		
		var formValues = this.$$("addBddForm").getValues();
		
		var scenarioRequest = {
			name : formValues.scenario_name,
			ticketGuid : this.ticket.guid
		}

		// get the first three that should be there by default
		var conditionRequests = [
			{
				ticketGuid : this.ticket.guid,
				OperatorId : formValues.operator_1,
				Body : formValues.condition_1
			},
			{
				ticketGuid : this.ticket.guid,
				OperatorId : formValues.operator_2,
				Body : formValues.condition_2
			},
			{
				ticketGuid : this.ticket.guid,
				OperatorId : formValues.operator_3,
				Body : formValues.condition_3
			}
		]

		var viewCount = this.$$("addBddForm").getChildViews().length;

		if(viewCount > 6){
			
			for(var i = 4; i <= viewCount-3; i++){

				if(formValues[`condition_${i}`]!=""){
					conditionRequests.push({
						ticketGuid : this.ticket.guid,
						operatorId : formValues[`operator_${i}`],
						body : formValues[`condition_${i}`]
					});
				}
			}
		}

		
		var scenario = JSON.parse(addScenarioSynchronous(scenarioRequest));
		scenario.conditions = [];

		conditionRequests.forEach(condition => {
			condition.scenarioGuid = scenario.guid;			
			addConditionSynchronous(condition);
			
			if(condition.operatorId === undefined)
				condition.operatorId = condition.OperatorId;
			if(condition.body === undefined)
				condition.body = condition.Body;

			scenario.conditions.push(condition);
		});	

		this.app.callEvent("sceanrio:created", [scenario]);
		this.$$("addBddForm").reconstruct();
		webix.message({type:"success", text: "Behaviour added"});
	}

	eventListeners(){

		this.on(this.app,"ticket:select", ticket => {			
            
            this.ticket = ticket;     
                       
        });
	}
	


}