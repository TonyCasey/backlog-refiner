import {JetView} from "webix-jet";
import { searchTestCases, deleteTestCase } from "../../../services/test-case-service";

export default class TestCaseListView extends JetView {

    config(){

        var testCases = [];

        return {
            view:"list",
            localId:"test-case-list",
            css:"persons_list",
            select:true,
            height:380,
            data: this.testCases,
            scrollSpeed:"2000ms",
            scroll: true,       
            type:{
                template:obj => { 
                   
                var item = `<div class="test-case-list-item">                
                        <div class="test-case-header-title"><i>${obj.title}</i></div>
                        <div class="test-case-div">${obj.description}</div>
                        <div class="test-case-header">Steps</div>
                        <div class="test-case-div"> ${obj.steps}</div>
                        <div class="test-case-header">Expected results</div>
                        <div class="test-case-div">${obj.expectedResults}</div>
                        `;
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

        const list = this.$$("test-case-list");
        list.clearAll();
        

        searchTestCases({ ticketGuid : this.ticket.guid }, (x) => {

            this.testCases = JSON.parse(x).data;
            
            this.testCases.forEach(testCase => {
                
                testCase.id = testCase.guid;

            });

            list.parse(this.testCases);
            
            this.app.callEvent("test-case-list:loaded", [this.testCases]);

            
        }
        
        )
		
    }
    
    eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            
            this.ticket = ticket;

            this.populateList();      
                       

        });

               
        this.on(this.app,"test-case:created", (testCase) => {			
                        

            testCase.id = testCase.guid;
            this.testCases.push(testCase);         
            this.$$("test-case-list").add(testCase);
            this.$$("test-case-list").showItem(testCase.id);

            webix.extend(this.$$("test-case-list"), webix.OverlayBox);
            this.$$("test-case-list").hideOverlay();

        });


        this.$$("test-case-list").attachEvent("onItemClick", function(id, e, node){
            
            //console.log(this.$scope.tasks.find(x => x.guid == id));

        });

        this.on(this.app,"test-case-list:loaded", (testCases) => {		
            
            var list = this.$$("test-case-list");
            if (!testCases.length){            
                webix.extend(list, webix.OverlayBox);
                list.showOverlay("<img src='/images/no-test-cases.png' style='margin-top: 50px;'/>");
            }
            
        });
        
    }


    getContextMenu(){

        var context = this.ui({
            view:"contextmenu",
            id:"test-case-cmenu",
            data:["<i class='mdi mdi-trash-can-outline'></i> Delete"],
            on:{
              onItemClick:function(id){
                var context = this.getContext();
                var list = context.obj;
                var listId = context.id;

                deleteTestCase(listId, ()=> {
                    webix.message("test case deleted");
                    list.remove(context.id); 
                    if (!list.count()){            
                        webix.extend(list, webix.OverlayBox);
                        list.showOverlay("<img src='/images/no-test-cases.png' style='margin-top: 50px;'/>");
                    }
                });
                //conetxt.app.callEvent("task:deleted"); 
                //webix.message("List item: <i>"+list.getItem(listId).name+"</i> <br/>Context menu item: <i>"+this.getItem(id).value+"</i>");
              }
            }
          });

          context.attachTo(this.$$("test-case-list"))


    }
}