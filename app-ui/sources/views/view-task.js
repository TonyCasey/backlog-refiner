import {JetView} from "webix-jet";
import { TestView } from "./test"
export class ViewTaskPopup extends JetView  {



    config(){
        
        return {
            view:"window",
			position:"center",
			modal:true,
			width:700,
      		height: 600,
			head: {
				view:"toolbar", 
				cols:[
					{ view: "label", label: "View"},
                    { 
                        view:"button", label: 'x', 
                        inputWidth: 20, align: 'right', 
                        click:function(){ this.getTopParentView().hide()} 
                    }]
			  },
			body:{
                rows : [
					{ template: "Hello"},
					{ id: "row2", template: `<div>
					Task 2 with a lot of data how will this look, will it wrap?, 
					
					Task 2 with a lot of data how will this look, will it wrap? , 
					
					Task 2 with a lot of data how will this look, will it wrap? , 
					
					Task 2 with a lot of data how will this look, will it wrap?  </div>` },
					{ TestView }
				]
			}
        };
    }


    showWindow(item){
        // this.item = item;
        // $$("view-who").define("template", item.text)
		// $$("view-who").refresh();

		// $$("viewForm").elements.what.setValue(`Task 2 with a lot of data how will this look, will it wrap?, 
			
		// Task 2 with a lot of data how will this look, will it wrap? , 
		
		// Task 2 with a lot of data how will this look, will it wrap? , 
		
		// Task 2 with a lot of data how will this look, will it wrap? `);
		
		//$$("row2").setHtml("Yo");

        // $$("viewForm").parse(item);
        this.getRoot().show();    
    }
    getBack(){
		this.getRoot().hide();
		this.$$("viewForm").clear();
		this.$$("viewForm").clearValidation();
	}
	saveTask(){
		const task = this.$$("viewForm").getValues();
		if (this.$$("viewForm").validate()){
			this.app.callEvent("add:task",[task]);
			this.getBack();
		}
		else{
			webix.message({ type:"error", text:"Form data is invalid" });
		}
	}

	init(){

	}
}

	
    
