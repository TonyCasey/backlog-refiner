import {JetView} from "webix-jet";

import QuestionsView from "../questions/questions";
import TicketDescriptionView from "./ticket-description";
import BddAccordionView from "../bdd/bdd-accordion";
import TaskAccordionView from "../tasks/task-accordion";
import TestCaseAccordionView from "../test-cases/test-case-accordion"
export class ViewTicketSummary extends JetView  {

	
    config(){

		return {
			view:"accordion", 
			width: 1200,
			rows: [
				
				{ cols:[
					{ 
						type:"space",
							rows: [
								 {
									height: 300, 
									cols: [TicketDescriptionView]
								 },
								 { view:"resizer" },
								{
									id: "tabview",
									view:"tabview",
									animate:false,
									cells: [
										{
											id: "behaviours",
											header:"Behaviours",
											type: "clean",
											rows :[
												{
													$subview: BddAccordionView
												}
											]
										},
										{
											id: "subTasks",
											header:"Tasks",
											rows: [
												{
													$subview : TaskAccordionView
												}
											]
										},
										{
											id: "testCases",
											header:"Test Cases",
											rows: [
												{
													$subview : TestCaseAccordionView
												}
											]
										}
									]
								}
							]
						
					},
					// { view:"resizer" },
					// { 
					// 	type:"space",
					// 	collapsed:true, 
					// 	header:"Comments",						
					// 	body:{
					// 		$subview : QuestionsView
					// 	},
					// 	width:400,
						
					// },
				]}
			]
		}


		
	}
	

	init(){

		this.eventListeners();
		
	}
	

	eventListeners(){


		this.on(this.app,"ticket:select", ticket => {			
			
			this.$$("tabview").setValue("behaviours");

			//this.$$("tabview").setValue("subtasks");

			// switch(ticket.status){
			// 	case "0ad8d818-cea5-4401-a851-614f37133ed9" : // dev
			// 		this.$$("tabview").setValue("subtasks");
			// 	break;
			// 	case "0ad8d818-cea5-4401-a851-614f37133ed2" : // qa
			// 		this.$$("tabview").setValue("behaviours");
			// 	break
			// }
                       

        });
	}
	
}
