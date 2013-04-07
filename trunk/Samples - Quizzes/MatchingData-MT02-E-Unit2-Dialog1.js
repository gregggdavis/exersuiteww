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
answers["b"]="Kurt Kluwer at the Technical Center.";
answers["a"]="asked you to call.";
answers["c"]="the schedule and the progress of development.";
answers["e"]="prototype release for testing is in 4 to 6 weeks.";
answers["d"]="if they are having any other problems.";
answers.length=5;

//ANSWERSEND

questions=new Object();
questions[0]=null; // skip index [0]
//questions[]=new Question("","");
questions.length=0;
//QUESTIONSBEGIN
questions[1]=new Question("Bob wants you to call","b");
questions[2]=new Question("Tell Kurt that Bob","a");
questions[3]=new Question("You should ask Kurt about","c");
questions[4]=new Question("Kurt may need reminding that","e");
questions[5]=new Question("You also need to ask","d");
questions.length=5;

//QUESTIONSEND
