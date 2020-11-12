import { getUrl } from "../environments"



export function searchScenarios(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("bdd")  + "/api/Scenario/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading Scenarios <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function getScenario(scenarioGuid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("bdd")  + "/api/Scenario/" + scenarioGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting Scenario <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addScenario(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("bdd")  + "/api/Scenario", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Scenario member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addScenarioSynchronous(object, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .headers({"Content-type":"application/json"})
    .post( getUrl("bdd")  + "/api/Scenario", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = response;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Scenario member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteScenario(scenarioGuid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("bdd")  + "/api/Scenario/" + scenarioGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting ticket member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}