import {JetView} from "webix-jet";
import { ExportSummary } from "./export-summary";

export class ExportWindow extends JetView  {

    config(){
        
        return {
            view:"window",
            type:"space",
			position:"center",
			modal:true,
			width: 1100,
            height: 800,
            move: true,            
            //css: "view-task-window",
			head: {
				view:"toolbar", 
				cols:[                    
                    { 
                        view:"icon", icon:"mdi mdi-close-circle",
                        align: 'right',
                        css: "close-icon", 
                        tooltip: "close",
                        click:function(){ this.getTopParentView().hide()} 
                    }]
              },              
			body:{
                scroll :true,           
                rows : [{
                    scroll :true,                                    
                    $subview: ExportSummary
                }]
			}
        };
    }

    init(){

    }
    
    showWindow(item){
        this.getRoot().show();    
    }

    getBack(){
		this.getRoot().hide();
	}
	
	
}
