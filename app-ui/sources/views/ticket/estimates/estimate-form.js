
import {JetView} from "webix-jet";

export default class EstimateForm extends JetView {

    config(){
        return {
            view:"form",
            localId:"addEstimateForm",
                elements:[
                    
                        { id: 'who', name: "who", view:"textarea", placeholder : "Estimate As a < type of user >", height: 50, invalidMessage: "cannot be empty" },
						{ id: 'what', name: "what", view:"textarea", placeholder : "I want < some goal > ", height: 50, invalidMessage: "cannot be empty" },
                        { id: 'why', name: "why", view:"textarea", placeholder : "so that < some reason >", height: 50, invalidMessage: "cannot be empty" },
                        {
							cols:[
								{
									//view:"button", value:_("Cancel"), width : 150, align: "left",
									//click:() => this.getBack()
								},
								{},
								{
									view:"button", value:"Add", type:"form", width : 150, align: "right",
									//click:() => this.saveTask()
								}
							]
						},                   
                    
                ]
        }
    }

}