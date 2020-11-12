import {JetView} from "webix-jet";
import { getTeams } from "../../../services/team-service";
import { searchTeamUsers, getTeamUser } from "../../../services/team-user-service";
import { searchTicketMembers, addTicketMember,  deleteTicketMember } from "../../../services/ticket-member-service";
import { addNotification } from "../../../services/notification-service";
import { addEmail } from "../../../services/email-service";
export default class TicketMembersListView extends JetView {

    
     
    config(){

        var ticket = null;
        var teamUsers = [];
            
    return {

        view:"multicombo", 
        localId: "memberSelect",
        label:"<i class='mdi mdi-account-multiple'></i> Members",
        labelPosition : "top",
        placeholder: "+ Add team member",
        css:"memberSelect",
        options:{
            body:{
                template:"#firstName# #lastName#"           
            }
        }
    };

    }

    init(){

        this.populateList();

        this.onChange();
        
        this.eventListeners();
        
    }
    
    onChange(){
                
        
        this.$$("memberSelect").attachEvent("onChange", function(newv, oldv){
                   

            var event = null;

            if( (oldv === undefined || ( oldv == "" && newv != "" ) ))
                event = "added-first-item"
            else if( newv === undefined || ( newv == "" && oldv != "" ) )
                event = "removed-last-item"
            else if( newv.split(',').length > oldv.split(',').length )
                event = "added-item"
            else if( oldv.split(',').length > newv.split(',').length )
                event = "removed-item"            
            

            switch( event ){

                case "added-first-item" :
                
                    var teamUserGuid = newv;

                    // get team member
                    getTeamUser(teamUserGuid, (x) => {

                        var teamUser = JSON.parse(x);

                        addTicketMember( { 
                            ticketGuid : this.config.$scope.ticket.guid, 
                            teamUserGuid: teamUserGuid,
                            userGuid: teamUser.userGuid
                         }, 
                         (ticketMember) => {   
                             
                            if(teamUser.userGuid.toLowerCase() != webix.storage.local.get("backlog_refiner_user").id.toLowerCase()){
                        
                                var notification = {
                                    ticketGuid : this.config.$scope.ticket.guid,
                                    boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                    title : "Added to ticket",
                                    body: `${this.config.$scope.ticket.summary}`,
                                    statusId : 1,
                                    teamUserGuid : teamUserGuid,
                                    userGuid: teamUser.userGuid
                                }
                                
                                addNotification(notification, (y) => {

                                    // send email
                                    var email = 
                                        {
                                            ticketGuid : notification.ticketGuid,
                                            boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                            ToUserGuid : notification.userGuid,
                                            SendGridTemplate : 1
                                        }
                                    
                                        addEmail(email);
                                    
                                });
                            }
    
                        });

                    })

                    
                       

                return;

                case "removed-last-item" :

                    var teamUserGuid = oldv;

                    searchTicketMembers({ teamUserGuid: teamUserGuid }, (y) => {

                        
                        var data = JSON.parse(y).data;
                    
                            data.forEach(ticketMember => {
                               
                                deleteTicketMember(ticketMember.guid, (x) => {    
                                     
                                    if(ticketMember.userGuid.toLowerCase() != webix.storage.local.get("backlog_refiner_user").id.toLowerCase()){

                                        var notification = {
                                            ticketGuid : this.config.$scope.ticket.guid,
                                            boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                            title : "Removed from ticket",
                                            Body: `${this.config.$scope.ticket.summary}`,
                                            StatusId : 1,
                                            teamUserGuid : teamUserGuid,
                                            userGuid: ticketMember.userGuid
                                        }
                                        
                                        addNotification(notification);

                                    }
                            });
                            })

                    });
                    return;

                
                case "added-item" : 
                    
                    var oldArry =  oldv.split(',');
                    var newArry = newv.split(',');

                    newArry.forEach(teamUserGuid => {

                        if(oldArry.indexOf(teamUserGuid)<0){
                            

                            getTeamUser(teamUserGuid, (x) => {

                                var teamUser = JSON.parse(x);

                            
                                addTicketMember( { 
                                    ticketGuid : this.config.$scope.ticket.guid,
                                     teamUserGuid : teamUserGuid,
                                     userGuid :  teamUser.userGuid
                                    }, (ticketMember)=>{

                                    
                                        if(teamUser.userGuid.toLowerCase() != webix.storage.local.get("backlog_refiner_user").id.toLowerCase()){

                                            var notification = {
                                                ticketGuid : this.config.$scope.ticket.guid,
                                                boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                                title : "Added to ticket",
                                                Body: `${this.config.$scope.ticket.summary}`,
                                                StatusId : 1,
                                                teamUserGuid : teamUserGuid,
                                                userGuid: teamUser.userGuid
                                            }
                                            
                                            addNotification(notification, (y) => {

                                                // send email
                                                var email = 
                                                    {
                                                        ticketGuid : notification.ticketGuid,
                                                        boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                                        ToUserGuid : notification.userGuid,
                                                        SendGridTemplate : 1
                                                    }
                                                
                                                    addEmail(email);
                                                
                                            });
                                        }
                                        
                                });
                            });
                        }
                    });

                break;

                case "removed-item" :

                    var oldArry =  oldv.split(',');
                    var newArry = newv.split(',');   
                    
                    oldArry.forEach(teamUserGuid => {

                        if(newArry.indexOf(teamUserGuid)<0){                        
                            // need to get the ticketUserGuid
                            searchTicketMembers( 
                                { teamUserGuid: teamUserGuid, 
                                    ticketGuid : this.config.$scope.ticket.guid 
                                }, (ticketMembers) => {

                                var data = JSON.parse(ticketMembers).data;

                                    data.forEach(ticketMember => {

                                        
                                        deleteTicketMember(ticketMember.guid, (x) => {    
                                                
                                            if(ticketMember.userGuid.toLowerCase() != webix.storage.local.get("backlog_refiner_user").id.toLowerCase()){

                                                var notification = {
                                                    ticketGuid : this.config.$scope.ticket.guid,
                                                    boardGuid : webix.storage.local.get("backlog_refiner_board").guid,
                                                    title : "Removed from ticket",
                                                    Body: `${this.config.$scope.ticket.summary}`,
                                                    StatusId : 1,
                                                    teamUserGuid : teamUserGuid,
                                                    userGuid: ticketMember.userGuid
                                                }
                                                
                                                addNotification(notification);
                                            }

                                        });
                                    });                            

                            });                        
                            
                        }
                    });

                break;
                
            };

        });

           
    }
    
    populateList(){

        getTeams((x)=>{

            searchTeamUsers( { teamGuid :  JSON.parse(x).data[0].guid }, (y)=>{

                var list = this.$$("memberSelect").getPopup().getList();
                list.clearAll();

                this.$$("memberSelect").blockEvent();
                this.$$("memberSelect").setValue(); //will not trigger list events 
                this.$$("memberSelect").unblockEvent();
               

                var data = JSON.parse(y).data;
                data.forEach(x => {
                    x.id = x.guid
                })

                list.parse(data);               
            })
        });
    }

    eventListeners(){

        this.on(this.app,"ticket:select", ticket => {			
            
            this.populateList();
            
            var ids = [];

            this.ticket = ticket;
            
            // get the ticket members
            searchTicketMembers({ ticketGuid: ticket.guid }, (x) => {

                var members = JSON.parse(x).data;
                
                if(members.length > 0){

                    // find the id's in the current list and select them
                    var list = this.$$("memberSelect").getPopup().getList();
                    
                    members.forEach(x => {                    

                        ids.push(x.teamUserGuid)
                    })
                    
                    this.$$("memberSelect").blockEvent();
                    this.$$("memberSelect").setValue(ids.toString()); //will not trigger list events 
                    this.$$("memberSelect").unblockEvent();
                    
                }
                
            });
            

        });

        this.on(this.app,"ticket-members:added",(ticketAndMember) => {
			
		});
    }

    processNotifications(ticketMember){
        
        this.app.callEvent("ticket-members:added",[ { ticket : this.config.$scope.ticket,  ticketMember: ticketMember }]);
    }
    
}