import {JetView} from "webix-jet";
import { searchTasks, deleteTask } from "../../../services/tasks-service";

export default class TaskListView extends JetView {

    config(){

        var tasks = [];

        return {
            view:"list",
            localId:"task-list",
            css:"persons_list",
            select:true,
            height:380,
            data: this.tasks,
            scrollSpeed:"2000ms",
            scroll: true,       
            type:{
                template:obj => { 
                   
                var item = `<div class="bdd-list-item">
                        <div class="bdd-item-header"><i>${obj.body}</i></div>`;
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

        const list = this.$$("task-list");
        list.clearAll();
        

        searchTasks({ ticketGuid : this.ticket.guid }, (x) => {

            this.tasks = JSON.parse(x).data;
            
            this.tasks.forEach(task => {
                
                task.id = task.guid;

            });

            list.parse(this.tasks);
            
            this.app.callEvent("task-list:loaded", [this.tasks]);

            
        }
        
        )
		
    }
    
    eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            
            this.ticket = ticket;

            this.populateList();      
                       

        });

               
        this.on(this.app,"task:created", (task) => {			
                        

            task.id = task.guid;
            this.tasks.push(task);         
            this.$$("task-list").add(task);// test
            this.$$("task-list").showItem(task.id);

            webix.extend(this.$$("task-list"), webix.OverlayBox);
            this.$$("task-list").hideOverlay();

        });


        this.$$("task-list").attachEvent("onItemClick", function(id, e, node){
            
            //console.log(this.$scope.tasks.find(x => x.guid == id));

        });

        this.on(this.app,"task-list:loaded", (tasks) => {		
            
            var list = this.$$("task-list");
            if (!tasks.length){            
                webix.extend(list, webix.OverlayBox);
                list.showOverlay("<img src='/images/no-tasks.png' style='margin-top: 50px;'/>");
            }
            
        });
        
    }


    getContextMenu(){

        var context = this.ui({
            view:"contextmenu",
            id:"task-cmenu",
            data:["<i class='mdi mdi-trash-can-outline'></i> Delete"],
            on:{
              onItemClick:function(id){
                var context = this.getContext();
                var list = context.obj;
                var listId = context.id;

                deleteTask(listId, ()=> {
                    webix.message("task deleted");
                    list.remove(context.id); 
                    if (!list.count()){            
                        webix.extend(list, webix.OverlayBox);
                        list.showOverlay("<img src='/images/no-tasks.png' style='margin-top: 50px;'/>");
                    }
                });
                //conetxt.app.callEvent("task:deleted"); 
                //webix.message("List item: <i>"+list.getItem(listId).name+"</i> <br/>Context menu item: <i>"+this.getItem(id).value+"</i>");
              }
            }
          });

          context.attachTo(this.$$("task-list"))


    }
}