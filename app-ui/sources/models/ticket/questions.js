export const questions = new webix.DataCollection({
    url:"data/questions.json",
    scheme:{                                                                              
		$init:function(obj){
            var format = webix.Date.dateToStr("%d %M %y, %H:%i");
			obj.creationTime =  format( obj.creationTime.replace("T", " "));
		}
	}
});
