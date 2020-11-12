

import {JetView} from "webix-jet";
import TicketMembersListView  from "./ticket-members-list";

export default class TicketDescriptionView extends JetView {

    config(){
        return {
            cols: [
                {
                rows:[
                    { 
                        localId:"header", template:"#summary#", type:"header", css:"webix_header" 
                    },
                    {
                        localId:"decription-body", template: "<div class='ticket-description'>#description#</div> ", scroll: true, padding:20
                    }
                ]
            },
            {width:10},
            {
                type:"clean",                
                width: 300,
                borderless:true,
                rows: [
                    // { 
                    //     template:"&nbsp;", type:"header", css:"webix_header" 
                    // },
                    // { 
                    //     localId:"createdDate", height: 35, template:"<div class='createdDate'><i class='mdi mdi-calendar-plus'></i> Created: #creationTime#</div><br><div class='createdDate'><i class='mdi mdi-account-edit'></i> Created By: Joe Bloggs</div>"
                    // },
                    // { height:30, template: "&nbsp;"},                  
                    {    height:300, body : { $subview : TicketMembersListView} }
                ]
            }            
            // {
            //     body:{
            //         //$subview : TicketAssignmentView
            //     }
            // }
            
        ]
        };
            
    }

    init(view){

        // todo: take out into data
        

        this.on(this.app,"ticket:select", ticket => {			
            this.$$("decription-body").parse(ticket);
            this.$$("header").parse(ticket);
            // this.$$("createdDate").parse(ticket);
            
		});
    }

}