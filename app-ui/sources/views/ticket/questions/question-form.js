import {JetView} from "webix-jet";

export default class QuestionForm extends JetView {

    config(){
        return {
            view:"form",
            localId:"addQuestionForm",
                elements:[
                    
                    { cols:[
                        { view:"text", placeholder: "ask a question"},
                        {
                            cols:[
                                {
                                    view:"button", label: 'Send', width: 50, 
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