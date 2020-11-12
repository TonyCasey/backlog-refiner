import { getUrl } from "../environments"



export function searchConditions(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("bdd")  + "/api/Condition/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading Conditions <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function searchConditionsSync(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .get( getUrl("bdd")  + "/api/Condition/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading Conditions <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function getCondition(conditionGuid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("bdd")  + "/api/Condition/" + conditionGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting Condition <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addCondition(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("bdd")  + "/api/Condition", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Condition member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addConditionSynchronous(object, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .headers({"Content-type":"application/json"})
    .post( getUrl("bdd")  + "/api/Condition", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Condition member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteCondition(conditionGuid, callBack){

    var results = null;
 
    webix
    .ajax()
    .del( getUrl("bdd")  + "/api/Condition/" + conditionGuid, 
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