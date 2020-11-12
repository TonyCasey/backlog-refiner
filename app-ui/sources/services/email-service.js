import { getUrl } from "../environments"



export function searchEmails(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("emails")  + "/api/email/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading emails <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function getEmail(guid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("emails")  + "/api/email/" + guid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting email <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addEmail(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("emails")  + "/api/email", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error email member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function deleteEmail(guid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("emails")  + "/api/email/" + guid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting email <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}
