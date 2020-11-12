
import { getUrl } from "../environments"

const url =  getUrl("sts") +  "/api/users";


webix.attachEvent("onBeforeAjax", 
	function(mode, url, data, request, headers, files, promise){
		headers["Authorization"] = "Bearer " + webix.storage.local.get("backlog_refiner_bearer");
	}
);

webix.attachEvent("onAjaxError", function(xhr){
	
	if (xhr.status == 401 ){
		logout();
		window.location.href = "/#!/login";
	}
	
 });

function status(){


	var bearer = webix.storage.local.get("backlog_refiner_bearer");

	if( bearer === undefined || bearer === null){
		return webix.promise.reject(null).fail(function(error){
			resolve(null);
		 });
	}

	var user = webix.storage.local.get("backlog_refiner_user");

	if( user === undefined || user === null){
		return webix.promise.reject(null).fail(function(error){
			resolve(null);
		 });
	}else{
		return webix.promise.resolve( user );
	}

	
	
}

function current(){

	return webix.ajax().get(url + "/current")
		.then(a => {
			a.json();
			webix.storage.local.put("backlog_refiner_user", a.json());
		});

}

function login(user, pass){

	
	return webix
	.ajax()
	.headers({"Content-type":"application/json"})
	.post( url + "/login", { "email": user, "password" : pass }
	)
	.then(a => {

		webix.storage.local.put("backlog_refiner_bearer", a.json().tokenString );
		current();
		return a.json()
	});

}

function logout(){
	return new webix.promise((resolve, reject) => {
		webix.storage.local.remove("backlog_refiner_bearer");
		webix.storage.local.remove("backlog_refiner_user");
		resolve(null)
	});
}

export default {
	status, login, logout
}