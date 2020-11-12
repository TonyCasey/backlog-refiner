
import {JetView} from "webix-jet";
import TaskListView from "./task-list"
import TaskFormView from "./task-form"

export default class TaskAccordionView extends JetView {

    config(){

        return  {
            id: "taskAccordion",
            view: "accordion",
            cols : [ 
                TaskListView,
                {
                    collapsed : false, 
						header:"<span title='add Sub Task'>add a Task</span>",				
						body:{
							$subview : TaskFormView
						}
                    }  
                ]
        }

    }

    init(){
        this.eventListeners();
    }
    
    eventListeners(){

        this.on(this.app,"task-list:loaded", (tasks) => {		
            
            // if (tasks.length > 0){
            //     $$("taskAccordion").getChildViews()[1].collapse();
            // }
            
        });
    }

}
