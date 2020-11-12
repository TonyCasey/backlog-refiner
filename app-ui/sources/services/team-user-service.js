import { getUrl } from "../environments"



export function searchTeamUsers(searchRequestObject, callBack){

    var teamUsers = [];

    webix
    .ajax()
    .sync()
    .get( getUrl("sts")  + "/api/TeamUser/Search", searchRequestObject, [ 
    { 
        success:function(response, xml, ajax){ 
            
            teamUsers = JSON.parse(response).data;
            
            if(teamUsers.length <= 0){
                webix.message({type:"debug", text: `No team users available`});
                return;
            }			
                        

        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading team users <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return teamUsers;

}




export function getTeamUser(teamUserGuid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("sts")  + "/api/TeamUser/" + teamUserGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting TeamUser <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTeamUser(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("sts")  + "/api/TeamUser", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error TeamUser member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTeamUserSynchronous(object, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .headers({"Content-type":"application/json"})
    .post( getUrl("sts")  + "/api/TeamUser", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = response;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error TeamUser <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteTeamUser(TeamUserGuid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("sts")  + "/api/TeamUser/" + TeamUserGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting TeamUser <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}