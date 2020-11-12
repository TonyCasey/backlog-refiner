export const tickets = new webix.DataCollection({
    url:"data/tickets.json",
    scheme:{                                                                              
		$init:function(obj){
            var format = webix.Date.dateToStr("%d %M %y, %H:%i");
			obj.creationTime =  format( obj.creationTime.replace("T", " "));
            obj.status = obj.statusGuid
		}
	}
});
