import {JetView} from "webix-jet";
import {ViewTicketSummary} from "./ticket-summary";
import { ExportWindow } from "../export/export-window";

export class TicketWindow extends JetView  {

    config(){
        
        return {
            view:"window",
            type:"space",
			position:"center",
			modal:true,
			width: 1100,
            height: 800,
            scroll:true,
            move: true,            
            css: "view-task-window",
			head: {
				view:"toolbar", 
				cols:[
                    {
                        view:"icon", icon:"mdi mdi-export",
                        css: "export-icon",
                        align: 'left', 
                        tooltip: "export",
                        click:function(){  
                            this.$scope.exportTicket.showWindow();
                        } 
                    },
                    { 
                        view:"icon", icon:"mdi mdi-close-circle",
                        align: 'right',
                        css: "close-icon", 
                        tooltip: "close",
                        click:function(){ this.getTopParentView().hide()} 
                    }]
			  },
			body:{
                borderless:true, 
                rows: [
                    { $subview: ViewTicketSummary }
                ]
			}
        };
    }

    init(){

        this.exportTicket = this.ui(ExportWindow);
        this.eventListeners();
    }
    
    showWindow(item){
        this.getRoot().show();    
    }

    getBack(){
		this.getRoot().hide();
	}
	
	eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            
            //this.exportTicket.showWindow();

        });

    }
}
