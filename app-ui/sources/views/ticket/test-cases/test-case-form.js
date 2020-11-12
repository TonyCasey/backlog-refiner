
import {JetView} from "webix-jet";
import { addTestCase } from "../../../services/test-case-service"

export default class TestCaseFormView extends JetView {

    config(){

		var ticket = null;  

        return {
            view:"form",
			localId:"addTestCaseForm",
			scroll: true, 
                elements:[
                    
                        { 
							id: 'title', 
							name: "title", 
							view:"textarea", 
							placeholder : "title", 
							height: 60, 
							invalidMessage: "cannot be empty",
							required: true
						 },
						 { 
							id: 'description', 
							name: "description", 
							view:"textarea", 
							placeholder : "description", 
							height: 60, 
							invalidMessage: "cannot be empty",
							required: true
						 },
						 { 
							id: 'steps', 
							name: "steps", 
							view:"textarea", 
							placeholder : "steps", 
							height: 60, 
							invalidMessage: "cannot be empty",
							required: true
						 },
						 { 
							id: 'expectedResults', 
							name: "expectedResults", 
							view:"textarea", 
							placeholder : "expected results", 
							height: 60, 
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

		if(!this.$$("addTestCaseForm").validate()){
			webix.message({ type:"debug", text:"Form data is invalid" });
			return;
		}

		var formValues = this.$$("addTestCaseForm").getValues();

		var request = {			
			ticketGuid : this.ticket.guid,
			boardGuid : this.ticket.boardGuid,
			title: formValues.title,
			description: formValues.description,
			steps: formValues.steps,
			expectedResults: formValues.expectedResults,
		}
		
		addTestCase(request, (x) => {

			var testCase = JSON.parse(x);
			
			this.app.callEvent("test-case:created", [testCase]);
			this.$$("addTestCaseForm").reconstruct();
			webix.message({type:"success", text: "Test Case added"});

		})

	}

}