import { getUrl } from "../environments"



export function searchTestCases(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("test-cases")  + "/api/TestCase/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading Test Cases <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function getTestCase(guid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("test-cases")  + "/api/TestCase/" + guid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting Test Case <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTestCase(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("test-cases")  + "/api/TestCase", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Test Case member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTestCaseSynchronous(object, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .headers({"Content-type":"application/json"})
    .post( getUrl("test-cases")  + "/api/TestCase", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = response;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Test Case <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteTestCase(TestCaseGuid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("test-cases")  + "/api/TestCase/" + TestCaseGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting Test Case <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}