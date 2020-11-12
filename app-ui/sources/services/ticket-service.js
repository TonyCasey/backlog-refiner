import { getUrl } from "../environments"


export function getTickets(selectedBoard, callBack){

    var tickets = null;

    webix
    .ajax()
    .get( getUrl("tickets")  + "/api/Ticket/Search", { boardGuid: selectedBoard}, 
    [{ 
        success:function(response, xml, ajax){ 

            tickets = JSON.parse(response).data;
            
            if(tickets.length <= 0){					
                webix.message({type:"debug", text: `No tickets available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading tickets <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return tickets;
}


export function addTicket(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("tickets")  + "/api/Ticket", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error adding Ticket <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteTicket(guid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("tickets")  + "/api/Ticket/" + guid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting Ticket <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function updateTicket(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .put( getUrl("tickets")  + "/api/Ticket/" + object.guid, object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error updating Ticket <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

