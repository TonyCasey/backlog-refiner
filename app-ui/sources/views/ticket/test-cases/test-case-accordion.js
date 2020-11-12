
import {JetView} from "webix-jet";
import TestCaseListView from "./test-case-list"
import TestCaseFormView from "./test-case-form"

export default class TestCaseAccordionView extends JetView {

    config(){

        return  {
            id: "testCaseAccordion",
            view: "accordion",
            cols : [ 
                TestCaseListView,
                {
                    collapsed : false, 
						header:"<span title='add Test Case'>add a Test Case</span>",				
						body:{
							$subview : TestCaseFormView
						}
                    }  
                ]
        }

    }

    init(){
        this.eventListeners();
    }
    
    eventListeners(){

        this.on(this.app,"test-case-list:loaded", (testCases) => {		
            
            // if (tasks.length > 0){
            //     $$("taskAccordion").getChildViews()[1].collapse();
            // }
            
        });
    }

}
