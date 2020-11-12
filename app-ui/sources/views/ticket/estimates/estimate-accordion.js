
import {JetView} from "webix-jet";
import EstimateListView from "./estimate-list"
import EstimateFormView from "./estimate-form"

export default class EstimateAccordionView extends JetView {

    config(){

        return  {
            view: "accordion",
            cols : [ 
                EstimateListView,
                {
                    collapsed : true, 
                    header:"<span title='add Estimate'>+ Estimate</span>",					
						body:{
							$subview : EstimateFormView
						}
                    }  
                ]
        }

    }

}
