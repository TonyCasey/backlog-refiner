import {JetView} from "webix-jet";
import { searchScenarios }  from "../../../services/bdd-scenario-service";
import { searchConditionsSync }  from "../../../services/bdd-condtions-service";
import { searchTasks } from "../../../services/tasks-service";
import { searchTestCases } from "../../../services/test-case-service";

export class ExportSummary extends JetView {

    config(){

        return {
            rows:[
                { 
                    localId:"header", template:"#summary#", type:"header", css:"webix_header" 
                },
                {
                    localId:"body", template: `
                    <div class="export">
                    <div class="description">#description#</div>
                    <hr/> 
                    <h2>Behaviours</h2>
                    <div>#bdd#</div>
                    <hr/> 
                    <h2>Tasks</h2>
                    <div>#tasks#</div>
                    <hr/> 
                    <h2>Test Cases</h2>
                    <div>#tests#</div>
                    </div>
                    `, padding:20, scroll: true
                },
            ]
        
        }
    }

    init(){
        this.eventListeners();

        //const tests = this.$$("tests");  
        //webix.extend(tests,webix.CopyPaste);
    }

    eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            // this.$$("decription-body").parse(ticket);
            this.$$("header").parse(ticket);

            var content = { description : ticket.description, bdd : "", tasks : "", tests : "" }

            this.loadBdd(ticket, content);
            this.loadTasks(ticket, content);
            this.loadTestCasese(ticket, content);             
		});
    }

    loadBdd(ticket, content){

        
        searchScenarios({ ticketGuid : ticket.guid }, (x) => {

            var scenarios = JSON.parse(x).data;
                        
            scenarios.forEach(scenario => {
            
                content.bdd += ""

                content.bdd += "<b><i>" + scenario.name + "</i></b><br><br>";

                scenario.id = scenario.guid;

                searchConditionsSync( { scenarioGuid: scenario.guid }, (y) => {

                    scenario.conditions = JSON.parse(y).data;

                    scenario.conditions.forEach(condition => {
                        
                        content.bdd  += "&nbsp;<b>" + this.getOperator(condition.operatorId) + "</b> " + condition.body; 
                        content.bdd  += "<br>";                       

                    });
                    
                    content.bdd  += "<br>";
                });


            });

            
            this.$$("body").parse(content);
        });
        

    }

    loadTasks(ticket, content){

        
        searchTasks({ ticketGuid : ticket.guid }, (x) => {

            var tasks = JSON.parse(x).data;
            
            tasks.forEach(task => {               
                
                content.tasks += "<div>";
                content.tasks  += "&nbsp;" + task.body;                        
                content.tasks += "</div>";
            });            
          
            this.$$("body").parse(content);
        });

    }

    loadTestCasese(ticket, content){

        
        searchTestCases({ ticketGuid : ticket.guid }, (x) => {

            var testCases = JSON.parse(x).data;
            
            testCases.forEach(testCase => {
                
                content.tests += `              
                        <div class="" style="border: 0px solid #DADEE0;">
                            <b><i>${testCase.title}</i></b>
                            <br>
                            <div>&nbsp;${testCase.description}</div>
                            <div class="sub-title"><b>Steps</b></div>
                            <div>&nbsp;${testCase.steps}</div>
                            <div class="sub-title"><b>Expected results</b></div>
                            <div>&nbsp;${testCase.expectedResults}</div>
                        </div>
                        `;

            });

            this.$$("body").parse(content);

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

}