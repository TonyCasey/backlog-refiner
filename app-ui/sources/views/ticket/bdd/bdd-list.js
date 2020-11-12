import {JetView} from "webix-jet";
import { searchScenarios, deleteScenario }  from "../../../services/bdd-scenario-service";
import { searchConditions }  from "../../../services/bdd-condtions-service";

export default class BddListView extends JetView {

    config(){

        var ticket = null;
        var scenarios = [];
        

        return {
            view:"list",
            localId:"bdd-list",
            css:"bdd-ist",
            select:true,
            height: 380,
            data: this.scenarios,
            scrollSpeed:"2000ms",
            scroll: true,    
            type:{
                template:obj => { 
                   
                var item = `<div class="bdd-list-item">
                        <div class="bdd-item-header"><i>${obj.name}</i></div>`;

                        if(obj.conditions !== undefined){
                            obj.conditions.forEach(condition => {
                                item += `<div class="bdd-condition">`;
                                item += `<span class="operator">${ isNaN(condition.operatorId) ? condition.operatorId:this.getOperator(condition.operatorId)}</span><span>${condition.body}</span>`;
                                item += `</div>`;
                            });
                        }

                    item +=`</div>`;

                    return item;
                },
                height:"auto"
            },
            ready:function(){                
            },
            on:{
                onBeforeLoad:function(){
                    webix.extend(this, webix.OverlayBox);
                    this.hideOverlay();
                    this.showOverlay("Loading...");
                },
                onAfterLoad:function(){
                  this.hideOverlay();
                }
              },
            onContext: {}
        }
    }

    init(){
		        
        this.eventListeners();
        this.getContextMenu();
       
    }
    
    populateList(){

        const list = this.$$("bdd-list");
        list.clearAll();
        

        searchScenarios({ ticketGuid : this.ticket.guid }, (x) => {

            this.scenarios = JSON.parse(x).data;
            
            this.scenarios.forEach(scenario => {
                
                scenario.id = scenario.guid;

                searchConditions( { scenarioGuid: scenario.guid }, (y) => {

                    scenario.conditions = JSON.parse(y).data;
                    list.parse(this.scenarios);
                })

            });
            
            this.app.callEvent("bdd-list:loaded", [this.scenarios]);

            
        }
        
        )
		
    }

    eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            
            this.ticket = ticket;

            this.populateList();      
                       

        });

               
        this.on(this.app,"sceanrio:created", (scenario) => {			
                        

            scenario.id = scenario.guid;
            this.scenarios.push(scenario);         
            this.$$("bdd-list").add(scenario);// test
            this.$$("bdd-list").showItem(scenario.id);

            webix.extend(this.$$("bdd-list"), webix.OverlayBox);
            this.$$("bdd-list").hideOverlay();

        });


        this.$$("bdd-list").attachEvent("onItemClick", function(id, e, node){
            
            //console.log(this.$scope.scenarios.find(x => x.guid == id));

        });

        this.on(this.app,"bdd-list:loaded", (scenarios) => {		
            
            var list = this.$$("bdd-list");
            if (!scenarios.length){            
                webix.extend(list, webix.OverlayBox);
                list.showOverlay("<img src='/images/no-behaviours.png' style='margin-top: 50px;'/>");
            }
            
        });
        
    }

    getOperator(id){
               
        switch(id){
            case 1 :
            return "Given";
            case 2 :
            return "When";
            case 3 :
            return "Then";
            case 4 :
            return "And";
            case 5 : 
            return "But"
        }
    }

    getContextMenu(){

        var context = this.ui({
            view:"contextmenu",
            id:"bdd-cmenu",
            data:["<i class='mdi mdi-trash-can-outline'></i> Delete"],
            on:{
              onItemClick:function(id){
                var context = this.getContext();
                var list = context.obj;
                var listId = context.id;

                deleteScenario(listId, ()=> {
                    webix.message("behaviour deleted");
                    list.remove(context.id); 
                    if (!list.count()){            
                        webix.extend(list, webix.OverlayBox);
                        list.showOverlay("<img src='/images/no-behaviours.png' style='margin-top: 50px;'/>");
                    }
                });
                //conetxt.app.callEvent("scenario:deleted"); 
                //webix.message("List item: <i>"+list.getItem(listId).name+"</i> <br/>Context menu item: <i>"+this.getItem(id).value+"</i>");
              }
            }
          });

          context.attachTo(this.$$("bdd-list"))


    }
    
}