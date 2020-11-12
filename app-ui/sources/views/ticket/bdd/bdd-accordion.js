
import {JetView} from "webix-jet";
import BddListView from "./bdd-list";
import BddFormView from "./bdd-form";

export default class BddAccordionView extends JetView {

    config(){

        return  {
            id:"bddAccordion",
            view: "accordion",
            cols : [
                    BddListView,      
                    {
                        id:"bddForm",
                        collapsed : false, 
                            header:"<span title='add new Beahviour'>add a Behaviour</span>",						
                            body:{
                                $subview : BddFormView
                            }
                    }  
                ]
        }

    }


    init(){
        this.eventListeners();
    }
    
    eventListeners(){

        this.on(this.app,"bdd-list:loaded", (scenarios) => {		
            
            // if (scenarios.length > 0){    
            //     $$("bddAccordion").getChildViews()[1].collapse();
            // }
            
        });
    }

}
