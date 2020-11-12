import {JetView} from "webix-jet";
import QuestionForm from "./question-form";


export default class QuestionsView extends JetView {

    config(){
        const _ = this.app.getService("locale")._;
        const theme = this.app.config.theme;
        
        var test = "";

        return {
                type : "clean",
                width: 300,
                rows : [ 
                    {
                        view:"toolbar",
                        localId:"toolbar",
                        elements:[
                            // { view:"label", label:"Questions"},
                            {},
                            {
                                view:"icon", icon:"mdi mdi-arrow-down",
                                tooltip:_("Click to sort"),
                                click:function(){
                                    let dir = "";
                                    if (this.config.icon.indexOf("up") !== -1){
                                        dir = "desc";
                                        this.config.icon = "mdi mdi-arrow-down";
                                    }
                                    else {
                                        dir = "asc";
                                        this.config.icon = "mdi mdi-arrow-up";
                                    }
                                    //this.$scope.$$("list").sort("fname",dir);
                                    this.refresh();
                                }
                            }
                        ]
                    },                   
                    {
                    localId:"question-list",
                    view : "list",
                    select: true,
                    css:"question-list",                    
                    type:{
                        template: obj => { 
                            var item = //`<image class="userphoto" src="data/photos/tommie.jpg" />
							`<div class="text">
                                  <div class="question">${obj.question}</div>`;

                                  if(obj.comments !== undefined){
                                            item += `<div class="comments">`
                                            obj.comments.forEach(comment => {
                                                item += `<div class="comment">${comment.body}`;
                                                item += `<span class="details">Sean W | 19th Oct 2018 5:25pm</span>`;                                                
                                                item += `</div>`;
                                            });
                                            item += `</div>`;
                                        }
                            
                            item += `<div class="reply">`
                            item += test;
                            if(obj.reply !== undefined  && obj.reply !== null){
                                item += `<div id="reply${obj.id}" class="reply-text" contentEditable style="display:block"></div>`;
                            }
                            item += `</div>`     
                            item += `</div>`;

                            //item += { body:{ CommentView } };
                                
                            return item;
                    },
						height:"auto"
                    },
                    on:{
						// onAfterSelect:(id) => {
                        //     webix.message(id);
                        //     // console.log("yes " + id)
                        //     //test += id;
                        //     //  test = `<div id="reply-${id}" class="reply-text" contentEditable style="display:block"></div>` ;
                        //     //this.getItem(id).reply = 1
                        //     //this.data[1].reply = 1;
                        // }
                        
                        
                    },
                    
                },
                {
                    $subview: QuestionForm
                }
            ]

        }
    }              
     

    init(){
        const data = [
            {question : "Is this applicable to all reatilers?", 
            comments: [
                {body : "No, only LSA, BUF"}, 
                {body : "Ok, thanks"}
            ]}
            , {question : "What is the Vat threshold? ", reply : null}
            , {question : "What is the Duty threshold?"}
            , {question : "Question 5 "}
            , {question : "Question 6 "}
            , {question : "Question 7 "}
            , {question : "Question 8 "}
            , {question : "Question 9 "}
            , {question : "Question 10 "}
            , {question : "Question 11"}
        ];
        this.$$("question-list").parse(data);

        this.$$("question-list").attachEvent("onItemClick", function(id, e, node){
            var item = this.getItem(id);
            item.reply = "";           

        });

        this.$$("question-list").attachEvent("onKeyPress", function(code, e){
            //code
            if( code == 13 && !e.shiftKey){
                var item = this.getSelectedItem();
                var content = webix.html.getValue("reply" + item.id);
                // item.comments.push({body : content})
                webix.message("save " + content );
                
                // this.app.callEvent("tasks:filter",[proj]);
            }
                
        });

        this.on(this.app,"save:comment", obj => {
			
		});
        
    }
    
   

    
}