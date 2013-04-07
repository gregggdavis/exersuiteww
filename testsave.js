//JSQUIZTYPE=Matching//JSQUIZTYPEEND
var iResultsWidth=47;
var iResultsHeight=8;
//SIZEVARSBEGIN
//SIZEVARSEND
function Question(text,answer) {
 this.text=text;
 this.answer=answer;
}
answers=new Object();
//answers[""]="";
answers.length=0;
//ANSWERSBEGIN

answers["a"]="test answer";
answers.length=1;
//ANSWERSEND
questions=new Object();
questions[0]=null; // skip index [0]
//questions[]=new Question("","");
questions.length=0;
//QUESTIONSBEGIN

questions[1]=new Question("test phtrase","a");
questions.length=1;
//QUESTIONSEND

iResultsWidth=47;

iResultsHeight=8;
