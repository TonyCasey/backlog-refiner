import {JetView} from "webix-jet";

export default class ReplyForm extends JetView {

    config(){
        return {
            view:"form",
            localId:"replyForm",
                elements:[
                    
                    { cols:[
                        { view:"text", placeholder: "reply", width: 300},
                        {
                            cols:[
                                {
                                    view:"button", label: '+ Add', width: 50, 
                                     align: 'left',
                                    //click:() => this.addQuestion()
                                }
                            ]
                        }
                        ]
                    }                    
                    
                ]
        }
    }

}